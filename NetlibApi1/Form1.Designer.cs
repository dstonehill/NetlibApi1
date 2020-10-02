namespace NetlibApi1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.butAddress3 = new System.Windows.Forms.Button();
            this.txtNewCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCustInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAcctID = new System.Windows.Forms.TextBox();
            this.lstLicenses = new System.Windows.Forms.ListBox();
            this.btnLicenses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 65);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "API - Create Customer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 345);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "SQL - Get Customers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstCustomers
            // 
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 20;
            this.lstCustomers.Location = new System.Drawing.Point(49, 403);
            this.lstCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(670, 144);
            this.lstCustomers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 868);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "New AddressLine3";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(214, 865);
            this.txtAddressLine3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(290, 26);
            this.txtAddressLine3.TabIndex = 4;
            // 
            // butAddress3
            // 
            this.butAddress3.Location = new System.Drawing.Point(543, 868);
            this.butAddress3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butAddress3.Name = "butAddress3";
            this.butAddress3.Size = new System.Drawing.Size(222, 31);
            this.butAddress3.TabIndex = 5;
            this.butAddress3.Text = "Update Address3";
            this.butAddress3.UseVisualStyleBackColor = true;
            this.butAddress3.Click += new System.EventHandler(this.butAddress3_Click);
            // 
            // txtNewCustomer
            // 
            this.txtNewCustomer.Location = new System.Drawing.Point(214, 69);
            this.txtNewCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewCustomer.Name = "txtNewCustomer";
            this.txtNewCustomer.Size = new System.Drawing.Size(290, 26);
            this.txtNewCustomer.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "New Customer Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Customer ID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(214, 128);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(290, 26);
            this.txtSearchCustomer.TabIndex = 9;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(543, 124);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(222, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "API - Search Customer";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustInfo
            // 
            this.txtCustInfo.Location = new System.Drawing.Point(49, 181);
            this.txtCustInfo.Multiline = true;
            this.txtCustInfo.Name = "txtCustInfo";
            this.txtCustInfo.Size = new System.Drawing.Size(671, 129);
            this.txtCustInfo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 630);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Account ID (SQL)";
            // 
            // txtAcctID
            // 
            this.txtAcctID.Location = new System.Drawing.Point(214, 630);
            this.txtAcctID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAcctID.Name = "txtAcctID";
            this.txtAcctID.Size = new System.Drawing.Size(290, 26);
            this.txtAcctID.TabIndex = 13;
            // 
            // lstLicenses
            // 
            this.lstLicenses.FormattingEnabled = true;
            this.lstLicenses.ItemHeight = 20;
            this.lstLicenses.Location = new System.Drawing.Point(50, 671);
            this.lstLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstLicenses.Name = "lstLicenses";
            this.lstLicenses.Size = new System.Drawing.Size(670, 144);
            this.lstLicenses.TabIndex = 15;
            // 
            // btnLicenses
            // 
            this.btnLicenses.Location = new System.Drawing.Point(530, 626);
            this.btnLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLicenses.Name = "btnLicenses";
            this.btnLicenses.Size = new System.Drawing.Size(189, 35);
            this.btnLicenses.TabIndex = 16;
            this.btnLicenses.Text = "SQL - Get Licenses";
            this.btnLicenses.UseVisualStyleBackColor = true;
            this.btnLicenses.Click += new System.EventHandler(this.btnLicenses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 954);
            this.Controls.Add(this.btnLicenses);
            this.Controls.Add(this.lstLicenses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAcctID);
            this.Controls.Add(this.txtCustInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewCustomer);
            this.Controls.Add(this.butAddress3);
            this.Controls.Add(this.txtAddressLine3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCustomers);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Netlib API";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Button butAddress3;
        private System.Windows.Forms.TextBox txtNewCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAcctID;
        private System.Windows.Forms.ListBox lstLicenses;
        private System.Windows.Forms.Button btnLicenses;
    }
}

