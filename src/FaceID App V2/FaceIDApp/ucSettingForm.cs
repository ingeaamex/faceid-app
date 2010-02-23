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
using FaceIDAppVBEta.Task;

namespace FaceIDAppVBEta
{
    public partial class ucSetting : UserControl
    {
        private IDataController _dtCtrl;

        public ucSetting()
        {
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();

            BindWeekdays();
            BindRoundValue();
            EnableControls();

            RestoreOldSettings();

            gbxServerSetting.Enabled = Properties.Settings.Default.IsClient;
            gbxBackup.Enabled = !Properties.Settings.Default.IsClient;
            gbxRestore.Enabled = !Properties.Settings.Default.IsClient;
        }

        private void BindRoundValue()
        {
            List<ListItem> listItemList = new List<ListItem>();

            listItemList.Add(new ListItem(1));
            listItemList.Add(new ListItem(5));
            listItemList.Add(new ListItem(6));
            listItemList.Add(new ListItem(10));
            listItemList.Add(new ListItem(15));
            listItemList.Add(new ListItem(30));

            Util.BindCombobox(cbxRoundValue, listItemList, true);
        }

        private void BindWeekdays()
        {
            List<ListItem> listItemList = new List<ListItem>();

            listItemList.Add(new ListItem(0, "Monday"));
            listItemList.Add(new ListItem(1, "Tuesday"));
            listItemList.Add(new ListItem(2, "Wednesday"));
            listItemList.Add(new ListItem(3, "Thursday"));
            listItemList.Add(new ListItem(4, "Friday"));
            listItemList.Add(new ListItem(5, "Saturday"));
            listItemList.Add(new ListItem(6, "Sunday"));

            Util.BindCombobox(cbxBackupWeeklyDay, listItemList, true);
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
                config.LastestBackupFile = backupPath;
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
                if (Util.Confirm("Current database will be overwritten. This cannot be undone. Are you sure?") == false)
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
            //back up settings
            cbxScheduledBackup.Checked = config.ScheduledBackup;
            rbtBackupDaily.Checked = (config.BackupPeriod == 1);
            rbtBackupWeekly.Checked = (config.BackupPeriod == 7);

            dtpBackUpDailyTime.Value = config.BackupTime;
            cbxBackupWeeklyDay.SelectedIndex = config.BackupDay;
            dtpBackupWeeklyTime.Value = config.BackupTime;
                        
            txtBackupFolder.Text = config.BackupFolder;

            cbxRemindBackup.Checked = config.BackupRemind;
            nudBackupPeriod.Value = config.BackupRemindPeriod;
            
            //restore settings
            rbtRestoreLastest.Checked = config.RestoreFromLatest;
            rbtRestoreFromFile.Checked = !rbtRestoreLastest.Checked;
            txtRestoreFile.Text = config.RestoreFromFile;

            //attendance settings
            cbxRoundValue.SelectedIndex = cbxRoundValue.FindString(config.RecordRoundingValue.ToString());
            nudAttendanceRecordInterval.Value = config.AttendanceRecordInterval;

            if (Properties.Settings.Default.IsClient)
            {
                ipcServerIP.Text = Properties.Settings.Default.ServerIP;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveNewSettings();
        }

        private void SaveNewSettings()
        {
            //get settings
            Config config = _dtCtrl.GetConfig();

            //backup setting
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

            //restore setting
            config.RestoreFromLatest = rbtRestoreLastest.Checked;
            config.RestoreFromFile = txtRestoreFile.Text;

            //attendance setting
            config.AttendanceRecordInterval = (int)nudAttendanceRecordInterval.Value;
            config.RecordRoundingValue = (int)cbxRoundValue.SelectedValue;

            if(Properties.Settings.Default.IsClient)
            {
                Properties.Settings.Default.ServerIP = ipcServerIP.Text;
                Properties.Settings.Default.Save();
            }

            //save settings
            try
            {
                if (_dtCtrl.UpdateConfig(config) == false)
                    throw new Exception("Settings not saved.");

                MessageBox.Show("Settings saved.");
                TaskDoer.Instance.DoTasks();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
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
