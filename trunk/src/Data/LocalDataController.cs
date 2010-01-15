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
        
        public List<Department> GetDepartmentByCompany(int id)
        {
            ConnectToDatabase();

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

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Company",
                new string[] { "Name" },
                new object[] { company.Name },
                "ID=@ID", new object[] { "@ID", company.ID }
                );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }
        #endregion Company

        #region Department
        public List<Department> GetDepartmentList()
        {
            ConnectToDatabase();

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

                department.ID = (int)odRdr["ID"];
                departmentList.Add(department);
            }

            odRdr.Close();
            dbConnection.Close();
            return departmentList;
        }

        public Department GetDepartment(int id)
        {
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
                return true;
            }

            odRdr.Close();
            return false;
        }

        public int AddDepartment(Department department)
        {
            ConnectToDatabase();

            if (department == null || CheckExistDepartmentName(department.Name, department.CompanyID, 0))
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
        #endregion Department

        #region Employee

        public Employee GetEmployee(int employeeId)
        {
            ConnectToDatabase();

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
            }
            odRdr.Close();
            return employee;
        }

        public List<Employee> GetEmployeeList(int compantId)
        {
            ConnectToDatabase();

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

                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public List<Employee> GetEmployeeListByDep(int departmentId)
        {
            ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("Employee", "*", "DepartmentID=@ID", "@ID", departmentId);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = null;
            while (odRdr.Read())
            {
                employee = new Employee();

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

                employeeList.Add(employee);
            }
            odRdr.Close();
            return employeeList;
        }

        public int AddEmployee(Employee employee)
        {
            ConnectToDatabase();

            if (employee == null)
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Employee",
                new string[] {"EmployeeNumber", "DepartmentID", "WorkingCalendarID", "FirstName",
                    "LastName","PhoneNumber","Address","JobDescription",
                    "Birthday","HiredDate","LeftDate","PhotoData","Active" },
                new object[] {employee.EmployeeNumber, employee.DepartmentID,employee.WorkingCalendarID,employee.FirstName,
                    employee.LastName,employee.PhoneNumber, employee.Address,employee.JobDescription,
                    employee.Birthday, employee.HiredDate,employee.LeftDate,employee.PhotoData,employee.Active
                });

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                int rs = Convert.ToInt16(odCom1.ExecuteScalar().ToString());
                dbConnection.Close();
                return rs;
            }

            return -1;
        }

        public bool DeleteEmployee(int employeeId)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] { "Active" }, new object[] { false}, "PayrollNumber=@ID",
                new object[] { "@ID", employeeId }
            );
            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            ConnectToDatabase();

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

            if (odCom1.ExecuteNonQuery() == 1)
            {
                dbConnection.Close();
                return true;
            }

            return false;
        }

        public bool UpdateEmployeeNumber(Employee employee)
        {
            ConnectToDatabase();

            if (employee == null)
                return false;

            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Employee",
                new string[] { "EmployeeNumber" },
                new object[] { employee.EmployeeNumber },
                "PayrollNumber=@ID", new object[] { "@ID", employee.PayrollNumber }
                );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        #endregion Employee

        #region WorkingCalendar
        public List<WorkingCalendar> GetWCalendarList()
        {
            ConnectToDatabase();

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
            ConnectToDatabase();

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
            string strCommand = "SELECT * FROM Terminal WHERE ID = " + id;

            System.Data.OleDb.OleDbCommand odCom = dbConnection.CreateCommand();
            odCom.CommandText += strCommand;
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

        public int AddTerminal(Terminal _terminal)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildInsertCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { _terminal.Name
                ,_terminal.IPAddress
                }
            );

            if (odCom1.ExecuteNonQuery() == 1)
            {
                odCom1.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt16(odCom1.ExecuteScalar().ToString());
            }
            return -1;
        }

        public bool UpdateTerminal(Terminal _terminal)
        {
            System.Data.OleDb.OleDbCommand odCom1 = BuildUpdateCmd("Terminal",
                new string[] { "Name"
                ,"IPAddress"
                },
                new object[] { _terminal.Name
                ,_terminal.IPAddress
                },
                "ID=@ID", new object[] { "@ID", _terminal.ID }
            );

            return odCom1.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool DeleteTerminal(int id)
        {
            OleDbTransaction trans = dbConnection.BeginTransaction();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("Terminal", "ID=@ID", new object[] { "@ID", id });
            odCom1.Transaction = trans;
            int t1 = odCom1.ExecuteNonQuery();
            odCom1 = BuildDelCmd("EmployeeTerminal", "TerminalID=@ID", new object[] { "@ID", id });
            odCom1.Transaction = trans;
            int t2 = odCom1.ExecuteNonQuery();
            if (t1 > 0 && t2 > 0)
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

        #endregion Terminal

        #region EmployeeTerminal

        public List<EmployeeTerminal> GetEmployeeTerminalsByEmpl(int employeeNumber)
        {
            ConnectToDatabase();
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
            ConnectToDatabase();
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
            ConnectToDatabase();

            if (emplTerminals == null)
                return -1;

            System.Data.OleDb.OleDbCommand odCom1 = null;

            foreach (EmployeeTerminal emplTerminal in emplTerminals)
            {
                odCom1 = BuildInsertCmd("EmployeeTerminal",
                    new string[] { "EmployeeNumber", "TerminalID" },
                    new object[] { emplTerminal.EmployeeNumber, emplTerminal.TerminalID }
                    );

                odCom1.ExecuteNonQuery();
            }
            return 1;
        }

        public bool DeleteEmplTerminal(EmployeeTerminal emplTerminal)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmplTerminal(List<Terminal> terminals, int employeeNumber)
        {
            ConnectToDatabase();

            OleDbTransaction trans = dbConnection.BeginTransaction();
            System.Data.OleDb.OleDbCommand odCom1 = BuildDelCmd("EmployeeTerminal", "EmployeeNumber=@ID", new object[] { "@ID", employeeNumber });
            odCom1.Transaction = trans;
            int t1 = odCom1.ExecuteNonQuery();
            if (t1 < 0)
            {
                trans.Rollback();
                dbConnection.Close();
                return false;
            }
            foreach (Terminal terminal in terminals)
            {
                odCom1 = BuildInsertCmd("EmployeeTerminal",
                    new string[] { "EmployeeNumber", "TerminalID" },
                    new object[] { employeeNumber, terminal.ID }
                    );
                odCom1.Transaction = trans;
                t1 = odCom1.ExecuteNonQuery();

                if (t1 < 1)
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

        #endregion EmployeeTerminal

        #region EmployeeNumber

        public List<EmployeeNumber> GetEmployeeNumberList()
        {
            throw new NotImplementedException();
        }

        public int AddEmployeeNumber()
        {
            ConnectToDatabase();

            System.Data.OleDb.OleDbCommand odCom = BuildSelectCmd("EmployeeNumber", "ID", null);
            System.Data.OleDb.OleDbDataReader odRdr = odCom.ExecuteReader();

            List<int> ids = new List<int>();

            while (odRdr.Read())
                ids.Add((int)odRdr["ID"]);
            
            odRdr.Close();
            
            int employeeNumber = 1;
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

            int rs = odCom1.ExecuteNonQuery();
            return rs > 0 ? employeeNumber : -1;
        }

        #endregion EmployeeNumber

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
            return command;
        }
        #endregion utils
    }
}