namespace _522H0083
{
    partial class EditOrder
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
            dgvProducts = new DataGridView();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAddToOrder = new Button();
            btnSaveOrder = new Button();
            lblOrderDetails = new Label();
            dgvOrderItems = new DataGridView();
            numericUpDownQuantity = new NumericUpDown();
            label1 = new Label();
            lblPrice = new Label();
            txtPrice = new TextBox();
            btnRemoveFromOrder = new Button();
            lblOrderID = new Label();
            txtOrderID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(431, 60);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(403, 241);
            dgvProducts.TabIndex = 2;
            dgvProducts.Click += dgvProducts_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(43, 127);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(68, 20);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(168, 129);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 27);
            txtQuantity.TabIndex = 4;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Location = new Point(43, 259);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(100, 42);
            btnAddToOrder.TabIndex = 5;
            btnAddToOrder.Text = "Add";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // btnSaveOrder
            // 
            btnSaveOrder.Location = new Point(288, 259);
            btnSaveOrder.Name = "btnSaveOrder";
            btnSaveOrder.Size = new Size(100, 42);
            btnSaveOrder.TabIndex = 6;
            btnSaveOrder.Text = "Save Order";
            btnSaveOrder.UseVisualStyleBackColor = true;
            btnSaveOrder.Click += btnSaveOrder_Click;
            // 
            // lblOrderDetails
            // 
            lblOrderDetails.AutoSize = true;
            lblOrderDetails.Location = new Point(43, 346);
            lblOrderDetails.Name = "lblOrderDetails";
            lblOrderDetails.Size = new Size(100, 20);
            lblOrderDetails.TabIndex = 7;
            lblOrderDetails.Text = "Order Details:";
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(34, 383);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.Size = new Size(800, 248);
            dgvOrderItems.TabIndex = 8;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(168, 125);
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(130, 27);
            numericUpDownQuantity.TabIndex = 4;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.ValueChanged += numericUpDownQuantity_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 31);
            label1.TabIndex = 14;
            label1.Text = "Edit Order";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(43, 188);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 20);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(168, 181);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(130, 27);
            txtPrice.TabIndex = 16;
            // 
            // btnRemoveFromOrder
            // 
            btnRemoveFromOrder.Location = new Point(168, 259);
            btnRemoveFromOrder.Name = "btnRemoveFromOrder";
            btnRemoveFromOrder.Size = new Size(100, 42);
            btnRemoveFromOrder.TabIndex = 9;
            btnRemoveFromOrder.Text = "Remove";
            btnRemoveFromOrder.UseVisualStyleBackColor = true;
            btnRemoveFromOrder.Click += btnRemoveFromOrder_Click;
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(42, 63);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(69, 20);
            lblOrderID.TabIndex = 18;
            lblOrderID.Text = "Order ID:";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(168, 60);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(130, 27);
            txtOrderID.TabIndex = 17;
            // 
            // EditOrder
            // 
            ClientSize = new Size(865, 643);
            Controls.Add(lblOrderID);
            Controls.Add(txtOrderID);
            Controls.Add(label1);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(dgvOrderItems);
            Controls.Add(lblOrderDetails);
            Controls.Add(btnSaveOrder);
            Controls.Add(btnAddToOrder);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(dgvProducts);
            Controls.Add(btnRemoveFromOrder);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditOrder";
            Text = "PiStoreOfCloud";
            Load += EditOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Button btnRemoveFromOrder;
        private System.Windows.Forms.Label lblOrderDetails;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private Label label1;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblOrderID;
        private TextBox txtOrderID;
    }
}
