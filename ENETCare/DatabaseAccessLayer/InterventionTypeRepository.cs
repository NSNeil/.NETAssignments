using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer.Utility;

namespace ENETCare.IMS.DatabaseAccessLayer
{
    public class InterventionTypeRepository 
    {

        public List<InterventionType> GetAll(string whereClause)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT *");
            sqlStr.Append(" FROM InterventionType ");
            if (whereClause.Trim() != "")
            {
                sqlStr.Append(" WHERE " + whereClause);
            }

            List<InterventionType> models = new List<InterventionType>();
            DataTable dataTable = SQLHelper.Select(sqlStr.ToString()).Tables[0];
            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    InterventionType interventionType = new InterventionType();
                    if (dataTable.Rows[n]["InterventionTypeId"].ToString() != "")
                    {
                        interventionType.InterventionTypeId = int.Parse(dataTable.Rows[n]["InterventionTypeId"].ToString());
                    }
                    if (dataTable.Rows[n]["Name"].ToString() != "")
                    {
                        interventionType.Name = dataTable.Rows[n]["Name"].ToString();
                    }
                    if (dataTable.Rows[n]["Cost"].ToString() != "")
                    {
                        interventionType.DefaultCost = decimal.Parse(dataTable.Rows[n]["Cost"].ToString());
                    }
                    if (dataTable.Rows[n]["LabourHours"].ToString() != "")
                    {
                        interventionType.DefaultLabourHours = int.Parse(dataTable.Rows[n]["LabourHours"].ToString());
                    }
                    models.Add(interventionType);
                }
            }
            return models;
        }
    }
}
