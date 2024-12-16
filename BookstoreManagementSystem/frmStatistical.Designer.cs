namespace BookstoreManagementSystem
{
    partial class frmStatistical
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatistical));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnTotalCustomer = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTtCustomerNum = new System.Windows.Forms.Label();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.pnTotalProduct = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTtProductNum = new System.Windows.Forms.Label();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.plTotalOrder = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTtOrderNum = new System.Windows.Forms.Label();
            this.lblTotalOrder = new System.Windows.Forms.Label();
            this.pnTotalRevenue = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblInThisMonth = new System.Windows.Forms.Label();
            this.lblRevenueMoney = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnTotalCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.pnTotalProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.plTotalOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnTotalRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(14, 216);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Total Revenue";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Total Orders";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Total Customers";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Total Products";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(961, 380);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // pnTotalCustomer
            // 
            this.pnTotalCustomer.BackColor = System.Drawing.Color.White;
            this.pnTotalCustomer.Controls.Add(this.pictureBox7);
            this.pnTotalCustomer.Controls.Add(this.label7);
            this.pnTotalCustomer.Controls.Add(this.lblTtCustomerNum);
            this.pnTotalCustomer.Controls.Add(this.lblTotalCustomer);
            this.pnTotalCustomer.Location = new System.Drawing.Point(773, 13);
            this.pnTotalCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.pnTotalCustomer.Name = "pnTotalCustomer";
            this.pnTotalCustomer.Size = new System.Drawing.Size(201, 167);
            this.pnTotalCustomer.TabIndex = 8;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(11, 12);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 31);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(9, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "In this month";
            // 
            // lblTtCustomerNum
            // 
            this.lblTtCustomerNum.AutoSize = true;
            this.lblTtCustomerNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTtCustomerNum.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTtCustomerNum.Location = new System.Drawing.Point(5, 101);
            this.lblTtCustomerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTtCustomerNum.Name = "lblTtCustomerNum";
            this.lblTtCustomerNum.Size = new System.Drawing.Size(77, 37);
            this.lblTtCustomerNum.TabIndex = 1;
            this.lblTtCustomerNum.Text = "0000";
            // 
            // lblTotalCustomer
            // 
            this.lblTotalCustomer.AutoSize = true;
            this.lblTotalCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomer.Location = new System.Drawing.Point(8, 81);
            this.lblTotalCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            this.lblTotalCustomer.Size = new System.Drawing.Size(87, 15);
            this.lblTotalCustomer.TabIndex = 0;
            this.lblTotalCustomer.Text = "Total Customer";
            // 
            // pnTotalProduct
            // 
            this.pnTotalProduct.BackColor = System.Drawing.Color.White;
            this.pnTotalProduct.Controls.Add(this.pictureBox5);
            this.pnTotalProduct.Controls.Add(this.label4);
            this.pnTotalProduct.Controls.Add(this.lblTtProductNum);
            this.pnTotalProduct.Controls.Add(this.lblTotalProduct);
            this.pnTotalProduct.Location = new System.Drawing.Point(520, 13);
            this.pnTotalProduct.Margin = new System.Windows.Forms.Padding(4);
            this.pnTotalProduct.Name = "pnTotalProduct";
            this.pnTotalProduct.Size = new System.Drawing.Size(201, 167);
            this.pnTotalProduct.TabIndex = 9;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(11, 12);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 31);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "In this month";
            // 
            // lblTtProductNum
            // 
            this.lblTtProductNum.AutoSize = true;
            this.lblTtProductNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTtProductNum.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTtProductNum.Location = new System.Drawing.Point(5, 101);
            this.lblTtProductNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTtProductNum.Name = "lblTtProductNum";
            this.lblTtProductNum.Size = new System.Drawing.Size(100, 37);
            this.lblTtProductNum.TabIndex = 1;
            this.lblTtProductNum.Text = "000.00";
            // 
            // lblTotalProduct
            // 
            this.lblTotalProduct.AutoSize = true;
            this.lblTotalProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.lblTotalProduct.Location = new System.Drawing.Point(8, 81);
            this.lblTotalProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProduct.Name = "lblTotalProduct";
            this.lblTotalProduct.Size = new System.Drawing.Size(78, 15);
            this.lblTotalProduct.TabIndex = 0;
            this.lblTotalProduct.Text = "Total Product";
            // 
            // plTotalOrder
            // 
            this.plTotalOrder.BackColor = System.Drawing.Color.White;
            this.plTotalOrder.Controls.Add(this.pictureBox3);
            this.plTotalOrder.Controls.Add(this.label1);
            this.plTotalOrder.Controls.Add(this.lblTtOrderNum);
            this.plTotalOrder.Controls.Add(this.lblTotalOrder);
            this.plTotalOrder.Location = new System.Drawing.Point(266, 13);
            this.plTotalOrder.Margin = new System.Windows.Forms.Padding(4);
            this.plTotalOrder.Name = "plTotalOrder";
            this.plTotalOrder.Size = new System.Drawing.Size(201, 167);
            this.plTotalOrder.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(11, 12);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 31);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(9, 143);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "In this month";
            // 
            // lblTtOrderNum
            // 
            this.lblTtOrderNum.AutoSize = true;
            this.lblTtOrderNum.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTtOrderNum.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTtOrderNum.Location = new System.Drawing.Point(5, 101);
            this.lblTtOrderNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTtOrderNum.Name = "lblTtOrderNum";
            this.lblTtOrderNum.Size = new System.Drawing.Size(100, 37);
            this.lblTtOrderNum.TabIndex = 1;
            this.lblTtOrderNum.Text = "000.00";
            // 
            // lblTotalOrder
            // 
            this.lblTotalOrder.AutoSize = true;
            this.lblTotalOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrder.Location = new System.Drawing.Point(8, 81);
            this.lblTotalOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOrder.Name = "lblTotalOrder";
            this.lblTotalOrder.Size = new System.Drawing.Size(66, 15);
            this.lblTotalOrder.TabIndex = 0;
            this.lblTotalOrder.Text = "Total Order";
            // 
            // pnTotalRevenue
            // 
            this.pnTotalRevenue.BackColor = System.Drawing.Color.White;
            this.pnTotalRevenue.Controls.Add(this.pictureBox2);
            this.pnTotalRevenue.Controls.Add(this.lblInThisMonth);
            this.pnTotalRevenue.Controls.Add(this.lblRevenueMoney);
            this.pnTotalRevenue.Controls.Add(this.lblRevenue);
            this.pnTotalRevenue.Location = new System.Drawing.Point(13, 13);
            this.pnTotalRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.pnTotalRevenue.Name = "pnTotalRevenue";
            this.pnTotalRevenue.Size = new System.Drawing.Size(201, 167);
            this.pnTotalRevenue.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 12);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 31);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lblInThisMonth
            // 
            this.lblInThisMonth.AutoSize = true;
            this.lblInThisMonth.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInThisMonth.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInThisMonth.Location = new System.Drawing.Point(9, 143);
            this.lblInThisMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInThisMonth.Name = "lblInThisMonth";
            this.lblInThisMonth.Size = new System.Drawing.Size(88, 17);
            this.lblInThisMonth.TabIndex = 3;
            this.lblInThisMonth.Text = "In this month";
            // 
            // lblRevenueMoney
            // 
            this.lblRevenueMoney.AutoSize = true;
            this.lblRevenueMoney.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueMoney.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRevenueMoney.Location = new System.Drawing.Point(4, 101);
            this.lblRevenueMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueMoney.Name = "lblRevenueMoney";
            this.lblRevenueMoney.Size = new System.Drawing.Size(100, 37);
            this.lblRevenueMoney.TabIndex = 1;
            this.lblRevenueMoney.Text = "000.00";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.Location = new System.Drawing.Point(8, 81);
            this.lblRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(81, 15);
            this.lblRevenue.TabIndex = 0;
            this.lblRevenue.Text = "Total Revenue";
            // 
            // frmStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 606);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pnTotalCustomer);
            this.Controls.Add(this.pnTotalProduct);
            this.Controls.Add(this.plTotalOrder);
            this.Controls.Add(this.pnTotalRevenue);
            this.Name = "frmStatistical";
            this.Text = "frmStatistical";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStatistical_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnTotalCustomer.ResumeLayout(false);
            this.pnTotalCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.pnTotalProduct.ResumeLayout(false);
            this.pnTotalProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.plTotalOrder.ResumeLayout(false);
            this.plTotalOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnTotalRevenue.ResumeLayout(false);
            this.pnTotalRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnTotalCustomer;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTtCustomerNum;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.Panel pnTotalProduct;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTtProductNum;
        private System.Windows.Forms.Label lblTotalProduct;
        private System.Windows.Forms.Panel plTotalOrder;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTtOrderNum;
        private System.Windows.Forms.Label lblTotalOrder;
        private System.Windows.Forms.Panel pnTotalRevenue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblInThisMonth;
        private System.Windows.Forms.Label lblRevenueMoney;
        private System.Windows.Forms.Label lblRevenue;
    }
}