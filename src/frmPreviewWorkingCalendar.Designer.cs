namespace FaceIDAppVBEta
{
    partial class frmPreviewWorkingCalendar
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
            this.gbxWorkingHours = new System.Windows.Forms.GroupBox();
            this.lblWorkTo = new System.Windows.Forms.Label();
            this.lblWorkFrom = new System.Windows.Forms.Label();
            this.lblBreak3 = new System.Windows.Forms.Label();
            this.lblBreak2 = new System.Windows.Forms.Label();
            this.lblBreak1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPayPeriodStartFrom = new System.Windows.Forms.Label();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mclWorkingCalendar = new Pabo.Calendar.MonthCalendar();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbxWorkDay = new System.Windows.Forms.PictureBox();
            this.pbxNonWorkDay = new System.Windows.Forms.PictureBox();
            this.pbxHoliday = new System.Windows.Forms.PictureBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.ucWorkingDayPaymentRate = new FaceIDAppVBEta.ucPaymentRate();
            this.ucNonWorkingDayPaymentRate = new FaceIDAppVBEta.ucPaymentRate();
            this.ucHolidayPaymentRate = new FaceIDAppVBEta.ucPaymentRate();
            this.gbxWorkingHours.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNonWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHoliday)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxWorkingHours
            // 
            this.gbxWorkingHours.Controls.Add(this.lblWorkTo);
            this.gbxWorkingHours.Controls.Add(this.lblWorkFrom);
            this.gbxWorkingHours.Controls.Add(this.lblBreak3);
            this.gbxWorkingHours.Controls.Add(this.lblBreak2);
            this.gbxWorkingHours.Controls.Add(this.lblBreak1);
            this.gbxWorkingHours.Controls.Add(this.label3);
            this.gbxWorkingHours.Controls.Add(this.label2);
            this.gbxWorkingHours.Controls.Add(this.label1);
            this.gbxWorkingHours.Location = new System.Drawing.Point(335, 12);
            this.gbxWorkingHours.Name = "gbxWorkingHours";
            this.gbxWorkingHours.Size = new System.Drawing.Size(312, 140);
            this.gbxWorkingHours.TabIndex = 0;
            this.gbxWorkingHours.TabStop = false;
            this.gbxWorkingHours.Text = "Working Hours";
            // 
            // lblWorkTo
            // 
            this.lblWorkTo.AutoSize = true;
            this.lblWorkTo.Location = new System.Drawing.Point(69, 51);
            this.lblWorkTo.Name = "lblWorkTo";
            this.lblWorkTo.Size = new System.Drawing.Size(47, 13);
            this.lblWorkTo.TabIndex = 7;
            this.lblWorkTo.Text = "6:00 PM";
            // 
            // lblWorkFrom
            // 
            this.lblWorkFrom.AutoSize = true;
            this.lblWorkFrom.Location = new System.Drawing.Point(69, 23);
            this.lblWorkFrom.Name = "lblWorkFrom";
            this.lblWorkFrom.Size = new System.Drawing.Size(47, 13);
            this.lblWorkFrom.TabIndex = 6;
            this.lblWorkFrom.Text = "9:00 AM";
            // 
            // lblBreak3
            // 
            this.lblBreak3.AutoSize = true;
            this.lblBreak3.Location = new System.Drawing.Point(69, 119);
            this.lblBreak3.Name = "lblBreak3";
            this.lblBreak3.Size = new System.Drawing.Size(96, 13);
            this.lblBreak3.TabIndex = 5;
            this.lblBreak3.Text = "3:30 PM - 3:40 PM";
            // 
            // lblBreak2
            // 
            this.lblBreak2.AutoSize = true;
            this.lblBreak2.Location = new System.Drawing.Point(69, 99);
            this.lblBreak2.Name = "lblBreak2";
            this.lblBreak2.Size = new System.Drawing.Size(96, 13);
            this.lblBreak2.TabIndex = 4;
            this.lblBreak2.Text = "0:30 PM - 1:30 PM";
            // 
            // lblBreak1
            // 
            this.lblBreak1.AutoSize = true;
            this.lblBreak1.Location = new System.Drawing.Point(69, 79);
            this.lblBreak1.Name = "lblBreak1";
            this.lblBreak1.Size = new System.Drawing.Size(108, 13);
            this.lblBreak1.TabIndex = 3;
            this.lblBreak1.Text = "11:00 AM - 11:10 AM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Break";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(332, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Rate";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 156);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucWorkingDayPaymentRate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(280, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Working day rate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucNonWorkingDayPaymentRate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(280, 130);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Non-working day rate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucHolidayPaymentRate);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(280, 130);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Holiday rate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPayPeriodStartFrom);
            this.groupBox2.Controls.Add(this.lblPayPeriod);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(332, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pay Period";
            // 
            // lblPayPeriodStartFrom
            // 
            this.lblPayPeriodStartFrom.AutoSize = true;
            this.lblPayPeriodStartFrom.Location = new System.Drawing.Point(69, 46);
            this.lblPayPeriodStartFrom.Name = "lblPayPeriodStartFrom";
            this.lblPayPeriodStartFrom.Size = new System.Drawing.Size(68, 13);
            this.lblPayPeriodStartFrom.TabIndex = 3;
            this.lblPayPeriodStartFrom.Text = "1st Jan 2010";
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.AutoSize = true;
            this.lblPayPeriod.Location = new System.Drawing.Point(69, 18);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(68, 13);
            this.lblPayPeriod.TabIndex = 2;
            this.lblPayPeriod.Text = "Every 5 days";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Start From";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Pay Period";
            // 
            // mclWorkingCalendar
            // 
            this.mclWorkingCalendar.ActiveMonth.Month = 1;
            this.mclWorkingCalendar.ActiveMonth.Year = 2010;
            this.mclWorkingCalendar.Culture = new System.Globalization.CultureInfo("en-AU");
            this.mclWorkingCalendar.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mclWorkingCalendar.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mclWorkingCalendar.Header.TextColor = System.Drawing.Color.White;
            this.mclWorkingCalendar.Header.YearSelectors = true;
            this.mclWorkingCalendar.ImageList = null;
            this.mclWorkingCalendar.Location = new System.Drawing.Point(12, 12);
            this.mclWorkingCalendar.MaxDate = new System.DateTime(2900, 12, 31, 0, 0, 0, 0);
            this.mclWorkingCalendar.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.mclWorkingCalendar.Month.BackgroundImage = null;
            this.mclWorkingCalendar.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mclWorkingCalendar.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mclWorkingCalendar.Name = "mclWorkingCalendar";
            this.mclWorkingCalendar.SelectionMode = Pabo.Calendar.mcSelectionMode.None;
            this.mclWorkingCalendar.ShowFooter = false;
            this.mclWorkingCalendar.Size = new System.Drawing.Size(300, 300);
            this.mclWorkingCalendar.TabIndex = 3;
            this.mclWorkingCalendar.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mclWorkingCalendar.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mclWorkingCalendar.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.mclWorkingCalendar_MonthChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(255, 454);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(337, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbxWorkDay
            // 
            this.pbxWorkDay.BackColor = System.Drawing.Color.White;
            this.pbxWorkDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxWorkDay.Location = new System.Drawing.Point(12, 340);
            this.pbxWorkDay.Name = "pbxWorkDay";
            this.pbxWorkDay.Size = new System.Drawing.Size(45, 43);
            this.pbxWorkDay.TabIndex = 6;
            this.pbxWorkDay.TabStop = false;
            // 
            // pbxNonWorkDay
            // 
            this.pbxNonWorkDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbxNonWorkDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxNonWorkDay.Location = new System.Drawing.Point(12, 387);
            this.pbxNonWorkDay.Name = "pbxNonWorkDay";
            this.pbxNonWorkDay.Size = new System.Drawing.Size(45, 43);
            this.pbxNonWorkDay.TabIndex = 7;
            this.pbxNonWorkDay.TabStop = false;
            // 
            // pbxHoliday
            // 
            this.pbxHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pbxHoliday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxHoliday.Location = new System.Drawing.Point(12, 434);
            this.pbxHoliday.Name = "pbxHoliday";
            this.pbxHoliday.Size = new System.Drawing.Size(45, 43);
            this.pbxHoliday.TabIndex = 8;
            this.pbxHoliday.TabStop = false;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(80, 355);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(69, 13);
            this.label88.TabIndex = 9;
            this.label88.Text = "Working Day";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(80, 402);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(92, 13);
            this.label89.TabIndex = 10;
            this.label89.Text = "Non-Working Day";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(80, 449);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(42, 13);
            this.label90.TabIndex = 11;
            this.label90.Text = "Holiday";
            // 
            // ucWorkingDayPaymentRate
            // 
            this.ucWorkingDayPaymentRate.Location = new System.Drawing.Point(0, 0);
            this.ucWorkingDayPaymentRate.Name = "ucWorkingDayPaymentRate";
            this.ucWorkingDayPaymentRate.Size = new System.Drawing.Size(280, 130);
            this.ucWorkingDayPaymentRate.TabIndex = 0;
            // 
            // ucNonWorkingDayPaymentRate
            // 
            this.ucNonWorkingDayPaymentRate.Location = new System.Drawing.Point(0, 0);
            this.ucNonWorkingDayPaymentRate.Name = "ucNonWorkingDayPaymentRate";
            this.ucNonWorkingDayPaymentRate.Size = new System.Drawing.Size(280, 130);
            this.ucNonWorkingDayPaymentRate.TabIndex = 0;
            // 
            // ucHolidayPaymentRate
            // 
            this.ucHolidayPaymentRate.Location = new System.Drawing.Point(0, 0);
            this.ucHolidayPaymentRate.Name = "ucHolidayPaymentRate";
            this.ucHolidayPaymentRate.Size = new System.Drawing.Size(280, 130);
            this.ucHolidayPaymentRate.TabIndex = 0;
            // 
            // frmPreviewWorkingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 490);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.pbxHoliday);
            this.Controls.Add(this.pbxNonWorkDay);
            this.Controls.Add(this.pbxWorkDay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.mclWorkingCalendar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxWorkingHours);
            this.Name = "frmPreviewWorkingCalendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Working Calendar Preview";
            this.gbxWorkingHours.ResumeLayout(false);
            this.gbxWorkingHours.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNonWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHoliday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxWorkingHours;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWorkTo;
        private System.Windows.Forms.Label lblWorkFrom;
        private System.Windows.Forms.Label lblBreak3;
        private System.Windows.Forms.Label lblBreak2;
        private System.Windows.Forms.Label lblBreak1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.Label lblPayPeriodStartFrom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Pabo.Calendar.MonthCalendar mclWorkingCalendar;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbxWorkDay;
        private System.Windows.Forms.PictureBox pbxNonWorkDay;
        private System.Windows.Forms.PictureBox pbxHoliday;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label90;
        private ucPaymentRate ucWorkingDayPaymentRate;
        private ucPaymentRate ucNonWorkingDayPaymentRate;
        private ucPaymentRate ucHolidayPaymentRate;
    }
}