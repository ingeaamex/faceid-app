using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta
{
    public class Util
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
                return DateTime.Parse(str, new System.Globalization.CultureInfo("en-US", true));
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
                    WriteLog(icEx);
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

        public static void WriteLog(Exception ex)
        {
            WriteLog(ex.Message + " || " + ex.StackTrace);
        }

        public static void WriteLog(string log)
        {
            try
            {
                System.IO.StreamWriter swter = System.IO.File.AppendText(@"errorlog.txt");
                swter.WriteLine(DateTime.Now.ToString() + ":" + log);
                swter.Close();
            }
            catch { }
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

        public static void SetComboboxSelectedByValue(System.Windows.Forms.ComboBox cbx, object value)
        {
            cbx.SelectedIndex = cbx.FindString(value.ToString());
        }

        public static DateTime GetTheFirstDayOfCurrentMonth()
        {
            DateTime dt = DateTime.Today;
            dt.AddDays(-dt.Day + 1);

            return dt;
        }

        public static string GetMasterPassword()
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
        public static bool IsValidIP(string addr)
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

        public static bool ConfirmCancel()
        {
            return Confirm("Any unsaved data will be lost. Are you sure you want to cancel?");
        }

        public static bool ConfirmCloseForm()
        {
            return Confirm("Any unsaved data will be lost. Are you sure you want to close the form?");
        }

        public static System.Collections.Hashtable CutOffValue
        {
            get
            {
                System.Collections.Hashtable hshCutOffValue = new System.Collections.Hashtable();
                hshCutOffValue.Add(1, 0.5);
                hshCutOffValue.Add(5, 3);
                hshCutOffValue.Add(6, 3);
                hshCutOffValue.Add(10, 5);
                hshCutOffValue.Add(15, 7);
                hshCutOffValue.Add(30, 15);

                return hshCutOffValue;
            }
        }

        public static DateTime RoundDateTime(DateTime dt, int roundValue)
        {
            if(CutOffValue.ContainsKey(roundValue))
            {
                return RoundDateTime(dt, roundValue, Convert.ToDouble(CutOffValue[roundValue]));
            }

            return dt;
        }

        public static DateTime RoundDateTime(DateTime dt, int roundValue, double cutOffValue)
        {
            if (60 % roundValue != 0 || roundValue <= 0 || cutOffValue < 0 || cutOffValue >= roundValue)
                return dt;

            if (roundValue == 1) //round to 1 minute
            {
                roundValue *= 60;
                cutOffValue *= 60;

                int secDiff = dt.Second % roundValue;
                if (secDiff != 0)
                {
                    if (secDiff >= cutOffValue)
                    {
                        dt = dt.AddSeconds(roundValue - secDiff);
                    }
                    else
                    {
                        dt = dt.AddSeconds(-1 * secDiff);
                    }
                }
            }
            else
            {
                double minDiff = (dt.Minute % roundValue) + ((double)dt.Second / 60);
                if (minDiff != 0)
                {
                    if (minDiff >= cutOffValue)
                    {
                        dt = dt.AddMinutes(roundValue - minDiff);
                    }
                    else
                    {
                        dt = dt.AddMinutes(-1 * minDiff);
                    }
                }
            }

            return dt;
        }

        public static void BindCombobox(System.Windows.Forms.ComboBox cbx, List<ListItem> listItemList)
        {
            BindCombobox(cbx, listItemList, false);
        }

        public static void BindCombobox(System.Windows.Forms.ComboBox cbx, List<ListItem> listItemList, bool selectFirstItem)
        {
            cbx.DisplayMember = "Name";
            cbx.ValueMember = "Value";
            cbx.Items.Clear();

            cbx.DataSource = listItemList;

            if (selectFirstItem && cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;

        }
    }
}
