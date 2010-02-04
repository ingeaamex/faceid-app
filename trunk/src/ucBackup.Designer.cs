namespace FaceIDAppVBEta
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
            this.gbxRestore = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.btnSelectRestoreFile = new System.Windows.Forms.Button();
            this.rbtRestoreFromFile = new System.Windows.Forms.RadioButton();
            this.rbtRestoreLastest = new System.Windows.Forms.RadioButton();
            this.gbxApperance = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackupPeriod)).BeginInit();
            this.gbxBackup.SuspendLayout();
            this.gbxRestore.SuspendLayout();
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
            // 
            // gbxApperance
            // 
            this.gbxApperance.Location = new System.Drawing.Point(423, 23);
            this.gbxApperance.Name = "gbxApperance";
            this.gbxApperance.Size = new System.Drawing.Size(381, 93);
            this.gbxApperance.TabIndex = 17;
            this.gbxApperance.TabStop = false;
            this.gbxApperance.Text = "Payroll Export";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(423, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 123);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(423, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 112);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // ucBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxApperance);
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
        private System.Windows.Forms.GroupBox gbxApperance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
