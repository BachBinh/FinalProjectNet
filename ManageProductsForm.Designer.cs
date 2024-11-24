namespace _522H0083
{
    partial class ManageProductsForm
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
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new NumericUpDown();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            dgvProducts = new DataGridView();
            labelID = new Label();
            labelName = new Label();
            labelDescription = new Label();
            labelPrice = new Label();
            labelQuantity = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(241, 31);
            label1.TabIndex = 0;
            label1.Text = "Manage Products";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(160, 96);
            txtID.Margin = new Padding(3, 4, 3, 4);
            txtID.Name = "txtID";
            txtID.Size = new Size(265, 27);
            txtID.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 154);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(265, 27);
            txtName.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(160, 211);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(265, 80);
            txtDescription.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(160, 310);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(265, 27);
            txtPrice.TabIndex = 4;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(160, 368);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(265, 27);
            txtQuantity.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(160, 428);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 44);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(325, 428);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 44);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(160, 495);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 44);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(325, 495);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 44);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(462, 96);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 24;
            dgvProducts.Size = new Size(500, 443);
            dgvProducts.TabIndex = 10;
            dgvProducts.Click += dgvProducts_Click;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(24, 100);
            labelID.Name = "labelID";
            labelID.Size = new Size(27, 20);
            labelID.TabIndex = 11;
            labelID.Text = "ID:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(24, 158);
            labelName.Name = "labelName";
            labelName.Size = new Size(52, 20);
            labelName.TabIndex = 12;
            labelName.Text = "Name:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(24, 215);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 20);
            labelDescription.TabIndex = 13;
            labelDescription.Text = "Description:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(24, 313);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(44, 20);
            labelPrice.TabIndex = 14;
            labelPrice.Text = "Price:";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(24, 371);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(68, 20);
            labelQuantity.TabIndex = 15;
            labelQuantity.Text = "Quantity:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 464);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 16;
            label2.Text = "Function:";
            // 
            // ManageProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 590);
            Controls.Add(label2);
            Controls.Add(labelQuantity);
            Controls.Add(labelPrice);
            Controls.Add(labelDescription);
            Controls.Add(labelName);
            Controls.Add(labelID);
            Controls.Add(dgvProducts);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ManageProductsForm";
            Text = "PiStoreOfCloud";
            Load += ManageProductsForm_Load;
            ((System.ComponentModel.ISupportInitialize)txtQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private NumericUpDown txtQuantity;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private DataGridView dgvProducts;
        private Label labelID;
        private Label labelName;
        private Label labelDescription;
        private Label labelPrice;
        private Label labelQuantity;
        private Label label2;
    }
}
