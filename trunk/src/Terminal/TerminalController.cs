using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace FaceIDAppVBEta
{
    public class TerminalController : Form, ITerminalController
    {
        [DllImport("HDCP_Utils.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string HDCP_Base64Decode(string pInputInfo, ref uint pSizeInput);

        [DllImport("HwDevComm.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int HwDev_Execute(string pDevInfoBuf, int nDevInfoLen, 
                                               string pSendBuf, int nSendLen,
                                               ref IntPtr pRecvBuf, ref uint pRecvLen,
                                               CallBack pFuncTotalDone);

        private delegate int CallBack(int total, int nDone);

        private int HwDev_Execute(string deviceInfo, string command, ref IntPtr result)
        {
            uint resultLength = 0;

            return HwDev_Execute(deviceInfo, deviceInfo.Length, command, command.Length, ref result, ref resultLength, null);
        }

        private string GetDeviceInfoStr(Terminal terminal)
        {
            return "DeviceInfo( dev_id = \"" + terminal.ID + "\" dev_type = \"HW_HDCP\" comm_type = \"ip\" ip_address = \"" + terminal.IPAddress + "\" )";
        }

        private string GetSetEmployeeCmdStr(Employee employee)
        {
            string cmd = "SetEmployee(id=\"" + employee.PayrollNumber + "\" name=\"" + employee.FirstName + "\" calid=\"\" card_num=\"0Xffffffff\" authority=\"0X0\" check_type=\"face\" opendoor_type=\"face\"";

            //load face_data

            cmd += ")";

            return cmd;
        }

        private string ConvertToDateTimeString(DateTime dt)
        {
            return dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.Hour + ":" + dt.Minute + ":" + dt.Second;
        }

        private bool IsSuccess(string result)
        {
            return result.ToLower().IndexOf("success") > 0;
        }

        private bool IsSuccess(IntPtr result)
        {
            return IsSuccess(Marshal.PtrToStringAnsi(result));
        }

        #region ITerminalControlller Members

        public List<AttendanceRecord> GetAttendanceRecord(Terminal terminal, DateTime dtFrom, DateTime dtTo)
        {
            string devInfo = GetDeviceInfoStr(terminal);

            string command = "GetRecord(start_time=\"" + ConvertToDateTimeString(dtFrom) + "\" end_time=\"" + ConvertToDateTimeString(dtTo) + "\")";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return null;
        }

        public bool UpdateEmployee(Terminal terminal, Employee employee)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = GetSetEmployeeCmdStr(employee);

            IntPtr result = IntPtr.Zero;
            HwDev_Execute(devInfo, command, ref result);

            return IsSuccess(result);
        }

        public Employee GetEmployee(Terminal terminal, int employeeID)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetEmployee(id=\"" + employeeID + "\")";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return null;
        }

        public bool DeleteAttendanceRecord(Terminal terminal)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "DeleteRecord()";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            return IsSuccess(result);
        }

        public List<Employee> GetAllEmployee(Terminal terminal)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEmployee(Terminal terminal, Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool IsTerminalConnected(Terminal terminal)
        {
            System.Net.NetworkInformation.Ping pinger = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingReply = pinger.Send(terminal.IPAddress);

            return pingReply.Status == System.Net.NetworkInformation.IPStatus.Success;
        }

        #endregion
    }
}
