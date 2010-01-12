using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FaceIDpp.Business
{
    public class Company : BaseData
    {
        public Company()
        { 
            
        }

        public DataTable GetData()
        {
            //objData.connection.Open();
            DataTable dt = objData.GetDataTable("select * from Company");
            //objData.connection.Close();
            return dt;
        }
    }
}
