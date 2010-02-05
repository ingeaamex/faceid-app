﻿namespace FaceIDAppVBEta
{
    partial class ucBackup
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
            this.cbxScheduledBackup = new System.Windows.Forms.CheckBox();
            this.rbtBackupDaily = new System.Windows.Forms.RadioButton();
            this.rbtBackupWeekly = new System.Windows.Forms.RadioButton();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.btnSelectBackupFolder = new System.Windows.Forms.Button();
            this.cbxRemindBackup = new System.Windows.Forms.CheckBox();
            this.nudBackupPeriod = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxBackup = new System.Windows.Forms.GroupBox();
            this.cbxBackupWeeklyDay = new System.Windows.Forms.ComboBox();
            this.dtpBackupWeeklyTime = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBackUpDailyTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.gbxRestore = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.btnSelectRestoreFile = new System.Windows.Forms.Button();
            this.rbtRestoreFromFile = new System.Windows.Forms.RadioButton();
            this.rbtRestoreLastest = new System.Windows.Forms.RadioButton();
            this.gbxNoname1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackupPeriod)).BeginInit();
            this.gbxBackup.SuspendLayout();
            this.gbxRestore.SuspendLayout();
            this.gbxNoname1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxScheduledBackup
            // 
            this.cbxScheduledBackup.AutoSize = true;
            this.cbxScheduledBackup.Location = new System.Drawing.Point(16, 19);
            this.cbxScheduledBackup.Name = "cbxScheduledBackup";
            this.cbxScheduledBackup.Size = new System.Drawing.Size(117, 17);
            this.cbxScheduledBackup.TabIndex = 0;
            this.cbxScheduledBackup.Text = "Scheduled Backup";
            this.cbxScheduledBackup.UseVisualStyleBackColor = true;
            this.cbxScheduledBackup.CheckedChanged += new System.EventHandler(this.cbxScheduledBackup_CheckedChanged);
            // 
            // rbtBackupDaily
            // 
            this.rbtBackupDaily.AutoSize = true;
            this.rbtBackupDaily.Checked = true;
            this.rbtBackupDaily.Location = new System.Drawing.Point(34, 42);
            this.rbtBackupDaily.Name = "rbtBackupDaily";
            this.rbtBackupDaily.Size = new System.Drawing.Size(48, 17);
            this.rbtBackupDaily.TabIndex = 1;
            this.rbtBackupDaily.TabStop = true;
            this.rbtBackupDaily.Text = "Daily";
            this.rbtBackupDaily.UseVisualStyleBackColor = true;
            this.rbtBackupDaily.CheckedChanged += new System.EventHandler(this.rbtBackupDaily_CheckedChanged);
            // 
            // rbtBackupWeekly
            // 
            this.rbtBackupWeekly.AutoSize = true;
            this.rbtBackupWeekly.Location = new System.Drawing.Point(34, 65);
            this.rbtBackupWeekly.Name = "rbtBackupWeekly";
            this.rbtBackupWeekly.Size = new System.Drawing.Size(61, 17);
            this.rbtBackupWeekly.TabIndex = 2;
            this.rbtBackupWeekly.Text = "Weekly";
            this.rbtBackupWeekly.UseVisualStyleBackColor = true;
            this.rbtBackupWeekly.CheckedChanged += new System.EventHandler(this.rbtBackupWeekly_CheckedChanged);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(151, 155);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(90, 23);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup Now";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(151, 100);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(90, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore Now";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Backup To";
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Location = new System.Drawing.Point(98, 96);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(181, 20);
            this.txtBackupFolder.TabIndex = 6;
            // 
            // btnSelectBackupFolder
            // 
            this.btnSelectBackupFolder.Location = new System.Drawing.Point(285, 95);
            this.btnSelectBackupFolder.Name = "btnSelectBackupFolder";
            this.btnSelectBackupFolder.Size = new System.Drawing.Size(86, 23);
            this.btnSelectBackupFolder.TabIndex = 7;
            this.btnSelectBackupFolder.Text = "Select Folder";
            this.btnSelectBackupFolder.UseVisualStyleBackColor = true;
            this.btnSelectBackupFolder.Click += new System.EventHandler(this.btnSelectBackupFolder_Click);
            // 
            // cbxRemindBackup
            // 
            this.cbxRemindBackup.AutoSize = true;
            this.cbxRemindBackup.Location = new System.Drawing.Point(16, 132);
            this.cbxRemindBackup.Name = "cbxRemindBackup";
            this.cbxRemindBackup.Size = new System.Drawing.Size(253, 17);
            this.cbxRemindBackup.TabIndex = 10;
            this.cbxRemindBackup.Text = "Remind me to backup if backup file is older than";
            this.cbxRemindBackup.UseVisualStyleBackColor = true;
            this.cbxRemindBackup.CheckedChanged += new System.EventHandler(this.cbxRemindBackup_CheckedChanged);
            // 
            // nudBackupPeriod
            // 
            this.nudBackupPeriod.Location = new System.Drawing.Point(275, 130);
            this.nudBackupPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBackupPeriod.Name = "nudBackupPeriod";
            this.nudBackupPeriod.Size = new System.Drawing.Size(62, 20);
            this.nudBackupPeriod.TabIndex = 11;
            this.nudBackupPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "day(s)";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(132, 371);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(90, 23);
            this.btnSaveSettings.TabIndex = 13;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxBackup
            // 
            this.gbxBackup.Controls.Add(this.cbxBackupWeeklyDay);
            this.gbxBackup.Controls.Add(this.dtpBackupWeeklyTime);
            this.gbxBackup.Controls.Add(this.label9);
            this.gbxBackup.Controls.Add(this.dtpBackUpDailyTime);
            this.gbxBackup.Controls.Add(this.label8);
            this.gbxBackup.Controls.Add(this.cbxScheduledBackup);
            this.gbxBackup.Controls.Add(this.rbtBackupDaily);
            this.gbxBackup.Controls.Add(this.rbtBackupWeekly);
            this.gbxBackup.Controls.Add(this.label3);
            this.gbxBackup.Controls.Add(this.btnBackup);
            this.gbxBackup.Controls.Add(this.label1);
            this.gbxBackup.Controls.Add(this.nudBackupPeriod);
            this.gbxBackup.Controls.Add(this.txtBackupFolder);
            this.gbxBackup.Controls.Add(this.cbxRemindBackup);
            this.gbxBackup.Controls.Add(this.btnSelectBackupFolder);
            this.gbxBackup.Location = new System.Drawing.Point(25, 23);
            this.gbxBackup.Name = "gbxBackup";
            this.gbxBackup.Size = new System.Drawing.Size(392, 197);
            this.gbxBackup.TabIndex = 15;
            this.gbxBackup.TabStop = false;
            this.gbxBackup.Text = "Backup";
            // 
            // cbxBackupWeeklyDay
            // 
            this.cbxBackupWeeklyDay.FormattingEnabled = true;
            this.cbxBackupWeeklyDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbxBackupWeeklyDay.Location = new System.Drawing.Point(126, 63);
            this.cbxBackupWeeklyDay.Name = "cbxBackupWeeklyDay";
            this.cbxBackupWeeklyDay.Size = new System.Drawing.Size(121, 21);
            this.cbxBackupWeeklyDay.TabIndex = 17;
            // 
            // dtpBackupWeeklyTime
            // 
            this.dtpBackupWeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBackupWeeklyTime.Location = new System.Drawing.Point(253, 63);
            this.dtpBackupWeeklyTime.Name = "dtpBackupWeeklyTime";
            this.dtpBackupWeeklyTime.ShowUpDown = true;
            this.dtpBackupWeeklyTime.Size = new System.Drawing.Size(94, 20);
            this.dtpBackupWeeklyTime.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "on";
            // 
            // dtpBackUpDailyTime
            // 
            this.dtpBackUpDailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBackUpDailyTime.Location = new System.Drawing.Point(126, 40);
            this.dtpBackUpDailyTime.Name = "dtpBackUpDailyTime";
            this.dtpBackUpDailyTime.ShowUpDown = true;
            this.dtpBackUpDailyTime.Size = new System.Drawing.Size(94, 20);
            this.dtpBackUpDailyTime.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "at";
            // 
            // gbxRestore
            // 
            this.gbxRestore.Controls.Add(this.label2);
            this.gbxRestore.Controls.Add(this.txtRestoreFile);
            this.gbxRestore.Controls.Add(this.btnSelectRestoreFile);
            this.gbxRestore.Controls.Add(this.rbtRestoreFromFile);
            this.gbxRestore.Controls.Add(this.rbtRestoreLastest);
            this.gbxRestore.Controls.Add(this.btnRestore);
            this.gbxRestore.Location = new System.Drawing.Point(25, 226);
            this.gbxRestore.Name = "gbxRestore";
            this.gbxRestore.Size = new System.Drawing.Size(392, 139);
            this.gbxRestore.TabIndex = 16;
            this.gbxRestore.TabStop = false;
            this.gbxRestore.Text = "Restore";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Restore From";
            // 
            // txtRestoreFile
            // 
            this.txtRestoreFile.Location = new System.Drawing.Point(98, 73);
            this.txtRestoreFile.Name = "txtRestoreFile";
            this.txtRestoreFile.Size = new System.Drawing.Size(181, 20);
            this.txtRestoreFile.TabIndex = 9;
            // 
            // btnSelectRestoreFile
            // 
            this.btnSelectRestoreFile.Location = new System.Drawing.Point(285, 72);
            this.btnSelectRestoreFile.Name = "btnSelectRestoreFile";
            this.btnSelectRestoreFile.Size = new System.Drawing.Size(86, 23);
            this.btnSelectRestoreFile.TabIndex = 10;
            this.btnSelectRestoreFile.Text = "Select File";
            this.btnSelectRestoreFile.UseVisualStyleBackColor = true;
            this.btnSelectRestoreFile.Click += new System.EventHandler(this.btnSelectRestoreFile_Click);
            // 
            // rbtRestoreFromFile
            // 
            this.rbtRestoreFromFile.AutoSize = true;
            this.rbtRestoreFromFile.Location = new System.Drawing.Point(22, 51);
            this.rbtRestoreFromFile.Name = "rbtRestoreFromFile";
            this.rbtRestoreFromFile.Size = new System.Drawing.Size(183, 17);
            this.rbtRestoreFromFile.TabIndex = 6;
            this.rbtRestoreFromFile.TabStop = true;
            this.rbtRestoreFromFile.Text = "Restore from manually chosen file";
            this.rbtRestoreFromFile.UseVisualStyleBackColor = true;
            this.rbtRestoreFromFile.CheckedChanged += new System.EventHandler(this.rbtRestoreFromFile_CheckedChanged);
            // 
            // rbtRestoreLastest
            // 
            this.rbtRestoreLastest.AutoSize = true;
            this.rbtRestoreLastest.Checked = true;
            this.rbtRestoreLastest.Location = new System.Drawing.Point(22, 25);
            this.rbtRestoreLastest.Name = "rbtRestoreLastest";
            this.rbtRestoreLastest.Size = new System.Drawing.Size(175, 17);
            this.rbtRestoreLastest.TabIndex = 5;
            this.rbtRestoreLastest.TabStop = true;
            this.rbtRestoreLastest.Text = "Restore from the lastest backup";
            this.rbtRestoreLastest.UseVisualStyleBackColor = true;
            this.rbtRestoreLastest.CheckedChanged += new System.EventHandler(this.rbtRestoreLastest_CheckedChanged);
            // 
            // gbxNoname1
            // 
            this.gbxNoname1.Controls.Add(this.label7);
            this.gbxNoname1.Controls.Add(this.numericUpDown3);
            this.gbxNoname1.Controls.Add(this.label11);
            this.gbxNoname1.Controls.Add(this.label10);
            this.gbxNoname1.Controls.Add(this.numericUpDown2);
            this.gbxNoname1.Controls.Add(this.numericUpDown1);
            this.gbxNoname1.Controls.Add(this.label6);
            this.gbxNoname1.Controls.Add(this.label5);
            this.gbxNoname1.Controls.Add(this.label4);
            this.gbxNoname1.Controls.Add(this.checkBox1);
            this.gbxNoname1.Location = new System.Drawing.Point(423, 23);
            this.gbxNoname1.Name = "gbxNoname1";
            this.gbxNoname1.Size = new System.Drawing.Size(391, 197);
            this.gbxNoname1.TabIndex = 17;
            this.gbxNoname1.TabStop = false;
            this.gbxNoname1.Text = "Attendance";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(258, 69);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(258, 46);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "minute(s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Grace back to exit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Grace forward to entry";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(196, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Show Chart in Attendance Summary";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Attendance Record interval";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(258, 92);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown3.TabIndex = 16;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(326, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "second(s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "minute(s)";
            // 
            // ucBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxNoname1);
            this.Controls.Add(this.gbxRestore);
            this.Controls.Add(this.gbxBackup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveSettings);
            this.Name = "ucBackup";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.nudBackupPeriod)).EndInit();
            this.gbxBackup.ResumeLayout(false);
            this.gbxBackup.PerformLayout();
            this.gbxRestore.ResumeLayout(false);
            this.gbxRestore.PerformLayout();
            this.gbxNoname1.ResumeLayout(false);
            this.gbxNoname1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxScheduledBackup;
        private System.Windows.Forms.RadioButton rbtBackupDaily;
        private System.Windows.Forms.RadioButton rbtBackupWeekly;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Button btnSelectBackupFolder;
        private System.Windows.Forms.CheckBox cbxRemindBackup;
        private System.Windows.Forms.NumericUpDown nudBackupPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbxBackup;
        private System.Windows.Forms.GroupBox gbxRestore;
        private System.Windows.Forms.RadioButton rbtRestoreFromFile;
        private System.Windows.Forms.RadioButton rbtRestoreLastest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRestoreFile;
        private System.Windows.Forms.Button btnSelectRestoreFile;
        private System.Windows.Forms.GroupBox gbxNoname1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpBackUpDailyTime;
        private System.Windows.Forms.ComboBox cbxBackupWeeklyDay;
        private System.Windows.Forms.DateTimePicker dtpBackupWeeklyTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label11;
    }
}
