using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _522H0083
{
    public partial class EditOrder : Form
    {
        public int OrderID { get; set; }
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable productTable;
        private DataTable orderItemsTable;

        public EditOrder()
        {
            InitializeComponent();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            txtOrderID.Text = OrderID.ToString();
            LoadProducts();

            orderItemsTable = new DataTable();
            orderItemsTable.Columns.Add("ProductID");
            orderItemsTable.Columns.Add("ProductName");
            orderItemsTable.Columns.Add("Quantity", typeof(int));
            orderItemsTable.Columns.Add("Price", typeof(decimal));
            //orderItemsTable.Columns.Add("TotalPrice", typeof(decimal), "Quantity * Price");
            orderItemsTable.Columns.Add("TotalPrice", typeof(decimal));
            dgvOrderItems.DataSource = orderItemsTable;
            LoadOrderDetails();
        }
        private void LoadProducts()
        {
            string sql = "SELECT ID, Name, Description, Price, Quantity FROM Product";
            adapter = new SqlDataAdapter(sql, connection);
            productTable = new DataTable();
            adapter.Fill(productTable);
            dgvProducts.DataSource = productTable;
            dgvProducts.Columns["ID"].Visible = false; // Ẩn cột ID
        }

        private void LoadOrderDetails()
        {
            //MessageBox.Show($"Text in txtOrderID: '{txtOrderID.Text}'");
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Please provide a valid Order ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtOrderID.Text, out int orderId))
            {
                MessageBox.Show("Order ID must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "SELECT p.ID AS ProductID, p.Name AS ProductName, p.Price AS Price, " +
                         "oi.Quantity, (oi.Quantity * p.Price) AS TotalPrice " +
                         "FROM OrderItem oi " +
                         "JOIN Product p ON oi.ProductID = p.ID " +
                         "WHERE oi.OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@OrderID", orderId);
                adapter = new SqlDataAdapter(command);
                orderItemsTable = new DataTable();
                adapter.Fill(orderItemsTable);
                dgvOrderItems.DataSource = orderItemsTable;
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && numericUpDownQuantity.Value > 0)
            {
                int productId = (int)dgvProducts.CurrentRow.Cells["ID"].Value; // ID của sản phẩm
                int quant = (int)numericUpDownQuantity.Value; // Số lượng muốn thêm

                int availableQuantity = (int)dgvProducts.CurrentRow.Cells["Quantity"].Value;
                if (quant > availableQuantity)
                {
                    MessageBox.Show("Not enough stock available.");
                    return;
                }

                if (string.IsNullOrEmpty(txtOrderID.Text))
                {
                    MessageBox.Show("Invalid order ID.");
                    return;
                }

                DataRow existingRow = null;
                foreach (DataRow row in orderItemsTable.Rows)
                {
                    string productIdInOrder = row["ProductID"].ToString(); // Lấy ProductID từ DataRow

                    if (productIdInOrder == productId.ToString()) // So sánh ProductID
                    {
                        existingRow = row;
                        break;
                    }
                }

                if (existingRow != null) //exist
                {
                    existingRow["Quantity"] = (int)existingRow["Quantity"] + quant;
                    decimal price = (decimal)existingRow["Price"];
                    existingRow["TotalPrice"] = (decimal)existingRow["Price"] * (int)existingRow["Quantity"];
                }
                else
                {
                    DataRow newRow = orderItemsTable.NewRow();
                    newRow["ProductID"] = productId; // ID sản phẩm
                    newRow["ProductName"] = dgvProducts.CurrentRow.Cells["Name"].Value; // Tên sản phẩm
                    newRow["Quantity"] = quant; // Số lượng
                    newRow["Price"] = dgvProducts.CurrentRow.Cells["Price"].Value; // Giá sản phẩm
                    newRow["TotalPrice"] = (decimal)dgvProducts.CurrentRow.Cells["Price"].Value * quant; // Tổng giá
                    orderItemsTable.Rows.Add(newRow);
                }

                dgvProducts.CurrentRow.Cells["Quantity"].Value = availableQuantity - quant;
                numericUpDownQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show("Please select a product and enter a valid quantity.");
            }
        }

        private void SaveOrderToDatabase(int orderId)
        {
            try
            {
                decimal totalOrderPrice = 0;
                foreach (DataRow row in orderItemsTable.Rows)
                {
                    totalOrderPrice += (decimal)row["TotalPrice"];
                }

                // Cập nhật thông tin đơn hàng trong bảng Order
                string updateOrderSql = "UPDATE [Order] SET TotalPrice = @TotalPrice, OrderDate = @OrderDate WHERE ID = @OrderID";
                SqlCommand cmdUpdateOrder = new SqlCommand(updateOrderSql, connection);
                cmdUpdateOrder.Parameters.AddWithValue("@TotalPrice", totalOrderPrice);
                cmdUpdateOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmdUpdateOrder.Parameters.AddWithValue("@OrderID", orderId);
                cmdUpdateOrder.ExecuteNonQuery();

                string deleteOrderItemsSql = "DELETE FROM OrderItem WHERE OrderID = @OrderID";
                SqlCommand cmdDeleteOrderItems = new SqlCommand(deleteOrderItemsSql, connection);
                cmdDeleteOrderItems.Parameters.AddWithValue("@OrderID", orderId);
                cmdDeleteOrderItems.ExecuteNonQuery();

                foreach (DataRow row in orderItemsTable.Rows)
                {
                    string insertOrderItemSql = "INSERT INTO OrderItem (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    SqlCommand cmdInsertOrderItem = new SqlCommand(insertOrderItemSql, connection);
                    cmdInsertOrderItem.Parameters.AddWithValue("@OrderID", orderId);
                    cmdInsertOrderItem.Parameters.AddWithValue("@ProductID", GetProductID(row["ProductName"].ToString()));
                    cmdInsertOrderItem.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                    cmdInsertOrderItem.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message);
            }
        }

        private int GetProductID(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Invalid product name. Please ensure a valid product is provided.");
                return 0;
            }

            foreach (DataRow row in productTable.Rows)
            {
                if (row["Name"].ToString() == productName)
                {
                    return (int)row["ID"];
                }
            }

            MessageBox.Show("Product not found: " + productName);
            return 0;
        }


        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text != "" && int.TryParse(txtOrderID.Text, out int orderId) && orderItemsTable.Rows.Count > 0)
            {
                // Cập nhật
                SaveOrderToDatabase(orderId);

                MessageBox.Show($"Order with ID {orderId} has been successfully updated!");

                var result = MessageBox.Show("Do you want to view this order in ManageOrder?", "Order Updated", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManageOrdersForm manageOrderForm = new ManageOrdersForm();
                    manageOrderForm.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("The order must contain at least one product, or you can choose to delete this order.");
            }
        }

        private void btnRemoveFromOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.CurrentRow != null)
            {
                // Lấy thông tin sản phẩm trong dòng được chọn
                DataRowView selectedRow = (DataRowView)dgvOrderItems.CurrentRow.DataBoundItem;

                // Hoàn trả lại số lượng tồn kho cho sản phẩm
                string productName = selectedRow["ProductName"].ToString();
                int quantityToRemove = (int)selectedRow["Quantity"];

                // Tìm lại sản phẩm trong productTable để cập nhật số lượng
                foreach (DataRow row in productTable.Rows)
                {
                    if (row["Name"].ToString() == productName)
                    {
                        row["Quantity"] = (int)row["Quantity"] + quantityToRemove;
                        break;
                    }
                }

                // Xóa dòng khỏi orderItemsTable
                orderItemsTable.Rows.Remove(selectedRow.Row);
            }
            else
            {
                MessageBox.Show("Please select an item to remove from the order.");
            }
        }


        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                decimal unitPrice = (decimal)dgvProducts.CurrentRow.Cells["Price"].Value;
                int quantity = (int)numericUpDownQuantity.Value;

                // Tính tổng giá
                decimal totalPrice = unitPrice * quantity;
                txtPrice.Text = totalPrice.ToString("C"); // Định dạng giá tiền
            }
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            txtPrice.Enabled = false;
            if (dgvProducts != null)
            {
                txtPrice.Text = "$" + dgvProducts.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}
