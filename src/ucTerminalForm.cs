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
        private Point cellContext;
        private IDataController dtCtrl;
        private int terminalID;
        public ucTerminalForm()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
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
                Terminal terminal = dtCtrl.GetTerminal(terminalID);
                if (terminal == null)
                    return;
                this.terminalID = terminalID;
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
            List<Terminal> terminals = dtCtrl.GetTerminalList();
            dgvTerminal.DataSource = terminals;
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

            int id = dtCtrl.AddTerminal(terminal);

            MessageBox.Show(id > 0 ? "sucessfull" : "error");

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

            terminal.ID = terminalID;

            bool rs = dtCtrl.UpdateTerminal(terminal);
            MessageBox.Show(rs ? "sucessfull" : "error");
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
            int id = (int)dgvTerminal.Rows[cellContext.X].Cells[1].Value;
            BindTerminalData(id);
            SetState(id);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object oId = dgvTerminal.Rows[cellContext.X].Cells[1].Value;
            DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dlogRs.ToString().Equals("Yes"))
            {
                bool rs = dtCtrl.DeleteTerminal((int)oId);
                MessageBox.Show(rs ? "sucessfull" : "error");
                if (rs)
                    LoadData();
            }
        }

        private void dgvTerminal_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellContext = new Point(e.RowIndex, e.ColumnIndex);
        }
    }
}
