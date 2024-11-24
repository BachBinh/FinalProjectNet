using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class PlaceOrderForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable productTable;
        private DataTable orderItemsTable;

        public PlaceOrderForm()
        {
            InitializeComponent();
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();

            LoadClients();
            LoadProducts();

            orderItemsTable = new DataTable();
            orderItemsTable.Columns.Add("ProductID");
            orderItemsTable.Columns.Add("ProductName");
            orderItemsTable.Columns.Add("Quantity", typeof(int));
            orderItemsTable.Columns.Add("Price", typeof(decimal));
            //orderItemsTable.Columns.Add("TotalPrice", typeof(decimal), "Quantity * Price");
            orderItemsTable.Columns.Add("TotalPrice", typeof(decimal));
            dgvOrderItems.DataSource = orderItemsTable;
        }

        private void LoadClients()
        {
            DataTable clientTable = new DataTable();
            clientTable.Columns.Add("ID", typeof(string));
            clientTable.Columns.Add("Name", typeof(string));
            DataRow emptyRow = clientTable.NewRow();
            emptyRow["ID"] = DBNull.Value;
            emptyRow["Name"] = "Select a Client";
            clientTable.Rows.Add(emptyRow);

            string sql = "SELECT ID, Name FROM Client";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(clientTable);

            cmbClients.DataSource = clientTable;
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "ID";
            cmbClients.SelectedIndex = 0; 
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

                // Lấy ClientID từ cmbClients.SelectedValue và kiểm tra kiểu
                string selectedClientId = cmbClients.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(selectedClientId))
                {
                    MessageBox.Show("Invalid client selection.");
                    return;
                }

                // Kiểm tra xem sản phẩm đã tồn tại trong orderItemsTable dựa trên ProductID
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

                if (existingRow != null)
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

                // Update the product quantity in the database
                string updateQuantitySql = "UPDATE Product SET Quantity = Quantity - @Quantity WHERE ID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(updateQuantitySql, connection))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quant);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery(); 
                }

                // Reset the numeric input field
                numericUpDownQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show("Please select a product and enter a valid quantity.");
            }
        }

        private int SaveOrderToDatabase()
        {
            int orderId = 0;
            try
            {
                // Tính tổng giá trị đơn hàng
                decimal totalOrderPrice = 0;
                foreach (DataRow row in orderItemsTable.Rows)
                {
                    totalOrderPrice += (decimal)row["TotalPrice"];
                }

                // Thêm đơn hàng vào bảng Order
                string insertOrderSql = "INSERT INTO [Order] (ClientID, EmployeeID, OrderDate, TotalPrice) OUTPUT INSERTED.ID VALUES (@ClientID, @EmployeeID, @OrderDate, @TotalPrice)";
                SqlCommand cmdOrder = new SqlCommand(insertOrderSql, connection);
                cmdOrder.Parameters.AddWithValue("@ClientID", cmbClients.SelectedValue);
                cmdOrder.Parameters.AddWithValue("@EmployeeID", GetEmployeeIdFromLogin());
                cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmdOrder.Parameters.AddWithValue("@TotalPrice", totalOrderPrice);

                orderId = (int)cmdOrder.ExecuteScalar();

                // Thêm từng mục vào bảng OrderItem
                foreach (DataRow row in orderItemsTable.Rows)
                {
                    string insertOrderItemSql = "INSERT INTO OrderItem (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    SqlCommand cmdOrderItem = new SqlCommand(insertOrderItemSql, connection);
                    cmdOrderItem.Parameters.AddWithValue("@OrderID", orderId);
                    cmdOrderItem.Parameters.AddWithValue("@ProductID", GetProductID(row["ProductName"].ToString()));
                    cmdOrderItem.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                    cmdOrderItem.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message);
            }
            return orderId;
        }

        private int GetProductID(string productName)
        {
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

        private string GetEmployeeIdFromLogin()
        {
            return Form1.currentEmployeeId;
        }





        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedValue != null && orderItemsTable.Rows.Count > 0)
            {
                // Thêm đơn hàng vào cơ sở dữ liệu
                int newOrderId = SaveOrderToDatabase();
                if (newOrderId > 0)
                {
                    var result = MessageBox.Show($"Order submitted successfully with ID {newOrderId}! Do you want to view this order in ManageOrder?", "Order Submitted", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Mở ManageOrderForm để xem chi tiết order
                        ManageOrdersForm manageOrderForm = new ManageOrdersForm();
                        manageOrderForm.Show();
                        Close();
                    }
                }
            }
            else if (cmbClients.SelectedValue == null)
            {
                MessageBox.Show("Please select a client.");
            }
            else if (orderItemsTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the order.");
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
                //MessageBox.Show();

                // Tìm lại sản phẩm trong productTable để cập nhật số lượng
                foreach (DataRow row in productTable.Rows)
                {
                    if (row["Name"].ToString() == productName)
                    {
                        row["Quantity"] = (int)row["Quantity"] + quantityToRemove;
                        break;
                    }
                }

                string sql = "UPDATE Product SET Quantity = Quantity + @QuantityToAdd WHERE Name = @ProductName";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@QuantityToAdd", quantityToRemove);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.ExecuteNonQuery();
                }

                // Xóa dòng khỏi orderItemsTable
                orderItemsTable.Rows.Remove(selectedRow.Row);
                dgvProducts.DataSource = null; // Xóa kết nối cũ
                dgvProducts.DataSource = productTable;
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
