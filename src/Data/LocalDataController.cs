using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.Data
{
    public class LocalDataController : IDataController
    {
        private OleDbConnection dbConnection;

        private static LocalDataController instance;
        private static readonly Object mutex = new Object();

        private LocalDataController() { }

        public static LocalDataController Instance
        {
            get
            {
               lock(mutex)
                   return instance == null ? (instance = new LocalDataController()) : instance;
            }
        }

        private void ConnectToDatabase()
        {
            if (dbConnection.State != ConnectionState.Connecting)
            {
                string connectionString = @"Provider=Microsoft.JET.OLEDB.4.0;data source=F:\FaceID\FaceIDApp\db\FaceIDdb.mdb";

                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
            }
        }

        #region IDataController Members

        public int AddCompany(FaceIDAppVBEta.Class.Company company)
        {
            ConnectToDatabase();

            string strCommand = "";

            if (GetCompanyByName(company.Name) != null)
                throw new Exception();

            strCommand = " INSERT INTO Company(Name) ";
            strCommand += " VALUES('" + company.Name.Replace("'", "''") + "') ";

            System.Data.OleDb.OleDbCommand odCom1 = dbConnection.CreateCommand();
            odCom1.CommandText = strCommand;

            if (odCom1.ExecuteNonQuery() == 1)
            {
                return GetCompanyByName(company.Name).ID;
            }

            return -1;
        }

        private Company GetCompanyByName(string name)
        {
            string strCommand = " SELECT Company.[ID] ";
            strCommand += " ,Company.[Name] ";
            strCommand += " FROM Company ";
            strCommand += " WHERE Company.[Name] = '" + name.Replace("'", "''") + "'";

            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText += strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Company company = null;
            if (odRdr.Read())
            {
                company = new Company();

                company.ID = Convert.ToInt16(odRdr["ID"]);
                company.Name = odRdr["Name"].ToString();
            }

            odRdr.Close();
            return company;
        }

        public bool DeleteCompany(FaceIDAppVBEta.Class.Company company)
        {
            string strCommand = " SELECT COUNT(*) FROM Transactions ";
            strCommand += " WHERE Transactions.[TransactionTypeID] = " + transTypeID;

            System.Data.OleDb.OleDbCommand odCom = conn.CreateCommand();
            odCom.CommandText = strCommand;
            if ((int)odCom.ExecuteScalar() == 0)
            {
                strCommand = " SELECT COUNT(*) FROM TransactionTypes ";
                strCommand += " WHERE TransactionTypes.[TransactionParentTypeID] = " + transTypeID;

                odCom.CommandText = strCommand;
                if ((int)odCom.ExecuteScalar() == 0)
                {
                    strCommand = " DELETE FROM TransactionTypes ";
                    strCommand += " WHERE TransactionTypes.[TransactionTypeID] = " + transTypeID;

                    odCom.CommandText = strCommand;
                    if (odCom.ExecuteNonQuery() == 1)
                    {
                        return 1;
                    }
                }
            }

            return -1;
        }

        public bool UpdateCompany(FaceIDAppVBEta.Class.Company company)
        {
            throw new NotImplementedException();
        }

        public int AddDepartment(FaceIDAppVBEta.Class.Department department)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDepartment(FaceIDAppVBEta.Class.Department department)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDepartment(FaceIDAppVBEta.Class.Department department)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
