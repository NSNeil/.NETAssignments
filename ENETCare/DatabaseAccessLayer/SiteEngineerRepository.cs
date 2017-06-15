using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer.Utility;

namespace ENETCare.IMS.DatabaseAccessLayer
{
    public class SiteEngineerRepository
    {
        public SiteEngineer GetOne(string userName)
        {
            string sqlStr = "SELECT * FROM SiteEngineer INNER JOIN [User] " +
                            "ON [User].UserId = SiteEngineer.UserId WHERE [User].LoginName = @UserName";

            SqlParameter[] pars =
            {
                new SqlParameter("@UserName",SqlDbType.NChar), 
            };
            pars[0].Value = userName;
            DataTable dataTable = SQLHelper.Select(sqlStr, pars).Tables[0];
            int rowsCount = dataTable.Rows.Count;

            return new SiteEngineer
            {
                  SiteEngineerId = (int) dataTable.Rows[0]["SiteEngineerId"],
                  MaxCost = (decimal)dataTable.Rows[0]["MaxCost"],
                  MaxHours = (int)dataTable.Rows[0]["MaxHours"],
                  UserId = (int)dataTable.Rows[0]["UserId"],
                  District = (string)dataTable.Rows[0]["District"],
                  Name = (string)dataTable.Rows[0]["Name"],
            };
        }

        //methods for getting SiteEngineer List from Db
        public List<SiteEngineer> GetSiteEngineerList()
        {
            string sqlStr = "SELECT [SiteEngineerId], [Name] FROM [SiteEngineer] JOIN [User] ON [SiteEngineer].[UserId] = [User].[UserId]";
            DataTable accReturnData = SQLHelper.Select(sqlStr).Tables[0];
            return (ConvertRowEngineerToObject(accReturnData));

        }

        private List<SiteEngineer> ConvertRowEngineerToObject(DataTable dataTable)
        {
            int rowsCount = dataTable.Rows.Count;
            List<SiteEngineer> siteEngineers = new List<SiteEngineer>();
            if (rowsCount > 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    SiteEngineer siteEngineer = new SiteEngineer();
                    siteEngineer.SiteEngineerId = (int)dataTable.Rows[i]["SiteEngineerId"];
                    siteEngineer.Name = (string)dataTable.Rows[i]["Name"];
                    siteEngineers.Add(siteEngineer);
                }
            }

            return siteEngineers;
        }
    }
}
