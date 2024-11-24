namespace _522H0083
{
    partial class ResetPwdForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnCheckOTP;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPhone = new TextBox();
            btnSendOTP = new Button();
            txtOTP = new TextBox();
            btnCheckOTP = new Button();
            txtNewPassword = new TextBox();
            btnSave = new Button();
            chkShowPassword = new CheckBox();
            lblPhone = new Label();
            lblOTP = new Label();
            lblNewPassword = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(23, 81);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(229, 27);
            txtPhone.TabIndex = 0;
            // 
            // btnSendOTP
            // 
            btnSendOTP.Location = new Point(323, 79);
            btnSendOTP.Name = "btnSendOTP";
            btnSendOTP.Size = new Size(99, 30);
            btnSendOTP.TabIndex = 1;
            btnSendOTP.Text = "Send OTP";
            btnSendOTP.UseVisualStyleBackColor = true;
            btnSendOTP.Click += btnSendOTP_Click;
            // 
            // txtOTP
            // 
            txtOTP.Enabled = false;
            txtOTP.Location = new Point(23, 198);
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(229, 27);
            txtOTP.TabIndex = 2;
            // 
            // btnCheckOTP
            // 
            btnCheckOTP.Location = new Point(323, 198);
            btnCheckOTP.Name = "btnCheckOTP";
            btnCheckOTP.Size = new Size(99, 30);
            btnCheckOTP.TabIndex = 3;
            btnCheckOTP.Text = "Check OTP";
            btnCheckOTP.UseVisualStyleBackColor = true;
            btnCheckOTP.Click += btnCheckOTP_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Enabled = false;
            txtNewPassword.Location = new Point(23, 307);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(229, 27);
            txtNewPassword.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(323, 307);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(120, 350);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(132, 24);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(23, 42);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(180, 20);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Enter your phone number:";
            // 
            // lblOTP
            // 
            lblOTP.AutoSize = true;
            lblOTP.Location = new Point(23, 154);
            lblOTP.Name = "lblOTP";
            lblOTP.Size = new Size(77, 20);
            lblOTP.TabIndex = 8;
            lblOTP.Text = "OTP Code:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(23, 263);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(107, 20);
            lblNewPassword.TabIndex = 9;
            lblNewPassword.Text = "New Password:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(150, 250);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 10;
            // 
            // ResetPwdForm
            // 
            ClientSize = new Size(515, 427);
            Controls.Add(lblStatus);
            Controls.Add(lblNewPassword);
            Controls.Add(lblOTP);
            Controls.Add(lblPhone);
            Controls.Add(chkShowPassword);
            Controls.Add(btnSave);
            Controls.Add(txtNewPassword);
            Controls.Add(btnCheckOTP);
            Controls.Add(txtOTP);
            Controls.Add(btnSendOTP);
            Controls.Add(txtPhone);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ResetPwdForm";
            Text = "Reset Password";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
