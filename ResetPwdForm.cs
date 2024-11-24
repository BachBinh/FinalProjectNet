using System;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class ResetPwdForm : Form
    {
        private string generatedOTP;
        private DateTime lastOTPSentTime;
        private int otpRequestAttempts = 0;
        private string userEmail;
        private string userType;
        private string userID;

        public ResetPwdForm()
        {
            InitializeComponent();
        }

        private string CheckIfPhoneNumberExists(string phoneNumber, out string userEmail)
        {
            userEmail = string.Empty;

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DPOISF3\\SQLEXPRESS01;Initial Catalog=PiStoreOfCloud;Integrated Security=True"))
            {
                conn.Open();

                string query = @"
                SELECT 'Employee' AS UserType, ID, Phone, Email FROM Employee WHERE Phone = @Phone
                UNION
                SELECT 'Client' AS UserType, ID, Phone, Email FROM Client WHERE Phone = @Phone";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Phone", phoneNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    userEmail = reader["Email"].ToString();
                    return reader["UserType"].ToString() + "-" + reader["ID"].ToString();
                }

                return null;
            }
        }

        private void SendOTPEmail(string email)
        {
            try
            {
                string subject = "Your OTP for Password Reset";
                string body = $"Your OTP is: {generatedOTP}";

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("your-email@gmail.com"); // Địa chỉ email người gửi
                mailMessage.To.Add(email); // Địa chỉ email người nhận
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                // Sử dụng SmtpClient để gửi email qua SMTP server
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Cổng sử dụng cho TLS
                    Credentials = new NetworkCredential("your-email@gmail.com", "your-email-password"), // Thông tin đăng nhập
                    EnableSsl = true // Bật SSL
                };

                smtpClient.Send(mailMessage); // Gửi email
                MessageBox.Show("OTP sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message);
            }
        }

        private void btnCheckOTP_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtOTP.Text.Trim();

            if (enteredOTP == generatedOTP)
            {
                MessageBox.Show("OTP is correct. You can now reset your password.");
                txtNewPassword.Enabled = true; // Kích hoạt textbox nhập mật khẩu mới
            }
            else
            {
                MessageBox.Show("Incorrect OTP. Please try again.");
                otpRequestAttempts++; // Tăng số lần thử nhập OTP
                if (otpRequestAttempts >= 5)
                {
                    MessageBox.Show("Too many incorrect OTP attempts. Please try again after 3 minutes.");
                    // Tắt chức năng gửi OTP trong 3 phút
                    btnSendOTP.Enabled = false;
                    lastOTPSentTime = DateTime.Now.AddMinutes(3);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }

            // Cập nhật mật khẩu trong cơ sở dữ liệu
            UpdatePassword(newPassword);

            MessageBox.Show("Password has been successfully reset.");
            this.Close();
        }

        private void UpdatePassword(string newPassword)
        {
            string query = userType == "Employee" ?
                "UPDATE Employee SET Password = @Password WHERE ID = @ID" :
                "UPDATE Client SET Password = @Password WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DPOISF3\\SQLEXPRESS01;Initial Catalog=PiStoreOfCloud;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@ID", userID);

                cmd.ExecuteNonQuery();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhone.Text.Trim();

            // Kiểm tra định dạng số điện thoại (phải là 10 chữ số)
            if (string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.");
                return;
            }

            if (otpRequestAttempts > 0 && (DateTime.Now - lastOTPSentTime).TotalMinutes < 3)
            {
                MessageBox.Show("You can request a new OTP only after 3 minutes.");
                return;
            }

            // Lấy email và thông tin người dùng từ số điện thoại
            userEmail = string.Empty;
            string userID = CheckIfPhoneNumberExists(phoneNumber, out userEmail);

            if (userID == null)
            {
                MessageBox.Show("Phone number not found in the database.");
                return;
            }

            // Tạo OTP
            Random random = new Random();
            generatedOTP = random.Next(100000, 999999).ToString();
            otpRequestAttempts++;

            // Gửi OTP qua email
            SendOTPEmail(userEmail);

            // Lưu thời gian gửi OTP
            lastOTPSentTime = DateTime.Now;

            MessageBox.Show("OTP has been sent to your email. Please check your inbox.");
            txtOTP.Enabled = true; // Kích hoạt textbox nhập OTP
        }
    }
}
