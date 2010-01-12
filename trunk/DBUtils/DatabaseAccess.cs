    using System;
    using System.Data;
    using System.Data.OleDb;

namespace DBUtils
{
    public class DatabaseAccess
    {
        private DataSet ds;
        private DataTable dt;
        private OleDbDataAdapter oleAdapter;
        private OleDbCommand oleCommand;
        public Connections connection;

        public DatabaseAccess()
        {
        }

        public DatabaseAccess(Connections conn)
        {
            connection = conn;
        }

        private OleDbCommand BuildDelCmd(string table, string condition, params object[] pCondition)
        {
            oleCommand = new OleDbCommand();
            oleCommand.CommandText = "DELETE FROM " + table + " WHERE " + condition;
            if ((pCondition != null) && (pCondition.Length > 0))
                for (int i = 0; i < pCondition.Length; i++)
                    oleCommand.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);

            oleCommand.Connection = connection.Get();
            return oleCommand;
        }

        private OleDbCommand BuildInsertOleCommand(string table, string[] listCols, object[] listValues)
        {
            OleDbCommand command = new OleDbCommand();
            string str = "INSERT INTO " + table + "(";
            foreach (string col in listCols)
                str += col + ",";

            str = str.Substring(0, str.Length - 1) + ") VALUES (";
            foreach (string col in listCols)
                str += "@" + col + ",";

            str = str.Substring(0, str.Length - 1) + ")";
            for (int k = 0; k < listCols.Length; k++)
            {
                command.Parameters.AddWithValue("@" + listCols[k], listValues[k]);
            }
            command.CommandText = str;
            command.Connection = connection.Get();
            return command;
        }

        private OleDbCommand BuildSelectCmd(string table, string listCols, string condition, params object[] pCondition)
        {
            OleDbCommand command = new OleDbCommand();
            if (listCols == null)
            {
                command.CommandText = "SELECT count(*) FROM " + table + ((condition == null) ? "" : (" WHERE " + condition));
            }
            else
            {
                command.CommandText = "SELECT " + listCols + " FROM " + table + ((condition == null) ? "" : (" WHERE " + condition));
            }
            if ((pCondition != null) && (pCondition.Length > 0))
            {
                for (int i = 0; i < pCondition.Length; i++)
                {
                    command.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);
                }
            }
            command.Connection = connection.Get();
            return command;
        }

        private OleDbCommand BuildUpdateOleCommand(string table, string[] listCols, object[] listValues, string condition, params object[] pCondition)
        {
            OleDbCommand command = new OleDbCommand();
            string str = "UPDATE " + table + " SET ";
            foreach (string col in listCols)
                str += col + " = @" + col + ",";

            str = str.Substring(0, str.Length - 1);
            if (!string.IsNullOrEmpty(condition))
                str += " WHERE " + condition;

            for (int j = 0; j < listCols.Length; j++)
                command.Parameters.AddWithValue("@" + listCols[j], listValues[j]);

            if (pCondition != null)
                for (int k = 0; k < pCondition.Length; k++)
                    command.Parameters.AddWithValue(pCondition[k].ToString(), pCondition[++k]);
            
            command.CommandText = str;
            command.Connection = connection.Get();
            return command;
        }

        public bool CreateConnection(string dbFilePath)
        {
            try
            {
                connection = new Connections();
                connection.Create(dbFilePath);
                return true;
            }
            catch (OleDbException exception)
            {
                connection.codeErr = exception.ErrorCode;
                connection.msgErr = exception.Message;
            }
            return false;
        }

        public OleDbDataReader GetDataReader(string query)
        {
            OleDbDataReader reader = null;
            if (connection.Open())
            {
                oleCommand = new OleDbCommand();
                try
                {
                    oleCommand.Connection = connection.Get();
                    oleCommand.CommandText = query;
                    oleCommand.Connection.Open();
                    reader = oleCommand.ExecuteReader();
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return reader;
        }

        public DataSet GetDataSet(string query)
        {
            if (connection.Open())
            {
                ds = new DataSet();
                try
                {
                    new OleDbDataAdapter(query, connection.Get()).Fill(ds);
                }
                catch (OleDbException exception)
                {
                    connection.codeErr = exception.ErrorCode;
                    connection.msgErr = exception.Message;
                }
            }
            return ds;
        }

        public DataTable GetDataTable(string query, params object[] pCondition)
        {
            ds = new DataSet();
            dt = new DataTable();
            oleCommand = new OleDbCommand();
            oleCommand.CommandText = query;
            if (pCondition != null)
                for (int i = 0; i < pCondition.Length; i++)
                    oleCommand.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);

            oleCommand.Connection = connection.Get();

            if (connection.Open())
            {
                try
                {
                    oleAdapter = new OleDbDataAdapter(oleCommand);
                    oleAdapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return dt;
        }

        public DataTable GetDataTable(string table, string listCols, string condition, params object[] pCondition)
        {
            if (connection.Open())
            {
                dt = new DataTable();
                oleCommand = BuildSelectCmd(table, listCols, condition, pCondition);
                oleAdapter = new OleDbDataAdapter(oleCommand);
                try
                {
                    oleAdapter.Fill(dt);
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return dt;
        }

        public int InsCmd(string table, string[] listCols, object[] listValues)
        {
            if (connection.Open())
            {
                oleCommand = BuildInsertOleCommand(table, listCols, listValues);
                try
                {
                    return oleCommand.ExecuteNonQuery();
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return -1;
        }

        public int UpdCmd(string table, string[] listCols, object[] listValues, string condition, params object[] pCondition)
        {
            if (connection.Open())
            {
                oleCommand = BuildUpdateOleCommand(table, listCols, listValues, condition, pCondition);
                try
                {
                    return oleCommand.ExecuteNonQuery();
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return -1;
        }

        public int DelCmd(string table, string condition, params object[] pCondition)
        {
            if (connection.Open())
            {
                oleCommand = BuildDelCmd(table, condition, pCondition);
                try
                {
                    return oleCommand.ExecuteNonQuery();
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return -1;
        }

        public int Execute(string query)
        {
            if (connection.Open())
            {
                try
                {
                    oleCommand = new OleDbCommand();
                    oleCommand.Connection = connection.Get();
                    oleCommand.CommandText = query;
                    return oleCommand.ExecuteNonQuery();
                }
                catch (OleDbException exception)
                {
                    connection.msgErr = exception.Message;
                }
            }
            return -1;
        }
    }
}
