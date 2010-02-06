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
        private int _rowIndex;
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
                btnSubmit.Text = "Add";

                txtTerminalName.Text = "";
                mtbIPAddess.Text = "";

                _terminalID = -1;
            }
            else//update
            {
                this.Text = "Update Terminal";
                gBoxAction.Text = "Update Terminal";
                btnSubmit.Text = "Update";

                _terminalID = terminalID;

                BindTerminalData(terminalID);
            }
        }

        private void BindTerminalData(int terminalID)
        {
            if (terminalID <= 0)
            {
                txtTerminalName.Text = "";
                mtbIPAddess.Text = "";
            }
            else
            {
                Terminal terminal = _dtCtrl.GetTerminal(terminalID);
                if (terminal == null)
                {
                    MessageBox.Show("Terminal not found or has been deleted.");
                    SetState(0); //add
                    return;
                }

                this._terminalID = terminalID;
                txtTerminalName.Text = terminal.Name;

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
                mtbIPAddess.Text = ips;
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
            string terminalName = txtTerminalName.Text;
            string ipAddress = mtbIPAddess.Text.Replace(" ", "");

            bool isValid = true;

            if (string.IsNullOrEmpty(terminalName))
            {
                MessageBox.Show("Terminal Name must not be empty.");
                return null;
            }

            if (Util.IsValidIP(ipAddress) == false)
            {
                MessageBox.Show("Invalid IP Addess.");
                return null;
            }

            Terminal terminal = new Terminal();
            terminal.Name = terminalName;
            terminal.IPAddress = ipAddress;

            return terminal;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Terminal terminal = GetTerminalUserInput();

                if (terminal == null) //invalid input
                    return;

                if (_terminalID == -1) //add
                {
                    //check for duplicated teminal
                    if (_dtCtrl.IsDuplicateTerminal(terminal, false))
                    {
                        MessageBox.Show("This name or IP Address has been used by another Terminal.");
                        return;
                    }

                    if (_dtCtrl.AddTerminal(terminal) > 0)
                    {
                        MessageBox.Show("Terminal added.");
                        SetState(0);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Terminal could not be added. Please try again");
                    }
                }
                else //update
                {
                    terminal.ID = _terminalID;

                    //check for duplicated teminal
                    if (_dtCtrl.IsDuplicateTerminal(terminal, true))
                    {
                        MessageBox.Show("This name or IP Address has been used by another Terminal.");
                        return;
                    }

                    if (_dtCtrl.UpdateTerminal(terminal))
                    {
                        MessageBox.Show("Terminal updated.");
                        SetState(0);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Terminal could not be updated. Please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (Util.ConfirmCancel())
            {
                SetState(0);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int terminalID = GetSelectedTerminalID();
            SetState(terminalID);
        }

        private int GetSelectedTerminalID()
        {
            if (_rowIndex >= 0 && _rowIndex < dgvTerminal.Rows.Count)
                return Convert.ToInt16(dgvTerminal.Rows[_rowIndex].Cells[dgvTerminal.Columns["TerminalID"].Index].Value);
            else
                return -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int terminalID = GetSelectedTerminalID();

            if (Util.Confirm("Are you sure you want to delete this Terminal? This cannot be undone."))
            {
                _dtCtrl.BeginTransaction();

                try
                {

                    bool brs1 = _dtCtrl.DeleteTerminal(terminalID);
                    bool brs2 = _dtCtrl.DeleteEmployeeTerminal(terminalID);

                    if (brs1 && brs2)
                    {
                        _dtCtrl.CommitTransaction();
                        LoadData();
                        MessageBox.Show("Terminal deleted.");
                    }
                    else
                    {
                        throw new Exception("Terminal could not be deleted.");
                    }
                }
                catch (Exception ex)
                {
                    _dtCtrl.RollbackTransaction();
                    Util.ShowErrorMessage(ex);
                }
            }
        }

        private void dgvTerminal_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
        }
    }
}
