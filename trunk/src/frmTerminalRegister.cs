using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class frmTerminalRegister : Form
    {
        private IDataController dtCtrl;
        private frmAddUpdateEmployee callbackForm;
        private bool isAlert = true;
        public frmTerminalRegister(Form callbackForm)
        {
            this.callbackForm = (frmAddUpdateEmployee)callbackForm;
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            BindData();
        }

        private void BindData()
        {
            List<Terminal> terminals = dtCtrl.GetTerminalList();
            lbxAvailTerminal.DataSource = terminals;

            List<Terminal> regRerminals = callbackForm.GetTerminalsUserInput();
            foreach (Terminal o in regRerminals)
            {
                lbxRegTerminal.Items.Add(o);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lbxRegTerminal.Items.Count > 0)
            {
                ListBox.ObjectCollection oTerminals = lbxRegTerminal.Items;
                List<Terminal> terminals = new List<Terminal>();
                foreach (Object o in oTerminals)
                {
                    terminals.Add((Terminal)o);
                }
                callbackForm.SetTerminalValues(terminals);
            }
            isAlert = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAlert = false;
            this.Close();
        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection items = lbxAvailTerminal.SelectedItems;
            ListBox.ObjectCollection objc = lbxRegTerminal.Items;
            bool isExist = false;
            for (int i = 0; i < items.Count; i++)
            {
                isExist = false;
                foreach (Object o in objc)
                {
                    if (((Terminal)o).ID == ((Terminal)items[i]).ID)
                    {
                        MessageBox.Show(((Terminal)items[i]).Name + " Equipment has registered");
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                    lbxRegTerminal.Items.Add(items[i]);
            }
        }

        private void btnRemoveTerminal_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection items = lbxRegTerminal.SelectedItems;
            while (items.Count > 0)
            {
                lbxRegTerminal.Items.Remove(items[0]);
            }
        }

        private void frmTerminalRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAlert)
            {
                DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Make sure that your changes have been updated. Click \"Cancel\" to continue or \"OK\" to closed.", "Confirm", MessageBoxButtons.YesNo);
                if (dlogRs.ToString().Equals("No"))
                    e.Cancel = true;
            }
        }
    }
}
