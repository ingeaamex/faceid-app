namespace FaceIDAppVBEta
{
    partial class ucEmployeeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDgvEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayrollNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingCalendarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingCalendar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAddNewEmployee = new System.Windows.Forms.Button();
            this.btnViewEmployee = new System.Windows.Forms.Button();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetEmployeeFromTerminal = new System.Windows.Forms.Button();
            this.btnSendEmployeeToTerminal = new System.Windows.Forms.Button();
            this.btnExportToFile = new System.Windows.Forms.Button();
            this.btnImportFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.cmnDgvEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management";
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AllowUserToOrderColumns = true;
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.JobDesc,
            this.PayrollNumber,
            this.WorkingCalendarID,
            this.WorkingCalendar,
            this.Terminal});
            this.dgvEmployee.Location = new System.Drawing.Point(36, 139);
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(772, 487);
            this.dgvEmployee.TabIndex = 1;
            this.dgvEmployee.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmpl_CellFormatting);
            this.dgvEmployee.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpl_CellMouseEnter);
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpl_CellContentClick);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.ContextMenuStrip = this.cmnDgvEmployee;
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            dataGridViewCellStyle1.NullValue = null;
            this.EmployeeNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeNumber.HeaderText = "EmployeeNumber";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            // 
            // cmnDgvEmployee
            // 
            this.cmnDgvEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmnDgvEmployee.Name = "cMnSaction";
            this.cmnDgvEmployee.Size = new System.Drawing.Size(110, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // EmployeeName
            // 
            this.EmployeeName.ContextMenuStrip = this.cmnDgvEmployee;
            dataGridViewCellStyle2.Format = "{0} {1}";
            dataGridViewCellStyle2.NullValue = null;
            this.EmployeeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeName.HeaderText = "Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // JobDesc
            // 
            this.JobDesc.ContextMenuStrip = this.cmnDgvEmployee;
            this.JobDesc.DataPropertyName = "JobDescription";
            this.JobDesc.HeaderText = "Job Description";
            this.JobDesc.Name = "JobDesc";
            this.JobDesc.ReadOnly = true;
            // 
            // PayrollNumber
            // 
            this.PayrollNumber.ContextMenuStrip = this.cmnDgvEmployee;
            this.PayrollNumber.DataPropertyName = "PayrollNumber";
            this.PayrollNumber.HeaderText = "Payroll Number";
            this.PayrollNumber.Name = "PayrollNumber";
            this.PayrollNumber.ReadOnly = true;
            // 
            // WorkingCalendarID
            // 
            this.WorkingCalendarID.DataPropertyName = "WorkingCalendarID";
            this.WorkingCalendarID.HeaderText = "WorkingCalendarID";
            this.WorkingCalendarID.Name = "WorkingCalendarID";
            this.WorkingCalendarID.ReadOnly = true;
            this.WorkingCalendarID.Visible = false;
            // 
            // WorkingCalendar
            // 
            this.WorkingCalendar.HeaderText = "WorkingCalendar";
            this.WorkingCalendar.Name = "WorkingCalendar";
            this.WorkingCalendar.ReadOnly = true;
            // 
            // Terminal
            // 
            this.Terminal.ContextMenuStrip = this.cmnDgvEmployee;
            this.Terminal.DataPropertyName = "EmployeeNumber";
            this.Terminal.HeaderText = "Terminal Registered";
            this.Terminal.Name = "Terminal";
            this.Terminal.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(36, 74);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(126, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.Location = new System.Drawing.Point(36, 103);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(126, 23);
            this.btnAddNewEmployee.TabIndex = 3;
            this.btnAddNewEmployee.Text = "Add New Employee";
            this.btnAddNewEmployee.UseVisualStyleBackColor = true;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btNewEmpl_Click);
            // 
            // btnViewEmployee
            // 
            this.btnViewEmployee.Location = new System.Drawing.Point(421, 44);
            this.btnViewEmployee.Name = "btnViewEmployee";
            this.btnViewEmployee.Size = new System.Drawing.Size(126, 23);
            this.btnViewEmployee.TabIndex = 4;
            this.btnViewEmployee.Text = "View Employees";
            this.btnViewEmployee.UseVisualStyleBackColor = true;
            this.btnViewEmployee.Click += new System.EventHandler(this.btView_Click);
            // 
            // cbxCompany
            // 
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(95, 45);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 5;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cboxCompany_SelectedIndexChanged);
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Name";
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(294, 45);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 6;
            this.cbxDepartment.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Department";
            // 
            // btnGetEmployeeFromTerminal
            // 
            this.btnGetEmployeeFromTerminal.Location = new System.Drawing.Point(168, 74);
            this.btnGetEmployeeFromTerminal.Name = "btnGetEmployeeFromTerminal";
            this.btnGetEmployeeFromTerminal.Size = new System.Drawing.Size(195, 23);
            this.btnGetEmployeeFromTerminal.TabIndex = 9;
            this.btnGetEmployeeFromTerminal.Text = "Get Employee Data From Terminal";
            this.btnGetEmployeeFromTerminal.UseVisualStyleBackColor = true;
            this.btnGetEmployeeFromTerminal.Click += new System.EventHandler(this.btnGetEmployeeFromTerminal_Click);
            // 
            // btnSendEmployeeToTerminal
            // 
            this.btnSendEmployeeToTerminal.Location = new System.Drawing.Point(168, 103);
            this.btnSendEmployeeToTerminal.Name = "btnSendEmployeeToTerminal";
            this.btnSendEmployeeToTerminal.Size = new System.Drawing.Size(195, 23);
            this.btnSendEmployeeToTerminal.TabIndex = 10;
            this.btnSendEmployeeToTerminal.Text = "Send Employee Data To Terminal";
            this.btnSendEmployeeToTerminal.UseVisualStyleBackColor = true;
            this.btnSendEmployeeToTerminal.Click += new System.EventHandler(this.btnSendEmployeeToTerminal_Click);
            // 
            // btnExportToFile
            // 
            this.btnExportToFile.Enabled = false;
            this.btnExportToFile.Location = new System.Drawing.Point(369, 103);
            this.btnExportToFile.Name = "btnExportToFile";
            this.btnExportToFile.Size = new System.Drawing.Size(105, 23);
            this.btnExportToFile.TabIndex = 11;
            this.btnExportToFile.Text = "Export to file";
            this.btnExportToFile.UseVisualStyleBackColor = true;
            this.btnExportToFile.Click += new System.EventHandler(this.btnExportToFile_Click);
            // 
            // btnImportFromFile
            // 
            this.btnImportFromFile.Location = new System.Drawing.Point(369, 74);
            this.btnImportFromFile.Name = "btnImportFromFile";
            this.btnImportFromFile.Size = new System.Drawing.Size(105, 23);
            this.btnImportFromFile.TabIndex = 12;
            this.btnImportFromFile.Text = "Import from file";
            this.btnImportFromFile.UseVisualStyleBackColor = true;
            this.btnImportFromFile.Click += new System.EventHandler(this.btnImportFromFile_Click);
            // 
            // ucEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportFromFile);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.btnExportToFile);
            this.Controls.Add(this.btnSendEmployeeToTerminal);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.btnGetEmployeeFromTerminal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewEmployee);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.btnAddNewEmployee);
            this.Name = "ucEmployeeForm";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.cmnDgvEmployee.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAddNewEmployee;
        private System.Windows.Forms.Button btnViewEmployee;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmnDgvEmployee;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnGetEmployeeFromTerminal;
        private System.Windows.Forms.Button btnSendEmployeeToTerminal;
        private System.Windows.Forms.Button btnExportToFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayrollNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingCalendarID;
        private System.Windows.Forms.DataGridViewLinkColumn WorkingCalendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal;
        private System.Windows.Forms.Button btnImportFromFile;
    }
}
