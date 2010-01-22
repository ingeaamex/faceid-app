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
        private OleDbTransaction transaction;
        private static OleDbConnection dbConnection;
        private static LocalDataController instance;
        private static readonly Object mutex = new Object();

        private LocalDataController() { }

        public static LocalDataController Instance
        {
            get
            {
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new LocalDataController();
                    }
                }

                ConnectToDatabase();

                return instance;
            }
        }

        #region Connection

        public void BeginTransaction()
        {
            //if (dbConnection.State != ConnectionState.Open)
            //{
            //    dbConnection.Open();
            //}
            transaction = dbConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            //dbConnection.Close();
            transaction.Dispose();
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
            //dbConnection.Close();
            transaction.Dispose();
        }

        #endregion Connection

        private static void ConnectToDatabase()
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

        private static void DisconnectFromDatabase()
        {
            if (dbConnection != null)
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }
        }

        #region IDataController Members

        #region Company
        public List<Company> GetCompanyList()
        {
            ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Company> companyList = new List<Company>();
            Company company = null;
            while(odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = (string)odRdr["Name"];

                companyList.Add(company);
            }

            odRdr.Close();
            return companyList;
        }

        public Company GetCompany(int id)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "ID=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Company company = null;
            if (odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = (string)odRdr["Name"];
            }

            odRdr.Close();
            return company;
        }

        public Company GetCompany(string name)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "[Name]=@Name", new object[] { "@Name", name });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Company company = null;
            if (odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = (string)odRdr["Name"];
            }

            odRdr.Close();
            return company;
        }

        private bool CheckExistCompanyName(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "ID",
                "[Name]=@Name" + (id > 0 ? " AND ID <> " + id : ""), new object[] { "@Name", name });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }
        
        public List<Department> GetDepartmentByCompany(int id)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "*", "CompanyID=@ID", "@ID", id);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = (string)odRdr["Name"];
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];

                departmentList.Add(department);
            }
            odRdr.Close();
            return departmentList;
        }

        public int AddCompany(Company company)
        {
            //ConnectToDatabase();

            if (company == null || CheckExistCompanyName(company.Name, 0))
                return -1;
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Company",
                new string[] { "Name" },
                new object[] { company.Name }
                );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteCompany(int id)
        {
            //ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Company", "ID=@ID", new object[] { "@ID", id });
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            //ConnectToDatabase();

            if (company == null || CheckExistCompanyName(company.Name, company.ID))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Company",
                new string[] { "Name" },
                new object[] { company.Name },
                "ID=@ID", new object[] { "@ID", company.ID }
                );

            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }
        #endregion Company

        #region Department
        public List<Department> GetDepartmentList()
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = (string)odRdr["Name"];
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];

                departmentList.Add(department);
            }

            odRdr.Close();
            return departmentList;
        }

        private List<Department> GetDepartmentListByGroup(int id)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "ID",
                "ID=@ID OR SupDepartmentID=@ID",
                new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                departmentList.Add(department);
            }

            odRdr.Close();

            return departmentList;
        }

        public Department GetDepartment(int id)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "*", "ID=@ID", "@ID", id);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Department department = null;
            if (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = (string)odRdr["Name"];
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];
            }

            odRdr.Close();
            return department;
        }

        private bool CheckExistDepartmentName(string name, int companyId, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            object[] parames;
            string condition = "[Name]=@Name AND CompanyID=@CompanyID";
            if (id > 0)
            {
                condition += " AND ID<>@ID";
                parames = new object[] { "@Name", name, "@CompanyID", companyId, "@ID", id };
            }
            else
            {
                parames = new object[] { "@Name", name, "@CompanyID", companyId };
            }
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Department", "ID", condition, parames);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }

            return false;
        }

        public int AddDepartment(Department department)
        {
            //ConnectToDatabase();

            if (department == null || CheckExistDepartmentName(department.Name, department.CompanyID, 0))
                return -1;
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Department",
                new string[] { "Name", "CompanyID", "SupDepartmentID" },
                new object[] { department.Name, department.CompanyID, department.SupDepartmentID }
                );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                int rs = Convert.ToInt16(odCom1.ExecuteScalar().ToString());
                return rs;
            }

            return -1;
        }

        public bool UpdateDepartment(Department department)
        {
            //ConnectToDatabase();

            if (department == null || CheckExistDepartmentName(department.Name,department.CompanyID, department.ID))
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
                    BeginTransaction();
                    System.Data.OleDb.OleDbCommand odCom2 = BuildUpdateCmd("Department",
                        new string[] { "SupDepartmentID" },
                        new object[] { dep1.SupDepartmentID },
                        "ID=@ID", new object[] { "@ID", department.SupDepartmentID }
                        );
                    odCom1.Transaction = transaction;
                    int rs = ExecuteNonQuery(odCom1);
                    int rs1 = ExecuteNonQuery(odCom2);
                    if (rs > 0 && rs1 > 0)
                    {
                        CommitTransaction();
                        return true;
                    }
                    else
                    {
                        RollbackTransaction();
                        return false;
                    }
                }
            }

            int rs2 = ExecuteNonQuery(odCom1);
            return rs2 > 0 ? true : false;
        }

        public bool DeleteDepartment(int id)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = null;
            List<Department> departmentList = GetDepartmentListByGroup(id);
            int rs = -1;

            if (departmentList != null && departmentList.Count > 1)
            {
                BeginTransaction();
                foreach (Department department in departmentList)
                {
                    odCom1 = BuildDelCmd("Department", "ID=@ID", new object[] { "@ID", department.ID });
                    rs = ExecuteNonQuery(odCom1);
                    if (rs < 1)
                    {
                        RollbackTransaction();
                        return false;
                    }
                }
                CommitTransaction();
                return true;
            }
            else
            {
                odCom1 = BuildDelCmd("Department", "ID=@ID", new object[] { "@ID", id });
                rs = ExecuteNonQuery(odCom1);
                return rs > 0 ? true : false;
            }
        }
        #endregion Department

        #region Employee

        public Employee GetEmployee(int employeeId)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "*", "PayrollNumber=@ID", "@ID", employeeId);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Employee employee = null;
            if (odRdr.Read())
            {
                employee = new Employee();
                employee.Active = (bool)odRdr["Active"];
                employee.Address = (string)odRdr["Address"];
                employee.Birthday = (DateTime)odRdr["Birthday"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.FirstName = (string)odRdr["FirstName"];
                employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = (string)odRdr["JobDescription"];
                employee.LastName = (string)odRdr["LastName"];
                employee.LeftDate = (DateTime)odRdr["LeftDate"];
                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.PhoneNumber = (string)odRdr["PhoneNumber"];
                employee.PhotoData = (string)odRdr["PhotoData"];
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.ActiveFrom = (DateTime)odRdr["ActiveFrom"];
                if (odRdr["ActiveTo"].GetType().Name != "DBNull")
                    employee.ActiveTo = (DateTime)odRdr["ActiveTo"];
            }
            odRdr.Close();
            return employee;
        }

        public List<Employee> GetEmployeeList(int compantId)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom;
            if (compantId <= 0)
                odCom = BuildSelectCmd("Employee", "*", null);
            else
                odCom = BuildSelectCmd("Employee", "*", " DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID)", new object[] { "@ID", compantId });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();
                employee.Active = (bool)odRdr["Active"];
                employee.Address = (string)odRdr["Address"];
                employee.Birthday = (DateTime)odRdr["Birthday"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.FirstName = (string)odRdr["FirstName"];
                employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = (string)odRdr["JobDescription"];
                employee.LastName = (string)odRdr["LastName"];
                employee.LeftDate = (DateTime)odRdr["LeftDate"];
                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.PhoneNumber = (string)odRdr["PhoneNumber"];
                employee.PhotoData = (string)odRdr["PhotoData"];
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.ActiveFrom = (DateTime)odRdr["ActiveFrom"];
                if (odRdr["ActiveTo"].GetType().Name != "DBNull")
                    employee.ActiveTo = (DateTime)odRdr["ActiveTo"];

                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public List<Employee> GetEmployeeListByDep(int departmentId)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "*", "DepartmentID=@ID", "@ID", departmentId);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();

                employee.Active = (bool)odRdr["Active"];
                employee.Address = (string)odRdr["Address"];
                employee.Birthday = (DateTime)odRdr["Birthday"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.FirstName = (string)odRdr["FirstName"];
                employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = (string)odRdr["JobDescription"];
                employee.LastName = (string)odRdr["LastName"];
                employee.LeftDate = (DateTime)odRdr["LeftDate"];
                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.PhoneNumber = (string)odRdr["PhoneNumber"];
                employee.PhotoData = (string)odRdr["PhotoData"];
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.ActiveFrom = (DateTime)odRdr["ActiveFrom"];
                if (odRdr["ActiveTo"].GetType().Name != "DBNull")
                    employee.ActiveTo = (DateTime)odRdr["ActiveTo"];

                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public bool IsExistEmployeeNumber(int employeeNumber)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber", "EmployeeNumber=@EmployeeNumber", "@EmployeeNumber", employeeNumber);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public int AddEmployee(Employee employee)
        {
            //ConnectToDatabase();

            if (employee == null)
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Employee",
                new string[] {"EmployeeNumber", "DepartmentID", "WorkingCalendarID", "FirstName",
                    "LastName","PhoneNumber","Address","JobDescription",
                    "Birthday","HiredDate","LeftDate","PhotoData","Active","ActiveFrom" },
                new object[] {employee.EmployeeNumber, employee.DepartmentID,employee.WorkingCalendarID,employee.FirstName,
                    employee.LastName,employee.PhoneNumber, employee.Address,employee.JobDescription,
                    employee.Birthday, employee.HiredDate,employee.LeftDate,employee.PhotoData,employee.Active,employee.ActiveFrom
                });

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                int rs = Convert.ToInt16(odCom1.ExecuteScalar().ToString());
                return rs;
            }

            return -1;
        }

        public bool DeleteEmployee(int employeeId)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] { "Active", "ActiveTo" }, new object[] { false, DateTime.Now }, "PayrollNumber=@ID",
                new object[] { "@ID", employeeId }
            );
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            //ConnectToDatabase();

            if (employee == null)
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] {"DepartmentID", "WorkingCalendarID", "FirstName",
                    "LastName","PhoneNumber","Address","JobDescription",
                    "Birthday","HiredDate","LeftDate" },
                new object[] {employee.DepartmentID,employee.WorkingCalendarID,employee.FirstName,
                    employee.LastName,employee.PhoneNumber, employee.Address,employee.JobDescription,
                    employee.Birthday, employee.HiredDate,employee.LeftDate
                }, "PayrollNumber=@ID", new object[] { "@ID", employee.PayrollNumber });

            if (ExecuteNonQuery(odCom1) == 1)
            {
                return true;
            }

            return false;
        }

        #endregion Employee

        #region WorkingCalendar
        public List<WorkingCalendar> GetWCalendarList()
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<WorkingCalendar> wCalendarList = new List<WorkingCalendar>();
            WorkingCalendar wCalendar = null;
            while (odRdr.Read())
            {
                wCalendar = new WorkingCalendar();

                wCalendar.ID = (int)odRdr["ID"];
                wCalendar.Name = (string)odRdr["Name"];
                wCalendar.RegularWorkingFrom = (DateTime)odRdr["RegularWorkingFrom"];
                wCalendar.RegularWorkingTo = (DateTime)odRdr["RegularWorkingTo"];

                wCalendarList.Add(wCalendar);
            }

            odRdr.Close();
            return wCalendarList;
        }
        #endregion WorkingCalendar

        #region Terminal
        public List<Terminal> GetTerminalList()
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Terminal", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Terminal> terminalList = new List<Terminal>();
            Terminal terminal = null;
            while (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = (int)odRdr["ID"];
                terminal.Name = (string)odRdr["Name"];
                terminal.IPAddress = (string)odRdr["IPAddress"];

                terminalList.Add(terminal);
            }

            odRdr.Close();
            return terminalList;
        }		

        public Terminal GetTerminal(int id)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Terminal", "*", "ID=@ID", new object[] { "@ID", id });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Terminal _terminal = null;
            if (odRdr.Read())
            {
                _terminal = new Terminal();

                _terminal.ID = Convert.ToInt16(odRdr["ID"]);
                _terminal.Name = odRdr["Name"].ToString();
                _terminal.IPAddress = odRdr["IPAddress"].ToString();
            }

            odRdr.Close();
            return _terminal;
        }

        private bool CheckEixstTerminal(Terminal _terminal, bool forUpdate)
        {
            System.Data.OleDb.OleDbCommand odCom;
            if (forUpdate)
                odCom = BuildSelectCmd("Terminal", "ID", "ID<>@ID AND ([Name]=@Name OR IPAddress=@IPAddress)",
                    new object[] { "@ID", _terminal.ID, "@Name", _terminal.Name, "@IPAddress", _terminal.IPAddress });
            else
                odCom = BuildSelectCmd("Terminal", "ID", "[Name]=@Name OR IPAddress=@IPAddress",
                    new object[] { "@Name", _terminal.Name, "@IPAddress", _terminal.IPAddress });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public int AddTerminal(Terminal _terminal)
        {
            //ConnectToDatabase();

            if (CheckEixstTerminal(_terminal,false))
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { _terminal.Name
                ,_terminal.IPAddress
                }
            );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateTerminal(Terminal _terminal)
        {
            //ConnectToDatabase();

            if (CheckEixstTerminal(_terminal, true))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { _terminal.Name
                ,_terminal.IPAddress
                },
                "ID=@ID", new object[] { "@ID", _terminal.ID }
            );

            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool DeleteTerminal(int id)
        {
            //ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Terminal", "ID=@ID", new object[] { "@ID", id });
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        #endregion Terminal

        #region EmployeeTerminal

        public List<EmployeeTerminal> GetEmployeeTerminalsByEmpl(int employeeNumber)
        {
            //ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("EmployeeTerminal", "*", "EmployeeNumber=@EmployeeNumber", new object[] { "@EmployeeNumber", employeeNumber });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<EmployeeTerminal> employeeTerminals = new List<EmployeeTerminal>();
            EmployeeTerminal employeeTerminal = null;
            while (odRdr.Read())
            {
                employeeTerminal = new EmployeeTerminal();

                employeeTerminal.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employeeTerminal.TerminalID = (int)odRdr["TerminalID"];
                employeeTerminals.Add(employeeTerminal);
            }

            odRdr.Close();
            return employeeTerminals;
        }
        
        public List<Terminal> GetTerminalsByEmpl(int employeeNumber)
        {
            //ConnectToDatabase();
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Terminal", "*", "ID in (SELECT TerminalID FROM EmployeeTerminal WHERE EmployeeNumber=@EmployeeNumber)", new object[] { "@EmployeeNumber", employeeNumber });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<Terminal> terminals = new List<Terminal>();
            Terminal terminal = null;
            while (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = (int)odRdr["ID"];
                terminal.Name = (string)odRdr["Name"];
                terminals.Add(terminal);
            }

            odRdr.Close();
            return terminals;
        }

        public List<EmployeeTerminal> GetEmplTerminalList()
        {
            throw new NotImplementedException();
        }

        public int AddEmplTerminal(List<EmployeeTerminal> emplTerminals)
        {
            //ConnectToDatabase();

            if (emplTerminals == null)
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = null;

            foreach (EmployeeTerminal emplTerminal in emplTerminals)
            {
                odCom1 = BuildInsertCmd("EmployeeTerminal",
                    new string[] { "EmployeeNumber", "TerminalID" },
                    new object[] { emplTerminal.EmployeeNumber, emplTerminal.TerminalID }
                    );

                int irs = ExecuteNonQuery(odCom1);
                if (irs < 1)
                    return -1;
            }
            return 1;
        }

        public bool DeleteEmplTerminalByEmpl(int employeeNumber)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }

        public bool DeleteEmplTerminal(int terminalID)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "TerminalID=@ID", new object[] { "@ID", terminalID });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }
        
        public bool UpdateEmplTerminal(List<Terminal> terminals, int employeeNumber)
        {
            //ConnectToDatabase();

            BeginTransaction();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });
            int t1 = ExecuteNonQuery(odCom1);
            if (t1 < 0)
            {
                RollbackTransaction();
                return false;
            }
            foreach (Terminal terminal in terminals)
            {
                odCom1 = BuildInsertCmd("EmployeeTerminal",
                    new string[] { "EmployeeNumber", "TerminalID" },
                    new object[] { employeeNumber, terminal.ID }
                    );
                t1 = ExecuteNonQuery(odCom1);

                if (t1 < 1)
                {
                    RollbackTransaction(); 
                    return false;
                }
            }

            CommitTransaction();
            return true;
        }

        #endregion EmployeeTerminal

        #region EmployeeNumber

        public List<EmployeeNumber> GetEmployeeNumberList()
        {
            throw new NotImplementedException();
        }

        public int GetAvailEmployeeNumber()
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "Min(EmployeeNumber) as EmployeeNumber", "Active=0");
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            int employeeNumber = 1;
            if (odRdr.Read())
            {
                if (int.TryParse(odRdr["EmployeeNumber"].ToString(), out employeeNumber))
                {
                    odRdr.Close();
                    return employeeNumber;
                }
                else
                {
                    employeeNumber = 1;
                    odRdr.Close();
                }
            }

            odCom = BuildSelectCmd("EmployeeNumber", "ID", null);
            odRdr = odCom.ExecuteReader();

            List<int> ids = new List<int>();

            while (odRdr.Read())
                ids.Add((int)odRdr["ID"]);
            
            odRdr.Close();
            
            if (ids.Count > 0)
            {
                ids.Sort();
                employeeNumber = ids[0] + 1;

                while (ids.Contains(employeeNumber))
                    employeeNumber++;
            }

            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("EmployeeNumber",
                new string[] { "ID", "Note" },
                new object[] { employeeNumber, "" }
            );

            int rs = ExecuteNonQuery(odCom1);
            return rs > 0 ? employeeNumber : -1;
        }

        #endregion EmployeeNumber

        #region WorkingCalendar


        public WorkingCalendar GetWorkingCalendarByEmployee(int employeeNumber)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*",
                "ID=(Select top 1 WorkingCalendarID From Employee Where EmployeeNumber=@ID)", new object[] { "@ID", employeeNumber });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            WorkingCalendar workingCalendar = null;
            if (odRdr.Read())
            {
                workingCalendar = new WorkingCalendar();

                workingCalendar.ID = (int)odRdr["ID"];
                workingCalendar.Name = (string)odRdr["Name"];
                workingCalendar.PayPeriodID = (int)odRdr["PayPeriodID"];
                workingCalendar.RegularWorkingFrom = (DateTime)odRdr["RegularWorkingFrom"];
                workingCalendar.RegularWorkingTo = (DateTime)odRdr["RegularWorkingTo"];
                workingCalendar.WorkOnFriday = (bool)odRdr["WorkOnFriday"];
                workingCalendar.WorkOnMonday = (bool)odRdr["WorkOnMonday"];
                workingCalendar.WorkOnSaturday = (bool)odRdr["WorkOnSaturday"];
                workingCalendar.WorkOnSunday = (bool)odRdr["WorkOnSunday"];
                workingCalendar.WorkOnThursday = (bool)odRdr["WorkOnThursday"];
                workingCalendar.WorkOnTuesday = (bool)odRdr["WorkOnTuesday"];
                workingCalendar.WorkOnWednesday = (bool)odRdr["WorkOnWednesday"];
            }

            odRdr.Close();
            return workingCalendar;
        }

        public WorkingCalendar GetWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public List<Break> GetBreakByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public PaymentRate GetWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public PaymentRate GetNonWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public PaymentRate GetHolidayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public List<Holiday> GetHolidayListByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public PayPeriod GetPayPeriodByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public int AddWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate)
        {
            throw new NotImplementedException();
        }

        public PayPeriod GetPayPeriodByName(string payPeriodName)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicatedWorkingCalendarName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicatedWorkingCalendarName(string name, int _workingCalendarID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Attendance Rcord

        private string GetEmployeeNumberList(int iCompany, int iDepartment)
        {
            System.Data.OleDb.OleDbCommand odCom = null;
            if (iDepartment > 0)
                odCom = BuildSelectCmd("Employee", "EmployeeNumber", "DepartmentID=@ID", new object[] { "@ID", iDepartment });
            else if (iCompany > 0)
                odCom = BuildSelectCmd("Employee", "EmployeeNumber", " DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID)", new object[] { "@ID", iCompany });
            else
                odCom = BuildSelectCmd("Employee", "EmployeeNumber", null);

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            string employeeNumberList = "";

            while (odRdr.Read())
            {
                employeeNumberList += odRdr["EmployeeNumber"] + ",";
            }
            odRdr.Close();

            return employeeNumberList.TrimEnd(',');
        }

        public List<AttendanceLog> GetAttendanceRecordList_1(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            string employeeNumberList = GetEmployeeNumberList(iCompany, iDepartment);

            if (employeeNumberList == "")
                return null;

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceReport as Att INNER JOIN Employee as Emp ON Att.EmployeeNumber = Emp.EmployeeNumber",
                "Emp.EmployeeNumber, Emp.FirstName, Emp.LastName, Att.WorkFrom, Att.WorkTo, Att.RegularHour",
                "Att.WorkFrom >=@Date_1 AND Att.WorkFrom <= @Date_2 AND Att.EmployeeNumber in(@Empl)", 
                new object[] { "@Date_1", beginDate, "@Date_2", endDate, "@Empl", employeeNumberList });

            OleDbDataAdapter odApt = new OleDbDataAdapter(odCom);
            DataTable dtReport = new DataTable();
            odApt.Fill(dtReport);

            if (dtReport.Rows.Count == 0)
                return null;

            System.Data.OleDb.OleDbDataReader odRdr = null;
            List<AttendanceLog> attLogs = new List<AttendanceLog>();
            foreach (DataRow drRp in dtReport.Rows)
            {
                AttendanceLog attLog = new AttendanceLog();
                attLog.DateLog = (DateTime)drRp["WorkFrom"];
                attLog.EmployeeNumber = (int)drRp["EmployeeNumber"];
                attLog.FirstName = (string)drRp["FirstName"];
                attLog.LastName = (string)drRp["LastName"];
                attLog.TotalHour = (int)drRp["RegularHour"];

                odCom = BuildSelectCmd("AttendanceRecord","*","Time >=@Date_1 AND Time <= @Date_2 AND EmployeeNumber=@Empl",
                new object[] { "@Date_1", drRp["WorkFrom"], "@Date_2", drRp["WorkTo"], "@Empl", drRp["EmployeeNumber"] });

                List<TimeSpan> attendanceDetails = new List<TimeSpan>();
                List<string> notes = new List<string>();

                odRdr = odCom.ExecuteReader();
                while (odRdr.Read())
                {
                    attendanceDetails.Add(Convert.ToDateTime(odRdr["Time"]).TimeOfDay);
                    notes.Add(odRdr["Note"].ToString());
                }
                odRdr.Close();
                attLog.AttendanceDetail = attendanceDetails;
                attLog.Note = notes;

                attLogs.Add(attLog);
            }
            return attLogs;
        }

        private AttendanceLog BuildAttendanceLog(DateTime dtime, string fistName, string lastName, int employeeNumber, List<TimeSpan> attendanceDetails, List<string> notes)
        {
            AttendanceLog attendanceLog = new AttendanceLog();
            attendanceLog.FirstName = fistName;
            attendanceLog.LastName = lastName;
            attendanceLog.EmployeeNumber = employeeNumber;
            attendanceLog.AttendanceDetail = attendanceDetails;
            attendanceLog.Note = notes;
            int iTotalHour = 0;
            if (attendanceDetails.Count>0 && attendanceDetails.Count % 2 == 0)
            {
                double workTime = 0;
                workTime = ((TimeSpan)attendanceDetails[attendanceDetails.Count - 1]).TotalMinutes
                - ((TimeSpan)attendanceDetails[0]).TotalMinutes;
                for (int j = 1; j < attendanceDetails.Count - 1; j++)
                {
                    workTime -= -((TimeSpan)attendanceDetails[j++]).TotalMinutes
                    + ((TimeSpan)attendanceDetails[j]).TotalMinutes;
                }
                iTotalHour = Convert.ToInt16(workTime / 60);//workTime % 60?
            }
            else
                iTotalHour = 0;

            attendanceLog.TotalHour = iTotalHour;
            attendanceLog.DateLog = dtime;

            return attendanceLog;
        }

        private static int AttendanceLogsSort(AttendanceLog a, AttendanceLog b) { return a.DateLog.CompareTo(b.DateLog); }

        public List<AttendanceRecord> GetAttendanceRecordList()
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<AttendanceRecord> attRecordList = new List<AttendanceRecord>();
            AttendanceRecord attRecord = null;
            while (odRdr.Read())
            {
                attRecord = new AttendanceRecord();

                attRecord.ID = (int)odRdr["ID"];
                attRecord.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attRecord.Note = (string)odRdr["Note"];
                attRecord.PhotoData = (string)odRdr["PhotoData"];
                attRecord.Time = (DateTime)odRdr["Time"];

                attRecordList.Add(attRecord);
            }

            odRdr.Close();
            return attRecordList;
        }

        public AttendanceRecord GetAttendanceRecord(int id)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", "ID=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if(odRdr.Read())
            {
                AttendanceRecord attRecord = new AttendanceRecord();

                attRecord.ID = (int)odRdr["ID"];
                attRecord.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attRecord.Note = (string)odRdr["Note"];
                attRecord.PhotoData = (string)odRdr["PhotoData"];
                attRecord.Time = (DateTime)odRdr["Time"];

                odRdr.Close();
                return attRecord;
            }

            return null;
        }

        private bool IsValidAttendanceRecord(AttendanceRecord attRecord, bool forUpdate)
        {
            System.Data.OleDb.OleDbCommand odCom;
            if (forUpdate)
                odCom = BuildSelectCmd("AttendanceRecord", "ID", "ID<>@ID AND EmployeeNumber=@EmployeeNumber AND Time=@Time",
                    new object[] { "@ID", attRecord.ID, "@EmployeeNumber", attRecord.EmployeeNumber, "@Time", attRecord.Time });
            else
                odCom = BuildSelectCmd("AttendanceRecord", "ID", "EmployeeNumber=@EmployeeNumber AND Time=@Time",
                    new object[] { "@EmployeeNumber", attRecord.EmployeeNumber, "@Time", attRecord.Time });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public bool AddAttendanceRecord(AttendanceRecord attRecord)
        {
            if (attRecord == null || IsValidAttendanceRecord(attRecord, false))
                return false;

            int iEmployeeNumber = attRecord.EmployeeNumber;

            WorkingCalendar workingCalendar = GetWorkingCalendarByEmployee(iEmployeeNumber);
            DateTime dRegularWorkingFrom = (DateTime)workingCalendar.RegularWorkingFrom;
            DateTime dRegularWorkingTo = (DateTime)workingCalendar.RegularWorkingTo;

            // get lastest record
            DateTime d2 = attRecord.Time;
            DateTime d1 = d2.Date.AddHours(dRegularWorkingFrom.Hour).AddMinutes(dRegularWorkingFrom.Minute);
            if (d1.CompareTo(d2) == 1)
                d1.AddDays(-1);

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "Time", "EmployeeNumber=@Empl AND Time>=@Date_1 AND Time<@Date_2", new object[] { "@Empl", iEmployeeNumber, "@Date_1", d1, "@Date_2", d2 });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            bool isFirstRsDay = true;
            if (odRdr.Read())
            {
                isFirstRsDay = false;
                odRdr.Close();
            }

            if (!isFirstRsDay)
            {
                odCom = BuildInsertCmd("AttendanceRecord",
                       new string[] { "EmployeeNumber", "Note", "PhotoData", "Time" },
                       new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.PhotoData, attRecord.Time }
                       );

                return ExecuteNonQuery(odCom) > 0;
            }

            int iPayPeriodID = (int)workingCalendar.PayPeriodID;
            int iWorkingCalendarID = (int)workingCalendar.ID;

            int iDayTypeID = 2;
            switch (attRecord.Time.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    if (workingCalendar.WorkOnFriday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Monday:
                    if (workingCalendar.WorkOnMonday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Saturday:
                    if (workingCalendar.WorkOnSaturday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Sunday:
                    if (workingCalendar.WorkOnSunday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Thursday:
                    if (workingCalendar.WorkOnThursday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Tuesday:
                    if (workingCalendar.WorkOnTuesday)
                        iDayTypeID = 1;
                    break;
                case DayOfWeek.Wednesday:
                    if (workingCalendar.WorkOnWednesday)
                        iDayTypeID = 1;
                    break;
            }

            odCom = BuildSelectCmd("Holiday", "*", "WorkingCalendarID=@ID", new object[] { "@ID", iWorkingCalendarID });
            odRdr = odCom.ExecuteReader();

            while (odRdr.Read())
            {
                DateTime holiday = (DateTime)odRdr["Date"];
                if (attRecord.Time.Month == holiday.Month && attRecord.Time.Day == holiday.Day)
                {
                    iDayTypeID = 3;
                    odRdr.Close();
                    break;
                }
            }
            if (!odRdr.IsClosed) odRdr.Close();

            odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WID AND DayTypeID=@DID", new object[] { "@WID", iWorkingCalendarID, "DID", iDayTypeID });
            odRdr = odCom.ExecuteReader();

            PaymentRate paymentRate = null;
            if (odRdr.Read())
            {
                paymentRate = new PaymentRate();

                paymentRate.DayTypeID = (int)odRdr["DayTypeID"];
                paymentRate.ID = (int)odRdr["ID"];
                paymentRate.NumberOfOvertime1 = (int)odRdr["NumberOfOvertime1"];
                paymentRate.NumberOfOvertime2 = (int)odRdr["NumberOfOvertime2"];
                paymentRate.NumberOfOvertime3 = (int)odRdr["NumberOfOvertime3"];
                paymentRate.NumberOfOvertime4 = (int)odRdr["NumberOfOvertime4"];
                paymentRate.NumberOfRegularHours = (int)odRdr["NumberOfRegularHours"];
                paymentRate.OvertimeRate1 = (int)odRdr["OvertimeRate1"];
                paymentRate.OvertimeRate2 = (int)odRdr["OvertimeRate2"];
                paymentRate.OvertimeRate3 = (int)odRdr["OvertimeRate3"];
                paymentRate.OvertimeRate4 = (int)odRdr["OvertimeRate4"];
                paymentRate.RegularRate = (int)odRdr["RegularRate"];
                paymentRate.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
            }
            odRdr.Close();

            DateTime dAttRecordPeriod1 = attRecord.Time.AddDays(-1);
            dAttRecordPeriod1 = dAttRecordPeriod1.Date.AddHours(dRegularWorkingFrom.Hour).AddMinutes(dRegularWorkingFrom.Minute);

            DateTime dWorkFrom = dAttRecordPeriod1;
            DateTime dWorkTo = dWorkFrom.Date.AddHours(dRegularWorkingTo.Hour).AddMinutes(dRegularWorkingTo.Minute);
            if (dAttRecordPeriod1.CompareTo(dWorkTo) == 1)
            {
                dWorkTo = dWorkTo.AddDays(1);
            }

            DateTime dAttRecordPeriod2 = dAttRecordPeriod1.AddHours(23);

            odCom = BuildSelectCmd("AttendanceRecord", "*", "EmployeeNumber=@Empl AND Time>=@Date_1 AND Time<=@Date_2", new object[] { "@Empl", iEmployeeNumber, "@Date_1", dAttRecordPeriod1, "@Date_2", dAttRecordPeriod2 });
            odRdr = odCom.ExecuteReader();

            List<DateTime> attendanceRecordTimes = new List<DateTime>();
            while (odRdr.Read())
            {
                attendanceRecordTimes.Add((DateTime)odRdr["Time"]);
            }
            odRdr.Close();

            if (attendanceRecordTimes.Count == 0)
            {
                odCom = BuildInsertCmd("AttendanceRecord",
                    new string[] { "EmployeeNumber", "Note", "PhotoData", "Time" },
                    new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.PhotoData, attRecord.Time }
                    );

                return ExecuteNonQuery(odCom) > 0;
            }

            attendanceRecordTimes.Sort();

            int totalHour = 0;
            int totalOverHour = 0;
            if (attendanceRecordTimes.Count % 2 == 0)
            {
                long totalTicks = 0;
                long totalOverTicks = 0;
                for (int i = 0; i < attendanceRecordTimes.Count - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (dWorkTo.CompareTo(attendanceRecordTimes[i]) == 1)
                            totalTicks += attendanceRecordTimes[i + 1].Ticks - attendanceRecordTimes[i].Ticks;
                        else
                            totalOverTicks += attendanceRecordTimes[i + 1].Ticks - attendanceRecordTimes[i].Ticks;
                    }
                }
                int totalMinute = Convert.ToInt16(totalTicks / (60 * 10000000));
                totalHour = totalMinute / 60;

                int totalOverMinute = Convert.ToInt16(totalOverTicks / (60 * 10000000));
                totalOverHour = totalOverMinute / 60;
            }

            DateTime attRcBengin = (DateTime)attendanceRecordTimes[0];
            DateTime attRcEnd = (DateTime)attendanceRecordTimes[attendanceRecordTimes.Count - 1];

            dWorkFrom = dWorkFrom.Date.AddHours(attRcBengin.Hour).AddMinutes(attRcBengin.Minute);
            dWorkTo = dWorkTo.Date.AddHours(attRcEnd.Hour).AddMinutes(attRcEnd.Minute);

            totalOverHour += totalHour - paymentRate.NumberOfRegularHours;

            int iOvertimeHour1 = 0;
            int iOvertimeHour2 = 0;
            int iOvertimeHour3 = 0;
            int iOvertimeHour4 = 0;
            if (totalOverHour > paymentRate.NumberOfOvertime1)
            {
                iOvertimeHour1 = paymentRate.NumberOfOvertime1;
                totalOverHour -= iOvertimeHour1;
                if (totalOverHour > paymentRate.NumberOfOvertime2)
                {
                    iOvertimeHour2 = paymentRate.NumberOfOvertime2;
                    totalOverHour -= iOvertimeHour2;
                    if (totalOverHour > paymentRate.NumberOfOvertime3)
                    {
                        iOvertimeHour3 = paymentRate.NumberOfOvertime3;
                        totalOverHour -= iOvertimeHour3;
                        iOvertimeHour4 = totalOverHour;
                    }
                    else
                        iOvertimeHour3 = totalOverHour;
                }
                else
                    iOvertimeHour2 = totalOverHour;
            }
            else
                iOvertimeHour1 = totalOverHour;

            AttendanceReport attendanceReport = new AttendanceReport();
            attendanceReport.DayTypeID = iDayTypeID;
            attendanceReport.EmployeeNumber = iEmployeeNumber;
            attendanceReport.OvertimeHour1 = iOvertimeHour1;
            attendanceReport.OvertimeHour2 = iOvertimeHour2;
            attendanceReport.OvertimeHour3 = iOvertimeHour3;
            attendanceReport.OvertimeHour4 = iOvertimeHour4;
            attendanceReport.OvertimeRate1 = paymentRate.OvertimeRate1;
            attendanceReport.OvertimeRate2 = paymentRate.OvertimeRate2;
            attendanceReport.OvertimeRate3 = paymentRate.OvertimeRate3;
            attendanceReport.OvertimeRate4 = paymentRate.OvertimeRate4;
            attendanceReport.PayPeriodID = iPayPeriodID;
            attendanceReport.RegularHour = paymentRate.NumberOfRegularHours;
            attendanceReport.RegularRate = paymentRate.RegularRate;
            attendanceReport.WorkFrom = dWorkFrom;
            attendanceReport.WorkTo = dWorkTo;

            BeginTransaction();

            bool oRs = AddAttendanceReport(attendanceReport);

            odCom = BuildInsertCmd("AttendanceRecord",
                new string[] { "EmployeeNumber", "Note", "PhotoData", "Time" },
                new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.PhotoData, attRecord.Time }
                );

            int iRs = ExecuteNonQuery(odCom);

            if (oRs && iRs > 0)
            {
                CommitTransaction();
                return true;
            }
            else
            {
                RollbackTransaction();
                return false;
            }
        }

        private bool AddAttendanceReport(AttendanceReport attendanceReport)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("AttendanceReport",
                new string[] { "DayTypeID", "EmployeeNumber", "OvertimeHour1", "OvertimeHour2", "OvertimeHour3", "OvertimeHour4",
                "OvertimeRate1","OvertimeRate2","OvertimeRate3","OvertimeRate4","PayPeriodID","RegularHour","RegularRate",
                "WorkFrom","WorkTo"},
                new object[] { attendanceReport.DayTypeID, attendanceReport.EmployeeNumber, attendanceReport.OvertimeHour1,
                attendanceReport.OvertimeHour2,attendanceReport.OvertimeHour3,attendanceReport.OvertimeHour4, attendanceReport.OvertimeRate1,
                attendanceReport.OvertimeRate2,attendanceReport.OvertimeRate3, attendanceReport.OvertimeRate4,attendanceReport.PayPeriodID,
                attendanceReport.RegularHour,attendanceReport.RegularRate,attendanceReport.WorkFrom,attendanceReport.WorkTo}
                );

            return ExecuteNonQuery(odCom1) > 0;
        }

        public bool DeleteAttendanceRecord(int id)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("AttendanceRecord", "ID=@ID", new object[] { "@ID", id });
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool UpdateAttendanceRecord(AttendanceRecord attRecord)
        {
            if (attRecord == null || IsValidAttendanceRecord(attRecord, true))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("AttendanceRecord",
                new string[] { "EmployeeNumber", "Note", "PhotoData", "Time" },
                new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.PhotoData, attRecord.Time },
                "ID=@ID", new object[] { "@ID", attRecord.ID }
                );

            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        #endregion Attendance Rcord

        #endregion

        #region utils

        private void WriteLog(string msg)
        {
            try
            {
                System.IO.StreamWriter swter = System.IO.File.AppendText(@"F:\vnanh\project\FaceID\log\log.txt");
                swter.WriteLine(DateTime.Now.ToString() + ":" + msg);
                swter.Close();
            }
            catch { }
        }

        private int ExecuteNonQuery(System.Data.OleDb.OleDbCommand odCom)
        {
            try
            {
                return odCom.ExecuteNonQuery();
            }
            catch(Exception ex) {
                WriteLog(ex.Message);
            }
            return -1;
        }

        private OleDbCommand BuildDelCmd(string table, string condition, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
            command.CommandText = "DELETE FROM " + table + " WHERE " + condition;
            if ((pCondition != null) && (pCondition.Length > 0))
                for (int i = 0; i < pCondition.Length; i++)
                    command.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);

            if (transaction != null)
                command.Transaction = transaction;
            return command;
        }

        private OleDbCommand BuildInsertCmd(string table, string[] listCols, object[] listValues)
        {
            OleDbCommand command = dbConnection.CreateCommand();
            string str = "INSERT INTO " + table + "(";
            foreach (string col in listCols)
                str += "[" + col + "],";

            str = str.Substring(0, str.Length - 1) + ") VALUES (";
            foreach (string col in listCols)
                str += "@" + col.Trim(new char[] { '[', ']' }) + ",";

            str = str.Substring(0, str.Length - 1) + ")";
            for (int k = 0; k < listCols.Length; k++)
            {
                if (listValues[k] != null && listValues[k].GetType().Name == "DateTime")
                    command.Parameters.Add("@" + listCols[k], OleDbType.Date).Value = listValues[k];
                else
                    command.Parameters.AddWithValue("@" + listCols[k], listValues[k]);
            }
            command.CommandText = str;

            if (transaction != null)
                command.Transaction = transaction;

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
                    if (pCondition[i + 1].GetType().Name == "DateTime")
                        command.Parameters.Add(pCondition[i].ToString(), OleDbType.Date).Value = pCondition[++i];
                    else
                        command.Parameters.AddWithValue(pCondition[i].ToString(), pCondition[++i]);
                }
            }
            if (transaction != null)
                command.Transaction = transaction;
            return command;
        }

        private OleDbCommand BuildUpdateCmd(string table, string[] listCols, object[] listValues, string condition, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
            string str = "UPDATE " + table + " SET ";
            foreach (string col in listCols)
                str += "[" + col + "] = @" + col + ",";

            str = str.Substring(0, str.Length - 1);
            if (!string.IsNullOrEmpty(condition))
                str += " WHERE " + condition;

            for (int j = 0; j < listCols.Length; j++)
            {
                if (listValues[j] != null && listValues[j].GetType().Name == "DateTime")
                    command.Parameters.Add("@" + listCols[j], OleDbType.Date).Value = listValues[j];
                else
                    command.Parameters.AddWithValue("@" + listCols[j], listValues[j]);
            }

            if (pCondition != null)
                for (int k = 0; k < pCondition.Length; k++)
                {
                    if (pCondition[k + 1].GetType().Name == "DateTime")
                        command.Parameters.Add(pCondition[k].ToString(), OleDbType.Date).Value = pCondition[++k];
                    else
                        command.Parameters.AddWithValue(pCondition[k].ToString(), pCondition[++k]);
                }

            command.CommandText = str;

            if (transaction != null)
                command.Transaction = transaction;

            return command;
        }
        #endregion utils

        #region IDataController Members


        public DataTable GetAttendanceReport(DateTime dateTime, DateTime dateTime_2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}