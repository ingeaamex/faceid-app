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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmpl = new System.Windows.Forms.DataGridView();
            this.cMnSaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btPrint = new System.Windows.Forms.Button();
            this.btNewEmpl = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingCalendar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PayrollNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpl)).BeginInit();
            this.cMnSaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management";
            // 
            // dgvEmpl
            // 
            this.dgvEmpl.AllowUserToAddRows = false;
            this.dgvEmpl.AllowUserToDeleteRows = false;
            this.dgvEmpl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.JobDesc,
            this.WorkingCalendar,
            this.PayrollNumber,
            this.Terminal});
            this.dgvEmpl.Location = new System.Drawing.Point(51, 99);
            this.dgvEmpl.Name = "dgvEmpl";
            this.dgvEmpl.ReadOnly = true;
            this.dgvEmpl.Size = new System.Drawing.Size(748, 150);
            this.dgvEmpl.TabIndex = 1;
            this.dgvEmpl.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmpl_CellFormatting);
            this.dgvEmpl.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpl_CellMouseEnter);
            // 
            // cMnSaction
            // 
            this.cMnSaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cMnSaction.Name = "cMnSaction";
            this.cMnSaction.Size = new System.Drawing.Size(113, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(51, 271);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 2;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btNewEmpl
            // 
            this.btNewEmpl.Location = new System.Drawing.Point(133, 271);
            this.btNewEmpl.Name = "btNewEmpl";
            this.btNewEmpl.Size = new System.Drawing.Size(171, 23);
            this.btNewEmpl.TabIndex = 3;
            this.btNewEmpl.Text = "Add New Employee";
            this.btNewEmpl.UseVisualStyleBackColor = true;
            this.btNewEmpl.Click += new System.EventHandler(this.btNewEmpl_Click);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(513, 64);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(75, 23);
            this.btView.TabIndex = 4;
            this.btView.Text = "View";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // cbCompany
            // 
            this.cbCompany.DisplayMember = "Name";
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(123, 64);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(121, 21);
            this.cbCompany.TabIndex = 5;
            this.cbCompany.ValueMember = "ID";
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cboxCompany_SelectedIndexChanged);
            // 
            // cbDepartment
            // 
            this.cbDepartment.DisplayMember = "Name";
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(342, 65);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbDepartment.TabIndex = 6;
            this.cbDepartment.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Department";
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.ContextMenuStrip = this.cMnSaction;
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            dataGridViewCellStyle1.NullValue = null;
            this.EmployeeNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeNumber.HeaderText = "EmployeeNumber";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.ContextMenuStrip = this.cMnSaction;
            dataGridViewCellStyle2.Format = "{0} {1}";
            dataGridViewCellStyle2.NullValue = null;
            this.EmployeeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeName.HeaderText = "Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // JobDesc
            // 
            this.JobDesc.ContextMenuStrip = this.cMnSaction;
            this.JobDesc.DataPropertyName = "JobDescription";
            this.JobDesc.HeaderText = "Job Description";
            this.JobDesc.Name = "JobDesc";
            this.JobDesc.ReadOnly = true;
            // 
            // WorkingCalendar
            // 
            this.WorkingCalendar.DataPropertyName = "WorkingCalendarID";
            dataGridViewCellStyle3.NullValue = null;
            this.WorkingCalendar.DefaultCellStyle = dataGridViewCellStyle3;
            this.WorkingCalendar.HeaderText = "Working Calendar";
            this.WorkingCalendar.Name = "WorkingCalendar";
            this.WorkingCalendar.ReadOnly = true;
            this.WorkingCalendar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkingCalendar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WorkingCalendar.Text = "View";
            this.WorkingCalendar.UseColumnTextForLinkValue = true;
            // 
            // PayrollNumber
            // 
            this.PayrollNumber.ContextMenuStrip = this.cMnSaction;
            this.PayrollNumber.DataPropertyName = "PayrollNumber";
            this.PayrollNumber.HeaderText = "Payroll Number";
            this.PayrollNumber.Name = "PayrollNumber";
            this.PayrollNumber.ReadOnly = true;
            // 
            // Terminal
            // 
            this.Terminal.ContextMenuStrip = this.cMnSaction;
            this.Terminal.DataPropertyName = "EmployeeNumber";
            this.Terminal.HeaderText = "Terminal Registered";
            this.Terminal.Name = "Terminal";
            this.Terminal.ReadOnly = true;
            // 
            // ucEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.btNewEmpl);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.dgvEmpl);
            this.Controls.Add(this.label1);
            this.Name = "ucEmployeeForm";
            this.Size = new System.Drawing.Size(875, 335);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpl)).EndInit();
            this.cMnSaction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmpl;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btNewEmpl;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cMnSaction;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobDesc;
        private System.Windows.Forms.DataGridViewLinkColumn WorkingCalendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayrollNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal;
    }
}
