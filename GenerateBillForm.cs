using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _522H0083
{
    public partial class GenerateBillForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-ME21P7E\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";

        public GenerateBillForm()
        {
            InitializeComponent();
        }

        private void GenerateBillForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Order]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrders.DataSource = dt;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                string orderId = row.Cells["ID"].Value.ToString();

                txtOrderId.Text = orderId;
                txtClientId.Text = row.Cells["ClientID"].Value.ToString();
                txtEmployeeId.Text = row.Cells["EmployeeID"].Value.ToString();

                DateTime orderDate = Convert.ToDateTime(row.Cells["OrderDate"].Value);
                txtOrderDate.Text = orderDate.ToString("yyyy-MM-dd");

                txtTotalPrice.Text = row.Cells["TotalPrice"].Value.ToString();

                LoadOrderDetails(orderId);
                LoadClientAndEmployeeInfo(row.Cells["ClientID"].Value.ToString(), row.Cells["EmployeeID"].Value.ToString());
            }
        }

        private void LoadOrderDetails(string orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT oi.ProductID, p.Name AS ProductName, oi.Quantity, p.Price, (p.Price * oi.Quantity) AS Total
                                FROM OrderItem oi 
                                JOIN Product p ON oi.ProductID = p.ID 
                                WHERE oi.OrderID = @OrderID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrderDetails.DataSource = dt;
            }
        }

        private void LoadClientAndEmployeeInfo(string clientId, string employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Client WHERE ID = @ClientID", conn);
                cmd.Parameters.AddWithValue("@ClientID", clientId);

                var clientName = cmd.ExecuteScalar();
                txtClientName.Text = clientName != null ? clientName.ToString() : "Client not found";

                if (employeeId == "e0000")
                {
                    txtEmployeeName.Text = "Admin";
                }
                else
                {
                    cmd.CommandText = "SELECT Name FROM Employee WHERE ID = @EmployeeID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    var employeeName = cmd.ExecuteScalar();
                    txtEmployeeName.Text = employeeName != null ? employeeName.ToString() : "Employee not found";
                }
            }
        }


        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                MessageBox.Show("Please select an order to generate a bill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Do you want to view a bill for Order ID: {txtOrderId.Text} and Client: {txtClientName.Text}?",
                                                  "Confirm Bill Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GenerateBill();
            }
        }

        private void GenerateBill()
        {
            StringBuilder billContent = new StringBuilder();
            billContent.AppendLine("                                 PiStoreOfCloud Bill                                    ");
            billContent.AppendLine(" \n ");
            billContent.AppendLine($"Order ID: {txtOrderId.Text}");
            billContent.AppendLine($"Client ID: {txtClientId.Text} | Client Name: {txtClientName.Text}");
            billContent.AppendLine($"Employee ID: {txtEmployeeId.Text} | Employee Name: {txtEmployeeName.Text}");
            billContent.AppendLine($"Order Date: {txtOrderDate.Text}");
            billContent.AppendLine("--------------------------------------------------------------------");
            billContent.AppendLine("Product ID  |  Product Name     |    Price      | Quantity |   Total Price");
            billContent.AppendLine("--------------------------------------------------------------------");

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["ProductID"].Value == null || Convert.ToInt32(row.Cells["ProductID"].Value) == 0)
                    continue; 
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                string productName = row.Cells["ProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal totalPrice = price * quantity;

                billContent.AppendLine($"{productId.ToString().PadRight(10)} | " +
                               $"{productName.PadRight(25)} | " +
                               $"{price.ToString("C").PadLeft(12)} | " +
                               $"{quantity.ToString().PadLeft(8)} | " +
                               $"{totalPrice.ToString("C").PadLeft(12)}");
            }

            billContent.AppendLine("-----------------------------------------------------------------");
            billContent.AppendLine($"Total Order Price: {txtTotalPrice.Text}");
            billContent.AppendLine("System ID: 522H0083");
            billContent.AppendLine("---------------------------- End of Bill -----------------------------");

            MessageBox.Show(billContent.ToString(), "Generated Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btBpdf_Click(object sender, EventArgs e)
        {
            string orderId = txtOrderId.Text;
            string clientId = txtClientId.Text;
            string clientName = txtClientName.Text;
            string billDate = DateTime.Now.ToString("yyyy-MM-dd"); // Curr date

            // File name format
            string fileName = $"{orderId}_{clientId}_{clientName}_{billDate}.pdf";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GeneratePdfBill(saveFileDialog.FileName);
                }
            }
        }


        private void GeneratePdfBill(string filePath)
        {
            string billDate = DateTime.Now.ToString("yyyy-MM-dd");
            Document pdfDoc = new Document();
            PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
            pdfDoc.Open();

            // Title
            Paragraph title = new Paragraph("-------------- PiStoreOfCloud Bill --------------", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            {
                Alignment = Element.ALIGN_CENTER
            };
            pdfDoc.Add(title);
            pdfDoc.Add(new Paragraph($"Order ID: {txtOrderId.Text}"));
            pdfDoc.Add(new Paragraph($"Client ID: {txtClientId.Text} | Client Name: {txtClientName.Text}"));
            pdfDoc.Add(new Paragraph($"Employee ID: {txtEmployeeId.Text} | Employee Name: {txtEmployeeName.Text}"));
            pdfDoc.Add(new Paragraph($"Order Date: {txtOrderDate.Text}"));
            pdfDoc.Add(new Paragraph("\n"));

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100; // 100% width

            // Headers
            table.AddCell("Product ID");
            table.AddCell("Product Name");
            table.AddCell("Price");
            table.AddCell("Quantity");
            table.AddCell("Total Price");

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["ProductID"].Value == null || Convert.ToInt32(row.Cells["ProductID"].Value) == 0)
                    continue; // Skip if ProductID: null || 0

                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                string productName = row.Cells["ProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal totalPrice = price * quantity;

                // Add cells to the table
                table.AddCell(productId.ToString());
                table.AddCell(productName);
                table.AddCell(price.ToString("C"));
                table.AddCell(quantity.ToString());
                table.AddCell(totalPrice.ToString("C"));
            }
            pdfDoc.Add(new Paragraph("\n"));
            pdfDoc.Add(table); // Add the table to the document
            pdfDoc.Add(new Paragraph($"Total Order Price: {txtTotalPrice.Text}"));
            pdfDoc.Add(new Paragraph($"Bill Date: {billDate}"));
            pdfDoc.Add(new Paragraph("System ID: 522H0083"));
            Paragraph title2 = new Paragraph("-------------- End of Bill --------------", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            {
                Alignment = Element.ALIGN_CENTER
            };
            pdfDoc.Add(title2);
            pdfDoc.Close();
            MessageBox.Show("PDF Bill has been generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGeneB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                MessageBox.Show("Please select an order to generate a bill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm
            DialogResult result = MessageBox.Show($"Do you want to generate a bill for Order ID: {txtOrderId.Text} and Client: {txtClientName.Text}?",
                                                  "Confirm Bill Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkBillQuery = "SELECT COUNT(1) FROM Bill WHERE OrderID = @OrderID";
                    using (SqlCommand checkCmd = new SqlCommand(checkBillQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@OrderID", txtOrderId.Text); 

                        int billExists = (int)checkCmd.ExecuteScalar();
                        if (billExists > 0)
                        {
                            MessageBox.Show("A bill for this order already exists. Cannot generate duplicate bills.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    DateTime billDate = DateTime.Now;
                    string insertBillQuery = @"INSERT INTO Bill (OrderID, ClientID, EmployeeID, BillDate, TotalPrice) 
                                       VALUES (@OrderID, @ClientID, @EmployeeID, @BillDate, @TotalPrice)";

                    using (SqlCommand cmd = new SqlCommand(insertBillQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", txtOrderId.Text);  
                        cmd.Parameters.AddWithValue("@ClientID", txtClientId.Text); 
                        cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeId.Text); 
                        cmd.Parameters.AddWithValue("@BillDate", billDate);
                        cmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(txtTotalPrice.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bill has been successfully generated and saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to generate the bill. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
