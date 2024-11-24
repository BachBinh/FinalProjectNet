using System.Windows.Forms;

namespace _522H0083
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbSearchType;
        private DataGridView dgvResults;
        private Label lblName;
        private Label lblPhone;
        private Label lblDateRange;
        private TextBox txtName;
        private TextBox txtPhone;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Label lblToDate;

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
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbSearchType = new ComboBox();
            dgvResults = new DataGridView();
            lblName = new Label();
            lblPhone = new Label();
            lblDateRange = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(23, 154);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(62, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Enter ID";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(152, 147);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(525, 221);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(128, 51);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbSearchType
            // 
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Items.AddRange(new object[] { "Employee", "Client", "Product", "Order", "Bill" });
            cmbSearchType.Location = new Point(152, 76);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(160, 28);
            cmbSearchType.TabIndex = 3;
            cmbSearchType.SelectedIndexChanged += cmbSearchType_SelectedIndexChanged;
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(22, 312);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(665, 195);
            dgvResults.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(363, 84);
            lblName.Name = "lblName";
            lblName.Size = new Size(94, 20);
            lblName.TabIndex = 5;
            lblName.Text = " Enter Name:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(369, 150);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(91, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Enter Phone:";
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(23, 236);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(90, 20);
            lblDateRange.TabIndex = 7;
            lblDateRange.Text = "Date Range:";
            // 
            // txtName
            // 
            txtName.Location = new Point(482, 77);
            txtName.Name = "txtName";
            txtName.Size = new Size(205, 27);
            txtName.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(482, 147);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(205, 27);
            txtPhone.TabIndex = 9;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(152, 229);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(100, 27);
            dtpFromDate.TabIndex = 10;
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(357, 231);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(100, 27);
            dtpToDate.TabIndex = 11;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(286, 236);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(26, 20);
            lblToDate.TabIndex = 12;
            lblToDate.Text = "to:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 79);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 13;
            label1.Text = "Select object:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(106, 31);
            label2.TabIndex = 14;
            label2.Text = "Search";
            // 
            // SearchForm
            // 
            ClientSize = new Size(717, 540);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblToDate);
            Controls.Add(dtpToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(lblDateRange);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(dgvResults);
            Controls.Add(cmbSearchType);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SearchForm";
            Text = "PiStoreOfCloud";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
    }
}
