using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _522H0083
{
    public partial class ManageEmployeeForm : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable employeeTable;
        int dk = 0;

        public ManageEmployeeForm()
        {
            InitializeComponent();
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            formload();
        }

        void formload()
        {
            LoadEmployeeData();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            dk = 0;
        }

        private void LoadEmployeeData()
        {
            string sql = "SELECT * FROM Employee";
            adapter = new SqlDataAdapter(sql, connection);
            employeeTable = new DataTable();
            adapter.Fill(employeeTable);
            dgvEmployees.DataSource = employeeTable;
        }

        private void ClearInputFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            dtpHireDate.Value = DateTime.Today; // Reset HireDate
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return false;
            }

            if (IsAllDigits(txtName.Text))
            {
                MessageBox.Show("Name cannot be just numbers. Please enter a valid name.");
                return false;
            }

            if (IsAllDigits(txtAddress.Text))
            {
                MessageBox.Show("Address cannot be just numbers. Please enter a valid address.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            if (txtPhone.Text.Length != 10 || !long.TryParse(txtPhone.Text, out _))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.");
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Please enter a valid salary.");
                return false;
            }

            if (dtpHireDate.Value > DateTime.Today)
            {
                MessageBox.Show("The hire date cannot be in the future. Please select a valid date.");
                return false;
            }

            return true;
        }

        private bool IsAllDigits(string input)
        {
            return input.All(char.IsDigit);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ClearInputFields();
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtSalary.Enabled = true;
            dtpHireDate.Enabled = true;
            txtName.Focus();
            btnSave.Enabled = true;
            string newId = GetNextEmployeeId(); // Get the next available ID
            txtID.Text = newId.ToString();
            txtName.Focus();
            btnSave.Enabled = true;
            dk = 1;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select an employee from the list to edit.");
                return;
            }
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtSalary.Enabled = true;
            dtpHireDate.Enabled = true;
            txtName.Focus();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            dk = 2;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select an employee from the list to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this employee?",
                                                 "Confirm Delete!",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string s = "DELETE FROM Employee WHERE ID = '" + txtID.Text + " ' ";
                command = new SqlCommand(s, connection);
                command.ExecuteNonQuery();
                formload();
            }
        }

        private string GetNextEmployeeId()
        {
            try
            {
                string sql = "SELECT TOP 1 ID FROM Employee ORDER BY ID DESC"; // Lấy mã nhân viên lớn nhất
                command = new SqlCommand(sql, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string lastId = result.ToString();
                    string prefix = lastId.Substring(0, 1); // Lấy ký tự 'e' từ ID (prefix)
                    string numericPart = lastId.Substring(1); // Phần số của ID
                    int nextNumber = int.Parse(numericPart) + 1; // Tăng số lên 1
                    string nextId = prefix + nextNumber.ToString("D4"); // D4 đảm bảo số có 4 chữ số, ví dụ: 0001, 0002...
                    return nextId;
                }
                else
                {
                    return "e0001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next employee ID: {ex.Message}");
                return "e0001"; // Default to e0001 if there's an error
            }
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string sql = "";
                if (dk == 1) // Add
                {
                    // Insert into
                    sql = "INSERT INTO Employee VALUES (N'" + txtID.Text + "', N'" + txtName.Text + "', N'" + txtEmail.Text + "', N'" + txtPhone.Text + "', N'" + txtAddress.Text + "', " + txtSalary.Text + ", '" + dtpHireDate.Value.ToShortDateString() + "')";
                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                else // dk = 2
                {
                    // Update
                    sql = "UPDATE Employee SET " +
                          "Name = N'" + txtName.Text + "', " +
                          "Email = N'" + txtEmail.Text + "', " +
                          "Phone = N'" + txtPhone.Text + "', " +
                          "Address = N'" + txtAddress.Text + "', " +
                          "Salary = " + txtSalary.Text + ", " +
                          "HireDate = '" + dtpHireDate.Value.ToShortDateString() + "' " +
                          "WHERE ID = N'" + txtID.Text + "'"; // Thêm N trước ID vì ID là kiểu NVARCHAR

                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }

                formload();
            }
        }

        private void dgvEmployees_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvEmployees.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvEmployees.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgvEmployees.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvEmployees.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dgvEmployees.CurrentRow.Cells[4].Value.ToString();
            txtSalary.Text = dgvEmployees.CurrentRow.Cells[5].Value.ToString();
            dtpHireDate.Text = dgvEmployees.CurrentRow.Cells[6].Value.ToString();

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            txtID.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtSalary.Enabled = false;
            dtpHireDate.Enabled = false;
        }
    }
}
