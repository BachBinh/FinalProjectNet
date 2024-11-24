using System;
using System.Drawing;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            ManageEmployeeForm manageEmployeeForm = new ManageEmployeeForm();
            manageEmployeeForm.Show();
        }

        private void btnManageClient_Click(object sender, EventArgs e)
        {
            ManageClientForm manageClientForm = new ManageClientForm();
            manageClientForm.Show();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ManageProductsForm manageProductsForm = new ManageProductsForm();
            manageProductsForm.Show();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            ManageOrdersForm manageOrdersForm = new ManageOrdersForm();
            manageOrdersForm.Show();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PlaceOrderForm placeOrderForm = new PlaceOrderForm();
            placeOrderForm.Show();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            GenerateBillForm generateBillForm = new GenerateBillForm();
            generateBillForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            ExportToCSVForm exportToCSVForm = new ExportToCSVForm();
            exportToCSVForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChGr_Click(object sender, EventArgs e)
        {
            ChartForm ChGrForm = new ChartForm();
            ChGrForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
