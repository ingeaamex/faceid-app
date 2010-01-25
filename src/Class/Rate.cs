using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Rate
    {
        public Rate(double value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public double Value { get; set; }
        public String Name { get; set; }
    }
}
