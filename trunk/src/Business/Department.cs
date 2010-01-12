using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FaceIDpp.Business
{
    public class Department : BaseData
    {
        public Department()
        {
            
        }

        public DataTable GetData()
        {
            DataTable dt = objData.GetDataTable("select * from Department");
            return dt;
        }
    }
}
