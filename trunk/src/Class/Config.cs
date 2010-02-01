using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Config : MarshalByRefObject
    {
        public static readonly DateTime MinDate = new DateTime(1899, 12, 30);
        public string DatabasePath { get; set; }
    }
}
