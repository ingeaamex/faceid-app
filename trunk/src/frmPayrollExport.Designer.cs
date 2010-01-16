namespace FaceIDAppVBEta
{
    partial class frmPayrollExport
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
            this.dgvPayrollExport = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegularHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvertimeHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPayrollFrom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayrollTo = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrollExport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayrollExport
            // 
            this.dgvPayrollExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayrollExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.Department,
            this.RegularHours,
            this.OvertimeHours,
            this.TotalHours});
            this.dgvPayrollExport.Location = new System.Drawing.Point(60, 136);
            this.dgvPayrollExport.Name = "dgvPayrollExport";
            this.dgvPayrollExport.Size = new System.Drawing.Size(690, 150);
            this.dgvPayrollExport.TabIndex = 0;
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            // 
            // Department
            // 
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            // 
            // RegularHours
            // 
            this.RegularHours.HeaderText = "Regular Hours";
            this.RegularHours.Name = "RegularHours";
            // 
            // OvertimeHours
            // 
            this.OvertimeHours.HeaderText = "Overtime Hours";
            this.OvertimeHours.Name = "OvertimeHours";
            // 
            // TotalHours
            // 
            this.TotalHours.HeaderText = "Total Hours";
            this.TotalHours.Name = "TotalHours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payroll Export";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // lblPayrollFrom
            // 
            this.lblPayrollFrom.AutoSize = true;
            this.lblPayrollFrom.Location = new System.Drawing.Point(144, 86);
            this.lblPayrollFrom.Name = "lblPayrollFrom";
            this.lblPayrollFrom.Size = new System.Drawing.Size(68, 13);
            this.lblPayrollFrom.TabIndex = 3;
            this.lblPayrollFrom.Text = "1st Jan 2010";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // lblPayrollTo
            // 
            this.lblPayrollTo.AutoSize = true;
            this.lblPayrollTo.Location = new System.Drawing.Point(380, 86);
            this.lblPayrollTo.Name = "lblPayrollTo";
            this.lblPayrollTo.Size = new System.Drawing.Size(74, 13);
            this.lblPayrollTo.TabIndex = 5;
            this.lblPayrollTo.Text = "31st Jan 2010";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(77, 411);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(176, 410);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 7;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmPayrollExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 486);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPayrollTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPayrollFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPayrollExport);
            this.Name = "frmPayrollExport";
            this.Text = "frmPayrollExport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrollExport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPayrollExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegularHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvertimeHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPayrollFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayrollTo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnCancel;
    }
}