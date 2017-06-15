using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer.Utility;

namespace ENETCare.IMS.DatabaseAccessLayer
{
    public class ClientRepository
    {
        public int Insert(Client client)
        {
            string sql =
                "INSERT INTO Client " +
                "VALUES (@District, @Name, @Address)";
            SqlParameter[] pars =
             {
                new SqlParameter("@District",SqlDbType.NChar),
                new SqlParameter("@Name",SqlDbType.NChar),
                new SqlParameter("@Address",SqlDbType.NChar)
            };

            pars[0].Value = client.District;
            pars[1].Value = client.Name;
            pars[2].Value = client.Address;

            return SQLHelper.Execute(sql, pars);
        }
        
        public List<Client> GetList(string district)
        {
            StringBuilder sb = new StringBuilder("SELECT * FROM Client");
            List<SqlParameter> pars = new List<SqlParameter>();
            DataTable clientTable = null;

            if (district != "")
            {
                sb.Append(" WHERE District = @District");
                pars.Add(new SqlParameter("@District", SqlDbType.NChar));
                pars[0].Value = district;
                clientTable = SQLHelper.Select(sb.ToString(),pars.ToArray()).Tables[0];
            }
            else
            {
                clientTable = SQLHelper.Select(sb.ToString()).Tables[0];
            }

            int rowCount = clientTable.Rows.Count;
            List<Client> clients = new List<Client>();
            if (rowCount>0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Client client = new Client
                    {
                        ClientId = (int)clientTable.Rows[i]["ClientId"],
                        District = (string)clientTable.Rows[i]["District"],
                        Name = (string)clientTable.Rows[i]["Name"],
                        Address = (string)clientTable.Rows[i]["Address"]
                    };
                    clients.Add(client);
                }
            }
            return clients;
        }
        
    }
}