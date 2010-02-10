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
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAttDate = new System.Windows.Forms.DateTimePicker();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.Note = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpAttTime = new System.Windows.Forms.DateTimePicker();
            this.cbxEmployeeNumber = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeaderAction
            // 
            this.lbHeaderAction.AutoSize = true;
            this.lbHeaderAction.Location = new System.Drawing.Point(222, 11);
            this.lbHeaderAction.Name = "lbHeaderAction";
            this.lbHeaderAction.Size = new System.Drawing.Size(168, 13);
            this.lbHeaderAction.TabIndex = 0;
            this.lbHeaderAction.Text = "Add / Update Attendance Record";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEmployeeName.Location = new System.Drawing.Point(122, 73);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(302, 20);
            this.txtEmployeeName.TabIndex = 2;
            this.txtEmployeeName.Text = "Enter to search";
            this.txtEmployeeName.Leave += new System.EventHandler(this.txtEmployeeName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date";
            // 
            // dtpAttDate
            // 
            this.dtpAttDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttDate.Location = new System.Drawing.Point(122, 98);
            this.dtpAttDate.Name = "dtpAttDate";
            this.dtpAttDate.Size = new System.Drawing.Size(120, 20);
            this.dtpAttDate.TabIndex = 3;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(122, 148);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(446, 91);
            this.txtNote.TabIndex = 5;
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Location = new System.Drawing.Point(23, 187);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(30, 13);
            this.Note.TabIndex = 9;
            this.Note.Text = "Note";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(122, 244);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(41, 243);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // dtpAttTime
            // 
            this.dtpAttTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpAttTime.Location = new System.Drawing.Point(122, 123);
            this.dtpAttTime.Name = "dtpAttTime";
            this.dtpAttTime.ShowUpDown = true;
            this.dtpAttTime.Size = new System.Drawing.Size(120, 20);
            this.dtpAttTime.TabIndex = 4;
            // 
            // cbxEmployeeNumber
            // 
            this.cbxEmployeeNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmployeeNumber.FormattingEnabled = true;
            this.cbxEmployeeNumber.Location = new System.Drawing.Point(122, 48);
            this.cbxEmployeeNumber.Name = "cbxEmployeeNumber";
            this.cbxEmployeeNumber.Size = new System.Drawing.Size(120, 21);
            this.cbxEmployeeNumber.TabIndex = 1;
            this.cbxEmployeeNumber.SelectedIndexChanged += new System.EventHandler(this.cbxEmployeeNumber_SelectedIndexChanged);
            // 
            // frmAddUpdateAttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 278);
            this.Controls.Add(this.cbxEmployeeNumber);
            this.Controls.Add(this.dtpAttTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.dtpAttDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHeaderAction);
            this.Name = "frmAddUpdateAttendanceRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdateAttendanceRecord";
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeaderAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAttDate;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errProviders;
        private System.Windows.Forms.DateTimePicker dtpAttTime;
        private System.Windows.Forms.ComboBox cbxEmployeeNumber;
    }
}