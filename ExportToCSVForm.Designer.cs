using System.Windows.Forms;

namespace _522H0083
{
    partial class ExportToCSVForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSearch;
        private ComboBox cmbSearchType;
        private ComboBox cmbPriceRange;
        private DataGridView dgvResults;
        private Label lblDateRange;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Label lblToDate;
        private ToolTip toolTip;

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
            components = new System.ComponentModel.Container();
            btnSearch = new Button();
            cmbSearchType = new ComboBox();
            cmbPriceRange = new ComboBox();
            dgvResults = new DataGridView();
            lblDateRange = new Label();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            label1 = new Label();
            label2 = new Label();
            btnExportToCSV = new Button();
            label3 = new Label();
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(173, 189);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(107, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "View";
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
            cmbSearchType.Size = new Size(128, 28);
            cmbSearchType.TabIndex = 3;
            cmbSearchType.SelectedIndexChanged += cmbSearchType_SelectedIndexChanged;
            // 
            // cmbPriceRange
            // 
            cmbPriceRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriceRange.FormattingEnabled = true;
            cmbPriceRange.Items.AddRange(new object[] { "0 - 100,000", "100,000 - 500,000", "500,000 - 1,000,000", "Larger than 1,000,000" });
            cmbPriceRange.Location = new Point(152, 119);
            cmbPriceRange.Name = "cmbPriceRange";
            cmbPriceRange.Size = new Size(180, 28);
            cmbPriceRange.TabIndex = 5;
            toolTip.SetToolTip(cmbPriceRange, "For Client: Bill Amount\nFor Employee: Salary\nFor Bill, Order: Total amount\nFor Product: Price");
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(22, 250);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(639, 257);
            dgvResults.TabIndex = 4;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(370, 78);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(90, 20);
            lblDateRange.TabIndex = 7;
            lblDateRange.Text = "Date Range:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(508, 76);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(100, 27);
            dtpFromDate.TabIndex = 10;
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(508, 120);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(100, 27);
            dtpToDate.TabIndex = 11;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(434, 122);
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
            label2.Size = new Size(198, 31);
            label2.TabIndex = 14;
            label2.Text = "Export to CSV";
            // 
            // btnExportToCSV
            // 
            btnExportToCSV.Location = new Point(336, 189);
            btnExportToCSV.Name = "btnExportToCSV";
            btnExportToCSV.Size = new Size(138, 35);
            btnExportToCSV.TabIndex = 15;
            btnExportToCSV.Text = "Export to CSV";
            btnExportToCSV.UseVisualStyleBackColor = true;
            btnExportToCSV.Click += btnExportToCSV_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 123);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 16;
            label3.Text = "Select amount:";
            // 
            // ExportToCSVForm
            // 
            ClientSize = new Size(683, 540);
            Controls.Add(label3);
            Controls.Add(btnExportToCSV);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblToDate);
            Controls.Add(dtpToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(lblDateRange);
            Controls.Add(dgvResults);
            Controls.Add(cmbSearchType);
            Controls.Add(cmbPriceRange);
            Controls.Add(btnSearch);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ExportToCSVForm";
            Text = "PiStoreOfCloud";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Button btnExportToCSV;
        private Label label3;
    }
}
