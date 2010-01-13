﻿using System;
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
            if (dbConnection == null)
            {
                string connectionString = @"Provider=Microsoft.JET.OLEDB.4.0;data source=F:\vnanh\project\FaceID\db\FaceIDdb.mdb";
                dbConnection = new OleDbConnection(connectionString);
            }
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }

        #region IDataController Members

        public List<Company> GetCompanyList()
        {
            ConnectToDatabase();

            string strCommand = "SELECT * from Company";
            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText = strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Company> companyList = new List<Company>();
            Company company = null;
            while(odRdr.Read())
            {
                company = new Company();

                company.ID = Convert.ToInt16(odRdr["ID"]);
                company.Name = odRdr["Name"].ToString();

                companyList.Add(company);
            }

            odRdr.Close();
            return companyList;
        }

        public List<Department> GetDepartmentByCompany(int id)
        {
            ConnectToDatabase();

            string strCommand = "SELECT * from Department where CompanyID=" + id;
            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText = strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = Convert.ToInt16(odRdr["ID"]);
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = Convert.ToInt16(odRdr["CompanyID"]);
                department.SupDepartmentID = Convert.ToInt16(odRdr["SupDepartmentID"]);

                departmentList.Add(department);
            }
            odRdr.Close();
            return departmentList;
        }

        public List<Department> GetDepartmentList()
        {
            ConnectToDatabase();

            string strCommand = "SELECT * from Department";
            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText = strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = Convert.ToInt16(odRdr["ID"]);
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = Convert.ToInt16(odRdr["CompanyID"]);
                department.SupDepartmentID = Convert.ToInt16(odRdr["SupDepartmentID"]);

                departmentList.Add(department);
            }

            odRdr.Close();
            return departmentList;
        }

        private List<Department> GetDepartmentListByGroup(int id)
        {
            ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "ID",
                "ID=@ID OR SupDepartmentID=@ID",
                new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = Convert.ToInt16(odRdr["ID"]);
                departmentList.Add(department);
            }

            odRdr.Close();
            dbConnection.Close();
            return departmentList;
        }

        public Department GetDepartment(int id)
        {
            string strCommand = "SELECT * from Department where ID=" + id;

            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText += strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Department department = null;
            if (odRdr.Read())
            {
                department = new Department();

                department.ID = Convert.ToInt16(odRdr["ID"]);
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = Convert.ToInt16(odRdr["CompanyID"]);
                department.SupDepartmentID = Convert.ToInt16(odRdr["SupDepartmentID"]);
            }

            odRdr.Close();
            return department;
        }

        public Company GetCompany(int id)
        {
            string strCommand = " SELECT Company.[ID] ";
            strCommand += " ,Company.[Name] ";
            strCommand += " FROM Company ";
            strCommand += " WHERE Company.[ID] = " + id;

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

        private bool CheckExistCompanyName(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            string strCommand = " SELECT * FROM Company WHERE [Name]='" + name + "'";
            if (id > 0)
                strCommand += " AND ID <> " + id;

            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText = strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                return true;
            }

            odRdr.Close();
            return false;
        }

        private bool CheckExistDepartmentName(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            string strCommand = " SELECT * FROM Department WHERE [Name]='" + name + "'";
            if (id > 0)
                strCommand += " AND ID <> " + id;

            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText = strCommand;
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                return true;
            }

            odRdr.Close();
            return false;
        }

        public int AddCompany(Company company)
        {
            ConnectToDatabase();

            if (company == null || CheckExistCompanyName(company.Name, 0))
                return -1;
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Company",
                new string[] { "Name" },
                new object[] { company.Name }
                );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteCompany(int id)
        {
            ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Company", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            ConnectToDatabase();

            if (company == null || CheckExistCompanyName(company.Name, company.ID))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Department",
                new string[] { "Name" },
                new object[] { company.Name },
                "ID=@ID", new object[] { "@ID", company.ID }
                );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public int AddDepartment(Department department)
        {
            ConnectToDatabase();

            if (department == null || CheckExistDepartmentName(department.Name, 0))
                return -1;
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Department",
                new string[] { "Name", "CompanyID", "SupDepartmentID" },
                new object[] { department.Name, department.CompanyID, department.SupDepartmentID }
                );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                int rs = Convert.ToInt16(odCom1.ExecuteScalar().ToString());
                dbConnection.Close();
                return rs;
            }

            return -1;
        }

        public bool UpdateDepartment(Department department)
        {
            ConnectToDatabase();

            if (department == null || CheckExistDepartmentName(department.Name, department.ID))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Department",
                new string[] { "Name", "CompanyID", "SupDepartmentID" },
                new object[] { department.Name, department.CompanyID, department.SupDepartmentID },
                "ID=@ID", new object[] { "@ID", department.ID }
            );
            
            Department dep1 = GetDepartment(department.ID);
            if (dep1.SupDepartmentID != department.SupDepartmentID)
            {
                bool isRelationship = false;
                Department dep2 = GetDepartment(department.SupDepartmentID);
                while (dep2 != null)
                {
                    if (dep2.ID == department.ID)
                    {
                        isRelationship = true;
                        break;
                    }
                    dep2 = GetDepartment(dep2.SupDepartmentID);
                }
                if (isRelationship)
                {
                    OleDbTransaction trans = dbConnection.BeginTransaction();
                    System.Data.OleDb.OleDbCommand odCom2 = BuildUpdateCmd("Department",
                        new string[] { "SupDepartmentID" },
                        new object[] { dep1.SupDepartmentID },
                        "ID=@ID", new object[] { "@ID", department.SupDepartmentID }
                        );
                    odCom1.Transaction = trans;
                    odCom2.Transaction = trans;
                    int rs = odCom1.ExecuteNonQuery();
                    int rs1 = odCom2.ExecuteNonQuery();
                    if (rs > 0 && rs1 > 0)
                    {
                        trans.Commit();
                        dbConnection.Close();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        dbConnection.Close();
                        return false;
                    }
                }
            }


            int rs2 = odCom1.ExecuteNonQuery();
            dbConnection.Close();
            return rs2 > 0 ? true : false;
        }

        public bool DeleteDepartment(int id)
        {
            System.Data.OleDb.OleDbCommand odCom1 = null;
            List<Department> departmentList = GetDepartmentListByGroup(id);
            int rs = -1;
            ConnectToDatabase();
            if (departmentList != null && departmentList.Count > 1)
            {
                OleDbTransaction trans = dbConnection.BeginTransaction();

                foreach (Department department in departmentList)
                {
                    odCom1 = BuildDelCmd("Department", "ID=@ID", new object[] { "@ID", department.ID });
                    odCom1.Transaction = trans;
                    rs = odCom1.ExecuteNonQuery();
                    if (rs < 1)
                    {
                        trans.Rollback();
                        dbConnection.Close();
                        return false;
                    }
                }
                trans.Commit();
                dbConnection.Close();
                return true;
            }
            else
            {
                odCom1 = BuildDelCmd("Department", "ID=@ID", new object[] { "@ID", id });
                rs = odCom1.ExecuteNonQuery();
                dbConnection.Close();
                return rs > 0 ? true : false;
            }
        }

        #endregion

        #region utils
        private OleDbCommand BuildDelCmd(string table, string condition, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
            command.CommandText = "DELETE FROM " + table + " WHERE " + condition;
            if ((pCondition != null) && (pCondition.Length > 0))
                for (int i = 0; i < pCondition.Length; i++)
                    command.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);

            return command;
        }

        private OleDbCommand BuildInsertCmd(string table, string[] listCols, object[] listValues)
        {
            OleDbCommand command = dbConnection.CreateCommand();
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
            return command;
        }

        private OleDbCommand BuildSelectCmd(string table, string listCols, string condition, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
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
            return command;
        }

        private OleDbCommand BuildUpdateCmd(string table, string[] listCols, object[] listValues, string condition, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
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
            return command;
        }
        #endregion utils
    }
}
