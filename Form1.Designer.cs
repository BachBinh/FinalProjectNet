namespace _522H0083
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btLgIn = new Button();
            txtUsrN = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            txtPwd = new TextBox();
            label4 = new Label();
            label3 = new Label();
            chkShowPassword = new CheckBox();
            panel3 = new Panel();
            label5 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            btMin = new Button();
            btMax = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btLgIn
            // 
            btLgIn.BackColor = Color.FromArgb(97, 211, 195);
            btLgIn.FlatAppearance.BorderSize = 0;
            btLgIn.FlatStyle = FlatStyle.Flat;
            btLgIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLgIn.ForeColor = Color.White;
            btLgIn.Location = new Point(128, 393);
            btLgIn.Name = "btLgIn";
            btLgIn.Size = new Size(97, 39);
            btLgIn.TabIndex = 1;
            btLgIn.Text = "Login";
            btLgIn.UseVisualStyleBackColor = false;
            btLgIn.Click += btLgIn_Click;
            // 
            // txtUsrN
            // 
            txtUsrN.Location = new Point(66, 198);
            txtUsrN.Name = "txtUsrN";
            txtUsrN.Size = new Size(266, 27);
            txtUsrN.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(39, 68);
            label1.Name = "label1";
            label1.Size = new Size(279, 54);
            label1.TabIndex = 3;
            label1.Text = "Welcome Back";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(28, 192, 169);
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtPwd);
            panel2.Controls.Add(btLgIn);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtUsrN);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(chkShowPassword);
            panel2.ForeColor = Color.Transparent;
            panel2.Location = new Point(43, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(355, 492);
            panel2.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Location = new Point(20, 299);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 34);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Location = new Point(20, 191);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 34);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(66, 306);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(266, 27);
            txtPwd.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(70, 274);
            label4.Name = "label4";
            label4.Size = new Size(88, 21);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(66, 166);
            label3.Name = "label3";
            label3.Size = new Size(93, 21);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(200, 339);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(132, 24);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(panel1);
            panel3.Location = new Point(448, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(449, 642);
            panel3.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Script", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(80, 486);
            label5.Name = "label5";
            label5.Size = new Size(324, 57);
            label5.TabIndex = 8;
            label5.Text = "Have a good day";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(449, 642);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Script", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(80, 486);
            label2.Name = "label2";
            label2.Size = new Size(324, 57);
            label2.TabIndex = 8;
            label2.Text = "Have a good day";
            // 
            // btMin
            // 
            btMin.Location = new Point(0, 0);
            btMin.Name = "btMin";
            btMin.Size = new Size(75, 23);
            btMin.TabIndex = 0;
            // 
            // btMax
            // 
            btMax.Location = new Point(0, 0);
            btMax.Name = "btMax";
            btMax.Size = new Size(75, 23);
            btMax.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(97, 211, 195);
            ClientSize = new Size(897, 640);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            Name = "Form1";
            Text = " PiStoreOfCloud";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btLgIn;
        private TextBox txtUsrN;
        private Label label1;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private TextBox txtPwd;
        private Panel panel3;
        private Label label5;
        private Button btMin;
        private Button btMax;
        private Panel panel1;
        private Label label2;
        //private LinkLabel lnkForgotPassword;
        private CheckBox chkShowPassword;
    }
}
