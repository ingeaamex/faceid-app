using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            BeServer();
        }

        private void BeServer()
        {
            //System.Runtime.Remoting.Channels.Tcp.TcpChannel channel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(9999);
            //System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, true);
            ////System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(FaceIDAppVBEta.Data.LocalDataController), "tcp://localhost:9999/DataController", System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            ////System.Runtime.Remoting.RemotingServices.Marshal(FaceIDAppVBEta.Data.LocalDataController.Instance, "DataController");
            //System.Runtime.Remoting.RemotingConfiguration.RegisterActivatedServiceType(typeof(FaceIDAppVBEta.Data.LocalDataController));

            //FaceIDAppVBEta.Class.Holiday holiday = new FaceIDAppVBEta.Class.Holiday();
            //holiday.Date = DateTime.Today;
            //holiday.Description = "";

            ////holiday.ID = FaceIDAppVBEta.Data.RemoteDataController.Instance.AddHoliday(holiday);

            ////FaceIDAppVBEta.Data.IDataController _dtCtrl = (FaceIDAppVBEta.Data.IDataController)Activator.GetObject(typeof(FaceIDAppVBEta.Data.LocalDataController), "tcp://localhost:9999/DataController");

            //object[] attr = { new System.Runtime.Remoting.Activation.UrlAttribute("tcp://localhost:9999") };
            //object[] args = { "Sample constructor argument" };
            //FaceIDAppVBEta.Data.IDataController _dtCtrl = (FaceIDAppVBEta.Data.IDataController)Activator.CreateInstance(typeof(FaceIDAppVBEta.Data.LocalDataController), args, attr);

            //int i = _dtCtrl.AddHoliday(holiday);
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucCompanyForm());
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucDepartmentForm());
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucEmployeeForm());
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucTerminalForm());
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucCompanyForm());
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucDepartmentForm());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucEmployeeForm());
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucTerminalForm());
        }

        private void btnWorkingCalendar_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucWorkingCalendar());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucAttendance());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucUserManagment());
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucConfigForm());
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceIDAppVBEta.Data.LocalDataController dtCtrl = FaceIDAppVBEta.Data.LocalDataController.Instance;
            dtCtrl.CalculateAttendanceRecord();
        }

        private void btnAttTest_Click(object sender, EventArgs e)
        {
            new FaceIDApp.Test().Show();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucReprocess());
        }
    }
}
