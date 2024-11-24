using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _522H0083
{
    partial class ChartForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxChartType; 
        private Button buttonLoadChart; 
        private Chart chart; 

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
            comboBoxChartType = new ComboBox();
            buttonLoadChart = new Button();
            label1 = new Label();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            lblDateRange = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBoxChartType
            // 
            comboBoxChartType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChartType.FormattingEnabled = true;
            comboBoxChartType.Items.AddRange(new object[] { "Number of products sold", "Number of employee orders", "Total spend per customer" });
            comboBoxChartType.Location = new Point(130, 94);
            comboBoxChartType.Margin = new Padding(3, 4, 3, 4);
            comboBoxChartType.Name = "comboBoxChartType";
            comboBoxChartType.Size = new Size(287, 28);
            comboBoxChartType.TabIndex = 0;
            comboBoxChartType.SelectedIndexChanged += comboBoxChartType_SelectedIndexChanged;
            // 
            // buttonLoadChart
            // 
            buttonLoadChart.Location = new Point(497, 118);
            buttonLoadChart.Margin = new Padding(3, 4, 3, 4);
            buttonLoadChart.Name = "buttonLoadChart";
            buttonLoadChart.Size = new Size(130, 47);
            buttonLoadChart.TabIndex = 1;
            buttonLoadChart.Text = "Display a chart";
            buttonLoadChart.UseVisualStyleBackColor = true;
            buttonLoadChart.Click += ButtonLoadChart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(230, 31);
            label1.TabIndex = 14;
            label1.Text = "Chart and Graph";
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(262, 161);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(26, 20);
            lblToDate.TabIndex = 18;
            lblToDate.Text = "to:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(317, 156);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(100, 27);
            dtpToDate.TabIndex = 17;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(130, 154);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(100, 27);
            dtpFromDate.TabIndex = 16;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(12, 161);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(90, 20);
            lblDateRange.TabIndex = 15;
            lblDateRange.Text = "Date Range:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 19;
            label2.Text = "Select: ";
            //
            //chart
            //
            chart = new Chart();
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            chart.Location = new Point(12, 200);
            chart.Size = new Size(660, 350);
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 609);
            Controls.Add(label2);
            Controls.Add(chart);
            Controls.Add(lblToDate);
            Controls.Add(dtpToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(lblDateRange);
            Controls.Add(label1);
            Controls.Add(buttonLoadChart);
            Controls.Add(comboBoxChartType);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChartForm";
            Text = "PiStoreOfCloud";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private DateTimePicker dtpFromDate;
        private Label lblDateRange;
        private Label label2;
    }
}
