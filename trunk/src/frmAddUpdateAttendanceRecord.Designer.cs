namespace FaceIDAppVBEta
{
    partial class frmAddUpdateAttendanceRecord
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
            this.lbHeaderAction = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.nudEmployeeNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAttDate = new System.Windows.Forms.DateTimePicker();
            this.nudAttHour = new System.Windows.Forms.NumericUpDown();
            this.nudAttMin = new System.Windows.Forms.NumericUpDown();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.Note = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAttSec = new System.Windows.Forms.NumericUpDown();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeaderAction
            // 
            this.lbHeaderAction.AutoSize = true;
            this.lbHeaderAction.Location = new System.Drawing.Point(289, 37);
            this.lbHeaderAction.Name = "lbHeaderAction";
            this.lbHeaderAction.Size = new System.Drawing.Size(168, 13);
            this.lbHeaderAction.TabIndex = 0;
            this.lbHeaderAction.Text = "Add / Update Attendance Record";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(211, 87);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(302, 20);
            this.txtEmployeeName.TabIndex = 3;
            this.txtEmployeeName.Text = "Enter to search";
            // 
            // nudEmployeeNumber
            // 
            this.nudEmployeeNumber.Location = new System.Drawing.Point(211, 61);
            this.nudEmployeeNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudEmployeeNumber.Name = "nudEmployeeNumber";
            this.nudEmployeeNumber.Size = new System.Drawing.Size(120, 20);
            this.nudEmployeeNumber.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date";
            // 
            // dtpAttDate
            // 
            this.dtpAttDate.Location = new System.Drawing.Point(131, 125);
            this.dtpAttDate.Name = "dtpAttDate";
            this.dtpAttDate.Size = new System.Drawing.Size(200, 20);
            this.dtpAttDate.TabIndex = 6;
            // 
            // nudAttHour
            // 
            this.nudAttHour.Location = new System.Drawing.Point(434, 122);
            this.nudAttHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudAttHour.Name = "nudAttHour";
            this.nudAttHour.Size = new System.Drawing.Size(55, 20);
            this.nudAttHour.TabIndex = 7;
            // 
            // nudAttMin
            // 
            this.nudAttMin.Location = new System.Drawing.Point(495, 123);
            this.nudAttMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudAttMin.Name = "nudAttMin";
            this.nudAttMin.Size = new System.Drawing.Size(55, 20);
            this.nudAttMin.TabIndex = 8;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(165, 173);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(446, 91);
            this.txtNote.TabIndex = 10;
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Location = new System.Drawing.Point(92, 173);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(30, 13);
            this.Note.TabIndex = 9;
            this.Note.Text = "Note";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(92, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(92, 286);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(173, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudAttSec
            // 
            this.nudAttSec.Location = new System.Drawing.Point(556, 123);
            this.nudAttSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudAttSec.Name = "nudAttSec";
            this.nudAttSec.Size = new System.Drawing.Size(55, 20);
            this.nudAttSec.TabIndex = 8;
            // 
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // frmAddUpdateAttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 387);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.nudAttSec);
            this.Controls.Add(this.nudAttMin);
            this.Controls.Add(this.nudAttHour);
            this.Controls.Add(this.dtpAttDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudEmployeeNumber);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHeaderAction);
            this.Name = "frmAddUpdateAttendanceRecord";
            this.Text = "frmAddUpdateAttendanceRecord";
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeaderAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.NumericUpDown nudEmployeeNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAttDate;
        private System.Windows.Forms.NumericUpDown nudAttHour;
        private System.Windows.Forms.NumericUpDown nudAttMin;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAttSec;
        private System.Windows.Forms.ErrorProvider errProviders;
    }
}