using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace FaceIDApp
{
    class Test
    {
        public delegate int Functotaldonetp(int total, int nDone);
        int FunctotaldonetpMethod(int total, int nDone)
        {
            return 1;
        }
        [DllImport("HwDevComm.dll")]
        public static extern int HwDev_Execute(string pDevInfoBuf, int nDevInfoLen, string pSendBuf, int nSendLen, ref string pRecvBuf, ref int pRecvLen, Functotaldonetp pFuncTotalDone);
        int total = int.MinValue;
        int nDone = int.MinValue;
        public Test()
        {
            Functotaldonetp functotaldonetp = new Functotaldonetp(FunctotaldonetpMethod);

            string pDevInfoBuf = "DeviceInfo( dev_id = \"1\" comm_type = \"ip\" ip_adress = \"192.168.1.33\" )";
            int nDevInfoLen = pDevInfoBuf.Length;
            string pSendBuf = "InitDevice()";
            int nSendLen = pSendBuf.Length;
            string pRecvBuf = null;
            int pRecvLen = 0;

            int result = HwDev_Execute(pDevInfoBuf, nDevInfoLen, pSendBuf, nSendLen, ref  pRecvBuf, ref pRecvLen, functotaldonetp);
        }
    }
}
