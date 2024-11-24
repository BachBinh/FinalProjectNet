using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class ManageOrdersForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable orderTable;
        private DataTable orderItemsTable;

        public ManageOrdersForm()
        {
            InitializeComponent();
            btnDeleteOrder.Enabled = false;
            btnEdit.Enabled = false;
            btnViewDetails.Enabled = false;
            btnSave.Enabled = false;
            btnEItem.Enabled = false;
        }

        private void ManageOrdersForm_Load_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            LoadOrderData();
        }
        private void LoadOrderData()
        {
            string sql = "SELECT * FROM [Order]";
            adapter = new SqlDataAdapter(sql, connection);
            orderTable = new DataTable();
            adapter.Fill(orderTable);
            dgvOrders.DataSource = orderTable;
        }


        private void LoadClients()
        {
            string sql = "SELECT ID, Name FROM Client";
            SqlDataAdapter clientAdapter = new SqlDataAdapter(sql, connection);
            DataTable clientTable = new DataTable();
            clientAdapter.Fill(clientTable);

            cbCliName.DataSource = clientTable;
            cbCliName.DisplayMember = "Name";
            cbCliName.ValueMember = "ID";
        }

        private void LoadEmployees()
        {
            string sql = "SELECT ID, Name FROM Employee";
            SqlDataAdapter employeeAdapter = new SqlDataAdapter(sql, connection);
            DataTable employeeTable = new DataTable();
            employeeAdapter.Fill(employeeTable);

            cbEmpName.DataSource = employeeTable;
            cbEmpName.DisplayMember = "Name";
            cbEmpName.ValueMember = "ID";
        }

        private void dgvOrders_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                dtpOrderDate.Enabled = false;
                cbCliName.Enabled = false;
                cbEmpName.Enabled = false;
                LoadClients();
                LoadEmployees();

                txtOrderID.Text = dgvOrders.CurrentRow.Cells[0].Value != DBNull.Value ? dgvOrders.CurrentRow.Cells[0].Value.ToString() : string.Empty;
                string clientID = dgvOrders.CurrentRow.Cells[1].Value != DBNull.Value ? dgvOrders.CurrentRow.Cells[1].Value.ToString() : string.Empty;
                string employeeID = dgvOrders.CurrentRow.Cells[2].Value != DBNull.Value ? dgvOrders.CurrentRow.Cells[2].Value.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(clientID))
                {
                    cbCliName.SelectedValue = clientID;
                }

                if (!string.IsNullOrEmpty(employeeID))
                {
                    cbEmpName.SelectedValue = employeeID;
                }

                if (dgvOrders.CurrentRow.Cells[3].Value != DBNull.Value)
                {
                    dtpOrderDate.Value = Convert.ToDateTime(dgvOrders.CurrentRow.Cells[3].Value);
                }

                txtTotalPrice.Text = dgvOrders.CurrentRow.Cells[4].Value != DBNull.Value ? dgvOrders.CurrentRow.Cells[4].Value.ToString() : string.Empty;
            }
            btnDeleteOrder.Enabled = true;
            btnEdit.Enabled = true;
            btnViewDetails.Enabled = true;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            btnEItem.Enabled = true;
            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                MessageBox.Show("Please select an order to view details.");
                return;
            }
            LoadOrderItems();
        }
        private void LoadOrderItems()
        {
            string sql = "SELECT p.Name AS ProductName, p.Price AS ProductPrice, " +
                         "oi.Quantity, (oi.Quantity * p.Price) AS TotalPrice " +
                         "FROM OrderItem oi " +
                         "JOIN Product p ON oi.ProductID = p.ID " +
                         "WHERE oi.OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@OrderID", int.Parse(txtOrderID.Text));
                adapter = new SqlDataAdapter(command);
                orderItemsTable = new DataTable();
                adapter.Fill(orderItemsTable);
                dgvOrderItems.DataSource = orderItemsTable;
            }
        }
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                MessageBox.Show("Please select an order to delete.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show($"Are you sure you want to delete order ID {txtOrderID.Text}?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteOrder(int.Parse(txtOrderID.Text));
            }
        }

        private void DeleteOrder(int orderId)
        {
            string checkBillSql = "SELECT COUNT(*) FROM Bill WHERE OrderID = @OrderID";
            string deleteOrderItemsSql = "DELETE FROM OrderItem WHERE OrderID = @OrderID";
            string deleteOrderSql = "DELETE FROM [Order] WHERE ID = @OrderID";

            using (SqlCommand checkCommand = new SqlCommand(checkBillSql, connection))
            {
                checkCommand.Parameters.AddWithValue("@OrderID", orderId);

                try
                {
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Confirm
                        DialogResult result = MessageBox.Show($"The order with the ID: {orderId} has been created as an invoice. Deleting the order will also delete the related invoice. Continue?",
                                                              "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            return;
                        }

                        // Delete related bills first
                        string deleteBillSql = "DELETE FROM Bill WHERE OrderID = @OrderID";
                        using (SqlCommand deleteBillCommand = new SqlCommand(deleteBillSql, connection))
                        {
                            deleteBillCommand.Parameters.AddWithValue("@OrderID", orderId);
                            deleteBillCommand.ExecuteNonQuery();
                        }
                    }

                    // Delete related OrderItems
                    using (SqlCommand deleteOrderItemsCommand = new SqlCommand(deleteOrderItemsSql, connection))
                    {
                        deleteOrderItemsCommand.Parameters.AddWithValue("@OrderID", orderId);
                        deleteOrderItemsCommand.ExecuteNonQuery();
                    }

                    // Delete the Order
                    using (SqlCommand deleteOrderCommand = new SqlCommand(deleteOrderSql, connection))
                    {
                        deleteOrderCommand.Parameters.AddWithValue("@OrderID", orderId);
                        int rowsAffected = deleteOrderCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Order ID {orderId} was successfully deleted.");
                            LoadOrderData(); // Reload order data
                            btnDeleteOrder.Enabled = false;
                            ClearOrderDetails();
                        }
                        else
                        {
                            MessageBox.Show("Order not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the order: {ex.Message}");
                }
            }
        }


        private void ClearOrderDetails()
        {
            txtOrderID.Clear();
            txtTotalPrice.Clear();
            dtpOrderDate.Value = DateTime.Now;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cbCliName.Enabled = true;
            cbEmpName.Enabled = true;
            dtpOrderDate.Enabled = true;

            txtOrderID.Enabled = false;
            txtTotalPrice.Enabled = false;

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                MessageBox.Show("Please select an order to save changes.");
                return;
            }

            string clientID = cbCliName.SelectedValue.ToString();
            string employeeID = cbEmpName.SelectedValue.ToString();
            DateTime orderDate = dtpOrderDate.Value;

            string updateOrderSql = "UPDATE [Order] SET ClientID = @ClientID, EmployeeID = @EmployeeID, OrderDate = @OrderDate WHERE ID = @OrderID";
            string updateBillSql = "UPDATE Bill SET ClientID = @ClientID, EmployeeID = @EmployeeID, BillDate = @OrderDate WHERE OrderID = @OrderID";

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Update Order Table
                using (SqlCommand updateOrderCommand = new SqlCommand(updateOrderSql, connection, transaction))
                {
                    updateOrderCommand.Parameters.AddWithValue("@ClientID", clientID);
                    updateOrderCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    updateOrderCommand.Parameters.AddWithValue("@OrderDate", orderDate);
                    updateOrderCommand.Parameters.AddWithValue("@OrderID", int.Parse(txtOrderID.Text));
                    updateOrderCommand.ExecuteNonQuery();
                }

                // Update Bill Table
                using (SqlCommand updateBillCommand = new SqlCommand(updateBillSql, connection, transaction))
                {
                    updateBillCommand.Parameters.AddWithValue("@ClientID", clientID);
                    updateBillCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    updateBillCommand.Parameters.AddWithValue("@OrderDate", orderDate);
                    updateBillCommand.Parameters.AddWithValue("@OrderID", int.Parse(txtOrderID.Text));
                    updateBillCommand.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show("Order and Bill (if created) updated successfully.");
                LoadOrderData(); // Reload order data
                btnSave.Enabled = false; // Disable Save button after saving
                btnEdit.Enabled = true;  // Enable Edit button again
                ClearOrderDetails();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"An error occurred while updating the order and bill: {ex.Message}");
            }
            ClearOrderDetails();
        }

        private void btnEItem_Click(object sender, EventArgs e)
        {
            int selectedOrderID = (int)dgvOrders.CurrentRow.Cells[0].Value;
            EditOrder editOrderForm = new EditOrder();
            editOrderForm.OrderID = selectedOrderID;
            editOrderForm.Show();

        }
    }
}
