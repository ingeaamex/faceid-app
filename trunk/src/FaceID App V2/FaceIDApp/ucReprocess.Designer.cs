namespace FaceIDAppVBEta
{
    partial class ucReprocess
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpReprocessTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpReprocessFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxWorkingCalendar = new System.Windows.Forms.ComboBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingCalendar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReprocess = new System.Windows.Forms.Button();
            this.btnViewEmployees = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Department";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Name";
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Items.AddRange(new object[] {
            "Select Department"});
            this.cbxDepartment.Location = new System.Drawing.Point(276, 8);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 2;
            this.cbxDepartment.ValueMember = "ID";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Items.AddRange(new object[] {
            "Select Company"});
            this.cbxCompany.Location = new System.Drawing.Point(63, 8);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 1;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Company";
            // 
            // dtpReprocessTo
            // 
            this.dtpReprocessTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReprocessTo.Location = new System.Drawing.Point(276, 41);
            this.dtpReprocessTo.Name = "dtpReprocessTo";
            this.dtpReprocessTo.Size = new System.Drawing.Size(121, 20);
            this.dtpReprocessTo.TabIndex = 8;
            this.dtpReprocessTo.Value = new System.DateTime(2010, 2, 7, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "To";
            // 
            // dtpReprocessFrom
            // 
            this.dtpReprocessFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReprocessFrom.Location = new System.Drawing.Point(60, 41);
            this.dtpReprocessFrom.Name = "dtpReprocessFrom";
            this.dtpReprocessFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpReprocessFrom.TabIndex = 7;
            this.dtpReprocessFrom.Value = new System.DateTime(2010, 2, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Working Calendar";
            // 
            // cbxWorkingCalendar
            // 
            this.cbxWorkingCalendar.DisplayMember = "Name";
            this.cbxWorkingCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkingCalendar.FormattingEnabled = true;
            this.cbxWorkingCalendar.Items.AddRange(new object[] {
            "Select Working Calendar"});
            this.cbxWorkingCalendar.Location = new System.Drawing.Point(520, 8);
            this.cbxWorkingCalendar.Name = "cbxWorkingCalendar";
            this.cbxWorkingCalendar.Size = new System.Drawing.Size(121, 21);
            this.cbxWorkingCalendar.TabIndex = 3;
            this.cbxWorkingCalendar.ValueMember = "ID";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(36, 77);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(117, 77);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnUnselectAll.TabIndex = 6;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.WorkingCalendar});
            this.dgvEmployee.Location = new System.Drawing.Point(36, 106);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(772, 521);
            this.dgvEmployee.TabIndex = 41;
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.FillWeight = 87.09677F;
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            this.EmployeeNumber.Width = 108;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.FillWeight = 112.9032F;
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // WorkingCalendar
            // 
            this.WorkingCalendar.DataPropertyName = "WorkingCalendar";
            this.WorkingCalendar.HeaderText = "Working Calendar";
            this.WorkingCalendar.Name = "WorkingCalendar";
            this.WorkingCalendar.ReadOnly = true;
            this.WorkingCalendar.Width = 107;
            // 
            // btnReprocess
            // 
            this.btnReprocess.Location = new System.Drawing.Point(403, 40);
            this.btnReprocess.Name = "btnReprocess";
            this.btnReprocess.Size = new System.Drawing.Size(75, 23);
            this.btnReprocess.TabIndex = 9;
            this.btnReprocess.Text = "ReProcess";
            this.btnReprocess.UseVisualStyleBackColor = true;
            this.btnReprocess.Click += new System.EventHandler(this.btnReprocess_Click);
            // 
            // btnViewEmployees
            // 
            this.btnViewEmployees.Location = new System.Drawing.Point(647, 6);
            this.btnViewEmployees.Name = "btnViewEmployees";
            this.btnViewEmployees.Size = new System.Drawing.Size(104, 23);
            this.btnViewEmployees.TabIndex = 4;
            this.btnViewEmployees.Text = "View Employees";
            this.btnViewEmployees.UseVisualStyleBackColor = true;
            this.btnViewEmployees.Click += new System.EventHandler(this.btnViewEmployees_Click);
            // 
            // ucReprocess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewEmployees);
            this.Controls.Add(this.btnReprocess);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxWorkingCalendar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpReprocessTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpReprocessFrom);
            this.Controls.Add(this.label2);
            this.Name = "ucReprocess";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpReprocessTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpReprocessFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxWorkingCalendar;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnReprocess;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingCalendar;
        private System.Windows.Forms.Button btnViewEmployees;
    }
}
