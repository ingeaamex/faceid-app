﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using FaceIDAppVBEta.Data;
using System.Runtime.Remoting;
using FaceIDAppVBEta.Class;
using System.Data.OleDb;
using FaceIDAppVBEta.Task;

namespace FaceIDAppVBEta
{
    public partial class MainForm : Form, IUserLoginCaller
    {
        private Color _originForeColor;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                _originForeColor = btnCompany.ForeColor;

                if (Properties.Settings.Default.IsClient)
                {
                    //TODO remove later
                    //RegisterChannel();
                    //RegisterService();

                    //client only
                    string serverIP = Properties.Settings.Default.ServerIP;
                    if (frmServerConnect.IsServerRunning(serverIP) == false)
                        new frmServerConnect().ShowDialog(this);
                }
                else
                {
                    //server only
                    //RegisterChannel();
                    //RegisterService();
                }

                if (VerifyUser() == false)
                    this.Close();
                else
                {
                    //TODO do tasks
                    TaskDoer.Instance.DoTasks();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
                Environment.Exit(0);
            }
        }

        private bool VerifyUser()
        {
            try
            {
                IDataController dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
                if (dtCtrl.GetFaceIDUserList().Count != 0)
                {
                    new frmUserLogin(this).ShowDialog(this);
                }

                return true;
            }
            catch (OleDbException)
            {
                MessageBox.Show("Cannot connect to Database. Please check then try again.");
                return false;
            }
        }

        //http://msdn.microsoft.com/en-us/library/5dxse167%28VS.71%29.aspx
        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;

            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = Properties.Settings.Default.ServerPort;

            ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
        }

        private void RegisterService()
        {
            string serviceName = Properties.Settings.Default.ServiceName;
            Type registeredType = typeof(LocalDataController);
            RemotingConfiguration.RegisterWellKnownServiceType(registeredType, serviceName, WellKnownObjectMode.Singleton);
        }

        //private void RequestService()
        //{
        //    Type lookupType = typeof(IDataController);
        //    IDataController _dtCtrl = (IDataController)Activator.GetObject(lookupType, "tcp://localhost:9999/DataController");

        //    _dtCtrl.AddHoliday(new Holiday());
        //}

        private void ChangeFunction(UserControl uc, Button btn)
        {
            try
            {
                sctMain.Panel2.Controls.Clear();
                sctMain.Panel2.Controls.Add(uc);

                UnHighlightAllButtons();
                HighlightButton(btn);
            }
            catch (OleDbException)
            {
                if (Properties.Settings.Default.IsClient)
                {
                    string message = "Cannot connect to database. Please check if the server machine is on and the network is working then try again.";
                    
                    MessageBox.Show(message);
                    Environment.Exit(0);
                }
                else
                {
                    string message = "Cannot connect to database. Please check if the server machine is on and the network is working then try again.";

                    MessageBox.Show(message);
                    Environment.Exit(0);
                }
            }
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucCompanyForm(), btnCompany);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucDepartmentForm(), btnDepartment);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucEmployeeForm(), btnEmployee);
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucTerminalForm(), btnTerminal);
        }

        private void btnWorkingCalendar_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucWorkingCalendar(), btnWorkingCalendar);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucAttendance(0), btnAttendance);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucUserManagment(), btnUser);
        }

        private void btnAttTest_Click(object sender, EventArgs e)
        {
            new FaceIDApp.Test().Show();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucReprocess(), btnReprocess);
        }

        #region IUserLoginCaller Members

        public void SetUserAccess(FaceIDUser user)
        {
            if (user != null) //not master
            {
                btnAttendance.Enabled = user.AttendanceManagementAccess;
                btnCompany.Enabled = user.CompanyDepartmentManagementAccess;
                btnDepartment.Enabled = user.CompanyDepartmentManagementAccess;
                btnEmployee.Enabled = user.EmployeeManagementAccess;
                btnReprocess.Enabled = user.AttendanceManagementAccess;
                btnTerminal.Enabled = user.TerminalManagementAccess;
                btnUser.Enabled = user.UserManagementAccess;
                btnWorkingCalendar.Enabled = user.WorkingCalendarManagementAccess;
            }
        }

        #endregion

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucSetting(), btnSetting);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ChangeFunction(new ucAttendance(1), btnExport);
        }

        private void HighlightButton(Button btn)
        {
            btn.ForeColor = Color.Red;
        }

        private void UnHighlightAllButtons()
        {
            btnCompany.ForeColor = _originForeColor;
            btnDepartment.ForeColor = _originForeColor;
            btnWorkingCalendar.ForeColor = _originForeColor;
            btnTerminal.ForeColor = _originForeColor;
            btnEmployee.ForeColor = _originForeColor;
            btnAttendance.ForeColor = _originForeColor;
            btnExport.ForeColor = _originForeColor;
            btnReprocess.ForeColor = _originForeColor;
            btnUser.ForeColor = _originForeColor;
            btnSetting.ForeColor = _originForeColor;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tsmHelpContents_Click(object sender, EventArgs e)
        {
            //TODO open CHM file
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            //TODO show frmAbout
            new frmAbout().ShowDialog(this);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskDoer.Instance.KillTasks();
            Environment.Exit(0);// Application.Exit();
        }
    }
}
