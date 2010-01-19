﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta
{
    public static class Util
    {
        public static bool Confirm(string message)
        {
            return (System.Windows.Forms.MessageBox.Show(message, "Confirm!", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes);
        }

        public static bool isNull(object obj)
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

            if(addItemAll)
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

        public static void WriteLogs(string log)
        {
            return;
        }

        internal static void SetComboboxSelectedByValue(System.Windows.Forms.ComboBox cbxWorkDayRegularRate, int p)
        {
            throw new NotImplementedException();
        }

        internal static DateTime GetTheFirstDayOfCurrentMonth()
        {
            throw new NotImplementedException();
        }
    }
}
