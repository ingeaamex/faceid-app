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

        ~LocalDataController()
        {
            DisconnectFromDatabase();
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
                //Config config = Util.GetConfig();
                //if (config == null)
                //    throw new Exception();
                string connectionString = @"Provider=Microsoft.JET.OLEDB.4.0;data source=F:\vnanh\project\FaceID\db\FaceIDdb.mdb";// +config.DatabasePath;
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
                    try
                    {
                        dbConnection.Close();
                    }
                    catch { }
                }
            }
        }

        #region Company
        public List<Company> GetCompanyList()
        {
            ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
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
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "ID=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Company", "ID,[Name]", "[Name]=@Name", new object[] { "@Name", name });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            if (id == 1) return false;
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
                department.Name = odRdr["Name"].ToString();
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

            if (department == null || CheckExistDepartmentName(department.Name, department.CompanyID, department.ID))
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
            if (id == 1) return false;

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

        public List<EmployeeReport> GetEmployeeReportList(int compantId, int departmentId)
        {
            System.Data.OleDb.OleDbCommand odCom;
            if (departmentId == 1 || compantId == 1)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID=1");
            else if (departmentId > 0)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID=@ID AND Active=TRUE", "@ID", departmentId);
            else if (compantId > 0)
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID) AND Active=true", new object[] { "@ID", compantId });
            else
                odCom = BuildSelectCmd("Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID", "Employee.*,Department.Name as DepartmentName", "Active=true");

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<EmployeeReport> employeeList = new List<EmployeeReport>();
            EmployeeReport employee = null;
            int employeeNo = 1;
            while (odRdr.Read())
            {
                employee = new EmployeeReport();
                employee.DepartmentName = odRdr["DepartmentName"].ToString();
                employee.EmployeeNo = employeeNo++;
                employee.FullName = odRdr["FirstName"].ToString() + ", " + odRdr["LastName"].ToString();
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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "PayrollNumber", "Active=TRUE AND EmployeeNumber=@EmployeeNumber", "@EmployeeNumber", employee.EmployeeNumber);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            result = (odRdr.Read() == false);
            odRdr.Close();
            return result;
        }

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
                employee.Address = odRdr["Address"].ToString();
                if (typeof(DBNull) != odRdr["Birthday"].GetType())
                    employee.Birthday = (DateTime)odRdr["Birthday"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.FirstName = odRdr["FirstName"].ToString();
                if (typeof(DBNull) != odRdr["HiredDate"].GetType())
                    employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                if (typeof(DBNull) != odRdr["LeftDate"].GetType())
                    employee.LeftDate = (DateTime)odRdr["LeftDate"];
                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                if (typeof(DBNull) != odRdr["ActiveFrom"].GetType())
                    employee.ActiveFrom = (DateTime)odRdr["ActiveFrom"];
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
            }
            odRdr.Close();
            return employee;
        }

        public List<Employee> GetEmployeeList(int compantId, int departmentId)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom;
            if (departmentId == 1 || compantId == 1)
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID=1");
            else if (departmentId > 0)
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID=@ID AND Active=TRUE", "@ID", departmentId);
            else if (compantId > 0)
                odCom = BuildSelectCmd("Employee", "*", "DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID) AND Active=true", new object[] { "@ID", compantId });
            else
                odCom = BuildSelectCmd("Employee", "*", "Active=true");

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();
                employee.Active = (bool)odRdr["Active"];
                employee.Address = odRdr["Address"].ToString();
                if (typeof(DBNull) != odRdr["Birthday"].GetType())
                    employee.Birthday = (DateTime)odRdr["Birthday"];
                employee.DepartmentID = (int)odRdr["DepartmentID"];
                employee.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                employee.FirstName = odRdr["FirstName"].ToString();
                if (typeof(DBNull) != odRdr["HiredDate"].GetType())
                    employee.HiredDate = (DateTime)odRdr["HiredDate"];
                employee.JobDescription = odRdr["JobDescription"].ToString();
                employee.LastName = odRdr["LastName"].ToString();
                if (typeof(DBNull) != odRdr["LeftDate"].GetType())
                    employee.LeftDate = (DateTime)odRdr["LeftDate"];
                employee.PayrollNumber = (int)odRdr["PayrollNumber"];
                employee.PhoneNumber = odRdr["PhoneNumber"].ToString();
                employee.WorkingCalendarID = (int)odRdr["WorkingCalendarID"];
                if (typeof(DBNull) != odRdr["ActiveFrom"].GetType())
                    employee.ActiveFrom = (DateTime)odRdr["ActiveFrom"];
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Employee",
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
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Employee",
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
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Terminal", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
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
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Terminal", "*", "ID=@ID", new object[] { "@ID", id });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            Terminal terminal = null;
            if (odRdr.Read())
            {
                terminal = new Terminal();

                terminal.ID = Convert.ToInt16(odRdr["ID"]);
                terminal.Name = odRdr["Name"].ToString();
                terminal.IPAddress = odRdr["IPAddress"].ToString();
            }

            odRdr.Close();
            return terminal;
        }

        private bool CheckExistTerminal(Terminal terminal, bool forUpdate)
        {
            System.Data.OleDb.OleDbCommand odCom;
            if (forUpdate)
                odCom = BuildSelectCmd("Terminal", "ID", "ID<>@ID AND ([Name]=@Name OR IPAddress=@IPAddress)",
                    new object[] { "@ID", terminal.ID, "@Name", terminal.Name, "@IPAddress", terminal.IPAddress });
            else
                odCom = BuildSelectCmd("Terminal", "ID", "[Name]=@Name OR IPAddress=@IPAddress",
                    new object[] { "@Name", terminal.Name, "@IPAddress", terminal.IPAddress });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            if (odRdr.Read())
            {
                odRdr.Close();
                return true;
            }
            return false;
        }

        public int AddTerminal(Terminal terminal)
        {
            //ConnectToDatabase();

            if (CheckExistTerminal(terminal, false))
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Terminal",
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
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateTerminal(Terminal terminal)
        {
            //ConnectToDatabase();

            if (CheckExistTerminal(terminal, true))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Terminal",
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

        public List<Terminal> GetTerminalListByEmployee(int employeeNumber)
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

        public bool DeleteEmployeeTerminalByEmployee(int employeeNumber)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }

        public bool DeleteEmployeeTerminal(int terminalID)
        {
            //ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "TerminalID=@ID", new object[] { "@ID", terminalID });

            return ExecuteNonQuery(odCom1) >= 0 ? true : false;
        }

        public bool UpdateEmployeeTerminal(List<Terminal> terminals, int employeeNumber)
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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("EmployeeNumber", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<EmployeeNumber> employeeNumberList = new List<EmployeeNumber>();
            EmployeeNumber employeeNumber = null;
            while (odRdr.Read())
            {
                employeeNumber = new EmployeeNumber();

                employeeNumber.ID = Convert.ToInt16(odRdr["ID"]);
                employeeNumber.Note = odRdr["Note"].ToString();

                employeeNumberList.Add(employeeNumber);
            }

            odRdr.Close();
            return employeeNumberList;
        }

        public int GetAvailEmployeeNumber()
        {
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
        public List<WorkingCalendar> GetWorkingCalendarList()
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
                wCalendar.Name = odRdr["Name"].ToString();
                if (typeof(DBNull) != odRdr["RegularWorkingFrom"].GetType())
                    wCalendar.RegularWorkingFrom = (DateTime)odRdr["RegularWorkingFrom"];
                if (typeof(DBNull) != odRdr["RegularWorkingTo"].GetType())
                    wCalendar.RegularWorkingTo = (DateTime)odRdr["RegularWorkingTo"];

                wCalendarList.Add(wCalendar);
            }

            odRdr.Close();
            return wCalendarList;
        }

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
                workingCalendar.Name = odRdr["Name"].ToString();
                workingCalendar.PayPeriodID = (int)odRdr["PayPeriodID"];
                if (typeof(DBNull) != odRdr["RegularWorkingFrom"].GetType())
                    workingCalendar.RegularWorkingFrom = (DateTime)odRdr["RegularWorkingFrom"];
                if (typeof(DBNull) != odRdr["RegularWorkingTo"].GetType())
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

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "*", "ID=@ID", new object[] { "@ID", workingCalendarID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            WorkingCalendar workingCalendar = null;
            if (odRdr.Read())
            {
                workingCalendar = new WorkingCalendar();

                workingCalendar.ID = Convert.ToInt16(odRdr["ID"]);
                workingCalendar.Name = odRdr["Name"].ToString();
                workingCalendar.WorkOnMonday = Convert.ToBoolean(odRdr["WorkOnMonday"]);
                workingCalendar.WorkOnTuesday = Convert.ToBoolean(odRdr["WorkOnTuesday"]);
                workingCalendar.WorkOnWednesday = Convert.ToBoolean(odRdr["WorkOnWednesday"]);
                workingCalendar.WorkOnThursday = Convert.ToBoolean(odRdr["WorkOnThursday"]);
                workingCalendar.WorkOnFriday = Convert.ToBoolean(odRdr["WorkOnFriday"]);
                workingCalendar.WorkOnSaturday = Convert.ToBoolean(odRdr["WorkOnSaturday"]);
                workingCalendar.WorkOnSunday = Convert.ToBoolean(odRdr["WorkOnSunday"]);
                workingCalendar.RegularWorkingFrom = Convert.ToDateTime(odRdr["RegularWorkingFrom"]);
                workingCalendar.RegularWorkingTo = Convert.ToDateTime(odRdr["RegularWorkingTo"]);
                workingCalendar.PayPeriodID = Convert.ToInt16(odRdr["PayPeriodID"]);
            }

            odRdr.Close();
            return workingCalendar;
        }

        public List<Break> GetBreakListByWorkingCalendar(int workingCalendarID)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Break", "*", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=1", new object[] { "@WorkingCalendarID", workingCalendarID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=2", new object[] { "@WorkingCalendarID", workingCalendarID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("PaymentRate", "*", "WorkingCalendarID=@WorkingCalendarID AND DayTypeID=3", new object[] { "@WorkingCalendarID", workingCalendarID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Holiday", "*", "WorkingCalendarID=@WorkingCalendarID", new object[] { "@WorkingCalendarID", workingCalendarID });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
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

        public PayPeriod GetPayPeriodByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
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

                if(workingCalendar.ID < 0)
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
            catch(Exception)
            {
                RollbackTransaction();
                return -1;
            }

            return workingCalendar.ID;
        }

        private int AddWorkingCalendar(WorkingCalendar workingCalendar)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("WorkingCalendar",
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
                    if(DeleteBreak(_break.ID) == false)
                        throw new NullReferenceException();
                }

                foreach (Break _break in breakList)
                {
                    _break.WorkingCalendarID = workingCalendar.ID;
                    if(AddBreak(_break) < 0)
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
                if (UpdatePaymentRate(workingDayPaymentRate)== false)
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("WorkingCalendar",
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
                },
                "ID=@ID", new object[] { "@ID", workingCalendar.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public PayPeriod GetPayPeriodByName(string payPeriodName)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateWorkingCalendarName(string name)
        {
            bool result = false;

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "ID", "Name=@Name", new object[] { "@Name", name });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            odRdr.Close();
            return result;
        }

        public bool IsDuplicateWorkingCalendarName(string name, int workingCalendarID)
        {
            bool result = false;

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("WorkingCalendar", "ID", "Name=@Name AND ID<>@ID", new object[] { "@Name", name, "@ID", workingCalendarID });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            odRdr.Close();
            return result;
        }

        public PayPeriodType GetPayPeriodType(int payPeriodTypeID)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("PayPeriodType", "*", "ID=@ID", new object[] { "@ID", payPeriodTypeID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("PayPeriod", "*", "ID=@ID", new object[] { "@ID", payPeriodID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("WorkingCalendar", "ID=@ID", new object[] { "@ID", workingCalendarID });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }
        #endregion

        #region Attendance Record

        private List<string> GetEmployeeNumberList(int iCompany, int iDepartment)
        {
            System.Data.OleDb.OleDbCommand odCom = null;
            if (iDepartment > 0)
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", "DepartmentID=@ID", new object[] { "@ID", iDepartment });
            else if (iCompany > 0)
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", " DepartmentID in (SELECT ID FROM Department WHERE CompanyID=@ID)", new object[] { "@ID", iCompany });
            else
                odCom = BuildSelectCmd("Employee", "Distinct EmployeeNumber", null);

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<string> empls = new List<string>();
            while (odRdr.Read())
            {
                empls.Add(odRdr["EmployeeNumber"].ToString());
            }
            odRdr.Close();

            return empls;
        }

        private AttendanceLogReport GetRegularOvertime(AttendanceLogReport _attReport, double _totalHour)
        {
            double _regularHour = _attReport.RegularHour;
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
                            overtimeHour2 = _totalHour;
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

            attReport.OvertimeHour1 = overtimeHour1;
            attReport.OvertimeHour2 = overtimeHour2;
            attReport.OvertimeHour3 = overtimeHour3;
            attReport.OvertimeHour4 = overtimeHour4;
            attReport.RegularHour = totalHour;

            return attReport;
        }

        public List<AttendanceLogReport> GetAttendanceReportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            List<string> lEmplNumbers = GetEmployeeNumberList(iCompany, iDepartment);
            if (lEmplNumbers.Count == 0)
                return null;
            string sEmplNumbers = string.Join(",", lEmplNumbers.ToArray());

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "WorkFrom >=@Date_1 AND WorkFrom <= @Date_2 AND EmployeeNumber in(" + sEmplNumbers + ")",
                new object[] { "@Date_1", beginDate, "@Date_2", endDate });

            OleDbDataAdapter odApt = new OleDbDataAdapter(odCom);
            DataTable dtReport = new DataTable();
            odApt.Fill(dtReport);

            if (dtReport.Rows.Count == 0)
                return null;

            odCom = BuildSelectCmd("Employee", "EmployeeNumber,FirstName,LastName", "EmployeeNumber in(" + sEmplNumbers + ")");

            odApt = new OleDbDataAdapter(odCom);
            DataTable dtEmpl = new DataTable();
            odApt.Fill(dtEmpl);

            if (dtReport.Rows.Count == 0)
                return null;

            System.Data.OleDb.OleDbDataReader odRdr = null;
            List<AttendanceLogReport> attLogs = new List<AttendanceLogReport>();
            foreach (DataRow drRp in dtReport.Rows)
            {
                AttendanceLogReport _attLog = new AttendanceLogReport();
                if (typeof(DBNull) != odRdr["WorkFrom"].GetType())
                    _attLog.WorkFrom = (DateTime)drRp["WorkFrom"];
                if (typeof(DBNull) != odRdr["WorkTo"].GetType())
                    _attLog.WorkTo = (DateTime)drRp["WorkTo"];
                _attLog.EmployeeNumber = (int)drRp["EmployeeNumber"];

                DataRow[] rdEmpl =  dtEmpl.Select("EmployeeNumber=" + _attLog.EmployeeNumber);
                if (rdEmpl.Length > 0)
                    _attLog.FullName = rdEmpl[0]["FirstName"] + ", " + rdEmpl[0]["LastName"];
                _attLog.AttendanceReportID = (int)drRp["AttendanceReportID"];
                _attLog.DayTypeID = (int)drRp["DayTypeID"];
                _attLog.OvertimeHour1 = (double)drRp["OvertimeHour1"];
                _attLog.OvertimeHour2 = (double)drRp["OvertimeHour2"];
                _attLog.OvertimeHour3 = (double)drRp["OvertimeHour3"];
                _attLog.OvertimeHour4 = (double)drRp["OvertimeHour4"];
                _attLog.OvertimeRate1 = (double)drRp["OvertimeRate1"];
                _attLog.OvertimeRate2 = (double)drRp["OvertimeRate1"];
                _attLog.OvertimeRate3 = (double)drRp["OvertimeRate1"];
                _attLog.OvertimeRate4 = (double)drRp["OvertimeRate1"];
                _attLog.PayPeriodID = (int)drRp["PayPeriodID"];
                _attLog.RegularHour = (double)drRp["RegularHour"];
                _attLog.RegularRate = (double)drRp["RegularRate"];

                string sAttendanceRecordIDs = (string)drRp["AttendanceRecordIDList"];
                sAttendanceRecordIDs = sAttendanceRecordIDs.Replace("{", "").Replace("}", ",").Trim(',');

                odCom = BuildSelectCmd("AttendanceRecord", "*", "ID in(" + sAttendanceRecordIDs + ")");

                List<DateTime> attTime = new List<DateTime>();
                odRdr = odCom.ExecuteReader();
                while (odRdr.Read())
                {
                    attTime.Add(Convert.ToDateTime(odRdr["Time"]));
                }
                odRdr.Close();

                long totalTicks = 0;

                for (int i = 0; i < attTime.Count - 1; i++)
                {
                    if (i % 2 == 0)
                        totalTicks += attTime[i + 1].Ticks - attTime[i].Ticks;
                }

                double totalMinute = totalTicks / 600000000;
                double totalHour = Math.Round(totalMinute / 60, 2);
                _attLog.TotalHour = totalHour;

                AttendanceLogReport attLog = GetRegularOvertime(_attLog, totalHour);

                attLogs.Add(attLog);
            }
            return attLogs;
        }

        public List<AttendanceLogRecord> GetAttendanceRecordList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            List<string> lEmplNumbers = GetEmployeeNumberList(iCompany, iDepartment);
            if (lEmplNumbers.Count == 0)
                return null;
            string sEmplNumbers = string.Join(",", lEmplNumbers.ToArray());


            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "EmployeeNumber,FirstName,LastName", "EmployeeNumber in(" + sEmplNumbers + ")");

            OleDbDataAdapter odApt = new OleDbDataAdapter(odCom);
            DataTable dtEmpl = new DataTable();
            odApt.Fill(dtEmpl);


            odCom = BuildSelectCmd("AttendanceRecord",
                "*","Time >=@Date_1 AND Time <= @Date_2 AND EmployeeNumber in(" + sEmplNumbers + ")",
                new object[] { "@Date_1", beginDate, "@Date_2", endDate });

            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<AttendanceRecord> attRecordList = new List<AttendanceRecord>();
            AttendanceRecord attRecord = null;
            List<Employee> empls = new List<Employee>();
            Employee empl = null;
            while (odRdr.Read())
            {
                attRecord = new AttendanceRecord();
                empl = new Employee();

                empl.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                DataRow[] rdEmpl = dtEmpl.Select("EmployeeNumber=" + empl.EmployeeNumber);
                if (rdEmpl.Length > 0)
                {
                    empl.FirstName = rdEmpl[0]["FirstName"].ToString();
                    empl.LastName = rdEmpl[0]["LastName"].ToString();
                }
                attRecord.ID = (int)odRdr["ID"];
                attRecord.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attRecord.Note = odRdr["Note"].ToString();
                attRecord.PhotoData = odRdr["PhotoData"].ToString();
                attRecord.Time = (DateTime)odRdr["Time"];

                empls.Add(empl);
                attRecordList.Add(attRecord);
            }
            odRdr.Close();

            if (empls.Count == 0)
                return null;

            List<AttendanceLogRecord> attLogRecords = new List<AttendanceLogRecord>();

            foreach (string emplNumber in lEmplNumbers)
            {
                List<AttendanceRecord> attRds = attRecordList.FindAll(delegate(AttendanceRecord attRd)
                {
                    return attRd.EmployeeNumber == Convert.ToInt32(emplNumber);
                });
                if (attRds != null)
                {
                    AttendanceLogRecord attLogRecord = new AttendanceLogRecord();
                    Employee empl1 = empls.Find(delegate(Employee e) { return e.EmployeeNumber == Convert.ToInt32(emplNumber); });
                    if (empl1 == null)
                        continue;
                    attLogRecord.EmployeeNumber = empl1.EmployeeNumber;
                    attLogRecord.FirstName = empl1.FirstName;
                    attLogRecord.LastName = empl1.LastName;

                    List<DateTime> lDateLog = new List<DateTime>();
                    List<string> lNote = new List<string>();
                    List<object[]> lInOutTime = new List<object[]>();
                    List<object[]> lTotalHour = new List<object[]>();

                    attRds.Sort(delegate(AttendanceRecord e1, AttendanceRecord e2) { return e1.Time.CompareTo(e2.Time); });
                    foreach (AttendanceRecord attRd in attRds)
                    {
                        if (!lDateLog.Contains(attRd.Time.Date))
                        {
                            lDateLog.Add(attRd.Time.Date);
                            long totalTicks = 0;
                            List<AttendanceRecord> attRds1 = attRds.FindAll(delegate(AttendanceRecord e) { return e.Time.Date.Equals(attRd.Time.Date); });
                            attRds1.Sort(delegate(AttendanceRecord e1, AttendanceRecord e2) { return e1.Time.CompareTo(e2.Time); });
                            for (int i = 0; i < attRds1.Count - 1; i++)
                            {
                                if (i % 2 == 0)
                                    totalTicks += attRds1[i + 1].Time.Ticks - attRds1[i].Time.Ticks;
                            }
                            double totalMinute = totalTicks / 600000000;
                            double totalHour = Math.Round(totalMinute / 60, 2);
                            lTotalHour.Add(new object[] { totalHour, attRds1.Count });
                        }

                        lNote.Add(attRd.Note);
                        lInOutTime.Add(new object[] { attRd.ID, attRd.Time.Hour + ":" + attRd.Time.Minute });
                    }
                    attLogRecord.DateLog = lDateLog;
                    attLogRecord.InOutTime = lInOutTime;
                    attLogRecord.Note = lNote;
                    attLogRecord.TotalHour = lTotalHour;
                    attLogRecords.Add(attLogRecord);
                }
            }
            return attLogRecords;
        }

        public AttendanceRecord GetAttendanceRecord(int id)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceRecord", "*", "ID=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            DateTime dRegularWorkingFrom = workingCalendar.RegularWorkingFrom;
            DateTime dRegularWorkingTo = workingCalendar.RegularWorkingTo;

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

            DateTime dAttRecordPeriod1 = attRecord.Time.AddDays(-1);
            dAttRecordPeriod1 = dAttRecordPeriod1.Date.AddHours(dRegularWorkingFrom.Hour).AddMinutes(dRegularWorkingFrom.Minute);

            DateTime dAttRecordPeriod2 = dAttRecordPeriod1.AddHours(23);

            odCom = BuildSelectCmd("AttendanceRecord", "*", "EmployeeNumber=@Empl AND Time>=@Date_1 AND Time<=@Date_2", new object[] { "@Empl", iEmployeeNumber, "@Date_1", dAttRecordPeriod1, "@Date_2", dAttRecordPeriod2 });
            odRdr = odCom.ExecuteReader();

            List<string> rcAtts = new List<string>();
            List<DateTime> attendanceRecordTimes = new List<DateTime>();
            while (odRdr.Read())
            {
                rcAtts.Add("{" + odRdr["ID"].ToString() + "}");
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

            string sAttendanceRecordIDs = string.Concat(rcAtts.ToArray());
           
            attendanceRecordTimes.Sort();

            DateTime wDate = attendanceRecordTimes[0].Date;
            dRegularWorkingFrom = new DateTime(wDate.Year, wDate.Month, wDate.Day, dRegularWorkingFrom.Hour, dRegularWorkingFrom.Minute, dRegularWorkingFrom.Second);
            dRegularWorkingTo = new DateTime(wDate.Year, wDate.Month, wDate.Day, dRegularWorkingTo.Hour, dRegularWorkingTo.Minute, dRegularWorkingTo.Second);
            if (dRegularWorkingFrom.CompareTo(dRegularWorkingTo) == 1)
                dRegularWorkingTo = dRegularWorkingTo.AddDays(1);

            AttendanceReport attendanceReport = new AttendanceReport();
            attendanceReport.DayTypeID = iDayTypeID;
            attendanceReport.EmployeeNumber = iEmployeeNumber;
            attendanceReport.OvertimeHour1 = paymentRate.NumberOfOvertime1;
            attendanceReport.OvertimeHour2 = paymentRate.NumberOfOvertime2;
            attendanceReport.OvertimeHour3 = paymentRate.NumberOfOvertime3;
            attendanceReport.OvertimeHour4 = paymentRate.NumberOfOvertime4;
            attendanceReport.OvertimeRate1 = paymentRate.OvertimeRate1;
            attendanceReport.OvertimeRate2 = paymentRate.OvertimeRate2;
            attendanceReport.OvertimeRate3 = paymentRate.OvertimeRate3;
            attendanceReport.OvertimeRate4 = paymentRate.OvertimeRate4;
            attendanceReport.PayPeriodID = iPayPeriodID;
            attendanceReport.RegularHour = paymentRate.NumberOfRegularHours;
            attendanceReport.RegularRate = paymentRate.RegularRate;
            attendanceReport.WorkFrom = dRegularWorkingFrom;
            attendanceReport.WorkTo = dRegularWorkingTo;
            attendanceReport.AttendanceRecordIDList = sAttendanceRecordIDs;

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

        private AttendanceReport GetAttendanceReport(int attRcId)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("AttendanceReport", "*", "AttendanceRecordIDList like '*{" + attRcId + "}*'");
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            AttendanceReport attendanceReport = null;
            if (odRdr.Read())
            {
                attendanceReport = new AttendanceReport();

                attendanceReport.DayTypeID = (int)odRdr["DayTypeID"];
                attendanceReport.EmployeeNumber = (int)odRdr["EmployeeNumber"];
                attendanceReport.OvertimeHour1 = (int)odRdr["OvertimeHour1"];
                attendanceReport.OvertimeHour2 = (int)odRdr["OvertimeHour2"];
                attendanceReport.OvertimeHour3 = (int)odRdr["OvertimeHour3"];
                attendanceReport.OvertimeHour4 = (int)odRdr["OvertimeHour4"];
                attendanceReport.OvertimeRate1 = (int)odRdr["OvertimeRate1"];
                attendanceReport.OvertimeRate2 = (int)odRdr["OvertimeRate2"];
                attendanceReport.OvertimeRate3 = (int)odRdr["OvertimeRate3"];
                attendanceReport.OvertimeRate4 = (int)odRdr["OvertimeRate4"];
                attendanceReport.PayPeriodID = (int)odRdr["PayPeriodID"];
                attendanceReport.RegularHour = (int)odRdr["RegularHour"];
                attendanceReport.RegularRate = (int)odRdr["RegularRate"];
                if (typeof(DBNull) != odRdr["WorkFrom"].GetType())
                    attendanceReport.WorkFrom = (DateTime)odRdr["WorkFrom"];
                if (typeof(DBNull) != odRdr["WorkTo"].GetType())
                    attendanceReport.WorkTo = (DateTime)odRdr["WorkTo"];
                attendanceReport.AttendanceReportID = (int)odRdr["AttendanceReportID"];
                attendanceReport.AttendanceRecordIDList = odRdr["AttendanceRecordIDList"].ToString();
            }
            odRdr.Close();
            return attendanceReport;
        }

        private bool AddAttendanceReport(AttendanceReport attendanceReport)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("AttendanceReport",
                new string[] { "DayTypeID", "EmployeeNumber", "OvertimeHour1", "OvertimeHour2", "OvertimeHour3", "OvertimeHour4",
                "OvertimeRate1","OvertimeRate2","OvertimeRate3","OvertimeRate4","PayPeriodID","RegularHour","RegularRate",
                "WorkFrom","WorkTo","AttendanceRecordIDList"},
                new object[] { attendanceReport.DayTypeID, attendanceReport.EmployeeNumber, attendanceReport.OvertimeHour1,
                attendanceReport.OvertimeHour2,attendanceReport.OvertimeHour3,attendanceReport.OvertimeHour4, attendanceReport.OvertimeRate1,
                attendanceReport.OvertimeRate2,attendanceReport.OvertimeRate3, attendanceReport.OvertimeRate4,attendanceReport.PayPeriodID,
                attendanceReport.RegularHour,attendanceReport.RegularRate,attendanceReport.WorkFrom,attendanceReport.WorkTo,attendanceReport.AttendanceRecordIDList}
                );

            return ExecuteNonQuery(odCom1) > 0;
        }

        public bool DeleteAttendanceRecord(int id)
        {
            AttendanceReport attReport = GetAttendanceReport(id);
            System.Data.OleDb.OleDbCommand odCom = null;
            if (attReport == null)
            {
                odCom = BuildDelCmd("AttendanceRecord", "ID=@ID", new object[] { "@ID", id });
                return ExecuteNonQuery(odCom) > 0;
            }
            else
            {
                string sAttendanceRecordIDs = attReport.AttendanceRecordIDList;
                sAttendanceRecordIDs = sAttendanceRecordIDs.Replace("{" + id + "}", "");

                BeginTransaction();

                odCom = BuildDelCmd("AttendanceRecord", "ID=@ID", new object[] { "@ID", id });
                int irs1 = ExecuteNonQuery(odCom);

                odCom = BuildUpdateCmd("AttendanceReport", new string[] { "AttendanceRecordIDList" }, new object[] { sAttendanceRecordIDs }, 
                    "AttendanceReportID=@ID", new object[] { "@@ID", attReport.AttendanceReportID });
                int irs2 = ExecuteNonQuery(odCom);

                if (irs1 > 0 && irs2 > 0)
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
            if (attRecord == null || IsValidAttendanceRecord(attRecord, true))
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("AttendanceRecord",
                new string[] { "EmployeeNumber", "Note", "Time" },
                new object[] { attRecord.EmployeeNumber, attRecord.Note, attRecord.Time },
                "ID=@ID", new object[] { "@ID", attRecord.ID }
                );

            return ExecuteNonQuery(odCom1) > 0 ? true : false;
        }

        #endregion Attendance Record

        #region FaceIDUser

        public List<FaceIDUser> GetFaceIDUserList()
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<FaceIDUser> faceIDUserList = new List<FaceIDUser>();
            FaceIDUser faceIDUser = null;
            while (odRdr.Read())
            {
                faceIDUser = new FaceIDUser();

                faceIDUser.EmployeeNumber = Convert.ToInt16(odRdr["EmployeeNumber"]);
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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", "EmployeeNumber=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            FaceIDUser faceIDUser = null;
            if (odRdr.Read())
            {
                faceIDUser = new FaceIDUser();

                faceIDUser.EmployeeNumber = Convert.ToInt16(odRdr["EmployeeNumber"]);
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("FaceIDUser",
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
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateFaceIDUser(FaceIDUser faceIDUser)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("FaceIDUser",
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
                "ID=@ID", new object[] { "@ID", faceIDUser.EmployeeNumber }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteFaceIDUser(int id)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("FaceIDUser", "EmployeeNumber=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool IsFaceIDUser(int employeeNumber)
        {
            bool result = false;

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("FaceIDUser", "*", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            result = odRdr.Read();

            return result;
        }
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

        #region AttendanceReport

        public DataTable GetAttendanceReport(int companyID, int departmentID, DateTime dtFrom, DateTime dtTo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataController Members

        public int AddPayPeriod(PayPeriod payPeriod)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("PayPeriod",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("PayPeriod", "ID=@ID", new object[] { "@ID", id });
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
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Break", "*", "ID=@ID", new object[] { "@ID", id });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

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
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Break",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Break", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdateBreak(Break _break)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Break",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("PaymentRate",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("PaymentRate", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdatePaymentRate(PaymentRate paymentRate)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("PaymentRate",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Holiday",
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
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Holiday", "ID=@ID", new object[] { "@ID", id });
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public List<Employee> GetEmployeeList()
        {
            return GetEmployeeList(-1, -1);
        }

        public List<Employee> GetEmployeeListByTerminal(int terminalID)
        {
            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "*", "Active=TRUE AND EmployeeNumber IN (SELECT EmployeeNumber FROM EmployeeTerminal WHERE TerminalID=@terminalID)", new object[] { "@terminalID", terminalID });
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();

                employee.PayrollNumber = Convert.ToInt16(odRdr["PayrollNumber"]);
                employee.EmployeeNumber = Convert.ToInt16(odRdr["EmployeeNumber"]);
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
    }
}