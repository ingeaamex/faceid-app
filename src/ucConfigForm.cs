using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class ucConfigForm : UserControl
    {
        public ucConfigForm()
        {
            InitializeComponent();

            LoadConfig();
            openFileDialog1.FileOk += new CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.Filter = "DB files (*.mdb)|*.mdb";
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dlogRs = openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, EventArgs e)
        {
            tbFilePath.Text = openFileDialog1.FileName;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            string path = tbFilePath.Text;

            StringBuilder strb = new StringBuilder();
            strb.Append("<CONFIG>");
            strb.AppendFormat("<DB_PATH>{0}</DB_PATH>\r\n", path);
            strb.Append("</CONFIG>");
            try
            {
                System.IO.File.WriteAllText("config.xml", strb.ToString());
                MessageBox.Show("successful");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        void LoadConfig()
        {
            Config config = Util.GetConfig();
            if (config != null)
            {
                tbFilePath.Text = config.DatabasePath;
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
}
