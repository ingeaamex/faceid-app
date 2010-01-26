using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public class TerminalController : Form, ITerminalController
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        private delegate int CallBack(int total, int nDone);

        [DllImport("HDCP_Utils.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string HDCP_Base64Decode(string pInputInfo, ref uint pSizeInput);

        [DllImport("HwDevComm.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int HwDev_Execute(string pDevInfoBuf, int nDevInfoLen, 
                                               string pSendBuf, int nSendLen,
                                               ref IntPtr pRecvBuf, ref uint pRecvLen,
                                               CallBack pFuncTotalDone);

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
            //string cmd = "SetEmployee(id=\"" + employee.EmployeeNumber + "\" name=\"" + employee.FirstName + "\" calid=\"\" card_num=\"0Xffffffff\" authority=\"0X0\" check_type=\"face\" opendoor_type=\"face\"";
            string cmd = "SetEmployee(id=\"" + employee.EmployeeNumber + "\" name=\"" + employee.FirstName + "\" calid=\"\" card_num=\"0xffffffff\" authority=\"0X0\" check_type=\"face\" opendoor_type=\"face\"";

            //load face_data
            cmd += " face_data=\"" + employee.FaceData1 + "\"";
            cmd += " face_data=\"" + employee.FaceData2 + "\"";
            cmd += " face_data=\"" + employee.FaceData3 + "\"";
            cmd += " face_data=\"" + employee.FaceData4 + "\"";
            cmd += " face_data=\"" + employee.FaceData5 + "\"";
            cmd += " face_data=\"" + employee.FaceData6 + "\"";
            cmd += " face_data=\"" + employee.FaceData7 + "\"";
            cmd += " face_data=\"" + employee.FaceData8 + "\"";
            cmd += " face_data=\"" + employee.FaceData9 + "\"";
            cmd += " face_data=\"" + employee.FaceData10 + "\"";
            cmd += " face_data=\"" + employee.FaceData11 + "\"";
            cmd += " face_data=\"" + employee.FaceData12 + "\"";
            cmd += " face_data=\"" + employee.FaceData13 + "\"";
            cmd += " face_data=\"" + employee.FaceData14 + "\"";
            cmd += " face_data=\"" + employee.FaceData15 + "\"";
            cmd += " face_data=\"" + employee.FaceData16 + "\"";
            cmd += " face_data=\"" + employee.FaceData17 + "\"";
            cmd += " face_data=\"" + employee.FaceData18 + "\"";

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

        //Ex: GetEmployeeNumberList("Return(result=\"success\" total=\"100\" id=\"11\" id=\"109\"")
        //-> return {11, 109}
        private List<int> GetEmployeeList(IntPtr result)
        {
            return GetEmployeeNumberList(Marshal.PtrToStringAnsi(result));
        }

        private List<Int32> GetEmployeeNumberList(string result)
        {
            List<Int32> employeeNumberList = new List<Int32>();

            if (IsSuccess(result) == false)
            {
                throw new Exception(GetFailedReason(result));
            }
            else
            {
                int iFrom, iTo;
                string keyName = "id=\"";

                while ((iFrom = result.IndexOf(keyName)) > 0)
                {
                    iFrom += keyName.Length;
                    iTo = result.IndexOf("\"", iFrom);
                    
                    int employeeNumber = Convert.ToInt32(result.Substring(iFrom, iTo - iFrom));
                    employeeNumberList.Add(employeeNumber);
                    
                    result = result.Substring(iTo);
                }
            }

            return employeeNumberList;
        }

        //Ex: GetValue("Return(result=\"failed\" reason=\"FAILED REASON\")", "reason")
        //-> return "FAILED REASON"
        private string GetValue(string result, string keyName)
        {
            return GetValue(result, keyName, 1);
        }

        private string GetValue(IntPtr result, string keyName)
        {
            return GetValue(Marshal.PtrToStringAnsi(result), keyName);
        }

        private string GetValue(string result, string keyName, int index)
        {
            string value = "";

            keyName += "=\"";

            while(index > 0)
            {
                int iFrom = result.IndexOf(keyName);
                if (iFrom < 0)
                    return "";

                iFrom += keyName.Length;
                int iTo = result.IndexOf('"', iFrom);

                if (iFrom > 0 && iTo > iFrom)
                    value = result.Substring(iFrom, iTo - iFrom);

                result = result.Substring(iTo);

                index--;
            }

            return value;
        }

        private string GetValue(IntPtr result, string keyName, int index)
        {
            return GetValue(Marshal.PtrToStringAnsi(result), keyName, index);
        }

        private string GetFailedReason(IntPtr result)
        {
            return GetFailedReason(Marshal.PtrToStringAnsi(result));
        }

        private string GetFailedReason(string result)
        {
            return GetValue(result, "reason");
        }

        #region ITerminalControlller Members

        public List<AttendanceRecord> GetAttendanceRecord(Terminal terminal, DateTime dtFrom, DateTime dtTo)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetRecord(start_time=\"" + ConvertToDateTimeString(dtFrom) + "\" end_time=\"" + ConvertToDateTimeString(dtTo) + "\")";
            
            IntPtr result = IntPtr.Zero;
            HwDev_Execute(devInfo, command, ref result);

            List<AttendanceRecord> attRecordList = new List<AttendanceRecord>();
            string keyName = "time=\"";
            int iFrom, iTo;
            
            string resultString = Marshal.PtrToStringAnsi(result);
            while ((iFrom = resultString.IndexOf(keyName)) >= 0)
            {
                iTo = resultString.IndexOf(keyName, iFrom + 1);
                if(iTo < 0)
                    iTo = resultString.IndexOf(")", iFrom + 1);

                if (iTo < 0)
                    throw new Exception();

                string attString = resultString.Substring(iFrom, iTo - iFrom);

                AttendanceRecord attRecord = new AttendanceRecord();
                attRecord.Time = Convert.ToDateTime(GetValue(attString, "time"));
                attRecord.EmployeeNumber = Convert.ToInt32(GetValue(attString, "id"));

                attRecordList.Add(attRecord);

                resultString = resultString.Substring(iTo);
            }

            return attRecordList;
        }

        public bool UpdateEmployee(Terminal terminal, Employee employee)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = GetSetEmployeeCmdStr(employee);

            IntPtr result = IntPtr.Zero;
            HwDev_Execute(devInfo, command, ref result);

            //MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return IsSuccess(result);
        }

        public Employee GetEmployee(Terminal terminal, int employeeNumber)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetEmployee(id=" + employeeNumber + ")";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            if (IsSuccess(result))
            {
                Employee employee = new Employee();

                employee.EmployeeNumber = Convert.ToInt32(GetValue(result, "id"));
                employee.FirstName = GetValue(result, "name");

                employee.FaceData1 = GetValue(result, "face_data", 1);
                employee.FaceData2 = GetValue(result, "face_data", 2);
                employee.FaceData3 = GetValue(result, "face_data", 3);
                employee.FaceData4 = GetValue(result, "face_data", 4);
                employee.FaceData5 = GetValue(result, "face_data", 5);
                employee.FaceData6 = GetValue(result, "face_data", 6);
                employee.FaceData7 = GetValue(result, "face_data", 7);
                employee.FaceData8 = GetValue(result, "face_data", 8);
                employee.FaceData9 = GetValue(result, "face_data", 9);
                employee.FaceData10 = GetValue(result, "face_data", 10);
                employee.FaceData11 = GetValue(result, "face_data", 11);
                employee.FaceData12 = GetValue(result, "face_data", 12);
                employee.FaceData13 = GetValue(result, "face_data", 13);
                employee.FaceData14 = GetValue(result, "face_data", 14);
                employee.FaceData15 = GetValue(result, "face_data", 15);
                employee.FaceData16 = GetValue(result, "face_data", 16);
                employee.FaceData17 = GetValue(result, "face_data", 17);
                employee.FaceData18 = GetValue(result, "face_data", 18);

                //string[] faceData = new string[]
                //{
                //    employee.FaceData1,
                //    employee.FaceData2,
                //    employee.FaceData3,
                //    employee.FaceData4,
                //    employee.FaceData5,
                //    employee.FaceData6,
                //    employee.FaceData7,
                //    employee.FaceData8,
                //    employee.FaceData9,
                //    employee.FaceData10,
                //    employee.FaceData11,
                //    employee.FaceData12,
                //    employee.FaceData13,
                //    employee.FaceData14,
                //    employee.FaceData15,
                //    employee.FaceData16,
                //    employee.FaceData17,
                //    employee.FaceData18
                //};

                //string resultString = Marshal.PtrToStringAnsi(result);

                //int iFrom, iTo, index = 0;
                //string keyName = "face_data=\"";
                //while ((iFrom = resultString.IndexOf(keyName)) >= 0 && index < faceData.Length)
                //{
                //    iFrom += keyName.Length;
                //    iTo = resultString.IndexOf("\"", iFrom);

                //    faceData[index] = resultString.Substring(iFrom, iTo - iFrom);

                //    resultString = resultString.Substring(iTo);
                //    index++;
                //}

                return employee;
            }
            else
            {
                throw new Exception(GetFailedReason(result));
            }
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
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetEmployeeID()";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            if (IsSuccess(result))
            {
                List<int> employeeNumberList = GetEmployeeList(result);
                List<Employee> employeeList = new List<Employee>();

                foreach (int employeeNumber in employeeNumberList)
                {
                    employeeList.Add(GetEmployee(terminal, employeeNumber));
                }

                return employeeList;
            }
            else
            {
                throw new Exception(GetFailedReason(result));
            }
        }

        public bool RemoveEmployee(Terminal terminal, Employee employee)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "DeleteEmployee(id=\"" + employee.EmployeeNumber + "\")";
            IntPtr result = IntPtr.Zero;

            HwDev_Execute(devInfo, command, ref result);

            return IsSuccess(result);
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
