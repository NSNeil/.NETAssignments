using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer.Utility;

namespace ENETCare.IMS.DatabaseAccessLayer
{
    public class DistrictRepository
    {
        public List<District> GetAll()
        {
            string sqlStr = "SELECT * FROM District";
            List<District> districts = new List<District>();
            DataTable dt = SQLHelper.Select(sqlStr).Tables[0];
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    districts.Add(new District
                    {
                        Name = dt.Rows[i]["District"].ToString()
                    });
                }
            }
            return districts;
        }
    }
}
