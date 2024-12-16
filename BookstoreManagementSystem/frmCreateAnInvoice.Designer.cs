namespace BookstoreManagementSystem
{
    partial class frmCreateAnInvoice
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
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.CustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDateApp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.orderTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cusID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvBook = new System.Windows.Forms.ListView();
            this.BookID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BookName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GenreID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.selectedBookId = new System.Windows.Forms.TextBox();
            this.updateAmount = new System.Windows.Forms.Button();
            this.selectedBookName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectedBookPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.OrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDcustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvOrderDetail = new System.Windows.Forms.ListView();
            this.OrderDetailID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDbook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCustomer
            // 
            this.lvCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CustomerID,
            this.CustomerName});
            this.lvCustomer.HideSelection = false;
            this.lvCustomer.LabelEdit = true;
            this.lvCustomer.Location = new System.Drawing.Point(8, 21);
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.Size = new System.Drawing.Size(321, 175);
            this.lvCustomer.TabIndex = 0;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.View = System.Windows.Forms.View.Details;
            this.lvCustomer.SelectedIndexChanged += new System.EventHandler(this.lvOrder_SelectedIndexChanged_1);
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "CustomerID";
            this.CustomerID.Width = 90;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "CustomerName";
            this.CustomerName.Width = 178;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpDateApp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.orderTotal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cusID);
            this.groupBox2.Controls.Add(this.txtOrderID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 222);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add invoice";
            // 
            // dtpDateApp
            // 
            this.dtpDateApp.Location = new System.Drawing.Point(131, 131);
            this.dtpDateApp.Name = "dtpDateApp";
            this.dtpDateApp.Size = new System.Drawing.Size(161, 22);
            this.dtpDateApp.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Date:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(131, 92);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(230, 22);
            this.txtCustomerName.TabIndex = 3;
            // 
            // orderTotal
            // 
            this.orderTotal.AutoSize = true;
            this.orderTotal.Location = new System.Drawing.Point(128, 176);
            this.orderTotal.Name = "orderTotal";
            this.orderTotal.Size = new System.Drawing.Size(14, 16);
            this.orderTotal.TabIndex = 2;
            this.orderTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer Name:";
            // 
            // cusID
            // 
            this.cusID.Location = new System.Drawing.Point(133, 48);
            this.cusID.Name = "cusID";
            this.cusID.Size = new System.Drawing.Size(230, 22);
            this.cusID.TabIndex = 1;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(134, 15);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(230, 22);
            this.txtOrderID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Order ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvBook);
            this.groupBox3.Location = new System.Drawing.Point(444, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 304);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select book";
            // 
            // lvBook
            // 
            this.lvBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BookID,
            this.BookName,
            this.Author,
            this.GenreID,
            this.Price,
            this.Stock,
            this.Amount});
            this.lvBook.HideSelection = false;
            this.lvBook.Location = new System.Drawing.Point(6, 21);
            this.lvBook.Name = "lvBook";
            this.lvBook.Size = new System.Drawing.Size(905, 269);
            this.lvBook.TabIndex = 0;
            this.lvBook.UseCompatibleStateImageBehavior = false;
            this.lvBook.View = System.Windows.Forms.View.Details;
            this.lvBook.SelectedIndexChanged += new System.EventHandler(this.lvBook_SelectedIndexChanged);
            // 
            // BookID
            // 
            this.BookID.Text = "ID";
            // 
            // BookName
            // 
            this.BookName.Text = "Name";
            this.BookName.Width = 160;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 88;
            // 
            // GenreID
            // 
            this.GenreID.Text = "GenreID";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 100;
            // 
            // Stock
            // 
            this.Stock.Text = "Stock";
            this.Stock.Width = 100;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 208;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(107, 21);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(185, 22);
            this.txtQuantity.TabIndex = 9;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(450, 563);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(206, 50);
            this.btnInvoice.TabIndex = 10;
            this.btnInvoice.Text = "Complete the invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "BookID";
            // 
            // selectedBookId
            // 
            this.selectedBookId.Location = new System.Drawing.Point(106, 53);
            this.selectedBookId.Name = "selectedBookId";
            this.selectedBookId.Size = new System.Drawing.Size(185, 22);
            this.selectedBookId.TabIndex = 9;
            // 
            // updateAmount
            // 
            this.updateAmount.Location = new System.Drawing.Point(316, 49);
            this.updateAmount.Name = "updateAmount";
            this.updateAmount.Size = new System.Drawing.Size(75, 23);
            this.updateAmount.TabIndex = 12;
            this.updateAmount.Text = "Update Invoice Amount";
            this.updateAmount.UseVisualStyleBackColor = true;
            this.updateAmount.Click += new System.EventHandler(this.updateAmount_Click);
            // 
            // selectedBookName
            // 
            this.selectedBookName.Location = new System.Drawing.Point(107, 81);
            this.selectedBookName.Name = "selectedBookName";
            this.selectedBookName.Size = new System.Drawing.Size(185, 22);
            this.selectedBookName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Book Name";
            // 
            // selectedBookPrice
            // 
            this.selectedBookPrice.Location = new System.Drawing.Point(106, 109);
            this.selectedBookPrice.Name = "selectedBookPrice";
            this.selectedBookPrice.Size = new System.Drawing.Size(185, 22);
            this.selectedBookPrice.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Book Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCustomer);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 212);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table Customers";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtQuantity);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.updateAmount);
            this.groupBox4.Controls.Add(this.selectedBookId);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.selectedBookName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.selectedBookPrice);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(13, 468);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(410, 154);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lvOrders);
            this.groupBox5.Location = new System.Drawing.Point(383, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(479, 224);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Order";
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderID,
            this.IDcustomer,
            this.OrderDate,
            this.TotalAmount});
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(7, 22);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(457, 190);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.lvOrders_SelectedIndexChanged);
            // 
            // OrderID
            // 
            this.OrderID.Text = "ID";
            // 
            // IDcustomer
            // 
            this.IDcustomer.Text = "CustomerID";
            this.IDcustomer.Width = 89;
            // 
            // OrderDate
            // 
            this.OrderDate.Text = "OrderDate";
            this.OrderDate.Width = 100;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Text = "TotalAmount";
            this.TotalAmount.Width = 120;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvOrderDetail);
            this.groupBox6.Location = new System.Drawing.Point(853, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(502, 224);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Order Details";
            // 
            // lvOrderDetail
            // 
            this.lvOrderDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderDetailID,
            this.IDbook,
            this.Quantity,
            this.Total});
            this.lvOrderDetail.HideSelection = false;
            this.lvOrderDetail.Location = new System.Drawing.Point(6, 21);
            this.lvOrderDetail.Name = "lvOrderDetail";
            this.lvOrderDetail.Size = new System.Drawing.Size(490, 190);
            this.lvOrderDetail.TabIndex = 1;
            this.lvOrderDetail.UseCompatibleStateImageBehavior = false;
            this.lvOrderDetail.View = System.Windows.Forms.View.Details;
            // 
            // OrderDetailID
            // 
            this.OrderDetailID.Text = "ID";
            // 
            // IDbook
            // 
            this.IDbook.Text = "BookID";
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 100;
            // 
            // Total
            // 
            this.Total.Text = "Price";
            this.Total.Width = 100;
            // 
            // frmCreateAnInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 634);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCreateAnInvoice";
            this.Text = "frmStaffDashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCreateAnInvoice_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpDateApp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvBook;
        private System.Windows.Forms.ColumnHeader BookID;
        private System.Windows.Forms.ColumnHeader BookName;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader GenreID;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox selectedBookId;
        private System.Windows.Forms.Button updateAmount;
        private System.Windows.Forms.TextBox selectedBookName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox selectedBookPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cusID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label orderTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader OrderID;
        private System.Windows.Forms.ColumnHeader IDcustomer;
        private System.Windows.Forms.ColumnHeader OrderDate;
        private System.Windows.Forms.ColumnHeader TotalAmount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lvOrderDetail;
        private System.Windows.Forms.ColumnHeader OrderDetailID;
        private System.Windows.Forms.ColumnHeader IDbook;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Total;
    }
}