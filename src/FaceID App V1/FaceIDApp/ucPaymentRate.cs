using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class ucPaymentRate : UserControl
    {
        public ucPaymentRate()
        {
            InitializeComponent();
        }

        public void SetPaymentRate(PaymentRate paymentRate)
        {
            lblRegularHour.Text = paymentRate.NumberOfRegularHours.ToString();
            lblRegularRate.Text = paymentRate.RegularRate + "%";

            lblOvertime1.Text = paymentRate.NumberOfOvertime1.ToString();
            lblOvertime2.Text = paymentRate.NumberOfOvertime2.ToString();
            lblOvertime3.Text = paymentRate.NumberOfOvertime3.ToString();
            lblOvertime4.Text = paymentRate.NumberOfOvertime4.ToString();

            lblOverrate1.Text = paymentRate.OvertimeRate1 + "%";
            lblOverrate2.Text = paymentRate.OvertimeRate2 + "%";
            lblOverrate3.Text = paymentRate.OvertimeRate3 + "%";
            lblOverrate4.Text = paymentRate.OvertimeRate4 + "%";
        }
    }
}
