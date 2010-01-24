using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;
using System.Windows.Forms;

namespace FaceIDAppVBEta.UnitTest
{
    class testTerminalController : Form
    {
        IDataController _dtCtrl = LocalDataController.Instance;
        ITerminalController _terCtrl = new TerminalController();
        
        private Terminal ter = new Terminal();
        private TextBox textBox1;
        private Button button1;
        private Employee emp;

        public testTerminalController()
        {
            InitializeComponent();
        }

        private void SetUp()
        {
            ter.IPAddress = "10.0.0.101";
            ter.Name = "Ter1";
            //ter.ID = _dtCtrl.AddTerminal(ter);

            Department dep = _dtCtrl.GetDepartmentList()[0];
            Company com = _dtCtrl.GetCompany(dep.CompanyID);

            emp = _dtCtrl.GetEmployeeList(com.ID, dep.ID)[0];
        }

        private void CleanUp()
        {
            _dtCtrl.DeleteTerminal(ter.ID);
        }

        private void AddText(String text)
        {
            textBox1.Text += text + "\r\n";

            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        public void TestGetAttendanceRecord()
        {
            AddText("TestGetAttendanceRecord");
            AddText("Expected :" + "Greater than 0");
            AddText("Got: "+ _terCtrl.GetAttendanceRecord(ter, DateTime.Today.AddYears(-1), DateTime.Today).Count);
        }

        public void TestDeleteAttendanceRecord()
        {
            AddText("TestDeleteAttendanceRecord");
            AddText("Expected :" + "true");
            AddText("Got: " + _terCtrl.DeleteAttendanceRecord(ter));

            AddText("Expected :" + "0");
            AddText("Got: " + _terCtrl.GetAttendanceRecord(ter, DateTime.Today.AddYears(-1), DateTime.Today).Count);
        }

        public void TestUpdateEmployee()
        {
            AddText("TestUpdateEmployee");
            AddText("Expected :" + "true");
            AddText("Got: " + _terCtrl.UpdateEmployee(ter, emp));

            AddText("Expected :" + emp.FirstName);
            AddText("Got: " + _terCtrl.GetEmployee(ter, emp.EmployeeNumber).FirstName);
        }

        public void TestGetEmployee()
        {
            AddText("TestGetEmployee");
            AddText("Expected :" + emp.FirstName);
            AddText("Got: " + _terCtrl.GetEmployee(ter, emp.EmployeeNumber).FirstName);
        }

        public void TestGetAllEmployee()
        {
            AddText("TestGetAllEmployee");
            AddText("Expected :" + "Greater than 0");
            AddText("Got: " + _terCtrl.GetAllEmployee(ter).Count);
        }

        public void TestRemoveEmployee()
        {
            AddText("TestRemoveEmployee");
            AddText("Expected :" + "true");
            AddText("Got: " + _terCtrl.RemoveEmployee(ter, emp));

            AddText("Expected :" + "null");
            AddText("Got: " + _terCtrl.GetEmployee(ter, emp.EmployeeNumber));
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(418, 292);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(418, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testTerminalController
            // 
            this.ClientSize = new System.Drawing.Size(456, 380);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "testTerminalController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void Test()
        {
            try
            {
                SetUp();
                textBox1.Text = "";

                TestGetAttendanceRecord();
                //TestDeleteAttendanceRecord();
                TestUpdateEmployee();
                //TestRemoveEmployee();
                TestGetEmployee();
                TestGetAllEmployee();

                CleanUp();
            }
            catch (Exception ex)
            {
                AddText(ex.Message);
            }
        }
    }
}
