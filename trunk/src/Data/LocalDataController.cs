using System;

using System.Text;
using System.Data.OleDb;
using System.Data;
using FaceIDAppVBEta.Class;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FaceIDAppVBEta.Data
{
    public class LocalDataController : MarshalByRefObject, IDataController
    {
        private static readonly string _dbPath = @"F:\FaceID\FaceIDApp\db\FaceIDdb.mdb";
        //private static readonly string _dbPath = @"F:\vnanh\project\FaceID\db\FaceIDdb.mdb";
        //private static readonly string _dbPath = @"FaceIDdb.mdb";

        private static string connStr = @"Provider=Microsoft.JET.OLEDB.4.0;data source=" + _dbPath;

        private OleDbTransaction transaction;
        private static OleDbConnection dbConnection;
        private static LocalDataController instance;
        private static readonly Object mutex = new Object();

        //private int timeBound1 = 60;
        private int timeBound2 = 0;

        public LocalDataController()
        {
            ConnectToDatabase();
        }

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

        ~LocalDataController()
        {
            DisconnectFromDatabase();
        }

        #region Connection
        public void RefreshConnection()
        {
            if (dbConnection == null)
            {
                dbConnection = new OleDbConnection(connStr);
            }
            while (dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(500);
            }
            while (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
                System.Threading.Thread.Sleep(500);
            }
        }

        public static void ConnectToDatabase()
        {
            if (dbConnection == null)
            {
                dbConnection = new OleDbConnection(connStr);
            }
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
        }

        public static void DisconnectFromDatabase()
        {
            if (dbConnection != null)
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    try
                    {
                        dbConnection.Close();
                    }
                    catch { }
                }
            }
        }

        private int _token = 0;
        public void BeginTransaction()
        {
            if (_token == 0)
            {
                transaction = dbConnection.BeginTransaction();
            }

            _token++;
        }

        public void CommitTransaction()
        {
            _token--;

            if (_token == 0)
            {
                transaction.Commit();
                transaction.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            _token--;

            if (_token == 0)
            {
                transaction.Rollback();
                transaction.Dispose();
            }
        }

        #endregion Connection

        #region Company
        public List<Company> GetCompanyList()
        {
            return GetCompanyList(true);
        }

        public List<Company> GetCompanyList(bool viewDefault)
        {
            OleDbCommand odCom = null;
            if (viewDefault)
                odCom = BuildSelectCmd("Company", "*", null);
            else
                odCom = BuildSelectCmd("Company", "*", "ID<>1");
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Company> companyList = new List<Company>();
            Company company = null;
            while (odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = odRdr["Name"].ToString();

                companyList.Add(company);
            }

            odRdr.Close();
            return companyList;
        }

        public Company GetCompany(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "ID=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Company company = null;
            if (odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = odRdr["Name"].ToString();
            }

            odRdr.Close();
            return company;
        }

        public Company GetCompany(string name)
        {
            OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "[Name]=@Name", new object[] { "@Name", name });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Company company = null;
            if (odRdr.Read())
            {
                company = new Company();

                company.ID = (int)odRdr["ID"];
                company.Name = odRdr["Name"].ToString();
            }

            odRdr.Close();
            return company;
        }

        private bool CheckExistCompanyName(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            OleDbCommand odCom = BuildSelectCmd("Company", "ID",
                "[Name]=@Name" + (id > 0 ? " AND ID <> " + id : ""), new object[] { "@Name", name });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public List<Department> GetDepartmentByCompany(int companyID)
        {
            return GetDepartmentByCompany(companyID, true);
        }

        public List<Department> GetDepartmentByCompany(int companyID, bool viewDefault)
        {
            OleDbCommand odCom = BuildSelectCmd("Department", "*", "CompanyID=@ID" + (viewDefault ? "" : " AND ID<>1"), new object[] { "@ID", companyID });
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];

                departmentList.Add(department);
            }
            odRdr.Close();
            return departmentList;
        }

        public int AddCompany(Company company)
        {
            if (company == null || CheckExistCompanyName(company.Name, 0))
                return -1;
            OleDbCommand odCom1 = BuildInsertCmd("Company",
                new string[] { "Name" },
                new object[] { company.Name }
                );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteCompany(int id)
        {
            if (id == 1) return false;
            OleDbCommand odCom1 = BuildDelCmd("Company", "ID=@ID", new object[] { "@ID", id });
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            if (company == null || CheckExistCompanyName(company.Name, company.ID))
                return false;

            OleDbCommand odCom1 = BuildUpdateCmd("Company",
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
            OleDbCommand odCom = BuildSelectCmd("Department", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            Department department = null;
            while (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];

                departmentList.Add(department);
            }

            odRdr.Close();
            return departmentList;
        }

        private List<Department> GetDepartmentListByGroup(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("Department", "ID",
                "ID=@ID OR SupDepartmentID=@ID",
                new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();
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
            OleDbCommand odCom = BuildSelectCmd("Department", "*", "ID=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Department department = null;
            if (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];
            }

            odRdr.Close();
            return department;
        }

        private bool CheckExistDepartmentName(string name, int companyID, int id)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            object[] parames;
            string condition = "[Name]=@Name AND CompanyID=@CompanyID";
            if (id > 0)
            {
                condition += " AND ID<>@ID";
                parames = new object[] { "@Name", name, "@CompanyID", companyID, "@ID", id };
            }
            else
            {
                parames = new object[] { "@Name", name, "@CompanyID", companyID };
            }
            OleDbCommand odCom = BuildSelectCmd("Department", "ID", condition, parames);
            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }

            return false;
        }

        public int AddDepartment(Department department)
        {
            if (department == null || CheckExistDepartmentName(department.Name, department.CompanyID, 0))
                return -1;
            OleDbCommand odCom1 = BuildInsertCmd("Department",
                new string[] { "Name", "CompanyID", "SupDepartmentID" },
                new object[] { department.Name, department.CompanyID, department.SupDepartmentID }
                );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                int rs = Convert.ToInt32(odCom1.ExecuteScalar().ToString());
                return rs;
            }

            return -1;
        }

        public bool UpdateDepartment(Department department)
        {
            if (department == null || CheckExistDepartmentName(department.Name, department.CompanyID, department.ID))
                return false;

            OleDbCommand odCom1 = BuildUpdateCmd("Department",
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
                    OleDbCommand odCom2 = BuildUpdateCmd("Department",
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
            if (id == 1) return false;

            OleDbCommand odCom1 = null;
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

        public List<EmployeeReport> GetEmployeeReportList(int compantID, int departmentID)
        {
            OleDbCommand odCom;
            if (departmentID == 1 || compantID == 1)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID=1");
            else if (departmentID > 0)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID=@ID AND Active=TRUE", new object[] { "@ID", departmentID });
            else if (compantID > 0)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID) AND Active=true", new object[] { "@ID", compantID });
            else
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "Active=true");

            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<EmployeeReport> employeeList = new List<EmployeeReport>();
            EmployeeReport employee = null;
            int employeeNo = 1;
            while (odRdr.Read())
            {
                employee = new EmployeeReport();
                employee.DepartmentName = odRdr["DepartmentName"].ToString();
                employee.EmployeeNo = employeeNo++;
                employee.FullName = odRdr["LastName"] + ", " + odRdr["FirstName"];
                if (typeof(DBNull) != odRdr["HiredDate"].GetType())
                    employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public bool IsNewEmployee(Employee employee)
        {
            bool result = false;
            OleDbCommand odCom = BuildSelectCmd("Employee", "PayrollNumber", "Active=TRUE AND EmployeeNumber=@EmployeeNumber", new object[] { "@EmployeeNumber", employee.EmployeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            result = (odRdr.Read() == false);
            odRdr.Close();
            return result;
        }

        public Employee GetEmployee(int employeeID)
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "*", "PayrollNumber=@ID", new object[] { "@ID", employeeID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Employee employee = null;
            if (odRdr.Read())
            {
                employee = new Employee();

                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.FirstName = odRdr["FirstName"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.HiredDate = odRdr["HiredDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["HiredDate"]) : Config.MinDate;
                employee.LeftDate = odRdr["LeftDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["LeftDate"]) : Config.MinDate;
                employee.Birthday = odRdr["Birthday"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["Birthday"]) : Config.MinDate;
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.Address = odRdr["Address"].ToString();
                employee.Active = Convert.ToBoolean(odRdr["Active"]);
                employee.ActiveFrom = odRdr["ActiveFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveFrom"]) : Config.MinDate;
                employee.ActiveTo = odRdr["ActiveTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveTo"]) : Config.MinDate;
                employee.FaceData1 = odRdr["FaceData1"].ToString();
                employee.FaceData2 = odRdr["FaceData2"].ToString();
                employee.FaceData3 = odRdr["FaceData3"].ToString();
                employee.FaceData4 = odRdr["FaceData4"].ToString();
                employee.FaceData5 = odRdr["FaceData5"].ToString();
                employee.FaceData6 = odRdr["FaceData6"].ToString();
                employee.FaceData7 = odRdr["FaceData7"].ToString();
                employee.FaceData8 = odRdr["FaceData8"].ToString();
                employee.FaceData9 = odRdr["FaceData9"].ToString();
                employee.FaceData10 = odRdr["FaceData10"].ToString();
                employee.FaceData11 = odRdr["FaceData11"].ToString();
                employee.FaceData12 = odRdr["FaceData12"].ToString();
                employee.FaceData13 = odRdr["FaceData13"].ToString();
                employee.FaceData14 = odRdr["FaceData14"].ToString();
                employee.FaceData15 = odRdr["FaceData15"].ToString();
                employee.FaceData16 = odRdr["FaceData16"].ToString();
                employee.FaceData17 = odRdr["FaceData17"].ToString();
                employee.FaceData18 = odRdr["FaceData18"].ToString();
            }
            odRdr.Close();
            return employee;
        }

        public List<Employee> GetEmployeeList(int compantID, int departmentID)
        {
            OleDbCommand odCom;
            if (departmentID == 1 && compantID == 1) //default company and default department
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID=1 AND Active=TRUE");
            else if (departmentID > 0)
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID=@ID AND Active=TRUE", new object[] { "@ID", departmentID });
            else if (compantID > 0) //WRONG
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID) AND Active=TRUE", new object[] { "@ID", compantID });
            else // all companies and all department
                odCom = BuildSelectCmd("Employee", "*", "Active=TRUE");

            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();

                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.FirstName = odRdr["FirstName"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.HiredDate = odRdr["HiredDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["HiredDate"]) : Config.MinDate;
                employee.LeftDate = odRdr["LeftDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["LeftDate"]) : Config.MinDate;
                employee.Birthday = odRdr["Birthday"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["Birthday"]) : Config.MinDate;
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.Address = odRdr["Address"].ToString();
                employee.Active = Convert.ToBoolean(odRdr["Active"]);
                employee.ActiveFrom = odRdr["ActiveFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveFrom"]) : Config.MinDate;
                employee.ActiveTo = odRdr["ActiveTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveTo"]) : Config.MinDate;
                employee.FaceData1 = odRdr["FaceData1"].ToString();
                employee.FaceData2 = odRdr["FaceData2"].ToString();
                employee.FaceData3 = odRdr["FaceData3"].ToString();
                employee.FaceData4 = odRdr["FaceData4"].ToString();
                employee.FaceData5 = odRdr["FaceData5"].ToString();
                employee.FaceData6 = odRdr["FaceData6"].ToString();
                employee.FaceData7 = odRdr["FaceData7"].ToString();
                employee.FaceData8 = odRdr["FaceData8"].ToString();
                employee.FaceData9 = odRdr["FaceData9"].ToString();
                employee.FaceData10 = odRdr["FaceData10"].ToString();
                employee.FaceData11 = odRdr["FaceData11"].ToString();
                employee.FaceData12 = odRdr["FaceData12"].ToString();
                employee.FaceData13 = odRdr["FaceData13"].ToString();
                employee.FaceData14 = odRdr["FaceData14"].ToString();
                employee.FaceData15 = odRdr["FaceData15"].ToString();
                employee.FaceData16 = odRdr["FaceData16"].ToString();
                employee.FaceData17 = odRdr["FaceData17"].ToString();
                employee.FaceData18 = odRdr["FaceData18"].ToString();

                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public bool IsExistEmployeeNumber(int employeeNumber)
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber", "EmployeeNumber=@EmployeeNumber", new object[] { "@EmployeeNumber", employeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public int AddEmployee(Employee employee, List<Terminal> terminalList)
        {
            BeginTransaction();

            try
            {
                //if Employee is added from terminal then Employee No has been assigned already
                if (employee.EmployeeNumber <= 0)
                    employee.EmployeeNumber = GetAvailEmployeeNumber();
                else
                    AddEmployeeNumber(employee.EmployeeNumber);

                if (employee.EmployeeNumber > 0)
                {
                    employee.PayrollNumber = AddEmployee(employee);

                    if (terminalList.Count > 0)
                    {
                        List<EmployeeTerminal> employeeTerminalList = new List<EmployeeTerminal>();
                        foreach (Terminal terminal in terminalList)
                        {
                            EmployeeTerminal emplTerminal = new EmployeeTerminal();
                            emplTerminal.TerminalID = terminal.ID;
                            emplTerminal.EmployeeNumber = employee.EmployeeNumber;

                            employeeTerminalList.Add(emplTerminal);
                        }

                        AddEmployeeTerminal(employeeTerminalList);
                    }

                    CommitTransaction();
                }
                else
                {
                    throw new Exception("There's no more employee number available. Please enter your CC detail to purchase more.");
                }
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }

            return employee.PayrollNumber;
        }

        private int AddEmployee(Employee employee)
        {
            OleDbCommand odCom1 = BuildInsertCmd("Employee",
                new string[] { "EmployeeNumber"
                ,"DepartmentID"
                ,"FirstName"
                ,"LastName"
                ,"WorkingCalendarID"
                ,"HiredDate"
                ,"LeftDate"
                ,"Birthday"
                ,"JobDescription"
                ,"PhoneNumber"
                ,"Address"
                ,"Active"
                ,"ActiveFrom"
                ,"ActiveTo"
                ,"FaceData1"
                ,"FaceData2"
                ,"FaceData3"
                ,"FaceData4"
                ,"FaceData5"
                ,"FaceData6"
                ,"FaceData7"
                ,"FaceData8"
                ,"FaceData9"
                ,"FaceData10"
                ,"FaceData11"
                ,"FaceData12"
                ,"FaceData13"
                ,"FaceData14"
                ,"FaceData15"
                ,"FaceData16"
                ,"FaceData17"
                ,"FaceData18"
                },
                new object[] { employee.EmployeeNumber
                ,employee.DepartmentID
                ,employee.FirstName
                ,employee.LastName
                ,employee.WorkingCalendarID
                ,employee.HiredDate
                ,employee.LeftDate
                ,employee.Birthday
                ,employee.JobDescription
                ,employee.PhoneNumber
                ,employee.Address
                ,employee.Active
                ,employee.ActiveFrom
                ,employee.ActiveTo
                ,employee.FaceData1
                ,employee.FaceData2
                ,employee.FaceData3
                ,employee.FaceData4
                ,employee.FaceData5
                ,employee.FaceData6
                ,employee.FaceData7
                ,employee.FaceData8
                ,employee.FaceData9
                ,employee.FaceData10
                ,employee.FaceData11
                ,employee.FaceData12
                ,employee.FaceData13
                ,employee.FaceData14
                ,employee.FaceData15
                ,employee.FaceData16
                ,employee.FaceData17
                ,employee.FaceData18
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteEmployee(int employeeID)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] { "Active", "ActiveTo" }, new object[] { false, DateTime.Now }, "PayrollNumber=@ID",
                new object[] { "@ID", employeeID }
            );
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] { "EmployeeNumber"
                ,"DepartmentID"
                ,"FirstName"
                ,"LastName"
                ,"WorkingCalendarID"
                ,"HiredDate"
                ,"LeftDate"
                ,"Birthday"
                ,"JobDescription"
                ,"PhoneNumber"
                ,"Address"
                ,"Active"
                ,"ActiveFrom"
                ,"ActiveTo"
                ,"FaceData1"
                ,"FaceData2"
                ,"FaceData3"
                ,"FaceData4"
                ,"FaceData5"
                ,"FaceData6"
                ,"FaceData7"
                ,"FaceData8"
                ,"FaceData9"
                ,"FaceData10"
                ,"FaceData11"
                ,"FaceData12"
                ,"FaceData13"
                ,"FaceData14"
                ,"FaceData15"
                ,"FaceData16"
                ,"FaceData17"
                ,"FaceData18"
                },
                new object[] { employee.EmployeeNumber
                ,employee.DepartmentID
                ,employee.FirstName
                ,employee.LastName
                ,employee.WorkingCalendarID
                ,employee.HiredDate
                ,employee.LeftDate
                ,employee.Birthday
                ,employee.JobDescription
                ,employee.PhoneNumber
                ,employee.Address
                ,employee.Active
                ,employee.ActiveFrom
                ,employee.ActiveTo
                ,employee.FaceData1
                ,employee.FaceData2
                ,employee.FaceData3
                ,employee.FaceData4
                ,employee.FaceData5
                ,employee.FaceData6
                ,employee.FaceData7
                ,employee.FaceData8
                ,employee.FaceData9
                ,employee.FaceData10
                ,employee.FaceData11
                ,employee.FaceData12
                ,employee.FaceData13
                ,employee.FaceData14
                ,employee.FaceData15
                ,employee.FaceData16
                ,employee.FaceData17
                ,employee.FaceData18
                },
                "PayrollNumber=@ID", new object[] { "@ID", employee.PayrollNumber }
            );

            return (odCom1.ExecuteNonQuery() == 1);
        }

        #endregion Employee

        #region Terminal
        public List<Terminal> GetTerminalList()
        {
            OleDbCommand odCom = BuildSelectCmd("Terminal", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Terminal> terminalList = new List<Terminal>();
            Terminal terminal = null;
            while (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = (int)odRdr["ID"];
                terminal.Name = odRdr["Name"].ToString();
                terminal.IPAddress = odRdr["IPAddress"].ToString();

                terminalList.Add(terminal);
            }

            odRdr.Close();
            return terminalList;
        }

        public Terminal GetTerminal(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("Terminal", "*", "ID=@ID", new object[] { "@ID", id });

            OleDbDataReader odRdr = odCom.ExecuteReader();

            Terminal terminal = null;
            if (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = Convert.ToInt32(odRdr["ID"]);
                terminal.Name = odRdr["Name"].ToString();
                terminal.IPAddress = odRdr["IPAddress"].ToString();
            }

            odRdr.Close();
            return terminal;
        }

        public bool IsDuplicateTerminal(Terminal terminal, bool existTerminal)
        {
            OleDbCommand odCom;
            if (existTerminal)
                odCom = BuildSelectCmd("Terminal", "ID", "ID<>@ID AND ([Name]=@Name OR IPAddress=@IPAddress)",
                    new object[] { "@ID", terminal.ID, "@Name", terminal.Name, "@IPAddress", terminal.IPAddress });
            else
                odCom = BuildSelectCmd("Terminal", "ID", "[Name]=@Name OR IPAddress=@IPAddress",
                    new object[] { "@Name", terminal.Name, "@IPAddress", terminal.IPAddress });

            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public int AddTerminal(Terminal terminal)
        {
            if (IsDuplicateTerminal(terminal, false))
                return -1;

            OleDbCommand odCom1 = BuildInsertCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { terminal.Name
                ,terminal.IPAddress
                }
            );

            if (ExecuteNonQuery(odCom1) == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateTerminal(Terminal terminal)
        {
            if (IsDuplicateTerminal(terminal, true))
                return false;

            OleDbCommand odCom1 = BuildUpdateCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { terminal.Name
                ,terminal.IPAddress
                },
                "ID=@ID", new object[] { "@ID", terminal.ID }
            );

            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        public bool DeleteTerminal(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("Terminal", "ID=@ID", new object[] { "@ID", id });
            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        #endregion Terminal

        #region EmployeeTerminal

        public List<EmployeeTerminal> GetEmployeeTerminalsByEmpl(int employeeNumber)
        {
            OleDbCommand odCom = BuildSelectCmd("EmployeeTerminal", "*", "EmployeeNumber=@EmployeeNumber", new object[] { "@EmployeeNumber", employeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

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

        public List<Terminal> GetTerminalListByEmployee(int employeeNumber)
        {
            OleDbCommand odCom = BuildSelectCmd("Terminal", "*", "ID in (SELECT TerminalID FROM EmployeeTerminal WHERE EmployeeNumber=@EmployeeNumber)", new object[] { "@EmployeeNumber", employeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            List<Terminal> terminals = new List<Terminal>();
            Terminal terminal = null;
            while (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = (int)odRdr["ID"];
                terminal.Name = odRdr["Name"].ToString();
                terminals.Add(terminal);
            }

            odRdr.Close();
            return terminals;
        }

        public List<EmployeeTerminal> GetEmployeeTerminalList()
        {
            throw new NotImplementedException();
        }

        public int AddEmployeeTerminal(List<EmployeeTerminal> emplTerminals)
        {
            if (emplTerminals == null)
                return -1;

            OleDbCommand odCom1 = null;

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

        public bool DeleteEmployeeTerminalByEmployee(int employeeNumber)
        {
            OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }

        public bool DeleteEmployeeTerminal(int terminalID)
        {
            OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "TerminalID=@ID", new object[] { "@ID", terminalID });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }

        public bool UpdateEmployeeTerminal(List<Terminal> terminals, int employeeNumber)
        {
            BeginTransaction();
            OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });

            if (ExecuteNonQuery(odCom1) < 0)
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

                if (ExecuteNonQuery(odCom1) < 1)
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
            OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber", "Active=TRUE");
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<EmployeeNumber> employeeNumberList = new List<EmployeeNumber>();
            EmployeeNumber employeeNumber = null;
            while (odRdr.Read())
            {
                employeeNumber = new EmployeeNumber();

                employeeNumber.ID = Convert.ToInt32(odRdr["EmployeeNumber"]);

                employeeNumberList.Add(employeeNumber);
            }

            odRdr.Close();
            return employeeNumberList;
        }

        public int GetAvailEmployeeNumber()
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "MIN(EmployeeNumber) AS EmployeeNumber", "Active=FALSE AND EmployeeNumber NOT IN(SELECT EmployeeNumber FROM Employee WHERE Active=TRUE)");
            OleDbDataReader odRdr = odCom.ExecuteReader();

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

            return AddEmployeeNumber(employeeNumber);
        }

        public int AddEmployeeNumber(int employeeNumber)
        {
            if (GetEmployeeNumber(employeeNumber) != null)
            {
                return employeeNumber;
            }
            else
            {
                OleDbCommand odCom1 = BuildInsertCmd("EmployeeNumber",
                    new string[] { "ID"
                },
                    new object[] { employeeNumber
                }
                );

                if (odCom1.ExecuteNonQuery() == 1)
                {
                    return employeeNumber;
                }
            }
            return -1;
        }

        public EmployeeNumber GetEmployeeNumber(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("EmployeeNumber", "*", "ID=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            EmployeeNumber employeeNumber = null;
            if (odRdr.Read())
            {
                employeeNumber = new EmployeeNumber();

                employeeNumber.ID = Convert.ToInt32(odRdr["ID"]);
            }

            odRdr.Close();
            return employeeNumber;
        }

        #endregion EmployeeNumber

        #region WorkingCalendar
        public List<WorkingCalendar> GetWorkingCalendarList()
        {
            OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<WorkingCalendar> workingCalendarList = new List<WorkingCalendar>();
            WorkingCalendar workingCalendar = null;
            while (odRdr.Read())
            {
                workingCalendar = new WorkingCalendar();

                workingCalendar.ID = (int)odRdr["ID"];
                workingCalendar.Name = odRdr["Name"].ToString();
                workingCalendar.WorkOnMonday = Convert.ToBoolean(odRdr["WorkOnMonday"]);
                workingCalendar.WorkOnTuesday = Convert.ToBoolean(odRdr["WorkOnTuesday"]);
                workingCalendar.WorkOnWednesday = Convert.ToBoolean(odRdr["WorkOnWednesday"]);
                workingCalendar.WorkOnThursday = Convert.ToBoolean(odRdr["WorkOnThursday"]);
                workingCalendar.WorkOnFriday = Convert.ToBoolean(odRdr["WorkOnFriday"]);
                workingCalendar.WorkOnSaturday = Convert.ToBoolean(odRdr["WorkOnSaturday"]);
                workingCalendar.WorkOnSunday = Convert.ToBoolean(odRdr["WorkOnSunday"]);
                workingCalendar.RegularWorkingFrom = odRdr["RegularWorkingFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingFrom"]) : Config.MinDate;
                workingCalendar.RegularWorkingTo = odRdr["RegularWorkingTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingTo"]) : Config.MinDate;
                workingCalendar.PayPeriodID = (int)odRdr["PayPeriodID"];
                workingCalendar.GraceForwardToEntry = (int)odRdr["GraceForwardToEntry"];
                workingCalendar.GraceBackwardToExit = (int)odRdr["GraceBackwardToExit"];
                workingCalendar.EarliestBeforeEntry = (int)odRdr["EarliestBeforeEntry"];
                workingCalendar.LastestAfterExit = (int)odRdr["LastestAfterExit"];

                workingCalendarList.Add(workingCalendar);
            }

            odRdr.Close();
            return workingCalendarList;
        }

        public WorkingCalendar GetWorkingCalendarByEmployee(int employeeNumber)
        {
            OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*",
                "ID=(Select TOP 1 WorkingCalendarID From Employee Where EmployeeNumber=@ID AND Active=TRUE)", new object[] { "@ID", employeeNumber });

            OleDbDataReader odRdr = odCom.ExecuteReader();

            WorkingCalendar workingCalendar = null;
            if (odRdr.Read())
            {
                workingCalendar = new WorkingCalendar();

                workingCalendar.ID = (int)odRdr["ID"];
                workingCalendar.Name = odRdr["Name"].ToString();
                workingCalendar.WorkOnMonday = Convert.ToBoolean(odRdr["WorkOnMonday"]);
                workingCalendar.WorkOnTuesday = Convert.ToBoolean(odRdr["WorkOnTuesday"]);
                workingCalendar.WorkOnWednesday = Convert.ToBoolean(odRdr["WorkOnWednesday"]);
                workingCalendar.WorkOnThursday = Convert.ToBoolean(odRdr["WorkOnThursday"]);
                workingCalendar.WorkOnFriday = Convert.ToBoolean(odRdr["WorkOnFriday"]);
                workingCalendar.WorkOnSaturday = Convert.ToBoolean(odRdr["WorkOnSaturday"]);
                workingCalendar.WorkOnSunday = Convert.ToBoolean(odRdr["WorkOnSunday"]);
                workingCalendar.RegularWorkingFrom = odRdr["RegularWorkingFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingFrom"]) : Config.MinDate;
                workingCalendar.RegularWorkingTo = odRdr["RegularWorkingTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingTo"]) : Config.MinDate;
                workingCalendar.PayPeriodID = (int)odRdr["PayPeriodID"];
                workingCalendar.GraceForwardToEntry = (int)odRdr["GraceForwardToEntry"];
                workingCalendar.GraceBackwardToExit = (int)odRdr["GraceBackwardToExit"];
                workingCalendar.EarliestBeforeEntry = (int)odRdr["EarliestBeforeEntry"];
                workingCalendar.LastestAfterExit = (int)odRdr["LastestAfterExit"];
            }

            odRdr.Close();
            return workingCalendar;
        }

        public WorkingCalendar GetWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*", "ID=@ID", new object[] { "@ID", workingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            WorkingCalendar workingCalendar = null;
            if (odRdr.Read())
            {
                workingCalendar = new WorkingCalendar();

                workingCalendar.ID = (int)odRdr["ID"];
                workingCalendar.Name = odRdr["Name"].ToString();
                workingCalendar.WorkOnMonday = Convert.ToBoolean(odRdr["WorkOnMonday"]);
                workingCalendar.WorkOnTuesday = Convert.ToBoolean(odRdr["WorkOnTuesday"]);
                workingCalendar.WorkOnWednesday = Convert.ToBoolean(odRdr["WorkOnWednesday"]);
                workingCalendar.WorkOnThursday = Convert.ToBoolean(odRdr["WorkOnThursday"]);
                workingCalendar.WorkOnFriday = Convert.ToBoolean(odRdr["WorkOnFriday"]);
                workingCalendar.WorkOnSaturday = Convert.ToBoolean(odRdr["WorkOnSaturday"]);
                workingCalendar.WorkOnSunday = Convert.ToBoolean(odRdr["WorkOnSunday"]);
                workingCalendar.RegularWorkingFrom = odRdr["RegularWorkingFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingFrom"]) : Config.MinDate;
                workingCalendar.RegularWorkingTo = odRdr["RegularWorkingTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["RegularWorkingTo"]) : Config.MinDate;
                workingCalendar.PayPeriodID = (int)odRdr["PayPeriodID"];
                workingCalendar.GraceForwardToEntry = (int)odRdr["GraceForwardToEntry"];
                workingCalendar.GraceBackwardToExit = (int)odRdr["GraceBackwardToExit"];
                workingCalendar.EarliestBeforeEntry = (int)odRdr["EarliestBeforeEntry"];
                workingCalendar.LastestAfterExit = (int)odRdr["LastestAfterExit"];
            }

            odRdr.Close();
            return workingCalendar;
        }

        public List<Break> GetBreakListByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("Break", "*", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });

            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Break> breakList = new List<Break>();
            Break _break = null;
            while (odRdr.Read())
            {
                _break = new Break();

                _break.ID = Convert.ToInt16(odRdr["ID"]);
                _break.Name = odRdr["Name"].ToString();
                _break.From = Convert.ToDateTime(odRdr["From"]);
                _break.To = Convert.ToDateTime(odRdr["To"]);
                _break.Paid = Convert.ToBoolean(odRdr["Paid"]);
                _break.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);

                breakList.Add(_break);
            }

            odRdr.Close();
            return breakList;
        }

        public PaymentRate GetWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=1", new object[] { "@WorkingCalendarID", workingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            PaymentRate paymentRate = null;
            if (odRdr.Read())
            {
                paymentRate = new PaymentRate();

                paymentRate.ID = Convert.ToInt16(odRdr["ID"]);
                paymentRate.NumberOfRegularHours = Convert.ToDouble(odRdr["NumberOfRegularHours"]);
                paymentRate.RegularRate = Convert.ToDouble(odRdr["RegularRate"]);
                paymentRate.NumberOfOvertime1 = Convert.ToDouble(odRdr["NumberOfOvertime1"]);
                paymentRate.OvertimeRate1 = Convert.ToDouble(odRdr["OvertimeRate1"]);
                paymentRate.NumberOfOvertime2 = Convert.ToDouble(odRdr["NumberOfOvertime2"]);
                paymentRate.OvertimeRate2 = Convert.ToDouble(odRdr["OvertimeRate2"]);
                paymentRate.NumberOfOvertime3 = Convert.ToDouble(odRdr["NumberOfOvertime3"]);
                paymentRate.OvertimeRate3 = Convert.ToDouble(odRdr["OvertimeRate3"]);
                paymentRate.NumberOfOvertime4 = Convert.ToDouble(odRdr["NumberOfOvertime4"]);
                paymentRate.OvertimeRate4 = Convert.ToDouble(odRdr["OvertimeRate4"]);
                paymentRate.DayTypeID = Convert.ToInt16(odRdr["DayTypeID"]);
                paymentRate.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);
            }

            odRdr.Close();
            return paymentRate;
        }

        public PaymentRate GetNonWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=2", new object[] { "@WorkingCalendarID", workingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            PaymentRate paymentRate = null;
            if (odRdr.Read())
            {
                paymentRate = new PaymentRate();

                paymentRate.ID = Convert.ToInt16(odRdr["ID"]);
                paymentRate.NumberOfRegularHours = Convert.ToDouble(odRdr["NumberOfRegularHours"]);
                paymentRate.RegularRate = Convert.ToDouble(odRdr["RegularRate"]);
                paymentRate.NumberOfOvertime1 = Convert.ToDouble(odRdr["NumberOfOvertime1"]);
                paymentRate.OvertimeRate1 = Convert.ToDouble(odRdr["OvertimeRate1"]);
                paymentRate.NumberOfOvertime2 = Convert.ToDouble(odRdr["NumberOfOvertime2"]);
                paymentRate.OvertimeRate2 = Convert.ToDouble(odRdr["OvertimeRate2"]);
                paymentRate.NumberOfOvertime3 = Convert.ToDouble(odRdr["NumberOfOvertime3"]);
                paymentRate.OvertimeRate3 = Convert.ToDouble(odRdr["OvertimeRate3"]);
                paymentRate.NumberOfOvertime4 = Convert.ToDouble(odRdr["NumberOfOvertime4"]);
                paymentRate.OvertimeRate4 = Convert.ToDouble(odRdr["OvertimeRate4"]);
                paymentRate.DayTypeID = Convert.ToInt16(odRdr["DayTypeID"]);
                paymentRate.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);
            }

            odRdr.Close();
            return paymentRate;
        }

        public PaymentRate GetHolidayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=3", new object[] { "@WorkingCalendarID", workingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            PaymentRate paymentRate = null;
            if (odRdr.Read())
            {
                paymentRate = new PaymentRate();

                paymentRate.ID = Convert.ToInt16(odRdr["ID"]);
                paymentRate.NumberOfRegularHours = Convert.ToDouble(odRdr["NumberOfRegularHours"]);
                paymentRate.RegularRate = Convert.ToDouble(odRdr["RegularRate"]);
                paymentRate.NumberOfOvertime1 = Convert.ToDouble(odRdr["NumberOfOvertime1"]);
                paymentRate.OvertimeRate1 = Convert.ToDouble(odRdr["OvertimeRate1"]);
                paymentRate.NumberOfOvertime2 = Convert.ToDouble(odRdr["NumberOfOvertime2"]);
                paymentRate.OvertimeRate2 = Convert.ToDouble(odRdr["OvertimeRate2"]);
                paymentRate.NumberOfOvertime3 = Convert.ToDouble(odRdr["NumberOfOvertime3"]);
                paymentRate.OvertimeRate3 = Convert.ToDouble(odRdr["OvertimeRate3"]);
                paymentRate.NumberOfOvertime4 = Convert.ToDouble(odRdr["NumberOfOvertime4"]);
                paymentRate.OvertimeRate4 = Convert.ToDouble(odRdr["OvertimeRate4"]);
                paymentRate.DayTypeID = Convert.ToInt16(odRdr["DayTypeID"]);
                paymentRate.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);
            }

            odRdr.Close();
            return paymentRate;
        }

        public List<Holiday> GetHolidayListByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("Holiday", "*", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });

            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Holiday> holidayList = new List<Holiday>();
            Holiday holiday = null;
            while (odRdr.Read())
            {
                holiday = new Holiday();

                holiday.ID = Convert.ToInt16(odRdr["ID"]);
                holiday.Date = Convert.ToDateTime(odRdr["Date"]);
                holiday.Description = odRdr["Description"].ToString();
                holiday.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);

                holidayList.Add(holiday);
            }

            odRdr.Close();
            return holidayList;
        }

        public int AddWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate, PayPeriod payPeriod)
        {
            BeginTransaction();

            try
            {
                //add pay period
                payPeriod.ID = AddPayPeriod(payPeriod);

                if (payPeriod.ID < 0)
                    throw new NullReferenceException();

                workingCalendar.PayPeriodID = payPeriod.ID;
                workingCalendar.ID = AddWorkingCalendar(workingCalendar);

                if (workingCalendar.ID < 0)
                    throw new NullReferenceException();

                //add breaks
                foreach (Break _break in breakList)
                {
                    _break.WorkingCalendarID = workingCalendar.ID;
                    if (AddBreak(_break) < 0)
                        throw new NullReferenceException();
                }

                //add holidays
                foreach (Holiday holiday in holidayList)
                {
                    holiday.WorkingCalendarID = workingCalendar.ID;
                    if (AddHoliday(holiday) < 0)
                        throw new NullReferenceException();
                }

                //add payment rates
                workingDayPaymentRate.DayTypeID = 1; //working day
                workingDayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (AddPaymentRate(workingDayPaymentRate) < 0)
                    throw new NullReferenceException();

                nonWorkingDayPaymentRate.DayTypeID = 2; //non working day
                nonWorkingDayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (AddPaymentRate(nonWorkingDayPaymentRate) < 0)
                    throw new NullReferenceException();

                holidayPaymentRate.DayTypeID = 3; //holiday
                holidayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (AddPaymentRate(holidayPaymentRate) < 0)
                    throw new NullReferenceException();

                CommitTransaction();
            }
            catch (Exception)
            {
                RollbackTransaction();
                return -1;
            }

            return workingCalendar.ID;
        }

        private int AddWorkingCalendar(WorkingCalendar workingCalendar)
        {
            OleDbCommand odCom1 = BuildInsertCmd("WorkingCalendar",
                new string[] { "Name"
                ,"WorkOnMonday"
                ,"WorkOnTuesday"
                ,"WorkOnWednesday"
                ,"WorkOnThursday"
                ,"WorkOnFriday"
                ,"WorkOnSaturday"
                ,"WorkOnSunday"
                ,"RegularWorkingFrom"
                ,"RegularWorkingTo"
                ,"PayPeriodID"
                ,"GraceForwardToEntry"
                ,"GraceBackwardToExit"
                ,"EarliestBeforeEntry"
                ,"LastestAfterExit"
                },
                new object[] { workingCalendar.Name
                ,workingCalendar.WorkOnMonday
                ,workingCalendar.WorkOnTuesday
                ,workingCalendar.WorkOnWednesday
                ,workingCalendar.WorkOnThursday
                ,workingCalendar.WorkOnFriday
                ,workingCalendar.WorkOnSaturday
                ,workingCalendar.WorkOnSunday
                ,workingCalendar.RegularWorkingFrom
                ,workingCalendar.RegularWorkingTo
                ,workingCalendar.PayPeriodID
                ,workingCalendar.GraceForwardToEntry
                ,workingCalendar.GraceBackwardToExit
                ,workingCalendar.EarliestBeforeEntry
                ,workingCalendar.LastestAfterExit
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate, PayPeriod payPeriod)
        {
            BeginTransaction();

            try
            {
                //update pay period
                PayPeriod oldPayPeriod = GetPayPeriod(workingCalendar.PayPeriodID);

                if (ComparePayPeriods(payPeriod, oldPayPeriod) == true)
                {
                    payPeriod = oldPayPeriod;
                }
                else
                {
                    payPeriod.ID = AddPayPeriod(payPeriod);
                }

                if (payPeriod.ID < 0)
                    throw new NullReferenceException();

                workingCalendar.PayPeriodID = payPeriod.ID;

                if (UpdateWorkingCalendar(workingCalendar) == false)
                    throw new NullReferenceException();

                //update breaks
                foreach (Break _break in GetBreakListByWorkingCalendar(workingCalendar.ID))
                {
                    if (DeleteBreak(_break.ID) == false)
                        throw new NullReferenceException();
                }

                foreach (Break _break in breakList)
                {
                    _break.WorkingCalendarID = workingCalendar.ID;
                    if (AddBreak(_break) < 0)
                        throw new NullReferenceException();
                }

                //add holidays
                foreach (Holiday holiday in GetHolidayListByWorkingCalendar(workingCalendar.ID))
                {
                    if (DeleteHoliday(holiday.ID) == false)
                        throw new NullReferenceException();
                }

                foreach (Holiday holiday in holidayList)
                {
                    holiday.WorkingCalendarID = workingCalendar.ID;
                    if (AddHoliday(holiday) < 0)
                        throw new NullReferenceException();
                }

                //update payment rates
                workingDayPaymentRate.ID = GetWorkingDayPaymentRateByWorkingCalendar(workingCalendar.ID).ID;
                workingDayPaymentRate.DayTypeID = 1; //working day
                workingDayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (UpdatePaymentRate(workingDayPaymentRate) == false)
                    throw new NullReferenceException();

                nonWorkingDayPaymentRate.ID = GetNonWorkingDayPaymentRateByWorkingCalendar(workingCalendar.ID).ID;
                nonWorkingDayPaymentRate.DayTypeID = 2; //non working day
                nonWorkingDayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (UpdatePaymentRate(nonWorkingDayPaymentRate) == false)
                    throw new NullReferenceException();

                holidayPaymentRate.ID = GetHolidayPaymentRateByWorkingCalendar(workingCalendar.ID).ID;
                holidayPaymentRate.DayTypeID = 3; //holiday
                holidayPaymentRate.WorkingCalendarID = workingCalendar.ID;
                if (UpdatePaymentRate(holidayPaymentRate) == false)
                    throw new NullReferenceException();

                CommitTransaction();
            }
            catch (Exception)
            {
                RollbackTransaction();
                return false;
            }

            return true;
        }

        private bool ComparePayPeriods(PayPeriod payPeriod1, PayPeriod payPeriod2)
        {
            if (payPeriod1 == null || payPeriod2 == null)
                return false;

            if (payPeriod1.PayPeriodTypeID != payPeriod2.PayPeriodTypeID)
                return false;

            if (payPeriod1.StartFrom != payPeriod2.StartFrom)
                return false;

            if (payPeriod1.CustomPeriod != payPeriod2.CustomPeriod)
                return false;

            return true;
        }

        public bool UpdateWorkingCalendar(WorkingCalendar workingCalendar)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("WorkingCalendar",
                new string[] { "Name"
                ,"WorkOnMonday"
                ,"WorkOnTuesday"
                ,"WorkOnWednesday"
                ,"WorkOnThursday"
                ,"WorkOnFriday"
                ,"WorkOnSaturday"
                ,"WorkOnSunday"
                ,"RegularWorkingFrom"
                ,"RegularWorkingTo"
                ,"PayPeriodID"
                ,"GraceForwardToEntry"
                ,"GraceBackwardToExit"
                ,"EarliestBeforeEntry"
                ,"LastestAfterExit"
                },
                new object[] { workingCalendar.Name
                ,workingCalendar.WorkOnMonday
                ,workingCalendar.WorkOnTuesday
                ,workingCalendar.WorkOnWednesday
                ,workingCalendar.WorkOnThursday
                ,workingCalendar.WorkOnFriday
                ,workingCalendar.WorkOnSaturday
                ,workingCalendar.WorkOnSunday
                ,workingCalendar.RegularWorkingFrom
                ,workingCalendar.RegularWorkingTo
                ,workingCalendar.PayPeriodID
                ,workingCalendar.GraceForwardToEntry
                ,workingCalendar.GraceBackwardToExit
                ,workingCalendar.EarliestBeforeEntry
                ,workingCalendar.LastestAfterExit
                },
                "ID=@ID", new object[] { "@ID", workingCalendar.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool IsDuplicateWorkingCalendarName(string name)
        {
            bool result = false;

            OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "ID", "Name=@Name", new object[] { "@Name", name });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            odRdr.Close();
            return result;
        }

        public bool IsDuplicateWorkingCalendarName(string name, int workingCalendarID)
        {
            bool result = false;

            OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "ID", "Name=@Name AND ID<>@ID", new object[] { "@Name", name, "@ID", workingCalendarID });

            OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            odRdr.Close();
            return result;
        }

        public PayPeriodType GetPayPeriodType(int payPeriodTypeID)
        {
            OleDbCommand odCom = BuildSelectCmd("PayPeriodType", "*", "ID=@ID", new object[] { "@ID", payPeriodTypeID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            PayPeriodType payPeriodType = null;
            if (odRdr.Read())
            {
                payPeriodType = new PayPeriodType();

                payPeriodType.ID = Convert.ToInt16(odRdr["ID"]);
                payPeriodType.Name = odRdr["Name"].ToString();
            }

            odRdr.Close();
            return payPeriodType;
        }

        public PayPeriod GetPayPeriod(int payPeriodID)
        {
            OleDbCommand odCom = BuildSelectCmd("PayPeriod", "*", "ID=@ID", new object[] { "@ID", payPeriodID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            PayPeriod payPeriod = null;
            if (odRdr.Read())
            {
                payPeriod = new PayPeriod();

                payPeriod.ID = Convert.ToInt16(odRdr["ID"]);
                payPeriod.PayPeriodTypeID = Convert.ToInt16(odRdr["PayPeriodTypeID"]);
                payPeriod.StartFrom = Convert.ToDateTime(odRdr["StartFrom"]);
                payPeriod.CustomPeriod = Convert.ToInt16(odRdr["CustomPeriod"]);
            }

            odRdr.Close();
            return payPeriod;
        }

        public bool DeleteWorkingCalendar(int workingCalendarID)
        {
            BeginTransaction();

            try
            {
                if (IsInUseWorkingCalendar(workingCalendarID))
                    throw new Exception("Working Calendar is assigned to employees and cannot be deleted");

                //delete pay period
                //Pay Period is kept for reports, so no deleting here

                //delete breaks
                foreach (Break _break in GetBreakListByWorkingCalendar(workingCalendarID))
                {
                    if (DeleteBreak(_break.ID) == false)
                        throw new NullReferenceException();
                }

                //delete holidays
                foreach (Holiday holiday in GetHolidayListByWorkingCalendar(workingCalendarID))
                {
                    if (DeleteHoliday(holiday.ID) == false)
                        throw new NullReferenceException();
                }

                //delete payment rates
                if (DeletePaymentRateByWorkingCalendar(workingCalendarID) == false)
                    throw new NullReferenceException();

                //finally delete working calendar
                OleDbCommand odCom = BuildDelCmd("WorkingCalendar", "ID=@ID", new object[] { "@ID", workingCalendarID });
                if (odCom.ExecuteNonQuery() == 0)
                    throw new NullReferenceException();

                CommitTransaction();
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }

            return true;
        }

        private bool IsInUseWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "TOP 1 PayrollNumber",
                "WorkingCalendarID=@WorkingCalendarID AND Active=TRUE", new object[] { "@WorkingCalendarID", workingCalendarID });

            OleDbDataReader odRdr = odCom.ExecuteReader();


            bool result = odRdr.Read();

            odRdr.Close();
            return result;
        }
        #endregion

        #region Attendance Record

        private List<string> GetEmployeeNumberList(int iCompany, int iDepartment)
        {
            OleDbCommand odCom = null;
            if (iDepartment > 0)
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", "DepartmentID=@ID", new object[] { "@ID", iDepartment });
            else if (iCompany > 0)
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", " DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID)", new object[] { "@ID", iCompany });
            else
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", null);

            OleDbDataReader odRdr = odCom.ExecuteReader();

            List<string> empls = new List<string>();
            while (odRdr.Read())
            {
                empls.Add(odRdr["EmployeeNumber"].ToString());
            }
            odRdr.Close();

            return empls;
        }

        public List<AttendanceSummaryReport> GetAttendanceSummaryReport(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            List<AttendanceSummaryReport> attSummarys = new List<AttendanceSummaryReport>();

            List<AttendanceLogReport> attReports = GetAttendanceLogReportList(iCompany, iDepartment, beginDate, endDate);

            if (attReports == null || attReports.Count == 0)
                return null;

            AttendanceSummaryReport attSummary = null;

            foreach (AttendanceLogReport attRp in attReports)
            {
                attSummary = new AttendanceSummaryReport();
                attSummary.EmployeeNumber = attRp.EmployeeNumber;
                attSummary.FullName = attRp.FullName;
                attSummary.TotalHour = attRp.TotalHour;
                attSummary.DateLog = attRp.WorkFrom;
                attSummary.WorkingHour = "Regular Hour : " + attRp.WorkingHour;
                attSummary.ChartData = new double[] { attRp.RegularHour, attRp.WorkingHour, attRp.OvertimeHour1 + attRp.OvertimeHour2 + attRp.OvertimeHour3 + attRp.OvertimeHour4 };
                attSummarys.Add(attSummary);

                if (attRp.OvertimeHour1 > 0)
                {
                    attSummary = new AttendanceSummaryReport();
                    attSummary.WorkingHour = "Overtime Hour 1 : " + attRp.OvertimeHour1;
                    attSummarys.Add(attSummary);

                    if (attRp.OvertimeHour2 > 0)
                    {
                        attSummary = new AttendanceSummaryReport();
                        attSummary.WorkingHour = "Overtime Hour 2 : " + attRp.OvertimeHour2;
                        attSummarys.Add(attSummary);

                        if (attRp.OvertimeHour3 > 0)
                        {
                            attSummary = new AttendanceSummaryReport();
                            attSummary.WorkingHour = "Overtime Hour 3 : " + attRp.OvertimeHour3;
                            attSummarys.Add(attSummary);

                            if (attRp.OvertimeHour4 > 0)
                            {
                                attSummary = new AttendanceSummaryReport();
                                attSummary.WorkingHour = "Overtime Hour 4 : " + attRp.OvertimeHour4;
                                attSummarys.Add(attSummary);
                            }
                        }
                    }
                }
            }

            return attSummarys;
        }

        public List<AttendanceLogReport> GetAttendanceLogReportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            List<AttendanceReport> attendanceReports = GetAttendanceReport(iCompany, iDepartment, beginDate, endDate, 0, true);
            if (attendanceReports.Count == 0)
                return null;

            List<string> lEmplNumbers = GetEmployeeNumberList(iCompany, iDepartment);
            if (lEmplNumbers == null || lEmplNumbers.Count == 0)
                return null;
            string sEmplNumbers = string.Join(",", lEmplNumbers.ToArray());

            OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber,FirstName,LastName,PayrollNumber,JobDescription", "EmployeeNumber in(" + sEmplNumbers + ")");

            OleDbDataAdapter odApt = new OleDbDataAdapter(odCom);
            DataTable dtEmpl = new DataTable();
            odApt.Fill(dtEmpl);

            List<AttendanceLogReport> attLogs = new List<AttendanceLogReport>();
            AttendanceLogReport _attLog = null;

            foreach (AttendanceReport attRp in attendanceReports)
            {
                _attLog = new AttendanceLogReport();

                DataRow[] rdEmpl = dtEmpl.Select("EmployeeNumber=" + attRp.EmployeeNumber);
                if (rdEmpl.Length > 0)
                {
                    _attLog.FullName = rdEmpl[0]["LastName"] + ", " + rdEmpl[0]["FirstName"];
                    _attLog.PayrollNumber = (int)rdEmpl[0]["PayrollNumber"];
                    _attLog.JobDescription = rdEmpl[0]["JobDescription"].ToString();
                }

                _attLog.AttendanceRecordIDList = attRp.AttendanceRecordIDList;
                _attLog.DayTypeID = attRp.DayTypeID;
                _attLog.EmployeeNumber = attRp.EmployeeNumber;
                _attLog.OvertimeHour1 = attRp.OvertimeHour1;
                _attLog.OvertimeHour2 = attRp.OvertimeHour2;
                _attLog.OvertimeHour3 = attRp.OvertimeHour3;
                _attLog.OvertimeHour4 = attRp.OvertimeHour4;
                _attLog.OvertimeRate1 = attRp.OvertimeRate1;
                _attLog.OvertimeRate1 = attRp.OvertimeRate1;
                _attLog.OvertimeRate1 = attRp.OvertimeRate1;
                _attLog.OvertimeRate1 = attRp.OvertimeRate1;
                _attLog.PayPeriodID = attRp.PayPeriodID;
                _attLog.RegularHour = 8;
                _attLog.RegularRate = attRp.RegularRate;
                _attLog.TotalHour = attRp.RegularHour + attRp.OvertimeHour1 + attRp.OvertimeHour2 + attRp.OvertimeHour3 + attRp.OvertimeHour4;
                _attLog.WorkingHour = attRp.RegularHour;
                _attLog.WorkFrom = attRp.WorkFrom;
                _attLog.WorkTo = attRp.WorkTo;

                attLogs.Add(_attLog);
            }
            return attLogs;
        }

        public List<AttendanceLogRecord> GetAttendanceLogRecordList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate, int columnIndex, bool isOrderByAcs)
        {
            List<AttendanceReport> attendanceReports = GetAttendanceReport(iCompany, iDepartment, beginDate, endDate, columnIndex, isOrderByAcs);
            if (attendanceReports.Count == 0)
                return null;

            List<string> lEmplNumbers = GetEmployeeNumberList(iCompany, iDepartment);
            if (lEmplNumbers == null || lEmplNumbers.Count == 0)
                return null;
            string sEmplNumbers = string.Join(",", lEmplNumbers.ToArray());

            OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber,FirstName,LastName,PayrollNumber,JobDescription", "EmployeeNumber in(" + sEmplNumbers + ")");

            OleDbDataAdapter odApt = new OleDbDataAdapter(odCom);
            DataTable dtEmpl = new DataTable();
            odApt.Fill(dtEmpl);

            List<AttendanceLogRecord> attLogs = new List<AttendanceLogRecord>();
            AttendanceLogRecord _attLog = null;
            List<AttendanceRecord> attRecords = new List<AttendanceRecord>();
            AttendanceRecord attRecord = null;

            foreach (AttendanceReport attRp in attendanceReports)
            {
                string sAttendanceRecordIDs = attRp.AttendanceRecordIDList;
                sAttendanceRecordIDs = sAttendanceRecordIDs.Replace("{", "").Replace("}", ",").Trim(',');

                odCom = BuildSelectCmd("AttendanceRecord", "*", "ID in(" + sAttendanceRecordIDs + ")");
                OleDbDataReader odRdr = odCom.ExecuteReader();

                attRecords.Clear();
                while (odRdr.Read())
                {
                    attRecord = new AttendanceRecord();
                    attRecord.ID = (int)odRdr["ID"];
                    attRecord.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                    attRecord.Note = odRdr["Note"].ToString();
                    attRecord.PhotoData = odRdr["PhotoData"].ToString();
                    attRecord.Time = (DateTime)odRdr["Time"];
                    attRecords.Add(attRecord);
                }
                odRdr.Close();

                attRecords.Sort(delegate(AttendanceRecord e1, AttendanceRecord e2) { return e1.Time.CompareTo(e2.Time); });

                bool isCheckIn = true;
                bool isFirst = true;

                DateTime dDateLog = attRecords[0].Time.Date;
                foreach (AttendanceRecord att in attRecords)
                {
                    _attLog = new AttendanceLogRecord();
                    if (isFirst)
                    {
                        _attLog.EmployeeNumber = attRp.EmployeeNumber;
                        _attLog.DateLog = attRp.WorkFrom.Date;
                        _attLog.TotalHours = attRp.RegularHour + attRp.OvertimeHour1 + attRp.OvertimeHour2 + attRp.OvertimeHour3 + attRp.OvertimeHour4;
                        DataRow[] rdEmpl = dtEmpl.Select("EmployeeNumber=" + attRp.EmployeeNumber);
                        if (rdEmpl.Length > 0)
                            _attLog.EmployeeName = rdEmpl[0]["LastName"] + ", " + rdEmpl[0]["FirstName"];
                        isFirst = false;
                    }
                    _attLog.ID = att.ID;
                    _attLog.TimeLog = (isCheckIn ? "In " : "Out ") + (att.Time.Hour > 9 ? "" : "0") + att.Time.Hour + ":" + (att.Time.Minute > 9 ? "" : "0") + att.Time.Minute + ":" + (att.Time.Second > 9 ? "" : "0") + att.Time.Second;
                    _attLog.Note = att.Note;

                    attLogs.Add(_attLog);

                    isCheckIn = !isCheckIn;
                }
                if (isCheckIn == false && dDateLog.Equals(DateTime.Now.Date) == false)
                {
                    _attLog = new AttendanceLogRecord();
                    _attLog.TimeLog = "OutMistakes";
                    attLogs.Add(_attLog);
                }
            }
            return attLogs;
        }

        public AttendanceRecord GetAttendanceRecord(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", "ID=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                AttendanceRecord attRecord = new AttendanceRecord();

                attRecord.ID = (int)odRdr["ID"];
                attRecord.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attRecord.Note = odRdr["Note"].ToString();
                attRecord.PhotoData = odRdr["PhotoData"].ToString();
                attRecord.Time = (DateTime)odRdr["Time"];

                odRdr.Close();
                return attRecord;
            }

            return null;
        }

        private bool IsNotValidAttendanceRecord(AttendanceRecord attRecord, bool forUpdate)
        {
            OleDbCommand odCom;
            if (forUpdate)
                odCom = BuildSelectCmd("AttendanceRecord", "ID", "ID<>@ID AND EmployeeNumber=@EmployeeNumber AND Time>@Time_1 AND Time<@Time_2",
                    new object[] { "@ID", attRecord.ID, "@EmployeeNumber", attRecord.EmployeeNumber, 
                        "@Time_1", attRecord.Time.AddMinutes(-timeBound2), "@Time_2", attRecord.Time.AddMinutes(timeBound2) });
            else
                odCom = BuildSelectCmd("AttendanceRecord", "ID", "EmployeeNumber=@EmployeeNumber AND Time>@Time_1 AND Time<@Time_2",
                    new object[] { "@EmployeeNumber", attRecord.EmployeeNumber,
                         "@Time_1", attRecord.Time.AddMinutes(-timeBound2), "@Time_2", attRecord.Time.AddMinutes(timeBound2) });

            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        private PaymentRate GetPaymentRateByEmployeeAndWorkDay(int employeeNumber,DateTime dWorkDay)
        {
            WorkingCalendar workingCalendar = GetWorkingCalendarByEmployee(employeeNumber);

            int iWorkingCalendarID = (int)workingCalendar.ID;

            int iDayTypeID = 2;
            switch (dWorkDay.DayOfWeek)
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

            OleDbCommand odCom = BuildSelectCmd("Holiday", "*", "WorkingCalendarID=@ID", new object[] { "@ID", iWorkingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            while (odRdr.Read())
            {
                DateTime holiday = (DateTime)odRdr["Date"];
                if (dWorkDay.Month == holiday.Month && dWorkDay.Day == holiday.Day)
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
                paymentRate.NumberOfOvertime1 = (double)odRdr["NumberOfOvertime1"];
                paymentRate.NumberOfOvertime2 = (double)odRdr["NumberOfOvertime2"];
                paymentRate.NumberOfOvertime3 = (double)odRdr["NumberOfOvertime3"];
                paymentRate.NumberOfOvertime4 = (double)odRdr["NumberOfOvertime4"];
                paymentRate.NumberOfRegularHours = (double)odRdr["NumberOfRegularHours"];
                paymentRate.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                paymentRate.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                paymentRate.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                paymentRate.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                paymentRate.RegularRate = (double)odRdr["RegularRate"];
                paymentRate.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
            }
            odRdr.Close();

            return paymentRate;
        }

        private PaymentRate GetPaymentRateByAttendanceRecord(AttendanceRecord attRecord)
        {
            int iEmployeeNumber = attRecord.EmployeeNumber;

            WorkingCalendar workingCalendar = GetWorkingCalendarByEmployee(iEmployeeNumber);

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

            OleDbCommand odCom = BuildSelectCmd("Holiday", "*", "WorkingCalendarID=@ID", new object[] { "@ID", iWorkingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

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
                paymentRate.NumberOfOvertime1 = (double)odRdr["NumberOfOvertime1"];
                paymentRate.NumberOfOvertime2 = (double)odRdr["NumberOfOvertime2"];
                paymentRate.NumberOfOvertime3 = (double)odRdr["NumberOfOvertime3"];
                paymentRate.NumberOfOvertime4 = (double)odRdr["NumberOfOvertime4"];
                paymentRate.NumberOfRegularHours = (double)odRdr["NumberOfRegularHours"];
                paymentRate.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                paymentRate.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                paymentRate.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                paymentRate.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                paymentRate.RegularRate = (double)odRdr["RegularRate"];
                paymentRate.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
            }
            odRdr.Close();

            return paymentRate;
        }

        private AttendanceReport AttendanceLogReportByEmplWfrom(int employeeNumber, DateTime dWorkingFrom)
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "EmployeeNumber=@Empl AND WorkFrom=@WorkFrom",
          new object[] { "@Empl", employeeNumber, "@WorkFrom", dWorkingFrom });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            AttendanceReport attendanceReport = null;
            if (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();
                attendanceReport.DayTypeID = (int)odRdr["DayTypeID"];
                attendanceReport.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attendanceReport.OvertimeHour1 = (double)odRdr["OvertimeHour1"];
                attendanceReport.OvertimeHour2 = (double)odRdr["OvertimeHour2"];
                attendanceReport.OvertimeHour3 = (double)odRdr["OvertimeHour3"];
                attendanceReport.OvertimeHour4 = (double)odRdr["OvertimeHour4"];
                attendanceReport.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                attendanceReport.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                attendanceReport.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                attendanceReport.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                attendanceReport.PayPeriodID = (int)odRdr["PayPeriodID"];
                attendanceReport.RegularHour = (double)odRdr["RegularHour"];
                attendanceReport.RegularRate = (double)odRdr["RegularRate"];
                if (typeof(DBNull) != odRdr["WorkFrom"].GetType())
                    attendanceReport.WorkFrom = (DateTime)odRdr["WorkFrom"];
                if (typeof(DBNull) != odRdr["WorkTo"].GetType())
                    attendanceReport.WorkTo = (DateTime)odRdr["WorkTo"];
                attendanceReport.ID = (int)odRdr["ID"];

                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();
                odRdr.Close();
            }
            return attendanceReport;
        }

        private DateTime GetWorkingDayByAttendanceRecord(AttendanceRecord attRecord)
        {
            WorkingCalendar wCal = GetWorkingCalendarByEmployee(attRecord.EmployeeNumber);

            DateTime dRegularWorkingFrom = wCal.RegularWorkingFrom;

            DateTime wFrom = new DateTime(attRecord.Time.Year, attRecord.Time.Month, attRecord.Time.Day, dRegularWorkingFrom.Hour,
               dRegularWorkingFrom.Minute, dRegularWorkingFrom.Second).AddMinutes(-1 * wCal.EarliestBeforeEntry);

            if (attRecord.Time.CompareTo(wFrom) == 1)
            {
                if (attRecord.Time.CompareTo(wFrom.AddDays(1)) != -1)
                    return wFrom.AddDays(1);
                else
                    return wFrom;
            }
            else
            {
                if (Is1stday(attRecord))
                    return wFrom;
                else
                    return wFrom.AddDays(-1);
            }
        }

        private bool Is1stday(AttendanceRecord attRecord)
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "COUNT(*) AS NumRc", "EmployeeNumber=@Empl",
                new object[] { "@Empl", attRecord.EmployeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                object o = odRdr["NumRc"];
                odRdr.Close();
                if (o == null || (int)o == 0)
                    return true;
            }
            return false;
        }

        public bool ReProcessAttendanceReport(AttendanceReport _attReport)
        {
            return AddUpdateAttendaceReport(null, _attReport);
        }

        private bool AddUpdateAttendaceReport(AttendanceRecord _attRecord, AttendanceReport _attReport)
        {
            int employeeNumber = _attReport == null ? _attRecord.EmployeeNumber : _attReport.EmployeeNumber;

            WorkingCalendar workingCalendar = GetWorkingCalendarByEmployee(employeeNumber);

            int payPeriodID = workingCalendar.PayPeriodID;
            DateTime dRegularWorkingFrom = workingCalendar.RegularWorkingFrom;
            DateTime dRegularWorkingTo = workingCalendar.RegularWorkingTo;
            int earliestBeforeEntry = workingCalendar.EarliestBeforeEntry;
            int lastestAfterExit = workingCalendar.LastestAfterExit;
            int graceForwardToEntry = workingCalendar.GraceForwardToEntry;
            int graceBackwardToExit = workingCalendar.GraceBackwardToExit;

            DateTime dWorkingFrom, dWorkingTo;

            string attIdList = "";
            int reportId = 0;
            
            if (_attReport == null)
            {
                dWorkingFrom = GetWorkingDayByAttendanceRecord(_attRecord);
                dWorkingTo = dWorkingFrom.Date.AddHours(dRegularWorkingTo.Hour).AddMinutes(dRegularWorkingTo.Minute + lastestAfterExit);

                if (dWorkingFrom.CompareTo(dWorkingTo) == 1)
                    dWorkingTo.AddDays(1);

                if (_attRecord.Time.CompareTo(dWorkingFrom) == -1 || _attRecord.Time.CompareTo(dWorkingTo) == 1)
                {
                    return false;
                }

                OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "EmployeeNumber=@Empl AND WorkFrom=@WorkFrom",
                    new object[] { "@Empl", employeeNumber, "@WorkFrom", dWorkingFrom });
                OleDbDataReader odRdr = odCom.ExecuteReader();

                if (odRdr.Read())
                {
                    reportId = (int)odRdr["ID"];
                    attIdList = odRdr["AttendanceRecordIDList"].ToString();
                    attIdList += "{" + _attRecord.ID + "}";
                    odRdr.Close();
                }
            }
            else
            {
                dWorkingFrom = _attReport.WorkFrom;
                dWorkingTo = _attReport.WorkTo;
                reportId = _attReport.ID;
                attIdList = _attReport.AttendanceRecordIDList;
            }

            if (reportId > 0)
            {
                string listId = attIdList.Replace("{", "").Replace("}", ",").TrimEnd(',');

                OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", "ID in (" + listId + ")");
                OleDbDataReader odRdr = odCom.ExecuteReader();

                List<DateTime> timeLogs = new List<DateTime>();
                while (odRdr.Read())
                {
                    timeLogs.Add((DateTime)odRdr["Time"]);
                }
                odRdr.Close();

                timeLogs.Sort();

                List<Break> breaks = GetBreakListByWorkingCalendar(workingCalendar.ID);
                
                long totalTicks = 0;
                for (int i = 0; i < timeLogs.Count - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        DateTime time1 = timeLogs[i];
                        DateTime time2 = timeLogs[i + 1];

                        DateTime timeFrom = time1.Date.AddHours(dRegularWorkingFrom.Hour).AddMinutes(dRegularWorkingFrom.Minute);
                        DateTime timeTo = time2.Date.AddHours(dRegularWorkingTo.Hour).AddMinutes(dRegularWorkingTo.Minute);
                        if (timeFrom.CompareTo(timeTo) == 1)
                            timeTo = timeTo.AddDays(1);

                        double distanceMinute1 = (timeFrom.Ticks - time1.Ticks) / 600000000;
                        if (distanceMinute1 > 0 && graceForwardToEntry >= distanceMinute1)
                        {
                            time1 = timeFrom;
                        }
                        double distanceMinute2 = (time2.Ticks - timeTo.Ticks) / 600000000;
                        if (distanceMinute2 > 0 && graceBackwardToExit >= distanceMinute2)
                        {
                            time2 = timeTo;
                        }

                        Break _break = breaks.Find(delegate(Break e)
                        {
                            //a,b,x,y//
                            //a,x,y,b
                            //a,x,b,y
                            //x,a,b,y
                            //x,a,y,b
                            //x,y,a,b//

                            DateTime breakFrom = dWorkingFrom.Date.AddHours(e.From.Hour).AddMinutes(e.From.Minute);
                            DateTime breakTo = dWorkingFrom.Date.AddHours(e.To.Hour).AddMinutes(e.To.Minute);
                            if (breakFrom.CompareTo(breakTo) == 1)
                                breakTo = breakTo.AddDays(1);
                            return e.Paid == false
                                && ((time1.CompareTo(breakFrom) == -1 && time2.CompareTo(breakFrom) == 1)
                                || (time1.CompareTo(breakTo) == -1 && time2.CompareTo(breakTo) == 1)
                                || (time1.CompareTo(breakFrom) != -1 && time2.CompareTo(breakTo) != 1));
                        });

                        if (_break != null)
                        {
                            DateTime breakFrom = dWorkingFrom.Date.AddHours(_break.From.Hour).AddMinutes(_break.From.Minute);
                            DateTime breakTo = dWorkingFrom.Date.AddHours(_break.To.Hour).AddMinutes(_break.To.Minute);
                            if (breakFrom.CompareTo(breakTo) == 1)
                                breakTo = breakTo.AddDays(1);

                            if (time1.CompareTo(breakFrom) == -1)
                            {
                                totalTicks += breakFrom.Ticks - time1.Ticks;
                                if (time2.CompareTo(breakTo) == 1)
                                {
                                    totalTicks += time2.Ticks - breakTo.Ticks;
                                }
                            }
                            else
                            {
                                totalTicks += time2.Ticks - breakTo.Ticks;
                            }
                        }
                        else
                        {
                            totalTicks += time2.Ticks - time1.Ticks;
                        }
                    }
                }

                double totalMinute = totalTicks / 600000000;
                double totalHour = totalMinute / 60;

                PaymentRate paymentRate = GetPaymentRateByEmployeeAndWorkDay(employeeNumber, dWorkingFrom);
                AttendanceReport attendanceReport = new AttendanceReport();

                attendanceReport.ID = reportId;
                attendanceReport.AttendanceRecordIDList = attIdList;
                attendanceReport.DayTypeID = paymentRate.DayTypeID;
                attendanceReport.EmployeeNumber = employeeNumber;

                attendanceReport.RegularHour = paymentRate.NumberOfRegularHours;
                attendanceReport.OvertimeHour1 = paymentRate.NumberOfOvertime1;
                attendanceReport.OvertimeHour2 = paymentRate.NumberOfOvertime2;
                attendanceReport.OvertimeHour3 = paymentRate.NumberOfOvertime3;
                attendanceReport.OvertimeHour4 = paymentRate.NumberOfOvertime4;

                attendanceReport.RegularRate = paymentRate.RegularRate;
                attendanceReport.OvertimeRate1 = paymentRate.OvertimeRate1;
                attendanceReport.OvertimeRate2 = paymentRate.OvertimeRate2;
                attendanceReport.OvertimeRate3 = paymentRate.OvertimeRate3;
                attendanceReport.OvertimeRate4 = paymentRate.OvertimeRate4;

                attendanceReport.PayPeriodID = workingCalendar.PayPeriodID;
                attendanceReport.WorkFrom = dWorkingFrom;
                attendanceReport.WorkTo = dWorkingTo;

                GetRegularOvertime(ref attendanceReport, totalHour);

                return UpdateAttendanceReport(attendanceReport);
            }
            else
            {
                workingCalendar.RegularWorkingFrom = dWorkingFrom;
                workingCalendar.RegularWorkingTo = dWorkingTo;
                return AddAttendanceReport(_attRecord, workingCalendar);
            }
        }

        public int AddAttendanceRecord(AttendanceRecord attRecord)
        {
            if (attRecord == null)
                return -1;

            if (IsNotValidAttendanceRecord(attRecord, false))
                return 1;

            int employeeNumber = attRecord.EmployeeNumber;
            int attRecordID = 0;

            if (attRecord.Note == null) attRecord.Note = "";

            OleDbCommand odCom = BuildInsertCmd("AttendanceRecord",
                 new string[] { "EmployeeNumber", "Note", "Time" },
                 new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.Time }
                 );

            if (ExecuteNonQuery(odCom) == 1)
            {
                odCom.CommandText = "SELECT @@IDENTITY";
                attRecordID = Convert.ToInt32(odCom.ExecuteScalar().ToString());
            }
            else
                return -1;

            attRecord.ID = attRecordID;
            AddUpdateAttendaceReport(attRecord, null);

            return attRecordID;
        }

        private bool AddAttendanceReport(AttendanceRecord attRecord, WorkingCalendar workingCalendar)
        {
            string attRecordIDs = "{" + attRecord.ID + "}";

            PaymentRate paymentRate = GetPaymentRateByAttendanceRecord(attRecord);

            AttendanceReport attendanceReport = new AttendanceReport();

            attendanceReport.DayTypeID = paymentRate.DayTypeID;
            attendanceReport.EmployeeNumber = attRecord.EmployeeNumber;

            attendanceReport.RegularHour = 0;
            attendanceReport.OvertimeHour1 = 0;
            attendanceReport.OvertimeHour2 = 0;
            attendanceReport.OvertimeHour3 = 0;
            attendanceReport.OvertimeHour4 = 0;

            attendanceReport.RegularRate = paymentRate.RegularRate;
            attendanceReport.OvertimeRate1 = paymentRate.OvertimeRate1;
            attendanceReport.OvertimeRate2 = paymentRate.OvertimeRate2;
            attendanceReport.OvertimeRate3 = paymentRate.OvertimeRate3;
            attendanceReport.OvertimeRate4 = paymentRate.OvertimeRate4;

            attendanceReport.PayPeriodID = workingCalendar.PayPeriodID;
            attendanceReport.WorkFrom = workingCalendar.RegularWorkingFrom;
            attendanceReport.WorkTo = workingCalendar.RegularWorkingTo;

            attendanceReport.AttendanceRecordIDList = attRecordIDs;

            return AddAttendanceReport(attendanceReport);
        }

        public bool DeleteAttendanceRecord(int id)
        {
            AttendanceReport attReport = GetAttendanceReportByAttendanceRecord(id);
            OleDbCommand odCom = null;
            if (attReport == null)
            {
                odCom = BuildDelCmd("AttendanceRecord", "ID=@ID", new object[] { "@ID", id });
                int irs1 = ExecuteNonQuery(odCom);
                return irs1 > 0;
            }
            else
            {
                attReport.AttendanceRecordIDList = attReport.AttendanceRecordIDList.Replace("{" + id + "}", "");
                BeginTransaction();

                odCom = BuildDelCmd("AttendanceRecord", "ID=@ID", new object[] { "@ID", id });
                int irs = ExecuteNonQuery(odCom);

                bool ors = false;
                if (string.IsNullOrEmpty(attReport.AttendanceRecordIDList))
                    ors = DeleteAttendanceReport(attReport.ID);
                else
                {
                    ors = AddUpdateAttendaceReport(null, attReport);
                }

                if (irs > 0 && ors)
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

        public bool UpdateAttendanceRecord(AttendanceRecord attRecord)
        {
            if (attRecord == null || IsNotValidAttendanceRecord(attRecord, true))
                return false;

            BeginTransaction();

            OleDbCommand odCom = BuildUpdateCmd("AttendanceRecord",
                new string[] { "EmployeeNumber", "Note", "Time" },
                new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.Time },
                "ID=@ID", new object[] { "@ID", attRecord.ID }
                );

            bool oRs1 = ExecuteNonQuery(odCom) > 0 ? true : false;
            bool oRs2 = true;
            AttendanceReport attendanceReport = GetAttendanceReportByAttendanceRecord(attRecord.ID);
            if (attendanceReport != null)
            {
                oRs2 = AddUpdateAttendaceReport(null, attendanceReport);
            }
            if (oRs1 && oRs2)
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

        #endregion Attendance Record

        #region FaceIDUser

        public List<FaceIDUser> GetFaceIDUserList()
        {
            OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<FaceIDUser> faceIDUserList = new List<FaceIDUser>();
            FaceIDUser faceIDUser = null;
            while (odRdr.Read())
            {
                faceIDUser = new FaceIDUser();

                faceIDUser.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                faceIDUser.Password = odRdr["Password"].ToString();
                faceIDUser.UserManagementAccess = Convert.ToBoolean(odRdr["UserManagementAccess"]);
                faceIDUser.TerminalManagementAccess = Convert.ToBoolean(odRdr["TerminalManagementAccess"]);
                faceIDUser.CompanyDepartmentManagementAccess = Convert.ToBoolean(odRdr["CompanyDepartmentManagementAccess"]);
                faceIDUser.WorkingCalendarManagementAccess = Convert.ToBoolean(odRdr["WorkingCalendarManagementAccess"]);
                faceIDUser.EmployeeManagementAccess = Convert.ToBoolean(odRdr["EmployeeManagementAccess"]);
                faceIDUser.AttendanceManagementAccess = Convert.ToBoolean(odRdr["AttendanceManagementAccess"]);

                faceIDUserList.Add(faceIDUser);
            }

            odRdr.Close();
            return faceIDUserList;
        }

        public FaceIDUser GetFaceIDUser(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", "EmployeeNumber=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            FaceIDUser faceIDUser = null;
            if (odRdr.Read())
            {
                faceIDUser = new FaceIDUser();

                faceIDUser.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                faceIDUser.Password = odRdr["Password"].ToString();
                faceIDUser.UserManagementAccess = Convert.ToBoolean(odRdr["UserManagementAccess"]);
                faceIDUser.TerminalManagementAccess = Convert.ToBoolean(odRdr["TerminalManagementAccess"]);
                faceIDUser.CompanyDepartmentManagementAccess = Convert.ToBoolean(odRdr["CompanyDepartmentManagementAccess"]);
                faceIDUser.WorkingCalendarManagementAccess = Convert.ToBoolean(odRdr["WorkingCalendarManagementAccess"]);
                faceIDUser.EmployeeManagementAccess = Convert.ToBoolean(odRdr["EmployeeManagementAccess"]);
                faceIDUser.AttendanceManagementAccess = Convert.ToBoolean(odRdr["AttendanceManagementAccess"]);
            }

            odRdr.Close();
            return faceIDUser;
        }

        public int AddFaceIDUser(FaceIDUser faceIDUser)
        {
            OleDbCommand odCom1 = BuildInsertCmd("FaceIDUser",
                new string[] { "Password"
                ,"UserManagementAccess"
                ,"TerminalManagementAccess"
                ,"CompanyDepartmentManagementAccess"
                ,"WorkingCalendarManagementAccess"
                ,"EmployeeManagementAccess"
                ,"AttendanceManagementAccess"
                ,"EmployeeNumber"
                },
                new object[] { faceIDUser.Password
                ,faceIDUser.UserManagementAccess
                ,faceIDUser.TerminalManagementAccess
                ,faceIDUser.CompanyDepartmentManagementAccess
                ,faceIDUser.WorkingCalendarManagementAccess
                ,faceIDUser.EmployeeManagementAccess
                ,faceIDUser.AttendanceManagementAccess
                ,faceIDUser.EmployeeNumber
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                return faceIDUser.EmployeeNumber;
            }
            return -1;
        }

        public bool UpdateFaceIDUser(FaceIDUser faceIDUser)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("FaceIDUser",
                new string[] { "Password"
                ,"UserManagementAccess"
                ,"TerminalManagementAccess"
                ,"CompanyDepartmentManagementAccess"
                ,"WorkingCalendarManagementAccess"
                ,"EmployeeManagementAccess"
                ,"AttendanceManagementAccess"
                },
                new object[] { faceIDUser.Password
                ,faceIDUser.UserManagementAccess
                ,faceIDUser.TerminalManagementAccess
                ,faceIDUser.CompanyDepartmentManagementAccess
                ,faceIDUser.WorkingCalendarManagementAccess
                ,faceIDUser.EmployeeManagementAccess
                ,faceIDUser.AttendanceManagementAccess
                },
                "EmployeeNumber=@ID", new object[] { "@ID", faceIDUser.EmployeeNumber }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteFaceIDUser(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("FaceIDUser", "EmployeeNumber=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool IsFaceIDUser(int employeeNumber)
        {
            bool result = false;

            OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            return result;
        }
        #endregion

        #region Utils

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

        private int ExecuteNonQuery(OleDbCommand odCom)
        {
            try
            {
                return odCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
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
                command.CommandText = "SELECT COUNT(*) FROM " + table + ((condition == null) ? "" : (" WHERE " + condition));
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

        private OleDbCommand BuildSelectCmd(string table, string listCols, string condition, string orderBy, params object[] pCondition)
        {
            OleDbCommand command = dbConnection.CreateCommand();
            if (listCols == null)
            {
                command.CommandText = "SELECT COUNT(*) FROM " + table + ((condition == null) ? "" : (" WHERE " + condition)) + (orderBy == null ? "" : " order by " + orderBy);
            }
            else
            {
                command.CommandText = "SELECT " + listCols + " FROM " + table + ((condition == null) ? "" : (" WHERE " + condition)) + (orderBy == null ? "" : " order by " + orderBy);
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
        #endregion Utils

        #region AttendanceReport
        public bool AddAttendanceReport(AttendanceReport attendanceReport)
        {
            return AddAttendanceReport(attendanceReport, false) > 0;
        }

        public int AddAttendanceReport(AttendanceReport attendanceReport, bool returnID)
        {
            OleDbCommand odCom1 = BuildInsertCmd("AttendanceReport",
                new string[] { "DayTypeID", "EmployeeNumber", "OvertimeHour1", "OvertimeHour2", "OvertimeHour3", "OvertimeHour4",
                "OvertimeRate1","OvertimeRate2","OvertimeRate3","OvertimeRate4","PayPeriodID","RegularHour","RegularRate",
                "WorkFrom","WorkTo","AttendanceRecordIDList"},
                new object[] { attendanceReport.DayTypeID, attendanceReport.EmployeeNumber, attendanceReport.OvertimeHour1,
                attendanceReport.OvertimeHour2,attendanceReport.OvertimeHour3,attendanceReport.OvertimeHour4, attendanceReport.OvertimeRate1,
                attendanceReport.OvertimeRate2,attendanceReport.OvertimeRate3, attendanceReport.OvertimeRate4,attendanceReport.PayPeriodID,
                attendanceReport.RegularHour,attendanceReport.RegularRate,attendanceReport.WorkFrom,attendanceReport.WorkTo,attendanceReport.AttendanceRecordIDList}
                );

            if (odCom1.ExecuteNonQuery() > 0)
            {
                if (returnID)
                {
                    odCom1.CommandText = "SELECT @@IDENTITY";
                    return Convert.ToInt32(odCom1.ExecuteScalar().ToString());
                }
                else
                {
                    return 1;
                }
            }

            return -1;
        }

        public AttendanceReport GetAttendanceReportByAttendanceRecord(int attendanceRecordID)
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "AttendanceRecordIDList LIKE '%{" + attendanceRecordID + "}%'");
            OleDbDataReader odRdr = odCom.ExecuteReader();
            AttendanceReport attendanceReport = null;
            if (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();

                attendanceReport.DayTypeID = (int)odRdr["DayTypeID"];
                attendanceReport.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attendanceReport.OvertimeHour1 = (double)odRdr["OvertimeHour1"];
                attendanceReport.OvertimeHour2 = (double)odRdr["OvertimeHour2"];
                attendanceReport.OvertimeHour3 = (double)odRdr["OvertimeHour3"];
                attendanceReport.OvertimeHour4 = (double)odRdr["OvertimeHour4"];
                attendanceReport.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                attendanceReport.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                attendanceReport.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                attendanceReport.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                attendanceReport.PayPeriodID = (int)odRdr["PayPeriodID"];
                attendanceReport.RegularHour = (double)odRdr["RegularHour"];
                attendanceReport.RegularRate = (double)odRdr["RegularRate"];
                if (typeof(DBNull) != odRdr["WorkFrom"].GetType())
                    attendanceReport.WorkFrom = (DateTime)odRdr["WorkFrom"];
                if (typeof(DBNull) != odRdr["WorkTo"].GetType())
                    attendanceReport.WorkTo = (DateTime)odRdr["WorkTo"];
                attendanceReport.ID = (int)odRdr["ID"];
                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();
            }
            odRdr.Close();
            return attendanceReport;
        }

        private AttendanceLogReport GetRegularOvertime(AttendanceLogReport _attReport, double ptotalHour)
        {
            double _totalHour = ptotalHour;
            double _regularHour = _attReport.WorkingHour;
            double _overtimeHour1 = _attReport.OvertimeHour1;
            double _overtimeHour2 = _attReport.OvertimeHour2;
            double _overtimeHour3 = _attReport.OvertimeHour3;
            double _overtimeHour4 = _attReport.OvertimeHour4;

            double totalHour = 0;
            double overtimeHour1 = 0;
            double overtimeHour2 = 0;
            double overtimeHour3 = 0;
            double overtimeHour4 = 0;

            if (_totalHour > _regularHour)
            {
                totalHour = _regularHour;
                _totalHour -= _regularHour;

                if (_totalHour > _overtimeHour1)
                {
                    overtimeHour1 = _overtimeHour1;
                    _totalHour -= _overtimeHour1;

                    if (_totalHour > _overtimeHour2)
                    {
                        overtimeHour2 = _overtimeHour2;
                        _totalHour -= _overtimeHour2;

                        if (_totalHour > _overtimeHour3)
                        {
                            overtimeHour3 = _overtimeHour3;
                            _totalHour -= _overtimeHour3;

                            overtimeHour4 = _totalHour;
                        }
                        else
                            overtimeHour3 = _totalHour;
                    }
                    else
                        overtimeHour2 = _totalHour;
                }
                else
                    overtimeHour1 = _totalHour;
            }
            else
                totalHour = _totalHour;

            AttendanceLogReport attReport = _attReport;

            attReport.OvertimeHour1 = Math.Round(overtimeHour1, 2);
            attReport.OvertimeHour2 = Math.Round(overtimeHour2, 2);
            attReport.OvertimeHour3 = Math.Round(overtimeHour3, 2);
            attReport.OvertimeHour4 = Math.Round(overtimeHour4, 2);
            attReport.WorkingHour = Math.Round(totalHour, 2);

            return attReport;
        }

        private void GetRegularOvertime(ref AttendanceReport _attReport, double ptotalHour)
        {
            double _totalHour = ptotalHour;
            double _regularHour = _attReport.RegularHour;
            double _overtimeHour1 = _attReport.OvertimeHour1;
            double _overtimeHour2 = _attReport.OvertimeHour2;
            double _overtimeHour3 = _attReport.OvertimeHour3;
            double _overtimeHour4 = _attReport.OvertimeHour4;

            double regularHour = 0;
            double overtimeHour1 = 0;
            double overtimeHour2 = 0;
            double overtimeHour3 = 0;
            double overtimeHour4 = 0;

            if (_totalHour > _regularHour)
            {
                regularHour = _regularHour;
                _totalHour -= _regularHour;

                if (_totalHour > _overtimeHour1)
                {
                    overtimeHour1 = _overtimeHour1;
                    _totalHour -= _overtimeHour1;

                    if (_totalHour > _overtimeHour2)
                    {
                        overtimeHour2 = _overtimeHour2;
                        _totalHour -= _overtimeHour2;

                        if (_totalHour > _overtimeHour3)
                        {
                            overtimeHour3 = _overtimeHour3;
                            _totalHour -= _overtimeHour3;

                            overtimeHour4 = _totalHour;
                        }
                        else
                            overtimeHour3 = _totalHour;
                    }
                    else
                        overtimeHour2 = _totalHour;
                }
                else
                    overtimeHour1 = _totalHour;
            }
            else
                regularHour = _totalHour;

            _attReport.RegularHour = Math.Round(regularHour, 2);
            _attReport.OvertimeHour1 = Math.Round(overtimeHour1, 2);
            _attReport.OvertimeHour2 = Math.Round(overtimeHour2, 2);
            _attReport.OvertimeHour3 = Math.Round(overtimeHour3, 2);
            _attReport.OvertimeHour4 = Math.Round(overtimeHour4, 2);
        }

        public bool UpdateAttendanceReport(AttendanceReport attendanceReport)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("AttendanceReport",
                new string[] { "DayTypeID", "EmployeeNumber", "OvertimeHour1", "OvertimeHour2", "OvertimeHour3", "OvertimeHour4",
                "OvertimeRate1","OvertimeRate2","OvertimeRate3","OvertimeRate4","PayPeriodID","RegularHour","RegularRate",
                "WorkFrom","WorkTo","AttendanceRecordIDList"},
                new object[] { attendanceReport.DayTypeID, attendanceReport.EmployeeNumber, attendanceReport.OvertimeHour1,
                attendanceReport.OvertimeHour2,attendanceReport.OvertimeHour3,attendanceReport.OvertimeHour4, attendanceReport.OvertimeRate1,
                attendanceReport.OvertimeRate2,attendanceReport.OvertimeRate3, attendanceReport.OvertimeRate4,attendanceReport.PayPeriodID,
                attendanceReport.RegularHour,attendanceReport.RegularRate,attendanceReport.WorkFrom,attendanceReport.WorkTo,attendanceReport.AttendanceRecordIDList},
                "ID=@ID", new object[] { "@ID", attendanceReport.ID }
                );

            return ExecuteNonQuery(odCom1) > 0;
        }

        public bool DeleteAttendanceReport(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("AttendanceReport",
                "ID=@ID", new object[] { "@ID", id }
                );

            return ExecuteNonQuery(odCom1) > 0;
        }

        public List<AttendanceReport> GetAttendanceReport(int companyID, int departmentID, DateTime dtFrom, DateTime dtTo, int columnIndex, bool isOrderByAcs)
        {
            List<string> lEmplNumbers = GetEmployeeNumberList(companyID, departmentID);
            if (lEmplNumbers == null || lEmplNumbers.Count == 0)
                return null;
            string sEmplNumbers = string.Join(",", lEmplNumbers.ToArray());

            string orderBy = "EmployeeNumber, WorkFrom";
            if (columnIndex == 0 || columnIndex == 1)
                orderBy = "EmployeeNumber" + (isOrderByAcs ? " ASC" : " DESC") + ",WorkFrom ASC";
            else if (columnIndex == 2)
                orderBy = "WorkFrom" + (isOrderByAcs ? " ASC" : " DESC") + ",EmployeeNumber ASC";

            OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "WorkFrom >=@Date_1 AND WorkFrom <= @Date_2 AND EmployeeNumber in(" + sEmplNumbers + ")", orderBy,
                new object[] { "@Date_1", dtFrom, "@Date_2", dtTo });

            List<AttendanceReport> attendanceReports = new List<AttendanceReport>();
            AttendanceReport attendanceReport = null;

            OleDbDataReader odRdr = odCom.ExecuteReader();
            while (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();

                attendanceReport.DayTypeID = (int)odRdr["DayTypeID"];
                attendanceReport.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attendanceReport.OvertimeHour1 = (double)odRdr["OvertimeHour1"];
                attendanceReport.OvertimeHour2 = (double)odRdr["OvertimeHour2"];
                attendanceReport.OvertimeHour3 = (double)odRdr["OvertimeHour3"];
                attendanceReport.OvertimeHour4 = (double)odRdr["OvertimeHour4"];
                attendanceReport.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                attendanceReport.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                attendanceReport.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                attendanceReport.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                attendanceReport.PayPeriodID = (int)odRdr["PayPeriodID"];
                attendanceReport.RegularHour = (double)odRdr["RegularHour"];
                attendanceReport.RegularRate = (double)odRdr["RegularRate"];
                attendanceReport.WorkFrom = (DateTime)odRdr["WorkFrom"];
                attendanceReport.WorkTo = (DateTime)odRdr["WorkTo"];
                attendanceReport.ID = (int)odRdr["ID"];
                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();

                attendanceReports.Add(attendanceReport);
            }
            odRdr.Close();

            return attendanceReports;
        }

        public List<AttendanceReport> GetReprocessAttendanceReport(string _employeeNumberList, DateTime _dReprocessFrom, DateTime _dReprocessTo)
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "WorkFrom >=@Date_1 AND WorkFrom <= @Date_2 AND EmployeeNumber in(" + _employeeNumberList + ")",
                new object[] { "@Date_1", _dReprocessFrom, "@Date_2", _dReprocessTo });

            List<AttendanceReport> attendanceReports = new List<AttendanceReport>();
            AttendanceReport attendanceReport = null;

            OleDbDataReader odRdr = odCom.ExecuteReader();
            while (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();

                attendanceReport.DayTypeID = (int)odRdr["DayTypeID"];
                attendanceReport.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attendanceReport.OvertimeHour1 = (double)odRdr["OvertimeHour1"];
                attendanceReport.OvertimeHour2 = (double)odRdr["OvertimeHour2"];
                attendanceReport.OvertimeHour3 = (double)odRdr["OvertimeHour3"];
                attendanceReport.OvertimeHour4 = (double)odRdr["OvertimeHour4"];
                attendanceReport.OvertimeRate1 = (double)odRdr["OvertimeRate1"];
                attendanceReport.OvertimeRate2 = (double)odRdr["OvertimeRate2"];
                attendanceReport.OvertimeRate3 = (double)odRdr["OvertimeRate3"];
                attendanceReport.OvertimeRate4 = (double)odRdr["OvertimeRate4"];
                attendanceReport.PayPeriodID = (int)odRdr["PayPeriodID"];
                attendanceReport.RegularHour = (double)odRdr["RegularHour"];
                attendanceReport.RegularRate = (double)odRdr["RegularRate"];
                attendanceReport.WorkFrom = (DateTime)odRdr["WorkFrom"];
                attendanceReport.WorkTo = (DateTime)odRdr["WorkTo"];
                attendanceReport.ID = (int)odRdr["ID"];
                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();

                attendanceReports.Add(attendanceReport);
            }
            odRdr.Close();

            return attendanceReports;
        }

        #endregion


        #region IDataController Members

        public int AddPayPeriod(PayPeriod payPeriod)
        {
            OleDbCommand odCom1 = BuildInsertCmd("PayPeriod",
                new string[] { "PayPeriodTypeID"
                ,"StartFrom"
                ,"CustomPeriod"
                },
                new object[] { payPeriod.PayPeriodTypeID
                ,payPeriod.StartFrom
                ,payPeriod.CustomPeriod
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeletePayPeriod(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("PayPeriod", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public int AddPayPeriodType(PayPeriodType payPeriodType)
        {
            throw new NotImplementedException();
        }

        public bool DeletePayPeriodType(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePayPeriodType(PayPeriodType payPeriodType)
        {
            throw new NotImplementedException();
        }

        public Break GetBreak(int id)
        {
            OleDbCommand odCom = BuildSelectCmd("Break", "*", "ID=@ID", new object[] { "@ID", id });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Break _break = null;
            if (odRdr.Read())
            {
                _break = new Break();

                _break.ID = Convert.ToInt16(odRdr["ID"]);
                _break.Name = odRdr["Name"].ToString();
                _break.From = Convert.ToDateTime(odRdr["From"]);
                _break.To = Convert.ToDateTime(odRdr["To"]);
                _break.Paid = Convert.ToBoolean(odRdr["Paid"]);
                _break.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);
            }

            odRdr.Close();
            return _break;
        }

        public int AddBreak(Break _break)
        {
            OleDbCommand odCom1 = BuildInsertCmd("Break",
                new string[] { "Name"
                ,"From"
                ,"To"
                ,"Paid"
                ,"WorkingCalendarID"
                },
                new object[] { _break.Name
                ,_break.From
                ,_break.To
                ,_break.Paid
                ,_break.WorkingCalendarID
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteBreak(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("Break", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdateBreak(Break _break)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("Break",
                new string[] { "Name"
                ,"From"
                ,"To"
                ,"Paid"
                ,"WorkingCalendarID"
                },
                new object[] { _break.Name
                ,_break.From
                ,_break.To
                ,_break.Paid
                ,_break.WorkingCalendarID
                },
                "ID=@ID", new object[] { "@ID", _break.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public PaymentRate GetPaymentRate(int id)
        {
            throw new NotImplementedException();
        }

        public int AddPaymentRate(PaymentRate paymentRate)
        {
            OleDbCommand odCom1 = BuildInsertCmd("PaymentRate",
                new string[] { "NumberOfRegularHours"
                ,"RegularRate"
                ,"NumberOfOvertime1"
                ,"OvertimeRate1"
                ,"NumberOfOvertime2"
                ,"OvertimeRate2"
                ,"NumberOfOvertime3"
                ,"OvertimeRate3"
                ,"NumberOfOvertime4"
                ,"OvertimeRate4"
                ,"DayTypeID"
                ,"WorkingCalendarID"
                },
                new object[] { paymentRate.NumberOfRegularHours
                ,paymentRate.RegularRate
                ,paymentRate.NumberOfOvertime1
                ,paymentRate.OvertimeRate1
                ,paymentRate.NumberOfOvertime2
                ,paymentRate.OvertimeRate2
                ,paymentRate.NumberOfOvertime3
                ,paymentRate.OvertimeRate3
                ,paymentRate.NumberOfOvertime4
                ,paymentRate.OvertimeRate4
                ,paymentRate.DayTypeID
                ,paymentRate.WorkingCalendarID
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeletePaymentRate(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("PaymentRate", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        private bool DeletePaymentRateByWorkingCalendar(int workingCalendarID)
        {
            OleDbCommand odCom1 = BuildDelCmd("PaymentRate", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdatePaymentRate(PaymentRate paymentRate)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("PaymentRate",
                new string[] { "NumberOfRegularHours"
                ,"RegularRate"
                ,"NumberOfOvertime1"
                ,"OvertimeRate1"
                ,"NumberOfOvertime2"
                ,"OvertimeRate2"
                ,"NumberOfOvertime3"
                ,"OvertimeRate3"
                ,"NumberOfOvertime4"
                ,"OvertimeRate4"
                ,"DayTypeID"
                ,"WorkingCalendarID"
                },
                new object[] { paymentRate.NumberOfRegularHours
                ,paymentRate.RegularRate
                ,paymentRate.NumberOfOvertime1
                ,paymentRate.OvertimeRate1
                ,paymentRate.NumberOfOvertime2
                ,paymentRate.OvertimeRate2
                ,paymentRate.NumberOfOvertime3
                ,paymentRate.OvertimeRate3
                ,paymentRate.NumberOfOvertime4
                ,paymentRate.OvertimeRate4
                ,paymentRate.DayTypeID
                ,paymentRate.WorkingCalendarID
                },
                "ID=@ID", new object[] { "@ID", paymentRate.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public int AddHoliday(Holiday holiday)
        {
            OleDbCommand odCom1 = BuildInsertCmd("Holiday",
                new string[] { "Date"
                ,"Description"
                ,"WorkingCalendarID"
                },
                new object[] { holiday.Date
                ,holiday.Description
                ,holiday.WorkingCalendarID
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool DeleteHoliday(int id)
        {
            OleDbCommand odCom1 = BuildDelCmd("Holiday", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public List<Employee> GetEmployeeList()
        {
            return GetEmployeeList(-1, -1);
        }

        public List<Employee> GetEmployeeListByTerminal(int terminalID)
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "*", "Active=TRUE AND EmployeeNumber IN (SELECT EmployeeNumber FROM EmployeeTerminal WHERE TerminalID=@terminalID)", new object[] { "@terminalID", terminalID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();

                employee.PayrollNumber = Convert.ToInt16(odRdr["PayrollNumber"]);
                employee.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                employee.DepartmentID = Convert.ToInt16(odRdr["DepartmentID"]);
                employee.FirstName = odRdr["FirstName"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                employee.WorkingCalendarID = Convert.ToInt16(odRdr["WorkingCalendarID"]);
                employee.HiredDate = Convert.ToDateTime(odRdr["HiredDate"]);
                employee.LeftDate = Convert.ToDateTime(odRdr["LeftDate"]);
                employee.Birthday = Convert.ToDateTime(odRdr["Birthday"]);
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.Address = odRdr["Address"].ToString();
                employee.Active = Convert.ToBoolean(odRdr["Active"]);
                employee.ActiveFrom = Convert.ToDateTime(odRdr["ActiveFrom"]);
                if (typeof(DBNull) != odRdr["ActiveTo"].GetType())
                    employee.ActiveTo = (DateTime)odRdr["ActiveTo"];
                employee.FaceData1 = odRdr["FaceData1"].ToString();
                employee.FaceData2 = odRdr["FaceData2"].ToString();
                employee.FaceData3 = odRdr["FaceData3"].ToString();
                employee.FaceData4 = odRdr["FaceData4"].ToString();
                employee.FaceData5 = odRdr["FaceData5"].ToString();
                employee.FaceData6 = odRdr["FaceData6"].ToString();
                employee.FaceData7 = odRdr["FaceData7"].ToString();
                employee.FaceData8 = odRdr["FaceData8"].ToString();
                employee.FaceData9 = odRdr["FaceData9"].ToString();
                employee.FaceData10 = odRdr["FaceData10"].ToString();
                employee.FaceData11 = odRdr["FaceData11"].ToString();
                employee.FaceData12 = odRdr["FaceData12"].ToString();
                employee.FaceData13 = odRdr["FaceData13"].ToString();
                employee.FaceData14 = odRdr["FaceData14"].ToString();
                employee.FaceData15 = odRdr["FaceData15"].ToString();
                employee.FaceData16 = odRdr["FaceData16"].ToString();
                employee.FaceData17 = odRdr["FaceData17"].ToString();
                employee.FaceData18 = odRdr["FaceData18"].ToString();

                employeeList.Add(employee);
            }

            odRdr.Close();
            return employeeList;
        }

        #endregion

        #region UndeletedEmployeeNumber
        public List<UndeletedEmployeeNumber> GetUndeletedEmployeeNumberList()
        {
            OleDbCommand odCom = BuildSelectCmd("UndeletedEmployeeNumber", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<UndeletedEmployeeNumber> undeletedEmployeeNumberList = new List<UndeletedEmployeeNumber>();
            UndeletedEmployeeNumber undeletedEmployeeNumber = null;
            while (odRdr.Read())
            {
                undeletedEmployeeNumber = new UndeletedEmployeeNumber();

                undeletedEmployeeNumber.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                undeletedEmployeeNumber.TerminalID = Convert.ToInt16(odRdr["TerminalID"]);

                undeletedEmployeeNumberList.Add(undeletedEmployeeNumber);
            }

            odRdr.Close();
            return undeletedEmployeeNumberList;
        }

        public UndeletedEmployeeNumber GetUndeletedEmployeeNumber(int employeeNumber, int terminalID)
        {
            OleDbCommand odCom = BuildSelectCmd("UndeletedEmployeeNumber", "*", "EmployeeNumber=@EmployeeNumber AND @TerminalID=@TerminalID", new object[] { "@EmployeeNumber", employeeNumber, "@TerminalID", terminalID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            UndeletedEmployeeNumber undeletedEmployeeNumber = null;
            if (odRdr.Read())
            {
                undeletedEmployeeNumber = new UndeletedEmployeeNumber();

                undeletedEmployeeNumber.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                undeletedEmployeeNumber.TerminalID = Convert.ToInt16(odRdr["TerminalID"]);
            }

            odRdr.Close();
            return undeletedEmployeeNumber;
        }

        public bool AddUndeletedEmployeeNumber(UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            OleDbCommand odCom1 = BuildInsertCmd("UndeletedEmployeeNumber",
                new string[] { "TerminalID"
                },
                new object[] { undeletedEmployeeNumber.TerminalID
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUndeletedEmployeeNumber(UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("UndeletedEmployeeNumber",
                new string[] { "TerminalID"
                },
                new object[] { undeletedEmployeeNumber.TerminalID
                },
                "EmployeeNumber=@ID", new object[] { "@ID", undeletedEmployeeNumber.EmployeeNumber }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteUndeletedEmployeeNumber(UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            OleDbCommand odCom1 = BuildDelCmd("UndeletedEmployeeNumber", "EmployeeNumber=@EmployeeNumber AND @TerminalID=@TerminalID", new object[] { "@EmployeeNumber", undeletedEmployeeNumber.EmployeeNumber, "@TerminalID", undeletedEmployeeNumber.TerminalID }); ;
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        #endregion

        public List<PayrollExport> GetPayrollExportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            List<AttendanceLogReport> attendanceLogReportList = GetAttendanceLogReportList(iCompany, iDepartment, beginDate, endDate);
            if (attendanceLogReportList == null || attendanceLogReportList.Count == 0)
                return null;

            List<int> employeeNumberListTemp = attendanceLogReportList.ConvertAll(delegate(AttendanceLogReport attRp)
            {
                return attRp.EmployeeNumber;
            });

            List<int> employeeNumberList = new List<int>();

            foreach (int emplNumber in employeeNumberListTemp)
            {
                if (employeeNumberList.Contains(emplNumber))
                    continue;
                employeeNumberList.Add(emplNumber);
            }

            List<PayrollExport> payrollExportList = new List<PayrollExport>();
            PayrollExport payrollExport = null;

            foreach (int emplNumber in employeeNumberList)
            {
                List<AttendanceLogReport> attendanceLogReportListByEmpl = attendanceLogReportList.FindAll(delegate(AttendanceLogReport attRp)
                {
                    return attRp.EmployeeNumber == emplNumber;
                });
                double regularHours = 0;
                string overtimeHourAndRate = "";
                double totalHours = 0;
                double totalHoursWithRate = 0;
                double totalOvertimeHours = 0;

                Hashtable hOvertimeHour1 = new Hashtable();
                Hashtable hOvertimeHour2 = new Hashtable();
                Hashtable hOvertimeHour3 = new Hashtable();
                Hashtable hOvertimeHour4 = new Hashtable();

                foreach (AttendanceLogReport attRp in attendanceLogReportListByEmpl)
                {
                    regularHours += attRp.WorkingHour;

                    totalHours += attRp.TotalHour;

                    totalHoursWithRate += attRp.WorkingHour
                        + attRp.OvertimeHour1 * attRp.OvertimeRate1 / 100
                        + attRp.OvertimeHour2 * attRp.OvertimeRate2 / 100
                        + attRp.OvertimeHour3 * attRp.OvertimeRate3 / 100
                        + attRp.OvertimeHour4 * attRp.OvertimeRate4 / 100;

                    totalOvertimeHours += attRp.OvertimeHour1
                    + attRp.OvertimeHour2
                    + attRp.OvertimeHour3
                    + attRp.OvertimeHour4;

                    if (attRp.OvertimeHour1 > 0)
                    {
                        if (hOvertimeHour1.ContainsKey(attRp.OvertimeRate1))
                        {
                            double overtimeHour = (double)hOvertimeHour1[attRp.OvertimeRate1];
                            hOvertimeHour1[attRp.OvertimeRate1] = overtimeHour + attRp.OvertimeHour1;
                        }
                        else
                            hOvertimeHour1.Add(attRp.OvertimeRate1, attRp.OvertimeHour1);
                    }

                    if (attRp.OvertimeHour2 > 0)
                    {
                        if (hOvertimeHour2.ContainsKey(attRp.OvertimeRate2))
                        {
                            double overtimeHour = (double)hOvertimeHour2[attRp.OvertimeRate2];
                            hOvertimeHour2[attRp.OvertimeRate2] = overtimeHour + attRp.OvertimeHour2;
                        }
                        else
                            hOvertimeHour2.Add(attRp.OvertimeRate2, attRp.OvertimeHour2);
                    }

                    if (attRp.OvertimeHour3 > 0)
                    {
                        if (hOvertimeHour3.ContainsKey(attRp.OvertimeRate3))
                        {
                            double overtimeHour = (double)hOvertimeHour3[attRp.OvertimeRate3];
                            hOvertimeHour3[attRp.OvertimeRate3] = overtimeHour + attRp.OvertimeHour3;
                        }
                        else
                            hOvertimeHour3.Add(attRp.OvertimeRate3, attRp.OvertimeHour3);
                    }

                    if (attRp.OvertimeHour4 > 0)
                    {
                        if (hOvertimeHour4.ContainsKey(attRp.OvertimeRate4))
                        {
                            double overtimeHour = (double)hOvertimeHour4[attRp.OvertimeRate4];
                            hOvertimeHour4[attRp.OvertimeRate4] = overtimeHour + attRp.OvertimeHour4;
                        }
                        else
                            hOvertimeHour4.Add(attRp.OvertimeRate4, attRp.OvertimeHour4);
                    }
                }

                StringBuilder strOvertime = new StringBuilder();

                foreach (DictionaryEntry item in hOvertimeHour1)
                    strOvertime.AppendFormat("{0} x {1}%\n", item.Value, item.Key);

                foreach (DictionaryEntry item in hOvertimeHour2)
                    strOvertime.AppendFormat("{0} x {1}%\n", item.Value, item.Key);

                foreach (DictionaryEntry item in hOvertimeHour3)
                    strOvertime.AppendFormat("{0} x {1}%\n", item.Value, item.Key);

                foreach (DictionaryEntry item in hOvertimeHour4)
                    strOvertime.AppendFormat("{0} x {1}%\n", item.Value, item.Key);

                overtimeHourAndRate = strOvertime.ToString();

                AttendanceLogReport attendanceLogReport = attendanceLogReportListByEmpl[0];

                payrollExport = new PayrollExport();

                payrollExport.EmployeeNumber = emplNumber;
                payrollExport.FullName = attendanceLogReport.FullName;
                payrollExport.JobDescription = attendanceLogReport.JobDescription;
                payrollExport.PayrollNumber = attendanceLogReport.PayrollNumber;
                payrollExport.RegularHour = Math.Round(regularHours, 2);
                payrollExport.OvertimeHour = overtimeHourAndRate;
                payrollExport.TotalHours = Math.Round(totalHours, 2);
                payrollExport.TotalHoursWithRate = Math.Round(totalHoursWithRate, 2);
                payrollExport.TotalOvertimeHours = Math.Round(totalOvertimeHours, 2);
                payrollExportList.Add(payrollExport);
            }

            return payrollExportList;
        }

        public List<AttendanceRecord> GetAttendanceRecordList()
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<AttendanceRecord> attendanceRecordList = new List<AttendanceRecord>();
            AttendanceRecord attendanceRecord = null;
            while (odRdr.Read())
            {
                attendanceRecord = new AttendanceRecord();

                attendanceRecord.ID = Convert.ToInt32(odRdr["ID"]);
                attendanceRecord.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                attendanceRecord.Time = Convert.ToDateTime(odRdr["Time"]);
                //attendanceRecord.CheckIn = Convert.ToBoolean(odRdr["CheckIn"]);
                attendanceRecord.PhotoData = odRdr["PhotoData"].ToString();
                attendanceRecord.Note = odRdr["Note"].ToString();

                attendanceRecordList.Add(attendanceRecord);
            }

            odRdr.Close();
            return attendanceRecordList;
        }

        public List<AttendanceReport> GetAttendanceReportList()
        {
            OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", null);
            OleDbDataReader odRdr = odCom.ExecuteReader();
            List<AttendanceReport> attendanceReportList = new List<AttendanceReport>();
            AttendanceReport attendanceReport = null;
            while (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();

                attendanceReport.ID = Convert.ToInt32(odRdr["ID"]);
                attendanceReport.EmployeeNumber = Convert.ToInt32(odRdr["EmployeeNumber"]);
                attendanceReport.WorkFrom = Convert.ToDateTime(odRdr["WorkFrom"]);
                attendanceReport.WorkTo = Convert.ToDateTime(odRdr["WorkTo"]);
                attendanceReport.RegularHour = Convert.ToDouble(odRdr["RegularHour"]);
                attendanceReport.RegularRate = Convert.ToDouble(odRdr["RegularRate"]);
                attendanceReport.OvertimeHour1 = Convert.ToDouble(odRdr["OvertimeHour1"]);
                attendanceReport.OvertimeRate1 = Convert.ToDouble(odRdr["OvertimeRate1"]);
                attendanceReport.OvertimeHour2 = Convert.ToDouble(odRdr["OvertimeHour2"]);
                attendanceReport.OvertimeRate2 = Convert.ToDouble(odRdr["OvertimeRate2"]);
                attendanceReport.OvertimeHour3 = Convert.ToDouble(odRdr["OvertimeHour3"]);
                attendanceReport.OvertimeRate3 = Convert.ToDouble(odRdr["OvertimeRate3"]);
                attendanceReport.OvertimeHour4 = Convert.ToDouble(odRdr["OvertimeHour4"]);
                attendanceReport.OvertimeRate4 = Convert.ToDouble(odRdr["OvertimeRate4"]);
                attendanceReport.DayTypeID = Convert.ToInt16(odRdr["DayTypeID"]);
                attendanceReport.PayPeriodID = Convert.ToInt16(odRdr["PayPeriodID"]);
                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();

                attendanceReportList.Add(attendanceReport);
            }

            odRdr.Close();
            return attendanceReportList;
        }

        #region IDataController Members

        public bool DeleteAllAttendanceRecord()
        {
            OleDbCommand odCom1 = BuildDelCmd("AttendanceRecord", "1=1");
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteAllAttendanceReport()
        {
            OleDbCommand odCom1 = BuildDelCmd("AttendanceReport", "1=1");
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteAllUncalculatedAttendanceRecord()
        {
            OleDbCommand odCom1 = BuildDelCmd("UncalculatedAttendanceRecord", "1=1");
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public Employee GetEmployeeByEmployeeNumber(int employeeNumber)
        {
            OleDbCommand odCom = BuildSelectCmd("Employee", "TOP 1 *", "EmployeeNumber=@EmployeeNumber AND Active=TRUE", new object[] { "@ID", employeeNumber });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Employee employee = null;
            if (odRdr.Read())
            {
                employee = new Employee();

                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.FirstName = odRdr["FirstName"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                employee.HiredDate = odRdr["HiredDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["HiredDate"]) : Config.MinDate;
                employee.LeftDate = odRdr["LeftDate"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["LeftDate"]) : Config.MinDate;
                employee.Birthday = odRdr["Birthday"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["Birthday"]) : Config.MinDate;
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.Address = odRdr["Address"].ToString();
                employee.Active = Convert.ToBoolean(odRdr["Active"]);
                employee.ActiveFrom = odRdr["ActiveFrom"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveFrom"]) : Config.MinDate;
                employee.ActiveTo = odRdr["ActiveTo"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["ActiveTo"]) : Config.MinDate;
                employee.FaceData1 = odRdr["FaceData1"].ToString();
                employee.FaceData2 = odRdr["FaceData2"].ToString();
                employee.FaceData3 = odRdr["FaceData3"].ToString();
                employee.FaceData4 = odRdr["FaceData4"].ToString();
                employee.FaceData5 = odRdr["FaceData5"].ToString();
                employee.FaceData6 = odRdr["FaceData6"].ToString();
                employee.FaceData7 = odRdr["FaceData7"].ToString();
                employee.FaceData8 = odRdr["FaceData8"].ToString();
                employee.FaceData9 = odRdr["FaceData9"].ToString();
                employee.FaceData10 = odRdr["FaceData10"].ToString();
                employee.FaceData11 = odRdr["FaceData11"].ToString();
                employee.FaceData12 = odRdr["FaceData12"].ToString();
                employee.FaceData13 = odRdr["FaceData13"].ToString();
                employee.FaceData14 = odRdr["FaceData14"].ToString();
                employee.FaceData15 = odRdr["FaceData15"].ToString();
                employee.FaceData16 = odRdr["FaceData16"].ToString();
                employee.FaceData17 = odRdr["FaceData17"].ToString();
                employee.FaceData18 = odRdr["FaceData18"].ToString();
            }
            odRdr.Close();
            return employee;
        }

        public Department GetDepartment(string name)
        {
            OleDbCommand odCom = BuildSelectCmd("Department", "TOP 1 *", "Name=@Name", new object[] { "@Name", name });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Department department = null;
            if (odRdr.Read())
            {
                department = new Department();

                department.ID = (int)odRdr["ID"];
                department.Name = odRdr["Name"].ToString();
                department.CompanyID = (int)odRdr["CompanyID"];
                department.SupDepartmentID = (int)odRdr["SupDepartmentID"];
            }

            odRdr.Close();
            return department;
        }

        #endregion

        #region Backup
        public void BackupDatabase(string backupPath)
        {
            //disconnect from db
            DisconnectFromDatabase();

            //copy db to a new file
            File.Copy(_dbPath, backupPath, true);

            //connect to db again
            ConnectToDatabase();
        }


        public void RestoreDatabase(string restoreFile)
        {
            //disconnect from db
            DisconnectFromDatabase();

            //copy db to a new file
            File.Copy(restoreFile, _dbPath, true);

            //connect to db again
            ConnectToDatabase();
        }
        #endregion

        #region Config
        public Config GetConfig()
        {
            OleDbCommand odCom = BuildSelectCmd("Config", "TOP 1 *", "1=1");
            OleDbDataReader odRdr = odCom.ExecuteReader();

            Config config = null;
            if (odRdr.Read())
            {
                config = new Config();

                config.ID = (int)odRdr["ID"];
                config.ScheduledBackup = Convert.ToBoolean(odRdr["ScheduledBackup"]);
                config.BackupPeriod = (int)odRdr["BackupPeriod"];
                config.BackupDay = (int)odRdr["BackupDay"];
                config.BackupTime = odRdr["BackupTime"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["BackupTime"]) : Config.MinDate;
                config.BackupFolder = odRdr["BackupFolder"].ToString();
                config.BackupRemind = Convert.ToBoolean(odRdr["BackupRemind"]);
                config.BackupRemindPeriod = (int)odRdr["BackupRemindPeriod"];
                config.LastestBackup = odRdr["LastestBackup"].GetType() != typeof(DBNull) ? Convert.ToDateTime(odRdr["LastestBackup"]) : Config.MinDate;
                config.LastestBackupFile = odRdr["LastestBackupFile"].ToString();
                config.RestoreFromLatest = Convert.ToBoolean(odRdr["RestoreFromLatest"]);
                config.RestoreFromFile = odRdr["RestoreFromFile"].ToString();
            }
            else
            {
                config = new Config();
                config.BackupFolder = "";
                config.RestoreFromFile = "";
                config.LastestBackupFile = "";

                config.BackupPeriod = 1;
                config.BackupRemindPeriod = 1;
                config.AttendanceRecordInterval = 5;

                config.LastestBackup = DateTime.Now;

                AddConfig(config);
                return GetConfig();
            }

            odRdr.Close();
            return config;
        }

        public bool UpdateConfig(Config config)
        {
            OleDbCommand odCom1 = BuildUpdateCmd("Config",
                new string[] { "ScheduledBackup"
                ,"BackupPeriod"
                ,"BackupDay"
                ,"BackupTime"
                ,"BackupFolder"
                ,"BackupRemind"
                ,"BackupRemindPeriod"
                ,"LastestBackup"
                ,"LastestBackupFile"
                ,"RestoreFromLatest"
                ,"RestoreFromFile"
                },
                new object[] { config.ScheduledBackup
                ,config.BackupPeriod
                ,config.BackupDay
                ,config.BackupTime
                ,config.BackupFolder
                ,config.BackupRemind
                ,config.BackupRemindPeriod
                ,config.LastestBackup
                ,config.LastestBackupFile
                ,config.RestoreFromLatest
                ,config.RestoreFromFile
                },
                "ID=@ID", new object[] { "@ID", config.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        private int AddConfig(Config config)
        {
            OleDbCommand odCom1 = BuildInsertCmd("Config",
                new string[] { "ScheduledBackup"
                ,"BackupPeriod"
                ,"BackupDay"
                ,"BackupTime"
                ,"BackupFolder"
                ,"BackupRemind"
                ,"BackupRemindPeriod"
                ,"RestoreFromLatest"
                ,"RestoreFromFile"
                },
                new object[] { config.ScheduledBackup
                ,config.BackupPeriod
                ,config.BackupDay
                ,config.BackupTime
                ,config.BackupFolder
                ,config.BackupRemind
                ,config.BackupRemindPeriod
                ,config.RestoreFromLatest
                ,config.RestoreFromFile
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return (int)odCom1.ExecuteScalar();
            }
            return -1;
        }

        public bool IsWorkingCalendarInUse(int workingCalendarID)
        {
            bool result = false;

            OleDbCommand odCom = BuildSelectCmd("Employee", "TOP 1 *", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });
            OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();
            odRdr.Close();

            return result;
        }

        public void TestDataController(MarshalByRefObject obj)
        {
            //do nothing
        }
        #endregion
    }
}