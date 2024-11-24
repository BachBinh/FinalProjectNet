namespace _522H0083
{
    partial class ManageEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtSalary = new TextBox();
            dtpHireDate = new DateTimePicker();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            dgvEmployees = new DataGridView();
            labelID = new Label();
            labelName = new Label();
            labelEmail = new Label();
            labelPhone = new Label();
            labelAddress = new Label();
            labelSalary = new Label();
            labelHireDate = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(16, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 31);
            label1.TabIndex = 0;
            label1.Text = "Manage Employee";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(160, 77);
            txtID.Margin = new Padding(4, 5, 4, 5);
            txtID.Name = "txtID";
            txtID.Size = new Size(265, 27);
            txtID.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 123);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(265, 27);
            txtName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 169);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(160, 215);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(265, 27);
            txtPhone.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(160, 262);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(265, 27);
            txtAddress.TabIndex = 5;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(160, 308);
            txtSalary.Margin = new Padding(4, 5, 4, 5);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(265, 27);
            txtSalary.TabIndex = 6;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(160, 354);
            dtpHireDate.Margin = new Padding(4, 5, 4, 5);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(265, 27);
            dtpHireDate.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(160, 414);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(325, 414);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(160, 480);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(325, 480);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(503, 77);
            dgvEmployees.Margin = new Padding(4, 5, 4, 5);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(533, 438);
            dgvEmployees.TabIndex = 12;
            dgvEmployees.Click += dgvEmployees_Click;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(40, 82);
            labelID.Margin = new Padding(4, 0, 4, 0);
            labelID.Name = "labelID";
            labelID.Size = new Size(27, 20);
            labelID.TabIndex = 13;
            labelID.Text = "ID:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(40, 128);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(52, 20);
            labelName.TabIndex = 14;
            labelName.Text = "Name:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(40, 174);
            labelEmail.Margin = new Padding(4, 0, 4, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 15;
            labelEmail.Text = "Email:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(40, 220);
            labelPhone.Margin = new Padding(4, 0, 4, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(53, 20);
            labelPhone.TabIndex = 16;
            labelPhone.Text = "Phone:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(40, 266);
            labelAddress.Margin = new Padding(4, 0, 4, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(65, 20);
            labelAddress.TabIndex = 17;
            labelAddress.Text = "Address:";
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Location = new Point(40, 312);
            labelSalary.Margin = new Padding(4, 0, 4, 0);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(52, 20);
            labelSalary.TabIndex = 18;
            labelSalary.Text = "Salary:";
            // 
            // labelHireDate
            // 
            labelHireDate.AutoSize = true;
            labelHireDate.Location = new Point(40, 358);
            labelHireDate.Margin = new Padding(4, 0, 4, 0);
            labelHireDate.Name = "labelHireDate";
            labelHireDate.Size = new Size(76, 20);
            labelHireDate.TabIndex = 19;
            labelHireDate.Text = "Hire Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 453);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 20;
            label2.Text = "Function:";
            // 
            // ManageEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 551);
            Controls.Add(label2);
            Controls.Add(labelHireDate);
            Controls.Add(labelSalary);
            Controls.Add(labelAddress);
            Controls.Add(labelPhone);
            Controls.Add(labelEmail);
            Controls.Add(labelName);
            Controls.Add(labelID);
            Controls.Add(dgvEmployees);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dtpHireDate);
            Controls.Add(txtSalary);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "ManageEmployeeForm";
            Text = "PiStoreOfCloud";
            Load += ManageEmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtSalary;
        private DateTimePicker dtpHireDate;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave; // Biến cho nút Save
        private DataGridView dgvEmployees;
        private Label labelID;
        private Label labelName;
        private Label labelEmail;
        private Label labelPhone;
        private Label labelAddress;
        private Label labelSalary;
        private Label labelHireDate;
        private Label label2;
    }
}
