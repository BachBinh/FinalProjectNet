using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class SearchForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-ME21P7E\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";

        public SearchForm()
        {
            InitializeComponent();
            ToggleInputFields();
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleInputFields();
            txtName.Clear();
            txtPhone.Clear();
            txtSearch.Clear();
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
        }

        private void ToggleInputFields()
        {
            string selectedType = cmbSearchType.SelectedItem?.ToString() ?? string.Empty;
            bool isEmployee = selectedType == "Employee";
            bool isClient = selectedType == "Client";
            bool isProduct = selectedType == "Product";
            bool isOrderOrBill = selectedType == "Order" || selectedType == "Bill";

            // Disable fields by default if "Select" is chosen
            txtSearch.Enabled = isEmployee || isClient || isProduct || isOrderOrBill;
            txtName.Enabled = isEmployee || isClient || isProduct;
            txtPhone.Enabled = isEmployee || isClient;
            dtpFromDate.Enabled = isOrderOrBill || isEmployee;
            dtpToDate.Enabled = isOrderOrBill || isEmployee;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            // **admin: e0000
            if (txtSearch.Text.Trim().Equals("e0000", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The ID 'e0000' is reserved for an administrator. Please enter a valid employee ID.",
                                "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            string query = BuildQuery();
            LoadResults(query);
        }


        private bool ValidateInput()
        {
            if (cmbSearchType.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSearchType.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a object before proceeding.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string selectedType = cmbSearchType.SelectedItem.ToString();

            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (selectedType != "Client" && selectedType != "Product")
            {
                // Validate date range
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

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$"); // Assuming a valid phone number is a 10-digit number
        }

        private string BuildQuery()
        {
            string searchType = cmbSearchType.SelectedItem.ToString();
            string query = string.Empty;

            if (searchType == "Employee")
            {
                query = "SELECT * FROM Employee WHERE 1=1";

                // Thêm điều kiện theo ID nếu có nhập
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    query += $" AND ID LIKE '%{txtSearch.Text}%'";

                // Thêm điều kiện theo Tên nếu có nhập
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    query += $" AND Name LIKE N'%{txtName.Text}%'";

                // Thêm điều kiện theo Số điện thoại nếu có nhập
                if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                    query += $" AND Phone LIKE '%{txtPhone.Text}%'";

                // Thêm điều kiện theo khoảng thời gian nếu hợp lệ
                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND HireDate BETWEEN '{dtpFromDate.Value.ToString("yyyy-MM-dd")}' AND '{dtpToDate.Value.ToString("yyyy-MM-dd")}'";
            }
            else if (searchType == "Client")
            {
                query = "SELECT * FROM Client WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    query += $" AND ID LIKE '%{txtSearch.Text}%'";

                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    query += $" AND Name LIKE N'%{txtName.Text}%'";

                if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                    query += $" AND Phone LIKE '%{txtPhone.Text}%'";
            }
            else if (searchType == "Product")
            {
                query = "SELECT * FROM Product WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && int.TryParse(txtSearch.Text, out int productId))
                    query += $" AND ID = {productId}";

                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    query += $" AND Name LIKE N'%{txtName.Text}%'";
            }
            else if (searchType == "Order")
            {
                query = "SELECT * FROM [Order] WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && int.TryParse(txtSearch.Text, out int orderId))
                    query += $" AND ID = {orderId}";

                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND OrderDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }
            else if (searchType == "Bill")
            {
                query = "SELECT * FROM Bill WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && int.TryParse(txtSearch.Text, out int billId))
                    query += $" AND ID = {billId}";

                if (dtpFromDate.Value.Date <= dtpToDate.Value.Date)
                    query += $" AND BillDate BETWEEN '{dtpFromDate.Value:yyyy-MM-dd}' AND '{dtpToDate.Value:yyyy-MM-dd}'";
            }

            return query;
        }



        private void LoadResults(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Set the DataGridView's data source
                dgvResults.DataSource = dataTable;

                // Check if the DataTable is empty
                if (dataTable.Rows.Count == 0)
                {
                    string searchType = cmbSearchType.SelectedItem.ToString();
                    string searchId = txtSearch.Text.Trim();
                    string searchName = txtName.Text.Trim();
                    string searchPhone = txtPhone.Text.Trim();
                    string dateRange = $" from {dtpFromDate.Value.ToShortDateString()} to {dtpToDate.Value.ToShortDateString()}";

                    string message = $"No results found for {searchType.ToLower()}";

                    if (searchType == "Employee")
                    {
                        message += $" with ID: '{searchId}' or Name: '{searchName}' or Phone: '{searchPhone}'" +
                                   $" hired{dateRange}.";
                    }
                    else if (searchType == "Client")
                    {
                        message += $" with ID: '{searchId}' or Name: '{searchName}' or Phone: '{searchPhone}'.";
                    }
                    else if (searchType == "Product")
                    {
                        message += $" with ID: '{searchId}' or Name: '{searchName}'.";
                    }
                    else if (searchType == "Order" || searchType == "Bill")
                    {
                        message += $" with ID: '{searchId}' created{dateRange}.";
                    }

                    MessageBox.Show(message, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
