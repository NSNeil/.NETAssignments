using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.IMS.DatabaseAccessLayer.Utility
{
    public abstract class SQLHelper
    {
        public static string connectionString = PublicConstants.ConnectionString;
        public SQLHelper()
        {

        }
        
        /// <summary>
        /// Use this to execute the SELECT statement
        /// </summary>
        /// <param name="sqlString">The SELECT sql string</param>
        /// <param name="cmdParms">Parameters for the sql string</param>
        /// <returns>The returned DataSet of the sql command</returns>
        public static DataSet Select(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, sqlString, cmdParms);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        dataAdapter.Fill(dataSet);
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return dataSet;
                }
            }
        }

        /// <summary>
        /// Please use this method for INSERT, UPDATE SQL 
        /// </summary>
        /// <param name="sql">The INSERT SQL string</param>
        /// <param name="pars">The parameters for the SQL</param>
        /// <returns>Number of rows affected</returns>
        public static int Execute(string sql, SqlParameter[] pars)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, sql, pars);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Add the parameters to the command and some fail-safe examination
        /// </summary>
        /// <param name="cmd">The SQL command</param>
        /// <param name="conn">DB connection</param>
        /// <param name="cmdString">The SQL string</param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string cmdString, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdString;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if (/*(parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&*/
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
