using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class Form1 : Form
    {
        // Biến toàn cục static để lưu thông tin đăng nhập
        public static string currentRole;
        public static string currentEmployeeId; // Lưu EmployeeID

        private string connectionString = @"Server=DESKTOP-ME21P7E\MAY2;Database=PiStoreOfCloud;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            txtPwd.UseSystemPasswordChar = true;
        }
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPwdForm resetForm = new ResetPwdForm();
            resetForm.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPwd.UseSystemPasswordChar = false; // Không dùng ký tự ẩn
            }
            else
            {
                txtPwd.UseSystemPasswordChar = true; // Sử dụng ký tự ẩn cho mật khẩu (dấu '*')
            }
        }

        private void btLgIn_Click(object sender, EventArgs e)
        {
            string username = txtUsrN.Text.ToLower(); // Chuyển thành chữ thường
            string password = txtPwd.Text.ToLower(); // Chuyển thành chữ thường

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Kết nối với cơ sở dữ liệu và xác thực username và password
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT Role, EmployeeID FROM [User] WHERE LOWER(Username) = @username AND LOWER(Password) = @password";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                string employeeId = reader["EmployeeID"].ToString();

                                // Lưu thông tin đăng nhập vào biến toàn cục
                                currentRole = role;
                                currentEmployeeId = employeeId;

                                // Điều hướng dựa trên role
                                if (role == "Admin")
                                {
                                    MessageBox.Show("Login successful! Role: Admin", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();
                                }
                                else if (role == "Employee")
                                {
                                    MessageBox.Show("Login successful! Role: Employee", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EmpForm empForm = new EmpForm();
                                    empForm.Show();
                                }
                                else if (role == "Client")
                                {
                                    MessageBox.Show("Login successful! Role: Client", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CliForm cliForm = new CliForm();
                                    cliForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Unknown role. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                // Ẩn Form đăng nhập sau khi mở form mới
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
