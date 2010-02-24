using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FaceIDAppVBEta;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.UnitTest;

namespace FaceIDApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new frmAddUpdateWorkingCalendar());
            //Application.Run(new frmAddUpdateAttendanceRecord(DateTime.Now, 134));

            //Terminal terminal = new Terminal();
            //terminal.IPAddress = "10.0.0.101";
            //Employee employee = new Employee();

            //employee.EmployeeNumber = 12;
            //employee.FirstName = "Anh";
            //employee.FaceData1 = "=";
            //employee.FaceData2 = "=";
            //employee.FaceData3 = "=";
            //employee.FaceData4 = "=";
            //employee.FaceData5 = "=";
            //employee.FaceData6 = "=";
            //employee.FaceData7 = "=";
            //employee.FaceData8 = "=";
            //employee.FaceData9 = "=";
            //employee.FaceData10 = "=";
            //employee.FaceData11 = "=";
            //employee.FaceData12 = "=";
            //employee.FaceData13 = "=";
            //employee.FaceData14 = "=";
            //employee.FaceData15 = "=";
            //employee.FaceData16 = "=";
            //employee.FaceData17 = "=";
            //employee.FaceData18 = "=";

            //new TerminalController().UpdateEmployee(terminal, employee);

            //new testAttendanceReportFunction().TestGetAttendanceReportByAttendanceRecord();

            //Application.Run(new frmPreviewWorkingCalendar(293));
            //Application.Run(new Test());
        }
    }
}
