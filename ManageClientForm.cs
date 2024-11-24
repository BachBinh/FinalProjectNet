using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class ManageClientForm : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable clientTable;
        int dk = 0; // 0: none, 1: add, 2: edit

        public ManageClientForm()
        {
            InitializeComponent();
        }

        private void ManageClientForm_Load_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            formload();
        }

        void formload()
        {
            LoadClientData();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            dk = 0;
        }

        private void LoadClientData()
        {
            string sql = "SELECT * FROM Client";
            adapter = new SqlDataAdapter(sql, connection);
            clientTable = new DataTable();
            adapter.Fill(clientTable);
            dgvClients.DataSource = clientTable;
        }

        private void ClearInputFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtAddress.Text))
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

            return true;
        }
        private bool IsAllDigits(string input)
        {
            return input.All(char.IsDigit);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            string newId = GetNextClientId(); // Get the next available ID
            txtID.Text = newId.ToString();
            txtName.Focus();
            btnSave.Enabled = true;
            dk = 1; // Set mode to add
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a client from the list to edit.");
                return;
            }
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtName.Focus();
            btnSave.Enabled = true;
            dk = 2; // Set mode to edit
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a client from the list to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this client?",
                                                    "Confirm Delete!",
                                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string s = "DELETE FROM Client WHERE ID = '" + txtID.Text + " ' ";
                command = new SqlCommand(s, connection);
                command.ExecuteNonQuery();
                formload();
            }
        }

        private string GetNextClientId()
        {
            try
            {
                string sql = "SELECT TOP 1 ID FROM Client ORDER BY ID DESC"; // Lấy mã KH lớn nhất
                command = new SqlCommand(sql, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string lastId = result.ToString();
                    string prefix = lastId.Substring(0, 1); // Lấy ký tự 'c' từ ID (prefix)
                    string numericPart = lastId.Substring(1); // Phần số của ID
                    int nextNumber = int.Parse(numericPart) + 1; // Tăng số lên 1
                    string nextId = prefix + nextNumber.ToString("D4"); // D4 đảm bảo số có 4 chữ số, ví dụ: 0001, 0002...
                    return nextId;
                }
                else
                {
                    return "c0001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next Client ID: {ex.Message}");
                return "c0001"; // Default to e0001 if there's an error
            }
        }

        private bool ClientIdExists(int id)
        {
            string sql = "SELECT COUNT(*) FROM Client WHERE ID = @ID";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", id);
            int count = (int)command.ExecuteScalar();
            return count > 0; // Nếu ID đã tồn tại, trả về true
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string sql = "";
                if (dk == 1) // Add
                {
                    sql = "INSERT INTO Client (ID, Name, Email, Phone, Address) VALUES (@ID, @Name, @Email, @Phone, @Address)";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@ID", txtID.Text); // Sử dụng ID từ TextBox
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                }
                else if (dk == 2) // Edit
                {
                    sql = "UPDATE Client SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE ID = @ID";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@ID", txtID.Text);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                }
                command.ExecuteNonQuery();
                LoadClientData();
            }
        }

        private void dgvClients_Click_1(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            if (dgvClients.CurrentRow != null)
            {
                txtID.Text = dgvClients.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgvClients.CurrentRow.Cells[1].Value.ToString();
                txtEmail.Text = dgvClients.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = dgvClients.CurrentRow.Cells[3].Value.ToString();
                txtAddress.Text = dgvClients.CurrentRow.Cells[4].Value.ToString();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
