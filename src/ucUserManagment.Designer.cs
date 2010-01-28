namespace FaceIDAppVBEta
{
    partial class ucUserManagment
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Access = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgvUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxAddUpdateUser = new System.Windows.Forms.GroupBox();
            this.cbxEmployeeNumber = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddUpdateUser = new System.Windows.Forms.Button();
            this.chbAttendanceManagement = new System.Windows.Forms.CheckBox();
            this.chbWorkingCalendarManagement = new System.Windows.Forms.CheckBox();
            this.chbEmployeeManagement = new System.Windows.Forms.CheckBox();
            this.chbTerminalManagement = new System.Windows.Forms.CheckBox();
            this.chbCompanyDepartmentManagement = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chbUserManagement = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.cmsDgvUser.SuspendLayout();
            this.gbxAddUpdateUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Management";
            // 
            // dgvUser
            // 
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.Access});
            this.dgvUser.ContextMenuStrip = this.cmsDgvUser;
            this.dgvUser.Location = new System.Drawing.Point(36, 73);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(772, 299);
            this.dgvUser.TabIndex = 1;
            this.dgvUser.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellMouseEnter);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            // 
            // Access
            // 
            this.Access.HeaderText = "Access";
            this.Access.Name = "Access";
            // 
            // cmsDgvUser
            // 
            this.cmsDgvUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.cmsDgvUser.Name = "cmsDgvUser";
            this.cmsDgvUser.Size = new System.Drawing.Size(106, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // gbxAddUpdateUser
            // 
            this.gbxAddUpdateUser.Controls.Add(this.cbxEmployeeNumber);
            this.gbxAddUpdateUser.Controls.Add(this.btnCancel);
            this.gbxAddUpdateUser.Controls.Add(this.btnAddUpdateUser);
            this.gbxAddUpdateUser.Controls.Add(this.chbAttendanceManagement);
            this.gbxAddUpdateUser.Controls.Add(this.chbWorkingCalendarManagement);
            this.gbxAddUpdateUser.Controls.Add(this.chbEmployeeManagement);
            this.gbxAddUpdateUser.Controls.Add(this.chbTerminalManagement);
            this.gbxAddUpdateUser.Controls.Add(this.chbCompanyDepartmentManagement);
            this.gbxAddUpdateUser.Controls.Add(this.label6);
            this.gbxAddUpdateUser.Controls.Add(this.txtRetypePassword);
            this.gbxAddUpdateUser.Controls.Add(this.label5);
            this.gbxAddUpdateUser.Controls.Add(this.txtPassword);
            this.gbxAddUpdateUser.Controls.Add(this.chbUserManagement);
            this.gbxAddUpdateUser.Controls.Add(this.label4);
            this.gbxAddUpdateUser.Controls.Add(this.label2);
            this.gbxAddUpdateUser.Location = new System.Drawing.Point(36, 396);
            this.gbxAddUpdateUser.Name = "gbxAddUpdateUser";
            this.gbxAddUpdateUser.Size = new System.Drawing.Size(772, 230);
            this.gbxAddUpdateUser.TabIndex = 2;
            this.gbxAddUpdateUser.TabStop = false;
            this.gbxAddUpdateUser.Text = "Add / Update User";
            // 
            // cbxEmployeeNumber
            // 
            this.cbxEmployeeNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmployeeNumber.FormattingEnabled = true;
            this.cbxEmployeeNumber.Location = new System.Drawing.Point(115, 21);
            this.cbxEmployeeNumber.Name = "cbxEmployeeNumber";
            this.cbxEmployeeNumber.Size = new System.Drawing.Size(121, 21);
            this.cbxEmployeeNumber.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddUpdateUser
            // 
            this.btnAddUpdateUser.Location = new System.Drawing.Point(139, 187);
            this.btnAddUpdateUser.Name = "btnAddUpdateUser";
            this.btnAddUpdateUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUpdateUser.TabIndex = 16;
            this.btnAddUpdateUser.Text = "Add/Update";
            this.btnAddUpdateUser.UseVisualStyleBackColor = true;
            this.btnAddUpdateUser.Click += new System.EventHandler(this.btnAddUpdateUser_Click);
            // 
            // chbAttendanceManagement
            // 
            this.chbAttendanceManagement.AutoSize = true;
            this.chbAttendanceManagement.Location = new System.Drawing.Point(219, 149);
            this.chbAttendanceManagement.Name = "chbAttendanceManagement";
            this.chbAttendanceManagement.Size = new System.Drawing.Size(146, 17);
            this.chbAttendanceManagement.TabIndex = 15;
            this.chbAttendanceManagement.Text = "Attendance Management";
            this.chbAttendanceManagement.UseVisualStyleBackColor = true;
            // 
            // chbWorkingCalendarManagement
            // 
            this.chbWorkingCalendarManagement.AutoSize = true;
            this.chbWorkingCalendarManagement.Location = new System.Drawing.Point(219, 126);
            this.chbWorkingCalendarManagement.Name = "chbWorkingCalendarManagement";
            this.chbWorkingCalendarManagement.Size = new System.Drawing.Size(176, 17);
            this.chbWorkingCalendarManagement.TabIndex = 14;
            this.chbWorkingCalendarManagement.Text = "Working Calendar Management";
            this.chbWorkingCalendarManagement.UseVisualStyleBackColor = true;
            // 
            // chbEmployeeManagement
            // 
            this.chbEmployeeManagement.AutoSize = true;
            this.chbEmployeeManagement.Location = new System.Drawing.Point(19, 149);
            this.chbEmployeeManagement.Name = "chbEmployeeManagement";
            this.chbEmployeeManagement.Size = new System.Drawing.Size(137, 17);
            this.chbEmployeeManagement.TabIndex = 13;
            this.chbEmployeeManagement.Text = "Employee Management";
            this.chbEmployeeManagement.UseVisualStyleBackColor = true;
            // 
            // chbTerminalManagement
            // 
            this.chbTerminalManagement.AutoSize = true;
            this.chbTerminalManagement.Location = new System.Drawing.Point(219, 103);
            this.chbTerminalManagement.Name = "chbTerminalManagement";
            this.chbTerminalManagement.Size = new System.Drawing.Size(131, 17);
            this.chbTerminalManagement.TabIndex = 12;
            this.chbTerminalManagement.Text = "Terminal Management";
            this.chbTerminalManagement.UseVisualStyleBackColor = true;
            // 
            // chbCompanyDepartmentManagement
            // 
            this.chbCompanyDepartmentManagement.AutoSize = true;
            this.chbCompanyDepartmentManagement.Location = new System.Drawing.Point(19, 126);
            this.chbCompanyDepartmentManagement.Name = "chbCompanyDepartmentManagement";
            this.chbCompanyDepartmentManagement.Size = new System.Drawing.Size(195, 17);
            this.chbCompanyDepartmentManagement.TabIndex = 11;
            this.chbCompanyDepartmentManagement.Text = "Company/Department Management";
            this.chbCompanyDepartmentManagement.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Access";
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(351, 46);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.Size = new System.Drawing.Size(115, 20);
            this.txtRetypePassword.TabIndex = 7;
            this.txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Retype password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chbUserManagement
            // 
            this.chbUserManagement.AutoSize = true;
            this.chbUserManagement.Location = new System.Drawing.Point(19, 103);
            this.chbUserManagement.Name = "chbUserManagement";
            this.chbUserManagement.Size = new System.Drawing.Size(113, 17);
            this.chbUserManagement.TabIndex = 4;
            this.chbUserManagement.Text = "User Management";
            this.chbUserManagement.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Employee Number";
            // 
            // ucUserManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxAddUpdateUser);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.label1);
            this.Name = "ucUserManagment";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.cmsDgvUser.ResumeLayout(false);
            this.gbxAddUpdateUser.ResumeLayout(false);
            this.gbxAddUpdateUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.GroupBox gbxAddUpdateUser;
        private System.Windows.Forms.CheckBox chbAttendanceManagement;
        private System.Windows.Forms.CheckBox chbWorkingCalendarManagement;
        private System.Windows.Forms.CheckBox chbEmployeeManagement;
        private System.Windows.Forms.CheckBox chbTerminalManagement;
        private System.Windows.Forms.CheckBox chbCompanyDepartmentManagement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chbUserManagement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddUpdateUser;
        private System.Windows.Forms.ComboBox cbxEmployeeNumber;
        private System.Windows.Forms.ContextMenuStrip cmsDgvUser;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Access;
    }
}
