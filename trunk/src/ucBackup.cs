using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;
using System.IO;

namespace FaceIDAppVBEta
{
    public partial class ucBackup : UserControl
    {
        private IDataController _dtCtrl;

        public ucBackup()
        {
            _dtCtrl = LocalDataController.Instance;

            InitializeComponent();

            RestoreOldSettings();
            EnableControls();
        }

        private void EnableControls()
        {
            rbtBackupDaily.Enabled = cbxScheduledBackup.Checked;
            rbtBackupWeekly.Enabled = cbxScheduledBackup.Checked;

            nudBackupPeriod.Enabled = cbxRemindBackup.Checked;

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

            if(backupFolder.EndsWith(@"\") == false)
                backupFolder+= @"\";

            string backupPath = backupFolder + fileName;

            //backup db
            try
            {
                _dtCtrl.BackupDatabase(backupPath);
                MessageBox.Show("Backup Complete.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("There has been an error. Please try again later. Error detail: " + ex.Message);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //confirm
            if (Util.Confirm("Current database will be overwritten. This can not be undone. Are you sure?") == false)
            {
                return;
            }

            //get restore file
            string restoreFile = txtRestoreFile.Text;
            if (File.Exists(restoreFile) == false)
            {
                MessageBox.Show("File " + restoreFile + " not found.");
                return;
            }

            //restore db
            try
            {
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
            throw new NotImplementedException();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveNewSettings();
        }

        private void SaveNewSettings()
        {
            throw new NotImplementedException();
        }
    }
}
