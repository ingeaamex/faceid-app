﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;
using System.IO;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class ucBackup : UserControl
    {
        private IDataController _dtCtrl;

        public ucBackup()
        {
            _dtCtrl = LocalDataController.Instance;

            InitializeComponent();

            BindWeekdays();
            RestoreOldSettings();
            EnableControls();
        }

        private void BindWeekdays()
        {
            cbxBackupWeeklyDay.DisplayMember = "Name";
            cbxBackupWeeklyDay.ValueMember = "Value";
            cbxBackupWeeklyDay.Items.Clear();

            cbxBackupWeeklyDay.Items.Add(new ListItem(0, "Monday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(1, "Tuesday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(2, "Wednesday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(3, "Thursday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(4, "Friday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(5, "Saturday"));
            cbxBackupWeeklyDay.Items.Add(new ListItem(6, "Sunday"));
        }

        private void EnableControls()
        {
            //backup
            rbtBackupDaily.Enabled = cbxScheduledBackup.Checked;
            rbtBackupWeekly.Enabled = cbxScheduledBackup.Checked;

            dtpBackUpDailyTime.Enabled = (rbtBackupDaily.Enabled && rbtBackupDaily.Checked);
            cbxBackupWeeklyDay.Enabled = (rbtBackupWeekly.Enabled && rbtBackupWeekly.Checked);
            dtpBackupWeeklyTime.Enabled = (rbtBackupWeekly.Enabled && rbtBackupWeekly.Checked);

            nudBackupPeriod.Enabled = cbxRemindBackup.Checked;

            //restore
            txtRestoreFile.Enabled = rbtRestoreFromFile.Checked;
            btnSelectRestoreFile.Enabled = rbtRestoreFromFile.Checked;
        }

        private void cbxScheduledBackup_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void cbxRemindBackup_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void rbtRestoreFromFile_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void btnSelectBackupFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdBackupFolder = new FolderBrowserDialog();

            if (fbdBackupFolder.ShowDialog() == DialogResult.OK)
            {
                txtBackupFolder.Text = fbdBackupFolder.SelectedPath;
            }
        }

        private void btnSelectRestoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdRestoreFile = new OpenFileDialog();
            ofdRestoreFile.Filter = "MDB file (*.mdb)|*.mdb";
            ofdRestoreFile.Multiselect = false;

            if (ofdRestoreFile.ShowDialog() == DialogResult.OK)
            {
                txtRestoreFile.Text = ofdRestoreFile.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            //get backup destination
            string fileName = "BK" + DateTime.Now.Ticks + ".mdb";
            string backupFolder = txtBackupFolder.Text;

            if (Directory.Exists(backupFolder) == false)
            {
                MessageBox.Show("Folder " + backupFolder + " not found.");
                return;
            }

            if (backupFolder.EndsWith(@"\") == false)
                backupFolder += @"\";

            string backupPath = backupFolder + fileName;

            //backup db
            try
            {
                _dtCtrl.BackupDatabase(backupPath);

                Config config = _dtCtrl.GetConfig();
                config.LastestBackup = DateTime.Now;
                _dtCtrl.UpdateConfig(config);

                MessageBox.Show("Backup Complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error. Please try again later. Error detail: " + ex.Message);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                //confirm
                if (Util.Confirm("Current database will be overwritten. This can not be undone. Are you sure?") == false)
                {
                    return;
                }

                //get restore file
                string restoreFile = "";

                if (rbtRestoreFromFile.Checked)
                {
                    restoreFile = txtRestoreFile.Text;
                    if (File.Exists(restoreFile) == false)
                    {
                        MessageBox.Show("File " + restoreFile + " not found.");
                        return;
                    }
                }
                else
                {
                    Config config = _dtCtrl.GetConfig();
                    restoreFile = config.LastestBackupFile;

                    if (File.Exists(restoreFile) == false)
                    {
                        MessageBox.Show("Lastest backup could not be found.");
                        return;
                    }
                }

                //restore db
                _dtCtrl.RestoreDatabase(restoreFile);
                MessageBox.Show("Restore Complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error. Please try again later. Error detail: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RestoreOldSettings();
        }

        private void RestoreOldSettings()
        {
            //read settings
            Config config = _dtCtrl.GetConfig();

            //set settings
            cbxScheduledBackup.Checked = config.ScheduledBackup;
            rbtBackupDaily.Checked = (config.BackupPeriod == 1);
            rbtBackupWeekly.Checked = (config.BackupPeriod == 7);

            dtpBackUpDailyTime.Value = config.BackupTime;
            cbxBackupWeeklyDay.SelectedIndex = config.BackupDay;
            dtpBackupWeeklyTime.Value = config.BackupTime;

            txtBackupFolder.Text = config.BackupFolder;

            cbxRemindBackup.Checked = config.BackupRemind;
            nudBackupPeriod.Value = config.BackupRemindPeriod;

            rbtRestoreLastest.Checked = config.RestoreFromLatest;
            rbtRestoreFromFile.Checked = !rbtRestoreLastest.Checked;
            txtRestoreFile.Text = config.RestoreFromFile;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveNewSettings();
        }

        private void SaveNewSettings()
        {
            //get settings
            Config config = _dtCtrl.GetConfig();

            config.ScheduledBackup = cbxScheduledBackup.Checked;

            if (rbtBackupDaily.Checked)
            {
                config.BackupPeriod = 1;
                config.BackupTime = dtpBackUpDailyTime.Value;
            }
            else if (rbtBackupWeekly.Checked)
            {
                config.BackupPeriod = 7;
                config.BackupDay = cbxBackupWeeklyDay.SelectedIndex;
                config.BackupTime = dtpBackupWeeklyTime.Value;
            }

            config.BackupFolder = txtBackupFolder.Text;
            if (config.ScheduledBackup && Directory.Exists(config.BackupFolder) == false)
            {
                MessageBox.Show("Backup Folder " + config.BackupFolder + " not found.");
                return;
            }

            config.BackupRemind = cbxRemindBackup.Checked;
            config.BackupRemindPeriod = (int)nudBackupPeriod.Value;

            config.RestoreFromLatest = rbtRestoreLastest.Checked;
            config.RestoreFromFile = txtRestoreFile.Text;

            //save settings
            try
            {
                if (_dtCtrl.UpdateConfig(config) == false)
                    throw new Exception("Settings not saved.");

                MessageBox.Show("Settings saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error. Please try again later. Error detail: " + ex.Message);
            }
        }

        private void rbtBackupDaily_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void rbtBackupWeekly_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void rbtRestoreLastest_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }
    }
}
