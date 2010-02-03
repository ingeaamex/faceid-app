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
        public frmUserLogin()
        {
            InitializeComponent();
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
                this.Close();
            }
            else
            {
                try
                {
                    IDataController dtCtrl = LocalDataController.Instance;

                    int employeeNumber = Convert.ToInt32(txtEmployeeNumber.Text);
                    FaceIDUser faceIDUser = dtCtrl.GetFaceIDUser(employeeNumber);

                    if (faceIDUser == null)
                    {
                        MessageBox.Show("User not found. Please try again.");
                    }
                    else
                    {
                        if (faceIDUser.Password != password)
                        {
                            MessageBox.Show("Incorrect password. Please try again.");
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Employee Number. Please try again.");
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Cannot connect to Database. Please try again.");
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
    }
}
