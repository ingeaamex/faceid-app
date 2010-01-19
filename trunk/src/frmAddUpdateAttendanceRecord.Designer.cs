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
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttMin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add / Update Attendance Record";
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
            this.nudAttMin.Location = new System.Drawing.Point(495, 122);
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
            this.Note.Size = new System.Drawing.Size(35, 13);
            this.Note.TabIndex = 9;
            this.Note.Text = "label5";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(74, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(184, 286);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(292, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.nudAttMin);
            this.Controls.Add(this.nudAttHour);
            this.Controls.Add(this.dtpAttDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudEmployeeNumber);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddUpdateAttendanceRecord";
            this.Text = "frmAddUpdateAttendanceRecord";
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
    }
}