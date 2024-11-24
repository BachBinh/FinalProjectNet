namespace _522H0083
{
    partial class ManageOrdersForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtOrderID = new TextBox();
            dtpOrderDate = new DateTimePicker();
            txtTotalPrice = new TextBox();
            dgvOrders = new DataGridView();
            dgvOrderItems = new DataGridView();
            btnViewDetails = new Button();
            btnDeleteOrder = new Button();
            label1 = new Label();
            lblOrderID = new Label();
            lblClientName = new Label();
            lblEmployeeName = new Label();
            lblOrderDate = new Label();
            lblTotalPrice = new Label();
            label2 = new Label();
            btnEdit = new Button();
            btnSave = new Button();
            cbCliName = new ComboBox();
            cbEmpName = new ComboBox();
            btnEItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(179, 74);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(244, 27);
            txtOrderID.TabIndex = 0;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Enabled = false;
            dtpOrderDate.Location = new Point(179, 266);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(244, 27);
            dtpOrderDate.TabIndex = 3;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(179, 331);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(244, 27);
            txtTotalPrice.TabIndex = 4;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(473, 74);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(572, 284);
            dgvOrders.TabIndex = 5;
            dgvOrders.Click += dgvOrders_Click;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(473, 394);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.Size = new Size(572, 158);
            dgvOrderItems.TabIndex = 6;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Location = new Point(179, 501);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(111, 51);
            btnViewDetails.TabIndex = 7;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(30, 503);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(111, 49);
            btnDeleteOrder.TabIndex = 7;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 31);
            label1.TabIndex = 13;
            label1.Text = "Manage Orders";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(30, 81);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(69, 20);
            lblOrderID.TabIndex = 8;
            lblOrderID.Text = "Order ID:";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(30, 143);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(94, 20);
            lblClientName.TabIndex = 9;
            lblClientName.Text = "Client Name:";
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Location = new Point(30, 208);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(122, 20);
            lblEmployeeName.TabIndex = 10;
            lblEmployeeName.Text = "Employee Name:";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(30, 271);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(86, 20);
            lblOrderDate.TabIndex = 11;
            lblOrderDate.Text = "Order Date:";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(30, 334);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(81, 20);
            lblTotalPrice.TabIndex = 12;
            lblTotalPrice.Text = "Total Price:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 422);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 14;
            label2.Text = "Function:";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(179, 408);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 49);
            btnEdit.TabIndex = 15;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(312, 408);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 49);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbCliName
            // 
            cbCliName.FormattingEnabled = true;
            cbCliName.Location = new Point(179, 135);
            cbCliName.Name = "cbCliName";
            cbCliName.Size = new Size(244, 28);
            cbCliName.TabIndex = 17;
            // 
            // cbEmpName
            // 
            cbEmpName.FormattingEnabled = true;
            cbEmpName.Location = new Point(179, 205);
            cbEmpName.Name = "cbEmpName";
            cbEmpName.Size = new Size(244, 28);
            cbEmpName.TabIndex = 18;
            // 
            // btnEItem
            // 
            btnEItem.Location = new Point(312, 501);
            btnEItem.Name = "btnEItem";
            btnEItem.Size = new Size(111, 51);
            btnEItem.TabIndex = 19;
            btnEItem.Text = "Edit Items";
            btnEItem.UseVisualStyleBackColor = true;
            btnEItem.Click += btnEItem_Click;
            // 
            // ManageOrdersForm
            // 
            ClientSize = new Size(1068, 589);
            Controls.Add(btnEItem);
            Controls.Add(cbEmpName);
            Controls.Add(cbCliName);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnViewDetails);
            Controls.Add(dgvOrderItems);
            Controls.Add(dgvOrders);
            Controls.Add(lblTotalPrice);
            Controls.Add(txtTotalPrice);
            Controls.Add(lblOrderDate);
            Controls.Add(dtpOrderDate);
            Controls.Add(lblEmployeeName);
            Controls.Add(lblClientName);
            Controls.Add(lblOrderID);
            Controls.Add(txtOrderID);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ManageOrdersForm";
            Text = "PiStoreOfCloud";
            Load += ManageOrdersForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnDeleteOrder;
        private Label label1;
        private Label lblOrderID;
        private Label lblClientName;
        private Label lblEmployeeName;
        private Label lblOrderDate;
        private Label lblTotalPrice;
        private Label label2;
        private Button btnEdit;
        private Button btnSave;
        private ComboBox cbCliName;
        private ComboBox cbEmpName;
        private Button btnEItem;
    }
}
