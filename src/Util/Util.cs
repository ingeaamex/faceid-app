using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta
{
    public static class Util
    {
        public static FaceIDAppVBEta.Class.Config GetConfig()
        {
            throw new NotImplementedException();
            //System.Data.DataSet dataConfig = new System.Data.DataSet();
            //try
            //{
            //    dataConfig.ReadXmlSchema("config.xml");
            //}
            //catch
            //{
            //    return new FaceIDAppVBEta.Class.Config();
            //}

            //System.Xml.XmlDataDocument xmldoc = new System.Xml.XmlDataDocument(dataConfig);
            //xmldoc.Load("config.xml");
            //System.Data.DataTable tblDB = dataConfig.Tables[0];
            //FaceIDAppVBEta.Class.Config config = null;
            //if (tblDB.Rows.Count > 0)
            //{
            //    config = new FaceIDAppVBEta.Class.Config();
            //    config.DatabasePath = tblDB.Rows[0][0].ToString();
            //}
            //return config;
        }

        public static bool Confirm(string message)
        {
            return (System.Windows.Forms.MessageBox.Show(message, "Confirm!", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes);
        }

        public static bool IsNull(object obj)
        {
            if (obj == DBNull.Value) return true;
            if (obj == null) return true;
            return false;
        }

        public static DateTime ToDateTime(string str)
        {
            try
            {
                return DateTime.Parse(str, new System.Globalization.CultureInfo("vi-VN", true));
            }
            catch
            {
                return DateTime.Today;
            }
        }

        /// <summary>
        /// Fill a ComboxBox with numbers between minValue & maxValue
        /// </summary>
        /// <param name="cbx">The ComboBox to be filled</param>
        /// <param name="minValue">The smallest value to be filled</param>
        /// <param name="maxValue">The biggest value to be filled</param>
        /// <param name="defaultValue">The default value to be choose by default. Use 'null' for none.</param>
        /// <param name="addItemAll">'true' to add an "All" item at first</param>
        public static void FillComboxBoxNumber(System.Windows.Forms.ComboBox cbx, int minValue, int maxValue, object defaultValue, bool addItemAll)
        {
            cbx.Items.Clear();

            if (addItemAll)
                cbx.Items.Add("All");

            for (int i = minValue; i <= maxValue; i++)
            {
                cbx.Items.Add(i);

                try
                {
                    if (defaultValue != null && (int)defaultValue == i)
                    {
                        cbx.SelectedIndex = cbx.Items.Count - 1;
                    }
                }
                catch (InvalidCastException icEx)
                {
                    WriteLogs(icEx.Message);
                }
            }
        }

        /// <summary>
        /// Show user an Error Message using System.Windows.Forms.MessageBox
        /// </summary>
        /// <param name="errorMessage">Error Message</param>
        public static void ShowErrorMessage(string errorMessage)
        {
            System.Windows.Forms.MessageBox.Show(errorMessage, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void ShowErrorMessage(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("There has been an error. Please try again later. Error detail: " + ex.Message);
        }

        public static void WriteLogs(string log)
        {
            return;
        }

        public static int CompareTime(DateTime dt1, DateTime dt2)
        {
            dt2 = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt2.Hour, dt2.Minute, dt2.Second);

            return TimeSpan.FromTicks(dt1.Ticks - dt2.Ticks).Seconds;
        }

        public static int CompareDate(DateTime dt1, DateTime dt2)
        {
            int dateDiff = TimeSpan.FromTicks(dt1.Ticks - dt2.Ticks).Days;

            if (dateDiff < 0)
                dateDiff *= -1;

            return dateDiff;
        }

        internal static void SetComboboxSelectedByValue(System.Windows.Forms.ComboBox cbx, object value)
        {
            cbx.SelectedIndex = cbx.FindString(value.ToString());
        }

        internal static DateTime GetTheFirstDayOfCurrentMonth()
        {
            DateTime dt = DateTime.Today;
            dt.AddDays(-dt.Day + 1);

            return dt;
        }

        internal static string GetMasterPassword()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DateTime today = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            string digits = today.Ticks.ToString().Substring(4, 4);
            string letters = "";

            for (int i = 0; i < digits.Length; i++)
            {
                letters += Convert.ToChar(65 + i + (Convert.ToInt16(digits.Substring(i, 1))));
            }

            return letters + digits;
        }

        //copied from http://www.dreamincode.net/code/snippet1378.htm
        internal static bool IsValidIP(string addr)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

            //create our Regular Expression object
            System.Text.RegularExpressions.Regex check = new System.Text.RegularExpressions.Regex(pattern);

            //boolean variable to hold the status
            bool valid = false;

            //check to make sure an ip address was provided
            if (addr == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(addr, 0);
            }

            //return the results
            return valid;
        }
    }
}
