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
            this.ucAttendanceLog1 = new FaceIDAppVBEta.ucAttendanceLog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucAttendanceReport1 = new FaceIDAppVBEta.ucAttendanceReport();
            this.btnCollectAttendanceData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 606);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucAttendanceLog1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(831, 580);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Attendance Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucAttendanceLog1
            // 
            this.ucAttendanceLog1.Location = new System.Drawing.Point(0, 0);
            this.ucAttendanceLog1.Name = "ucAttendanceLog1";
            this.ucAttendanceLog1.Size = new System.Drawing.Size(831, 580);
            this.ucAttendanceLog1.TabIndex = 0;
            this.ucAttendanceLog1.Load += new System.EventHandler(this.ucAttendanceLog1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucAttendanceReport1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(831, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attendance Summary / Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucAttendanceReport1
            // 
            this.ucAttendanceReport1.Location = new System.Drawing.Point(0, 0);
            this.ucAttendanceReport1.Name = "ucAttendanceReport1";
            this.ucAttendanceReport1.Size = new System.Drawing.Size(831, 580);
            this.ucAttendanceReport1.TabIndex = 0;
            // 
            // btnCollectAttendanceData
            // 
            this.btnCollectAttendanceData.Location = new System.Drawing.Point(7, 16);
            this.btnCollectAttendanceData.Name = "btnCollectAttendanceData";
            this.btnCollectAttendanceData.Size = new System.Drawing.Size(241, 23);
            this.btnCollectAttendanceData.TabIndex = 1;
            this.btnCollectAttendanceData.Text = "Collect Attendance Data from Terminals";
            this.btnCollectAttendanceData.UseVisualStyleBackColor = true;
            this.btnCollectAttendanceData.Click += new System.EventHandler(this.btnCollectAttendanceData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attendance Management";
            // 
            // ucAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCollectAttendanceData);
            this.Controls.Add(this.tabControl1);
            this.Name = "ucAttendance";
            this.Size = new System.Drawing.Size(845, 662);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucAttendanceLog ucAttendanceLog1;
        private ucAttendanceReport ucAttendanceReport1;
        private System.Windows.Forms.Button btnCollectAttendanceData;
        private System.Windows.Forms.Label label1;
    }
}
