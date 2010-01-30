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

            new testEmployeeFunction().TestAddEmployee();

            //Application.Run(new testTerminalController());
            //Application.Run(new Test());
        }
    }
}
