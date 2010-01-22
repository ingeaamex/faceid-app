using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace FaceIDAppVBEta
{
    public class TerminalController : Form, ITerminalControlller
    {
        [DllImport("HDCP_Utils.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern string HDCP_Base64Decode(string pInputInfo, ref uint pSizeInput);
        [DllImport("HwDevComm.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int HwDev_Execute(string pDevInfoBuf, int nDevInfoLen, 
                                               string pSendBuf, int nSendLen,
                                               ref IntPtr pRecvBuf, ref uint pRecvLen,
                                               CallBack pFuncTotalDone);

        private delegate int CallBack(int total, int nDone);

        private int HwDev_Execute(string deviceInfo, string command, ref IntPtr result, ref uint resultLength, CallBack function)
        {
            return HwDev_Execute(deviceInfo, deviceInfo.Length, command, command.Length, ref result, ref resultLength, function);
        }

        private string GetDeviceInfoStr(Terminal terminal)
        {
            return "DeviceInfo( dev_id = \"" + terminal.ID + "\" dev_type = \"HW_HDCP\" comm_type = \"ip\" ip_address = \"" + terminal.IPAddress + "\" )";
        }

        public List<AttendanceRecord> GetAttendanceRecord(Terminal terminal)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetRecord()";
            IntPtr result = IntPtr.Zero;
            uint resLen = 0;

            HwDev_Execute(devInfo, command, ref result, ref resLen, null);

            MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return null;
        }

        public bool AddEmployee(Terminal terminal, Employee employee)
        {
            string employeeData = "id=\"2\" name=\"aaa\" calid=\"123\" card_num=\"0Xffffffff\" authority=\"0X0\" check_type=\"face\"opendoor_type=\"face\")";

            string cmdStr = "SetEmployee(";
            cmdStr = cmdStr + employeeData;

            string devInfo = GetDeviceInfoStr(terminal);
            string command = "SetEmployee(id=\"1\" name=\"minh2\" calid=\"\" card_num=\"0Xffffffff\" authority=\"0X0\" check_type=\"face\" opendoor_type=\"face\")";

            IntPtr result = IntPtr.Zero;
            uint resLen = 0;

            HwDev_Execute(devInfo, command, ref result, ref resLen, null);

            MessageBox.Show(command.Length.ToString());
            MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return true;
        }

        public bool GetEmployee(Terminal terminal, int employeeID)
        {
            string devInfo = GetDeviceInfoStr(terminal);
            string command = "GetEmployee(id=\"" + employeeID + "\")";
            IntPtr result = IntPtr.Zero;
            uint resLen = 0;

            HwDev_Execute(devInfo, command, ref result, ref resLen, null);

            MessageBox.Show(Marshal.PtrToStringAnsi(result));

            return true;
        }

        public void SavePic(string strPath, string strPicName, string strResult)
        {
            const string strPhoto = "photo=\"";
            int nStart = strResult.IndexOf(strPhoto) + strPhoto.Length;
            int nCount = strResult.Length - nStart;
            string strPhotoInfo = strResult.Substring(nStart);
            int nEnd = strPhotoInfo.IndexOf("\"");
            //strPhotoInfo = strPhotoInfo.Substring(0, nEnd);
            strPhotoInfo = strPhotoInfo.Replace('<', '/');
            string strPathandName;
            strPathandName = strPath + "\\" + strPicName;

            byte[] bs = Convert.FromBase64String(strPhotoInfo);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bs);
            Bitmap b = new Bitmap(memoryStream);
            b.Save(strPathandName, System.Drawing.Imaging.ImageFormat.Jpeg);
            memoryStream.Close();
        }
    }
}
