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
            this.txtLicInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchLicense = new System.Windows.Forms.TextBox();
            this.btnSearchLic = new System.Windows.Forms.Button();
            this.btnGetAccts = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioRange = new System.Windows.Forms.RadioButton();
            this.radioSingle = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.txtClientID2 = new System.Windows.Forms.TextBox();
            this.txtClientID1 = new System.Windows.Forms.TextBox();
            this.labelClientID1 = new System.Windows.Forms.Label();
            this.labelClientID2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClientID1A = new System.Windows.Forms.TextBox();
            this.txtClientID2A = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioRangeA = new System.Windows.Forms.RadioButton();
            this.radioSingleA = new System.Windows.Forms.RadioButton();
            this.radioAllA = new System.Windows.Forms.RadioButton();
            this.btnAddCustAndLic = new System.Windows.Forms.Button();
            this.btnAddLicense = new System.Windows.Forms.Button();
            this.checkBoxTestA = new System.Windows.Forms.CheckBox();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnTestDate = new System.Windows.Forms.Button();
            this.txtSearchLicenseTo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOpenCust = new System.Windows.Forms.Button();
            this.labelCustProcessed = new System.Windows.Forms.Label();
            this.checkBoxCustOnly = new System.Windows.Forms.CheckBox();
            this.btnLoadContacts = new System.Windows.Forms.Button();
            this.labelContactsProcessed = new System.Windows.Forms.Label();
            this.btnLoadSN = new System.Windows.Forms.Button();
            this.labelSNProcessed = new System.Windows.Forms.Label();
            this.btnTestWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2005, 424);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(318, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "API - Create Customer (SWK)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2134, 1091);
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
            this.lstCustomers.Location = new System.Drawing.Point(74, 235);
            this.lstCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(1397, 224);
            this.lstCustomers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1841, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "New AddressLine3";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(2005, 301);
            this.txtAddressLine3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(318, 26);
            this.txtAddressLine3.TabIndex = 4;
            // 
            // butAddress3
            // 
            this.butAddress3.Location = new System.Drawing.Point(2101, 337);
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
            this.txtNewCustomer.Location = new System.Drawing.Point(2005, 382);
            this.txtNewCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewCustomer.Name = "txtNewCustomer";
            this.txtNewCustomer.Size = new System.Drawing.Size(318, 26);
            this.txtNewCustomer.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1825, 382);
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
            this.label3.Location = new System.Drawing.Point(1596, 498);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Customer ID (SWK)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(1772, 498);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(290, 26);
            this.txtSearchCustomer.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(2070, 494);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(253, 30);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "API - Search Cust by CustID (SWK)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustInfo
            // 
            this.txtCustInfo.Location = new System.Drawing.Point(1608, 579);
            this.txtCustInfo.Multiline = true;
            this.txtCustInfo.Name = "txtCustInfo";
            this.txtCustInfo.Size = new System.Drawing.Size(715, 63);
            this.txtCustInfo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1617, 1182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Account ID (SQL)";
            // 
            // txtAcctID
            // 
            this.txtAcctID.Location = new System.Drawing.Point(1775, 1176);
            this.txtAcctID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAcctID.Name = "txtAcctID";
            this.txtAcctID.Size = new System.Drawing.Size(290, 26);
            this.txtAcctID.TabIndex = 13;
            // 
            // lstLicenses
            // 
            this.lstLicenses.FormattingEnabled = true;
            this.lstLicenses.ItemHeight = 20;
            this.lstLicenses.Location = new System.Drawing.Point(75, 569);
            this.lstLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstLicenses.Name = "lstLicenses";
            this.lstLicenses.Size = new System.Drawing.Size(1396, 224);
            this.lstLicenses.TabIndex = 15;
            // 
            // btnLicenses
            // 
            this.btnLicenses.Location = new System.Drawing.Point(2134, 1169);
            this.btnLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLicenses.Name = "btnLicenses";
            this.btnLicenses.Size = new System.Drawing.Size(189, 35);
            this.btnLicenses.TabIndex = 16;
            this.btnLicenses.Text = "SQL - Get Licenses";
            this.btnLicenses.UseVisualStyleBackColor = true;
            this.btnLicenses.Click += new System.EventHandler(this.btnLicenses_Click);
            // 
            // txtLicInfo
            // 
            this.txtLicInfo.Location = new System.Drawing.Point(1607, 764);
            this.txtLicInfo.Multiline = true;
            this.txtLicInfo.Name = "txtLicInfo";
            this.txtLicInfo.Size = new System.Drawing.Size(716, 114);
            this.txtLicInfo.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1603, 689);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "LicID(SWK) From:";
            // 
            // txtSearchLicense
            // 
            this.txtSearchLicense.Location = new System.Drawing.Point(1748, 686);
            this.txtSearchLicense.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchLicense.Name = "txtSearchLicense";
            this.txtSearchLicense.Size = new System.Drawing.Size(117, 26);
            this.txtSearchLicense.TabIndex = 18;
            // 
            // btnSearchLic
            // 
            this.btnSearchLic.Location = new System.Drawing.Point(2073, 721);
            this.btnSearchLic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearchLic.Name = "btnSearchLic";
            this.btnSearchLic.Size = new System.Drawing.Size(250, 35);
            this.btnSearchLic.TabIndex = 17;
            this.btnSearchLic.Text = "API - Search License (SWK)";
            this.btnSearchLic.UseVisualStyleBackColor = true;
            this.btnSearchLic.Click += new System.EventHandler(this.btnSearchLic_Click);
            // 
            // btnGetAccts
            // 
            this.btnGetAccts.Location = new System.Drawing.Point(2134, 1014);
            this.btnGetAccts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetAccts.Name = "btnGetAccts";
            this.btnGetAccts.Size = new System.Drawing.Size(189, 35);
            this.btnGetAccts.TabIndex = 21;
            this.btnGetAccts.Text = "SQL - Get Accts";
            this.btnGetAccts.UseVisualStyleBackColor = true;
            this.btnGetAccts.Click += new System.EventHandler(this.btnGetAccts_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioRange);
            this.groupBox1.Controls.Add(this.radioSingle);
            this.groupBox1.Controls.Add(this.radioAll);
            this.groupBox1.Location = new System.Drawing.Point(2087, 945);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 44);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // radioRange
            // 
            this.radioRange.AutoSize = true;
            this.radioRange.Location = new System.Drawing.Point(147, 14);
            this.radioRange.Name = "radioRange";
            this.radioRange.Size = new System.Drawing.Size(82, 24);
            this.radioRange.TabIndex = 2;
            this.radioRange.Text = "Range";
            this.radioRange.UseVisualStyleBackColor = true;
            this.radioRange.CheckedChanged += new System.EventHandler(this.radioRange_CheckedChanged);
            // 
            // radioSingle
            // 
            this.radioSingle.AutoSize = true;
            this.radioSingle.Location = new System.Drawing.Point(63, 14);
            this.radioSingle.Name = "radioSingle";
            this.radioSingle.Size = new System.Drawing.Size(78, 24);
            this.radioSingle.TabIndex = 1;
            this.radioSingle.Text = "Single";
            this.radioSingle.UseVisualStyleBackColor = true;
            this.radioSingle.CheckedChanged += new System.EventHandler(this.radioSingle_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(6, 14);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(51, 24);
            this.radioAll.TabIndex = 0;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // txtClientID2
            // 
            this.txtClientID2.Enabled = false;
            this.txtClientID2.Location = new System.Drawing.Point(1914, 954);
            this.txtClientID2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientID2.Name = "txtClientID2";
            this.txtClientID2.Size = new System.Drawing.Size(130, 26);
            this.txtClientID2.TabIndex = 23;
            // 
            // txtClientID1
            // 
            this.txtClientID1.Enabled = false;
            this.txtClientID1.Location = new System.Drawing.Point(1745, 954);
            this.txtClientID1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientID1.Name = "txtClientID1";
            this.txtClientID1.Size = new System.Drawing.Size(120, 26);
            this.txtClientID1.TabIndex = 24;
            // 
            // labelClientID1
            // 
            this.labelClientID1.AutoSize = true;
            this.labelClientID1.Location = new System.Drawing.Point(1617, 957);
            this.labelClientID1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClientID1.Name = "labelClientID1";
            this.labelClientID1.Size = new System.Drawing.Size(111, 20);
            this.labelClientID1.TabIndex = 25;
            this.labelClientID1.Text = "ClientID From:";
            // 
            // labelClientID2
            // 
            this.labelClientID2.AutoSize = true;
            this.labelClientID2.Location = new System.Drawing.Point(1875, 957);
            this.labelClientID2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClientID2.Name = "labelClientID2";
            this.labelClientID2.Size = new System.Drawing.Size(31, 20);
            this.labelClientID2.TabIndex = 26;
            this.labelClientID2.Text = "To:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(373, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "To:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "ClientID From:";
            // 
            // txtClientID1A
            // 
            this.txtClientID1A.Enabled = false;
            this.txtClientID1A.Location = new System.Drawing.Point(198, 72);
            this.txtClientID1A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientID1A.Name = "txtClientID1A";
            this.txtClientID1A.Size = new System.Drawing.Size(157, 26);
            this.txtClientID1A.TabIndex = 30;
            // 
            // txtClientID2A
            // 
            this.txtClientID2A.Enabled = false;
            this.txtClientID2A.Location = new System.Drawing.Point(412, 72);
            this.txtClientID2A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientID2A.Name = "txtClientID2A";
            this.txtClientID2A.Size = new System.Drawing.Size(158, 26);
            this.txtClientID2A.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioRangeA);
            this.groupBox2.Controls.Add(this.radioSingleA);
            this.groupBox2.Controls.Add(this.radioAllA);
            this.groupBox2.Location = new System.Drawing.Point(75, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 48);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // radioRangeA
            // 
            this.radioRangeA.AutoSize = true;
            this.radioRangeA.Location = new System.Drawing.Point(147, 14);
            this.radioRangeA.Name = "radioRangeA";
            this.radioRangeA.Size = new System.Drawing.Size(82, 24);
            this.radioRangeA.TabIndex = 2;
            this.radioRangeA.Text = "Range";
            this.radioRangeA.UseVisualStyleBackColor = true;
            this.radioRangeA.CheckedChanged += new System.EventHandler(this.radioRangeA_CheckedChanged);
            // 
            // radioSingleA
            // 
            this.radioSingleA.AutoSize = true;
            this.radioSingleA.Location = new System.Drawing.Point(63, 14);
            this.radioSingleA.Name = "radioSingleA";
            this.radioSingleA.Size = new System.Drawing.Size(78, 24);
            this.radioSingleA.TabIndex = 1;
            this.radioSingleA.Text = "Single";
            this.radioSingleA.UseVisualStyleBackColor = true;
            this.radioSingleA.CheckedChanged += new System.EventHandler(this.radioSingleA_CheckedChanged);
            // 
            // radioAllA
            // 
            this.radioAllA.AutoSize = true;
            this.radioAllA.Checked = true;
            this.radioAllA.Location = new System.Drawing.Point(6, 14);
            this.radioAllA.Name = "radioAllA";
            this.radioAllA.Size = new System.Drawing.Size(51, 24);
            this.radioAllA.TabIndex = 0;
            this.radioAllA.TabStop = true;
            this.radioAllA.Text = "All";
            this.radioAllA.UseVisualStyleBackColor = true;
            this.radioAllA.CheckedChanged += new System.EventHandler(this.radioAllA_CheckedChanged);
            // 
            // btnAddCustAndLic
            // 
            this.btnAddCustAndLic.Location = new System.Drawing.Point(412, 122);
            this.btnAddCustAndLic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCustAndLic.Name = "btnAddCustAndLic";
            this.btnAddCustAndLic.Size = new System.Drawing.Size(276, 35);
            this.btnAddCustAndLic.TabIndex = 27;
            this.btnAddCustAndLic.Text = "SQL - Add Custs and Licenses";
            this.btnAddCustAndLic.UseVisualStyleBackColor = true;
            this.btnAddCustAndLic.Click += new System.EventHandler(this.btnAddCustAndLic_Click);
            // 
            // btnAddLicense
            // 
            this.btnAddLicense.Location = new System.Drawing.Point(2001, 42);
            this.btnAddLicense.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddLicense.Name = "btnAddLicense";
            this.btnAddLicense.Size = new System.Drawing.Size(222, 35);
            this.btnAddLicense.TabIndex = 33;
            this.btnAddLicense.Text = "API - Create License (SWK)";
            this.btnAddLicense.UseVisualStyleBackColor = true;
            this.btnAddLicense.Click += new System.EventHandler(this.btnAddLicense_Click);
            // 
            // checkBoxTestA
            // 
            this.checkBoxTestA.AutoSize = true;
            this.checkBoxTestA.Checked = true;
            this.checkBoxTestA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTestA.Location = new System.Drawing.Point(599, 75);
            this.checkBoxTestA.Name = "checkBoxTestA";
            this.checkBoxTestA.Size = new System.Drawing.Size(75, 24);
            this.checkBoxTestA.TabIndex = 34;
            this.checkBoxTestA.Text = "Test?";
            this.checkBoxTestA.UseVisualStyleBackColor = true;
            // 
            // checkBoxTest
            // 
            this.checkBoxTest.AutoSize = true;
            this.checkBoxTest.Checked = true;
            this.checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTest.Location = new System.Drawing.Point(2248, 46);
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.Size = new System.Drawing.Size(75, 24);
            this.checkBoxTest.TabIndex = 35;
            this.checkBoxTest.Text = "Test?";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2001, 86);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(322, 35);
            this.button3.TabIndex = 36;
            this.button3.Text = "API - Test Update Custom Data (SWK)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1599, 545);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Customer Name (SWK)";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(1775, 542);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(290, 26);
            this.txtSearchName.TabIndex = 38;
            // 
            // btnSearchName
            // 
            this.btnSearchName.Location = new System.Drawing.Point(2073, 540);
            this.btnSearchName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(250, 30);
            this.btnSearchName.TabIndex = 37;
            this.btnSearchName.Text = "API - Search Cust by Name";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(2001, 130);
            this.btnTest1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(322, 31);
            this.btnTest1.TabIndex = 40;
            this.btnTest1.Text = "Test Update Customer SQL record";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(2001, 170);
            this.btnTest2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(322, 31);
            this.btnTest2.TabIndex = 41;
            this.btnTest2.Text = "Test Update License SQL record";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnTestDate
            // 
            this.btnTestDate.Location = new System.Drawing.Point(2000, 210);
            this.btnTestDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestDate.Name = "btnTestDate";
            this.btnTestDate.Size = new System.Drawing.Size(323, 31);
            this.btnTestDate.TabIndex = 42;
            this.btnTestDate.Text = "Test Date Split";
            this.btnTestDate.UseVisualStyleBackColor = true;
            this.btnTestDate.Click += new System.EventHandler(this.btnTestDate_Click);
            // 
            // txtSearchLicenseTo
            // 
            this.txtSearchLicenseTo.Location = new System.Drawing.Point(1914, 686);
            this.txtSearchLicenseTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchLicenseTo.Name = "txtSearchLicenseTo";
            this.txtSearchLicenseTo.Size = new System.Drawing.Size(130, 26);
            this.txtSearchLicenseTo.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1875, 689);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "To:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Location = new System.Drawing.Point(2086, 672);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 50);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(147, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 24);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Range";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(63, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Single";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 14);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 24);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "All";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(2001, 252);
            this.btnWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(322, 31);
            this.btnWrite.TabIndex = 45;
            this.btnWrite.Text = "Test Write Stuff to file";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(81, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 20);
            this.label10.TabIndex = 46;
            this.label10.Text = "Processed Customers";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 544);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 47;
            this.label11.Text = "Processed Licenses";
            // 
            // btnOpenCust
            // 
            this.btnOpenCust.Location = new System.Drawing.Point(74, 954);
            this.btnOpenCust.Name = "btnOpenCust";
            this.btnOpenCust.Size = new System.Drawing.Size(260, 45);
            this.btnOpenCust.TabIndex = 48;
            this.btnOpenCust.Text = "Load Accounts to SQL";
            this.btnOpenCust.UseVisualStyleBackColor = true;
            this.btnOpenCust.Click += new System.EventHandler(this.btnOpenCust_Click);
            // 
            // labelCustProcessed
            // 
            this.labelCustProcessed.AutoSize = true;
            this.labelCustProcessed.Location = new System.Drawing.Point(364, 969);
            this.labelCustProcessed.Name = "labelCustProcessed";
            this.labelCustProcessed.Size = new System.Drawing.Size(14, 20);
            this.labelCustProcessed.TabIndex = 49;
            this.labelCustProcessed.Text = "|";
            // 
            // checkBoxCustOnly
            // 
            this.checkBoxCustOnly.AutoSize = true;
            this.checkBoxCustOnly.Checked = true;
            this.checkBoxCustOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCustOnly.Location = new System.Drawing.Point(698, 72);
            this.checkBoxCustOnly.Name = "checkBoxCustOnly";
            this.checkBoxCustOnly.Size = new System.Drawing.Size(147, 24);
            this.checkBoxCustOnly.TabIndex = 50;
            this.checkBoxCustOnly.Text = "Customers Only";
            this.checkBoxCustOnly.UseVisualStyleBackColor = true;
            // 
            // btnLoadContacts
            // 
            this.btnLoadContacts.Location = new System.Drawing.Point(74, 1028);
            this.btnLoadContacts.Name = "btnLoadContacts";
            this.btnLoadContacts.Size = new System.Drawing.Size(260, 45);
            this.btnLoadContacts.TabIndex = 51;
            this.btnLoadContacts.Text = "Load Contacts to SQL";
            this.btnLoadContacts.UseVisualStyleBackColor = true;
            this.btnLoadContacts.Click += new System.EventHandler(this.btnLoadContacts_Click);
            // 
            // labelContactsProcessed
            // 
            this.labelContactsProcessed.AutoSize = true;
            this.labelContactsProcessed.Location = new System.Drawing.Point(364, 1040);
            this.labelContactsProcessed.Name = "labelContactsProcessed";
            this.labelContactsProcessed.Size = new System.Drawing.Size(14, 20);
            this.labelContactsProcessed.TabIndex = 52;
            this.labelContactsProcessed.Text = "|";
            // 
            // btnLoadSN
            // 
            this.btnLoadSN.Location = new System.Drawing.Point(74, 1103);
            this.btnLoadSN.Name = "btnLoadSN";
            this.btnLoadSN.Size = new System.Drawing.Size(260, 45);
            this.btnLoadSN.TabIndex = 53;
            this.btnLoadSN.Text = "Load SerialNums to SQL";
            this.btnLoadSN.UseVisualStyleBackColor = true;
            this.btnLoadSN.Click += new System.EventHandler(this.btnLoadSN_Click);
            // 
            // labelSNProcessed
            // 
            this.labelSNProcessed.AutoSize = true;
            this.labelSNProcessed.Location = new System.Drawing.Point(364, 1115);
            this.labelSNProcessed.Name = "labelSNProcessed";
            this.labelSNProcessed.Size = new System.Drawing.Size(14, 20);
            this.labelSNProcessed.TabIndex = 54;
            this.labelSNProcessed.Text = "|";
            // 
            // btnTestWrite
            // 
            this.btnTestWrite.Location = new System.Drawing.Point(2000, 1235);
            this.btnTestWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestWrite.Name = "btnTestWrite";
            this.btnTestWrite.Size = new System.Drawing.Size(322, 31);
            this.btnTestWrite.TabIndex = 55;
            this.btnTestWrite.Text = "Test Write Stuff to file 2";
            this.btnTestWrite.UseVisualStyleBackColor = true;
            this.btnTestWrite.Click += new System.EventHandler(this.btnTestWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2360, 1280);
            this.Controls.Add(this.btnTestWrite);
            this.Controls.Add(this.labelSNProcessed);
            this.Controls.Add(this.btnLoadSN);
            this.Controls.Add(this.labelContactsProcessed);
            this.Controls.Add(this.btnLoadContacts);
            this.Controls.Add(this.checkBoxCustOnly);
            this.Controls.Add(this.labelCustProcessed);
            this.Controls.Add(this.btnOpenCust);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearchLicenseTo);
            this.Controls.Add(this.btnTestDate);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBoxTest);
            this.Controls.Add(this.checkBoxTestA);
            this.Controls.Add(this.btnAddLicense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtClientID1A);
            this.Controls.Add(this.txtClientID2A);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAddCustAndLic);
            this.Controls.Add(this.labelClientID2);
            this.Controls.Add(this.labelClientID1);
            this.Controls.Add(this.txtClientID1);
            this.Controls.Add(this.txtClientID2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetAccts);
            this.Controls.Add(this.txtLicInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchLicense);
            this.Controls.Add(this.btnSearchLic);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TextBox txtLicInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchLicense;
        private System.Windows.Forms.Button btnSearchLic;
        private System.Windows.Forms.Button btnGetAccts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioRange;
        private System.Windows.Forms.RadioButton radioSingle;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.TextBox txtClientID2;
        private System.Windows.Forms.TextBox txtClientID1;
        private System.Windows.Forms.Label labelClientID1;
        private System.Windows.Forms.Label labelClientID2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClientID1A;
        private System.Windows.Forms.TextBox txtClientID2A;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioRangeA;
        private System.Windows.Forms.RadioButton radioSingleA;
        private System.Windows.Forms.RadioButton radioAllA;
        private System.Windows.Forms.Button btnAddCustAndLic;
        private System.Windows.Forms.Button btnAddLicense;
        private System.Windows.Forms.CheckBox checkBoxTestA;
        private System.Windows.Forms.CheckBox checkBoxTest;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.Button btnTestDate;
        private System.Windows.Forms.TextBox txtSearchLicenseTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOpenCust;
        private System.Windows.Forms.Label labelCustProcessed;
        private System.Windows.Forms.CheckBox checkBoxCustOnly;
        private System.Windows.Forms.Button btnLoadContacts;
        private System.Windows.Forms.Label labelContactsProcessed;
        private System.Windows.Forms.Button btnLoadSN;
        private System.Windows.Forms.Label labelSNProcessed;
        private System.Windows.Forms.Button btnTestWrite;
    }
}

