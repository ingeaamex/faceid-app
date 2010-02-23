using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Rate : MarshalByRefObject
    {
        public Rate(double value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public Rate(double value)
        {
            this.Value = value;
            this.Name = value.ToString() + "%";
        }


        public double Value { get; set; }
        public String Name { get; set; }
    }
}
