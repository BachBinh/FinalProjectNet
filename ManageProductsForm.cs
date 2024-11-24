using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class ManageProductsForm : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable productTable;
        int dk = 0; // 0: none, 1: add, 2: edit

        public ManageProductsForm()
        {
            InitializeComponent();
        }

        private void ManageProductsForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            formload();
        }

        void formload()
        {
            LoadProductData();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            dk = 0;
            ClearInputFields();
        }

        private void LoadProductData()
        {
            string sql = "SELECT * FROM Product";
            adapter = new SqlDataAdapter(sql, connection);
            productTable = new DataTable();
            adapter.Fill(productTable);
            dgvProducts.DataSource = productTable;
        }

        private void ClearInputFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtQuantity.Value = 0; // Đặt về 0 cho NumericUpDown
            txtName.Enabled = false;
            txtDescription.Enabled = false;
            txtPrice.Enabled = false;
            txtQuantity.Enabled = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid price.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtID.Text = GetNextProductId().ToString(); // Lấy ID mới
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            txtQuantity.Enabled = true;
            txtName.Focus();
            btnSave.Enabled = true;
            dk = 1; // Đặt chế độ thêm mới
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a product from the list to edit.");
                return;
            }
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            txtQuantity.Enabled = true;
            txtName.Focus();
            btnSave.Enabled = true;
            dk = 2; // Đặt chế độ chỉnh sửa
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a product from the list to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this product?",
                                                 "Confirm Delete!",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string s = "DELETE FROM Product WHERE ID = @ID";
                command = new SqlCommand(s, connection);
                command.Parameters.AddWithValue("@ID", txtID.Text);
                command.ExecuteNonQuery();
                formload();
            }
        }

        private int GetNextProductId()
        {
            try
            {
                string sql = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Product"; // Lấy ID mới
                command = new SqlCommand(sql, connection);
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result); // Trả về ID mới
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next product ID: {ex.Message}");
                return 1; // Trả về 1 nếu có lỗi
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string sql = "";
                if (dk == 1) // Chế độ thêm
                {
                    sql = "INSERT INTO Product (Name, Description, Price, Quantity) VALUES (@Name, @Description, @Price, @Quantity)";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    command.Parameters.AddWithValue("@Quantity", (int)txtQuantity.Value); // Lấy giá trị từ NumericUpDown
                }
                else if (dk == 2) // Chế độ chỉnh sửa
                {
                    sql = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity WHERE ID = @ID";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@ID", txtID.Text);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    command.Parameters.AddWithValue("@Quantity", (int)txtQuantity.Value); // Lấy giá trị từ NumericUpDown
                }
                command.ExecuteNonQuery();
                formload();
            }
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtDescription.Enabled = false;
            txtPrice.Enabled = false;
            txtQuantity.Enabled = false;
            btnSave.Enabled = false;

            if (dgvProducts.CurrentRow != null)
            {
                txtID.Text = dgvProducts.CurrentRow.Cells[0].Value?.ToString() ?? string.Empty;
                txtName.Text = dgvProducts.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtDescription.Text = dgvProducts.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtPrice.Text = dgvProducts.CurrentRow.Cells[3].Value?.ToString() ?? string.Empty;

                int quantityValue = dgvProducts.CurrentRow.Cells[4].Value != null
                    && int.TryParse(dgvProducts.CurrentRow.Cells[4].Value.ToString(), out int result) ? result : 0;
                txtQuantity.Value = quantityValue; // Chuyển sang NumericUpDown
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
