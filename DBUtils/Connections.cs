using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DBUtils
{
    public class Connections
    {
        public string msgErr;
        public int codeErr;
        private OleDbConnection conn;
        private string connStr;

        public bool Close()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (OleDbException exception)
            {
                msgErr = exception.Message;
                codeErr = exception.ErrorCode;
                return false;
            }
        }

        public bool Create(string dbFilePath)
        {
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dbFilePath;
            conn = new OleDbConnection(connStr);
            return true;
        }

        public OleDbConnection Get()
        {
            return conn;
        }

        public bool Open()
        {
            bool flag = true;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    System.IO.StreamWriter swt = System.IO.File.AppendText(@"f:\vnanh\test.txt");
                    swt.WriteLine(DateTime.Now.Ticks);
                    swt.Flush();
                    swt.Close();
                    conn.Open();
                }
            }
            catch (OleDbException exception)
            {
                msgErr = exception.Message;
                codeErr = exception.ErrorCode;
                flag = false;
            }
            return flag;
        }
    }
}
