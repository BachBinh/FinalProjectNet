namespace _522H0083
{
    partial class GenerateBillForm
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
            dgvOrders = new DataGridView();
            dgvOrderDetails = new DataGridView();
            lblOrderId = new Label();
            txtOrderId = new TextBox();
            lblClientId = new Label();
            txtClientId = new TextBox();
            lblClientName = new Label();
            txtClientName = new TextBox();
            lblEmployeeId = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeName = new Label();
            txtEmployeeName = new TextBox();
            lblOrderDate = new Label();
            txtOrderDate = new TextBox();
            lblTotalPrice = new Label();
            txtTotalPrice = new TextBox();
            btnGenerateBill = new Button();
            btBpdf = new Button();
            label1 = new Label();
            btnGeneB = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(30, 71);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(800, 200);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(30, 471);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 51;
            dgvOrderDetails.Size = new Size(800, 200);
            dgvOrderDetails.TabIndex = 3;
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(30, 324);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(69, 20);
            lblOrderId.TabIndex = 4;
            lblOrderId.Text = "Order ID:";
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(158, 317);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.ReadOnly = true;
            txtOrderId.Size = new Size(100, 27);
            txtOrderId.TabIndex = 5;
            // 
            // lblClientId
            // 
            lblClientId.AutoSize = true;
            lblClientId.Location = new Point(30, 373);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new Size(69, 20);
            lblClientId.TabIndex = 6;
            lblClientId.Text = "Client ID:";
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(158, 366);
            txtClientId.Name = "txtClientId";
            txtClientId.ReadOnly = true;
            txtClientId.Size = new Size(100, 27);
            txtClientId.TabIndex = 7;
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(304, 373);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(94, 20);
            lblClientName.TabIndex = 8;
            lblClientName.Text = "Client Name:";
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(444, 366);
            txtClientName.Name = "txtClientName";
            txtClientName.ReadOnly = true;
            txtClientName.Size = new Size(210, 27);
            txtClientName.TabIndex = 9;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Location = new Point(30, 417);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(97, 20);
            lblEmployeeId.TabIndex = 10;
            lblEmployeeId.Text = "Employee ID:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Location = new Point(158, 417);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(100, 27);
            txtEmployeeId.TabIndex = 11;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Location = new Point(304, 424);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(122, 20);
            lblEmployeeName.TabIndex = 12;
            lblEmployeeName.Text = "Employee Name:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(444, 421);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(210, 27);
            txtEmployeeName.TabIndex = 13;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(304, 324);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(86, 20);
            lblOrderDate.TabIndex = 14;
            lblOrderDate.Text = "Order Date:";
            // 
            // txtOrderDate
            // 
            txtOrderDate.Location = new Point(444, 317);
            txtOrderDate.Name = "txtOrderDate";
            txtOrderDate.ReadOnly = true;
            txtOrderDate.Size = new Size(132, 27);
            txtOrderDate.TabIndex = 15;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(616, 324);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(81, 20);
            lblTotalPrice.TabIndex = 16;
            lblTotalPrice.Text = "Total Price:";
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(730, 317);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(100, 27);
            txtTotalPrice.TabIndex = 17;
            // 
            // btnGenerateBill
            // 
            btnGenerateBill.Location = new Point(128, 699);
            btnGenerateBill.Name = "btnGenerateBill";
            btnGenerateBill.Size = new Size(130, 54);
            btnGenerateBill.TabIndex = 18;
            btnGenerateBill.Text = "View a bill";
            btnGenerateBill.UseVisualStyleBackColor = true;
            btnGenerateBill.Click += btnGenerateBill_Click;
            // 
            // btBpdf
            // 
            btBpdf.Location = new Point(557, 699);
            btBpdf.Name = "btBpdf";
            btBpdf.Size = new Size(171, 54);
            btBpdf.TabIndex = 19;
            btBpdf.Text = "Print a PDF ";
            btBpdf.UseVisualStyleBackColor = true;
            btBpdf.Click += btBpdf_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(183, 31);
            label1.TabIndex = 20;
            label1.Text = "Generate Bill";
            // 
            // btnGeneB
            // 
            btnGeneB.Location = new Point(342, 699);
            btnGeneB.Name = "btnGeneB";
            btnGeneB.Size = new Size(130, 54);
            btnGeneB.TabIndex = 21;
            btnGeneB.Text = "Generate bill";
            btnGeneB.UseVisualStyleBackColor = true;
            btnGeneB.Click += btnGeneB_Click;
            // 
            // GenerateBillForm
            // 
            ClientSize = new Size(865, 770);
            Controls.Add(btnGeneB);
            Controls.Add(label1);
            Controls.Add(btBpdf);
            Controls.Add(dgvOrderDetails);
            Controls.Add(dgvOrders);
            Controls.Add(lblOrderId);
            Controls.Add(txtOrderId);
            Controls.Add(lblClientId);
            Controls.Add(txtClientId);
            Controls.Add(lblClientName);
            Controls.Add(txtClientName);
            Controls.Add(lblEmployeeId);
            Controls.Add(txtEmployeeId);
            Controls.Add(lblEmployeeName);
            Controls.Add(txtEmployeeName);
            Controls.Add(lblOrderDate);
            Controls.Add(txtOrderDate);
            Controls.Add(lblTotalPrice);
            Controls.Add(txtTotalPrice);
            Controls.Add(btnGenerateBill);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GenerateBillForm";
            Text = "PiStoreOfCloud";
            Load += GenerateBillForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnGenerateBill;
        private Button btBpdf;
        private Label label1;
        private Button btnGeneB;
    }
}
