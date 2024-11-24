using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class ExportToCSVForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-ME21P7E\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";

        public ExportToCSVForm()
        {
            InitializeComponent();
            ToggleInputFields();
            btnExportToCSV.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleInputFields();
            btnSearch.Enabled = true;
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
        }

        private void ToggleInputFields()
        {
            string selectedType = cmbSearchType.SelectedItem?.ToString() ?? string.Empty;
            bool isEmployee = selectedType == "Employee";
            bool isClient = selectedType == "Client";
            bool isProduct = selectedType == "Product";
            bool isOrderOrBill = selectedType == "Order" || selectedType == "Bill";

            // Enable or disable fields based on selected search type
            cmbPriceRange.Enabled = isEmployee || isClient || isProduct || isOrderOrBill;
            dtpFromDate.Enabled = isOrderOrBill || isEmployee || isClient;
            dtpToDate.Enabled = isOrderOrBill || isEmployee || isClient;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnExportToCSV.Enabled = true;
            if (!ValidateInput())
                return;

            string query = BuildQuery();
            LoadResults(query);
        }

        private bool ValidateInput()
        {
            if (cmbSearchType.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSearchType.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select an object before proceeding.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPriceRange.SelectedItem == null || string.IsNullOrWhiteSpace(cmbPriceRange.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a valid amount range.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string selectedType = cmbSearchType.SelectedItem.ToString();

            if (selectedType != "Product")
            {
                if (dtpFromDate.Value > DateTime.Now || dtpToDate.Value > DateTime.Now)
                {
                    MessageBox.Show("Date cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    MessageBox.Show("From date cannot be later than To date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private string BuildQuery()
        {
            string searchType = cmbSearchType.SelectedItem.ToString();
            string query = string.Empty;

            decimal? minAmount = null;
            decimal? maxAmount = null;

            // Handle price range input
            if (cmbPriceRange.Enabled)
            {
                var priceRange = cmbPriceRange.SelectedItem.ToString();
                if (priceRange.Contains("-"))
                {
                    var rangeParts = priceRange.Split('-');
                    if (rangeParts.Length == 2)
                    {
                        if (decimal.TryParse(rangeParts[0].Trim().Replace(",", ""), out decimal min) &&
                            decimal.TryParse(rangeParts[1].Trim().Replace(",", ""), out decimal max))
                        {
                            minAmount = min;
                            maxAmount = max;
                        }
                        else
                        {
                            MessageBox.Show("Invalid amount range format.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return string.Empty;
                        }
                    }
                }
                else if (priceRange.StartsWith("Larger than"))
                {
                    var parts = priceRange.Split(new[] { "Larger than" }, StringSplitOptions.None);
                    if (parts.Length == 2 && decimal.TryParse(parts[1].Trim().Replace(",", ""), out decimal min))
                    {
                        minAmount = min;
                        maxAmount = decimal.MaxValue;  // No upper limit for "Larger than"
                    }
                    else
                    {
                        MessageBox.Show("Invalid amount range format.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return string.Empty;
                    }
                }
            }
            //MessageBox.Show($"Min Amount: {minAmount}, Max Amount: {maxAmount}",
                        //"Amount Range", MessageBoxButtons.OK, MessageBoxIcon.Information);



            if (searchType == "Employee")
            {
                query = "SELECT * FROM Employee WHERE 1=1";

                // Filter by salary
                if (minAmount.HasValue)
                    query += $" AND Salary >= {minAmount.Value}";

                if (maxAmount.HasValue)
                    query += $" AND Salary <= {maxAmount.Value}";

                // Filter by hire date
                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND HireDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }
            else if (searchType == "Client")
            {
                query = "SELECT c.ID AS ClientID, c.Name AS ClientName, b.ID AS BillID, b.TotalPrice as TotalSpent " +
                        "FROM Client c " +
                        "INNER JOIN Bill b ON c.ID = b.ClientID ";

                if (minAmount.HasValue)
                {
                    query += $"AND b.TotalPrice >= {minAmount.Value} "; 
                }

                if (maxAmount.HasValue)
                {
                    query += $"AND b.TotalPrice <= {maxAmount.Value} ";
                }

                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND BillDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }

            else if (searchType == "Product")
            {
                query = "SELECT * FROM Product WHERE 1=1";

                // Filter by product price
                if (minAmount.HasValue)
                    query += $" AND Price >= {minAmount.Value}";

                if (maxAmount.HasValue)
                    query += $" AND Price <= {maxAmount.Value}";
            }
            else if (searchType == "Order")
            {
                query = "SELECT * FROM [Order] WHERE 1=1";

                // Filter by total price
                if (minAmount.HasValue)
                    query += $" AND TotalPrice >= {minAmount.Value}";

                if (maxAmount.HasValue)
                    query += $" AND TotalPrice <= {maxAmount.Value}";

                // Filter by order date
                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND OrderDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }
            else if (searchType == "Bill")
            {
                query = "SELECT * FROM Bill WHERE 1=1";

                // Filter by bill total price
                if (minAmount.HasValue)
                    query += $" AND TotalPrice >= {minAmount.Value}";

                if (maxAmount.HasValue)
                    query += $" AND TotalPrice <= {maxAmount.Value}";

                // Filter by bill date
                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND BillDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }

            return query;
        }
        private void LoadResults(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                command.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dgvResults.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {
                    string searchType = cmbSearchType.SelectedItem.ToString();
                    string dateRange = $" from {dtpFromDate.Value.ToShortDateString()} to {dtpToDate.Value.ToShortDateString()}";

                    string message = $"No results found for {searchType.ToLower()}";

                    MessageBox.Show(message, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FileName = "Export.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Specify UTF-8 encoding to support Vietnamese characters
                        using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                        {
                            for (int i = 0; i < dgvResults.Columns.Count; i++)
                            {
                                writer.Write(dgvResults.Columns[i].HeaderText);
                                if (i < dgvResults.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();

                            foreach (DataGridViewRow row in dgvResults.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dgvResults.Columns.Count; i++)
                                    {
                                        string cellValue = row.Cells[i].Value?.ToString().Replace(",", ";") ?? string.Empty;
                                        writer.Write(cellValue);
                                        if (i < dgvResults.Columns.Count - 1)
                                            writer.Write(",");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }

                        MessageBox.Show("Exported successfully to CSV.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data to CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
