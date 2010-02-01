using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class ucTerminalForm : UserControl
    {
        private Point _cellContext;
        private IDataController _dtCtrl = LocalDataController.Instance;
        private int _terminalID;

        private ITerminalController _terCtrl = new TerminalController();

        public ucTerminalForm()
        {
            InitializeComponent();
            SetState(0);
            LoadData();
        }

        private void SetState(int terminalID)
        {
            if (terminalID <= 0)//add
            {
                this.Text = "Add New Terminal";
                gBoxAction.Text = "Add New Terminal";
                btAdd.Visible = true;
                btUpdate.Visible = false;
                btCancel.Visible = false;
                
            }
            else//update
            {
                this.Text = "Update Terminal";
                gBoxAction.Text = "Update Terminal";
                btAdd.Visible = false;
                btUpdate.Visible = true;
                btCancel.Visible = true;

                BindTerminalData(terminalID);
            }
        }

        private void BindTerminalData(int terminalID)
        {
            if (terminalID <= 0)
            {
                tbTerminalName.Text = "";
                mtbIpAddess.Text = "";
            }
            else
            {
                Terminal terminal = _dtCtrl.GetTerminal(terminalID);
                if (terminal == null)
                    return;
                this._terminalID = terminalID;
                tbTerminalName.Text = terminal.Name;
                string[] ip = terminal.IPAddress.Split('.');
                for (int i = 0; i < ip.Length;i++ )
                {
                    ip[i] = ip[i].Length < 3 ? ip[i] + " " : ip[i];
                    ip[i] = ip[i].Length < 3 ? ip[i] + " " : ip[i];
                }
                string ips = "";
                foreach (string s in ip)
                    ips += s + ".";
                ips = ips.Trim('.');
                mtbIpAddess.Text = ips;
            }
        }

        private void LoadData()
        {
            List<Terminal> terminalList = _dtCtrl.GetTerminalList();

            DataTable dtTerminal = new DataTable();
            dtTerminal.Columns.Add("ID");
            dtTerminal.Columns.Add("Name");
            dtTerminal.Columns.Add("IPAddress");
            dtTerminal.Columns.Add("Status");

            foreach (Terminal terminal in terminalList)
            {
                DataRow dr = dtTerminal.NewRow();
                dr["ID"] = terminal.ID;
                dr["Name"] = terminal.Name;
                dr["IPAddress"] = terminal.IPAddress;
                dr["Status"] = ""; // _terCtrl.IsTerminalConnected(terminal) ? "Connected" : "Not Connected";

                dtTerminal.Rows.Add(dr);
            }

            dgvTerminal.DataSource = dtTerminal;
        }

        private Terminal GetTerminalUserInput()
        {
            string sTerminalName = tbTerminalName.Text;
            string sIpAddess = mtbIpAddess.Text;

            bool isValid = true;
            if (string.IsNullOrEmpty(sTerminalName))
            {
                errProviders.SetError(tbTerminalName, "Enter Terminal Name");
                isValid = false;
            }

            if (string.IsNullOrEmpty(sIpAddess))
            {
                errProviders.SetError(mtbIpAddess, "Enter Ip Addess");
                isValid = false;
            }

            if (!isValid)
                return null;

            sIpAddess = sIpAddess.Replace(" ", "");
            Terminal terminal = new Terminal();
            terminal.Name = sTerminalName;
            terminal.IPAddress = sIpAddess;

            return terminal;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Terminal terminal = GetTerminalUserInput();

            if (terminal == null)
                return;

            int id = _dtCtrl.AddTerminal(terminal);

            MessageBox.Show(id > 0 ? "successful" : "error");

            if (id > 0)
            {
                SetState(0);
                LoadData();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Terminal terminal = GetTerminalUserInput();

            if (terminal == null)
                return;

            terminal.ID = _terminalID;

            bool rs = _dtCtrl.UpdateTerminal(terminal);
            MessageBox.Show(rs ? "successful" : "error");
            if (rs)
            {
                SetState(0);
                LoadData();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            SetState(0);
            BindTerminalData(0);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTerminal.Rows[_cellContext.X].Cells[dgvTerminal.Columns["TerminalID"].Index].Value;
            BindTerminalData(id);
            SetState(id);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int terminalID = Convert.ToInt16(dgvTerminal.Rows[_cellContext.X].Cells[dgvTerminal.Columns["TerminalID"].Index].Value);

            if (Util.Confirm("Are you sure?"))
            {
                _dtCtrl.BeginTransaction();

                bool brs1 = _dtCtrl.DeleteTerminal(terminalID);
                bool brs2 = _dtCtrl.DeleteEmployeeTerminal(terminalID);
                if (brs1 && brs2)
                {
                    _dtCtrl.CommitTransaction();
                    LoadData();
                    MessageBox.Show("successful");
                }
                else
                {
                    _dtCtrl.RollbackTransaction();
                    MessageBox.Show("error");
                }
            }
        }

        private void dgvTerminal_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _cellContext = new Point(e.RowIndex, e.ColumnIndex);
        }
    }
}
