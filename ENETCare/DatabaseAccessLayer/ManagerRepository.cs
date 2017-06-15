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
    public class ManagerRepository
    {
        public Manager GetOne(string userName)
        {
            string sqlStr = "SELECT * FROM Manager INNER JOIN [User] " +
                            "ON [User].UserId = Manager.UserId WHERE [User].LoginName = @UserName";

            SqlParameter[] pars =
            {
                new SqlParameter("@UserName", SqlDbType.NChar),
            };

            pars[0].Value = userName;
            DataTable dataTable = SQLHelper.Select(sqlStr, pars).Tables[0];
            int rowsCount = dataTable.Rows.Count;
            Manager manager = new Manager();

            manager.ManagerId = (int) dataTable.Rows[0]["ManagerId"];
            manager.MaxCost = (decimal)dataTable.Rows[0]["MaxCost"];
            manager.MaxHours = (int)dataTable.Rows[0]["MaxHours"];
            manager.UserId = (int) dataTable.Rows[0]["UserId"];
            manager.District = (string) dataTable.Rows[0]["District"];
            manager.Name = (string) dataTable.Rows[0]["Name"];
            
            return manager;
        }


        //Methods for accountant to get list of managers from db 
        public List<Manager> GetManagerListFromDb()
        {
            string sqlStr = "SELECT [ManagerId], [Name] FROM [Manager] JOIN [User] ON [Manager].[UserId] = [User].[UserId]";
            DataTable dataTable = SQLHelper.Select(sqlStr).Tables[0];
            return (ConvertRowManagerToObject(dataTable)); 


        }

        private List<Manager> ConvertRowManagerToObject(DataTable dataTable)
        {
            int rowsCount = dataTable.Rows.Count;
            List<Manager> managers = new List<Manager>();
            if (rowsCount > 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    Manager manager = new Manager();
                    manager.ManagerId = (int)dataTable.Rows[i]["ManagerId"];
                    manager.Name = (string)dataTable.Rows[i]["Name"];
                    managers.Add(manager);
                }
            }

            return managers;
        }
    }
}
