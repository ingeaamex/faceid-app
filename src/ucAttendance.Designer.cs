namespace FaceIDAppVBEta
{
    partial class ucAttendance
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucAttendanceLog1 = new FaceIDAppVBEta.ucAttendanceLog();
            this.ucAttendanceReport1 = new FaceIDAppVBEta.ucAttendanceReport();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 477);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucAttendanceLog1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1202, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Attendance Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucAttendanceReport1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1202, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attendance Summary / Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucAttendanceLog1
            // 
            this.ucAttendanceLog1.Location = new System.Drawing.Point(7, 7);
            this.ucAttendanceLog1.Name = "ucAttendanceLog1";
            this.ucAttendanceLog1.Size = new System.Drawing.Size(1058, 475);
            this.ucAttendanceLog1.TabIndex = 0;
            this.ucAttendanceLog1.Load += new System.EventHandler(this.ucAttendanceLog1_Load);
            // 
            // ucAttendanceReport1
            // 
            this.ucAttendanceReport1.Location = new System.Drawing.Point(6, 6);
            this.ucAttendanceReport1.Name = "ucAttendanceReport1";
            this.ucAttendanceReport1.Size = new System.Drawing.Size(923, 534);
            this.ucAttendanceReport1.TabIndex = 0;
            // 
            // ucAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucAttendance";
            this.Size = new System.Drawing.Size(1252, 606);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucAttendanceLog ucAttendanceLog1;
        private ucAttendanceReport ucAttendanceReport1;
    }
}
