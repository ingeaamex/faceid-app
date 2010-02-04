using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;
using System.Data.OleDb;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class frmUserLogin : Form
    {
        private IUserLoginCaller _userLoginCaller = null;
        private FaceIDUser _user = null;
        private bool _isMaster = false;

        public frmUserLogin(IUserLoginCaller userLoginCaller)
        {
            InitializeComponent();
            _userLoginCaller = userLoginCaller;

            //TODO remove this later
            txtEmployeeNumber.Text = "Just press Enter to login";
            txtPassword.Text = Util.GetMasterPassword();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string password = txtPassword.Text;

            if (IsMasterPassword(password))
            {
                _isMaster = true;
                this.Close();
            }
            else
            {
                try
                {
                    IDataController dtCtrl = LocalDataController.Instance;

                    int employeeNumber = Convert.ToInt32(txtEmployeeNumber.Text);
                    _user = dtCtrl.GetFaceIDUser(employeeNumber);

                    if (_user == null)
                    {
                        MessageBox.Show("User not found.");
                    }
                    else
                    {
                        if (_user.Password != password)
                        {
                            MessageBox.Show("Incorrect password.");
                        }
                        else
                        {
                            _userLoginCaller.SetUserAccess(_user);
                            this.Close();                            
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Employee Number.");
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Cannot connect to Database.");
                    Application.Exit();
                }
                catch(Exception ex)
                {
                    Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again.");
                }
            }
        }

        private bool IsMasterPassword(string password)
        {
            return password == Util.GetMasterPassword();
        }

        private void frmUserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isMaster == false && _user == null)
                Application.Exit();
        }
    }
}
