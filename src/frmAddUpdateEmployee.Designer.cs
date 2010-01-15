namespace FaceIDAppVBEta
{
    partial class frmAddUpdateEmployee
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
            this.components = new System.ComponentModel.Container();
            this.lblAddUpdateEmployee = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEmployeeNumber = new System.Windows.Forms.TextBox();
            this.tbPayrollNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbJobDesc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbxWorkingCalendar = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpJoinedDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpLeftDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnRegisterOnTerminal = new System.Windows.Forms.Button();
            this.lbxTerminal = new System.Windows.Forms.ListBox();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddUpdateEmployee
            // 
            this.lblAddUpdateEmployee.AutoSize = true;
            this.lblAddUpdateEmployee.Location = new System.Drawing.Point(36, 26);
            this.lblAddUpdateEmployee.Name = "lblAddUpdateEmployee";
            this.lblAddUpdateEmployee.Size = new System.Drawing.Size(100, 13);
            this.lblAddUpdateEmployee.TabIndex = 0;
            this.lblAddUpdateEmployee.Text = "Add New Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(107, 58);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 2;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Name";
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(311, 58);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 4;
            this.cbxDepartment.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Employee Number";
            // 
            // tbEmployeeNumber
            // 
            this.tbEmployeeNumber.Location = new System.Drawing.Point(150, 112);
            this.tbEmployeeNumber.Name = "tbEmployeeNumber";
            this.tbEmployeeNumber.Size = new System.Drawing.Size(100, 20);
            this.tbEmployeeNumber.TabIndex = 8;
            this.tbEmployeeNumber.Text = "Auto";
            // 
            // tbPayrollNumber
            // 
            this.tbPayrollNumber.Location = new System.Drawing.Point(382, 112);
            this.tbPayrollNumber.Name = "tbPayrollNumber";
            this.tbPayrollNumber.Size = new System.Drawing.Size(100, 20);
            this.tbPayrollNumber.TabIndex = 10;
            this.tbPayrollNumber.Text = "Auto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Payroll Number";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(151, 143);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 20);
            this.tbFirstName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "First Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(382, 143);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 20);
            this.tbLastName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Last Name";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(151, 176);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.tbPhoneNumber.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Phone Number";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(382, 173);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(100, 20);
            this.tbAddress.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Address";
            // 
            // tbJobDesc
            // 
            this.tbJobDesc.Location = new System.Drawing.Point(151, 207);
            this.tbJobDesc.Name = "tbJobDesc";
            this.tbJobDesc.Size = new System.Drawing.Size(100, 20);
            this.tbJobDesc.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Job Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(274, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Birthday";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(382, 207);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthday.TabIndex = 22;
            // 
            // cbxWorkingCalendar
            // 
            this.cbxWorkingCalendar.DisplayMember = "Name";
            this.cbxWorkingCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkingCalendar.FormattingEnabled = true;
            this.cbxWorkingCalendar.Location = new System.Drawing.Point(554, 55);
            this.cbxWorkingCalendar.Name = "cbxWorkingCalendar";
            this.cbxWorkingCalendar.Size = new System.Drawing.Size(121, 21);
            this.cbxWorkingCalendar.TabIndex = 24;
            this.cbxWorkingCalendar.ValueMember = "ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(447, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Working Calendar";
            // 
            // dtpJoinedDate
            // 
            this.dtpJoinedDate.Location = new System.Drawing.Point(149, 237);
            this.dtpJoinedDate.Name = "dtpJoinedDate";
            this.dtpJoinedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpJoinedDate.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Joined Date";
            // 
            // dtpLeftDate
            // 
            this.dtpLeftDate.Location = new System.Drawing.Point(436, 236);
            this.dtpLeftDate.Name = "dtpLeftDate";
            this.dtpLeftDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLeftDate.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(365, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Left Date";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(130, 274);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnAddEmployee.TabIndex = 29;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(211, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Location = new System.Drawing.Point(130, 274);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateEmployee.TabIndex = 31;
            this.btnUpdateEmployee.Text = "Update";
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(514, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Terminal";
            // 
            // btnRegisterOnTerminal
            // 
            this.btnRegisterOnTerminal.Location = new System.Drawing.Point(693, 115);
            this.btnRegisterOnTerminal.Name = "btnRegisterOnTerminal";
            this.btnRegisterOnTerminal.Size = new System.Drawing.Size(84, 23);
            this.btnRegisterOnTerminal.TabIndex = 35;
            this.btnRegisterOnTerminal.Text = "Change";
            this.btnRegisterOnTerminal.UseVisualStyleBackColor = true;
            this.btnRegisterOnTerminal.Click += new System.EventHandler(this.btnAddTerminal_Click);
            // 
            // lbxTerminal
            // 
            this.lbxTerminal.DisplayMember = "Name";
            this.lbxTerminal.FormattingEnabled = true;
            this.lbxTerminal.Location = new System.Drawing.Point(567, 94);
            this.lbxTerminal.Name = "lbxTerminal";
            this.lbxTerminal.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxTerminal.Size = new System.Drawing.Size(120, 95);
            this.lbxTerminal.TabIndex = 36;
            this.lbxTerminal.ValueMember = "ID";
            // 
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // frmAddUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 315);
            this.Controls.Add(this.lbxTerminal);
            this.Controls.Add(this.btnRegisterOnTerminal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.dtpLeftDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpJoinedDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxWorkingCalendar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbJobDesc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPayrollNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEmployeeNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddUpdateEmployee);
            this.Name = "frmAddUpdateEmployee";
            this.Text = "frmAddUpdateEmployee";
            this.Load += new System.EventHandler(this.frmAddUpdateEmployee_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddUpdateEmployee_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddUpdateEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEmployeeNumber;
        private System.Windows.Forms.TextBox tbPayrollNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbJobDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.ComboBox cbxWorkingCalendar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpJoinedDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpLeftDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnRegisterOnTerminal;
        private System.Windows.Forms.ListBox lbxTerminal;
        private System.Windows.Forms.ErrorProvider errProviders;
    }
}