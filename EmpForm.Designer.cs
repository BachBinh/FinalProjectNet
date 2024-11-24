namespace _522H0083
{
    partial class EmpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpForm));
            sidebarPanel = new Panel();
            btnChGr = new Button();
            btnExportToCSV = new Button();
            btnSearch = new Button();
            btnGenerateBill = new Button();
            btnPlaceOrder = new Button();
            btnManageOrder = new Button();
            btnManageProducts = new Button();
            btnManageClient = new Button();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(28, 192, 169);
            sidebarPanel.Controls.Add(btnChGr);
            sidebarPanel.Controls.Add(btnExportToCSV);
            sidebarPanel.Controls.Add(btnSearch);
            sidebarPanel.Controls.Add(btnGenerateBill);
            sidebarPanel.Controls.Add(btnPlaceOrder);
            sidebarPanel.Controls.Add(btnManageOrder);
            sidebarPanel.Controls.Add(btnManageProducts);
            sidebarPanel.Controls.Add(btnManageClient);
            sidebarPanel.Location = new Point(0, -1);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(243, 451);
            sidebarPanel.TabIndex = 0;
            // 
            // btnChGr
            // 
            btnChGr.BackColor = Color.FromArgb(28, 192, 169);
            btnChGr.Dock = DockStyle.Top;
            btnChGr.FlatAppearance.BorderSize = 0;
            btnChGr.FlatStyle = FlatStyle.Flat;
            btnChGr.Font = new Font("Segoe UI", 10.8F);
            btnChGr.ForeColor = Color.White;
            btnChGr.ImageAlign = ContentAlignment.MiddleLeft;
            btnChGr.Location = new Point(0, 280);
            btnChGr.Name = "btnChGr";
            btnChGr.Size = new Size(243, 40);
            btnChGr.TabIndex = 8;
            btnChGr.Text = "Chart and Graph";
            btnChGr.UseVisualStyleBackColor = false;
            btnChGr.Click += btnChGr_Click;
            // 
            // btnExportToCSV
            // 
            btnExportToCSV.BackColor = Color.FromArgb(28, 192, 169);
            btnExportToCSV.Dock = DockStyle.Top;
            btnExportToCSV.FlatAppearance.BorderSize = 0;
            btnExportToCSV.FlatStyle = FlatStyle.Flat;
            btnExportToCSV.Font = new Font("Segoe UI", 10.8F);
            btnExportToCSV.ForeColor = Color.White;
            btnExportToCSV.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportToCSV.Location = new Point(0, 240);
            btnExportToCSV.Name = "btnExportToCSV";
            btnExportToCSV.Size = new Size(243, 40);
            btnExportToCSV.TabIndex = 6;
            btnExportToCSV.Text = "Export to CSV";
            btnExportToCSV.UseVisualStyleBackColor = false;
            btnExportToCSV.Click += btnExportToCSV_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(28, 192, 169);
            btnSearch.Dock = DockStyle.Top;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10.8F);
            btnSearch.ForeColor = Color.White;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(0, 200);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(243, 40);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnGenerateBill
            // 
            btnGenerateBill.BackColor = Color.FromArgb(28, 192, 169);
            btnGenerateBill.Dock = DockStyle.Top;
            btnGenerateBill.FlatAppearance.BorderSize = 0;
            btnGenerateBill.FlatStyle = FlatStyle.Flat;
            btnGenerateBill.Font = new Font("Segoe UI", 10.8F);
            btnGenerateBill.ForeColor = Color.White;
            btnGenerateBill.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenerateBill.Location = new Point(0, 160);
            btnGenerateBill.Name = "btnGenerateBill";
            btnGenerateBill.Size = new Size(243, 40);
            btnGenerateBill.TabIndex = 5;
            btnGenerateBill.Text = "Generate Bill";
            btnGenerateBill.UseVisualStyleBackColor = false;
            btnGenerateBill.Click += btnGenerateBill_Click;
            // 
            // btnPlaceOrder
            // 
            btnPlaceOrder.BackColor = Color.FromArgb(28, 192, 169);
            btnPlaceOrder.Dock = DockStyle.Top;
            btnPlaceOrder.FlatAppearance.BorderSize = 0;
            btnPlaceOrder.FlatStyle = FlatStyle.Flat;
            btnPlaceOrder.Font = new Font("Segoe UI", 10.8F);
            btnPlaceOrder.ForeColor = Color.White;
            btnPlaceOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlaceOrder.Location = new Point(0, 120);
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new Size(243, 40);
            btnPlaceOrder.TabIndex = 4;
            btnPlaceOrder.Text = "Place Order";
            btnPlaceOrder.UseVisualStyleBackColor = false;
            btnPlaceOrder.Click += btnPlaceOrder_Click;
            // 
            // btnManageOrder
            // 
            btnManageOrder.BackColor = Color.FromArgb(28, 192, 169);
            btnManageOrder.Dock = DockStyle.Top;
            btnManageOrder.FlatAppearance.BorderSize = 0;
            btnManageOrder.FlatStyle = FlatStyle.Flat;
            btnManageOrder.Font = new Font("Segoe UI", 10.8F);
            btnManageOrder.ForeColor = Color.White;
            btnManageOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageOrder.Location = new Point(0, 80);
            btnManageOrder.Name = "btnManageOrder";
            btnManageOrder.Size = new Size(243, 40);
            btnManageOrder.TabIndex = 3;
            btnManageOrder.Text = "Manage Order";
            btnManageOrder.UseVisualStyleBackColor = false;
            btnManageOrder.Click += btnManageOrder_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.FromArgb(28, 192, 169);
            btnManageProducts.Dock = DockStyle.Top;
            btnManageProducts.FlatAppearance.BorderSize = 0;
            btnManageProducts.FlatStyle = FlatStyle.Flat;
            btnManageProducts.Font = new Font("Segoe UI", 10.8F);
            btnManageProducts.ForeColor = Color.White;
            btnManageProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageProducts.Location = new Point(0, 40);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(243, 40);
            btnManageProducts.TabIndex = 2;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // btnManageClient
            // 
            btnManageClient.BackColor = Color.FromArgb(28, 192, 169);
            btnManageClient.Dock = DockStyle.Top;
            btnManageClient.FlatAppearance.BorderSize = 0;
            btnManageClient.FlatStyle = FlatStyle.Flat;
            btnManageClient.Font = new Font("Segoe UI", 10.8F);
            btnManageClient.ForeColor = Color.White;
            btnManageClient.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageClient.Location = new Point(0, 0);
            btnManageClient.Name = "btnManageClient";
            btnManageClient.Size = new Size(243, 40);
            btnManageClient.TabIndex = 1;
            btnManageClient.Text = "Manage Client";
            btnManageClient.UseVisualStyleBackColor = false;
            btnManageClient.Click += btnManageClient_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(530, 199);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 251);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Script", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(446, 39);
            label5.Name = "label5";
            label5.Size = new Size(320, 57);
            label5.TabIndex = 9;
            label5.Text = "Have a nice day";
            label5.Click += label5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(260, 39);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(272, 280);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // EmpForm
            // 
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(pictureBox2);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "EmpForm";
            Text = "PiStoreOfCloud";
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnManageClient;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageOrder;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.Button btnSearch;
        private Button btnChGr;
        private PictureBox pictureBox1;
        private Label label5;
        private PictureBox pictureBox2;
    }
}
