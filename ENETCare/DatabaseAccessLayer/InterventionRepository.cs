using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer.Utility;

namespace ENETCare.IMS.DatabaseAccessLayer
{
    public class InterventionRepository 
    {
        public int Insert(Intervention intervention)
        {
           string sql =
                "INSERT INTO Intervention(InterventionTypeId, ProposedBy, ClientId, LabourHours, Cost, DateToPerform, State, ApprovedBy, Note, Life, MostRecentVisitDate, District) " +
                "VALUES (@InterventionTypeId, @ProposedBy, @ClientId, @LabourHours, @Cost, @DateToPerform, @State, @ApprovedBy, @Note, @Life, @MostRecentVisitDate, @District)";

            SqlParameter[] pars =
            {
                new SqlParameter("@InterventionTypeId",SqlDbType.Int),
                new SqlParameter("@ProposedBy",SqlDbType.Int),
                new SqlParameter("@ClientId",SqlDbType.Int),
                new SqlParameter("@LabourHours",SqlDbType.Int),
                new SqlParameter("@Cost",SqlDbType.Decimal),
                new SqlParameter("@DateToPerform",SqlDbType.NChar),
                new SqlParameter("@State",SqlDbType.NChar),
                new SqlParameter("@ApprovedBy",SqlDbType.Int),
                new SqlParameter("@Note",SqlDbType.NChar),
                new SqlParameter("@Life",SqlDbType.Float),
                new SqlParameter("@MostRecentVisitDate",SqlDbType.NChar),
                new SqlParameter("@District",SqlDbType.NChar),
            };

            pars[0].Value = intervention.InterventionType.InterventionTypeId;
            pars[1].Value = intervention.ProposedBy.SiteEngineerId;
            pars[2].Value = intervention.Client.ClientId;
            pars[3].Value = intervention.LabourHours;
            pars[4].Value = intervention.Cost;
            pars[5].Value = intervention.DateToPerform;
            pars[6].Value = intervention.State;
            pars[7].Value = null;
            pars[8].Value = intervention.Note;
            pars[9].Value = -1;
            pars[10].Value = intervention.MostRecentVisitDate;
            pars[11].Value = intervention.District;

            return SQLHelper.Execute(sql, pars);
        }

        /// <summary>
        /// For site engineer to update intervention information in the view all intervention page
        /// </summary>
        /// <param name="approverId"></param>
        /// <param name="interventionId"></param>
        /// <param name="state"></param>
        /// <param name="note"></param>
        /// <param name="life"></param>
        /// <param name="mostRecentVisitDate"></param>
        /// <returns></returns>
        public int UpdateInterventionInfo(int approverId, int interventionId, string state, string note, float life, string mostRecentVisitDate)
        {
            StringBuilder sb = new StringBuilder("UPDATE Intervention SET Note = @Note, Life = @Life, State = @State, MostRecentVisitDate = @MostRecentVisitDate");
            List<SqlParameter> pars = new List<SqlParameter>
            {
                new SqlParameter("@Note", SqlDbType.NChar),
                new SqlParameter("@Life", SqlDbType.NChar),
                new SqlParameter("@MostRecentVisitDate", SqlDbType.NChar),
                new SqlParameter("@State", SqlDbType.NChar),
                new SqlParameter("@InterventionId", SqlDbType.Int)
            };

            pars[0].Value = note;
            pars[1].Value = life;
            pars[2].Value = mostRecentVisitDate;
            pars[3].Value = state;
            pars[4].Value = interventionId;
            
            if (approverId != -1)
            {
                sb.Append(",ApprovedBy = @ApprovedBy");
                pars.Add(new SqlParameter("@ApprovedBy", SqlDbType.Int));
                pars[5].Value = approverId;
            }
            
            sb.Append(" WHERE InterventionId = @InterventionId");

            return SQLHelper.Execute(sb.ToString(), pars.ToArray());
        }

        /// <summary>
        /// Get a list of interventions of the current user
        /// </summary>
        /// <returns></returns>
        public List<Intervention> GetList()
        {
            string sqlStr = "SELECT [SEName].Name AS [Proposed By], [InterventionType].Name " +
                            "AS [Intervention Type]," +
                            " [User].Name AS [Approved By], [Client].Name AS [Client], Intervention.* FROM Intervention INNER JOIN" +
                            " (SELECT [User].Name, [SiteEngineer].SiteEngineerId, [SiteEngineer].District " +
                            "FROM [User] INNER JOIN " +
                            "SiteEngineer ON [User].UserId = [SiteEngineer].UserId WHERE [User].UserId = " +
                            "@UserId) AS [SEName] ON " +
                            "[SEName].SiteEngineerId = Intervention.ProposedBy INNER JOIN [InterventionType] " +
                            "ON [InterventionType].InterventionTypeId = Intervention.InterventionTypeId " +
                            "LEFT JOIN [User] ON [User].UserId = Intervention.ApprovedBy INNER JOIN [Client] " +
                            "ON [Client].ClientId = Intervention.ClientId AND [Intervention].[State] != 'Cancelled'";
            SqlParameter[] pars =
            {
                new SqlParameter("@UserId", SqlDbType.Int)
            };
            pars[0].Value = ENETCareGlobal.CurrentUser.UserId;
            DataTable dataTable = SQLHelper.Select(sqlStr, pars).Tables[0];
            return ConvertToList(dataTable);
        }

        /// <summary>
        /// Get a list for viewing all interventions of engineer to view a specific only
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        public List<Intervention> GetList(string district)
        {
            string sqlStr = "SELECT [SEName].Name AS [Proposed By]," +
                            "[InterventionType].Name AS [Intervention Type], " +
                            "[User].Name AS [Approved By], [Client].Name AS [Client], Intervention.* " +
                            "FROM Intervention INNER JOIN (SELECT [User].Name, [SiteEngineer].SiteEngineerId, " +
                            "[SiteEngineer].District " +
                            "FROM [User] INNER JOIN SiteEngineer ON [User].UserId = [SiteEngineer].UserId " +
                            ") AS [SEName] ON " +
                            "[SEName].SiteEngineerId = Intervention.ProposedBy LEFT JOIN" +
                            " [InterventionType] ON [InterventionType].InterventionTypeId = Intervention.InterventionTypeId " +
                            "LEFT JOIN [User] ON [User].UserId = Intervention.ApprovedBy LEFT JOIN " +
                            "[Client] ON [Client].ClientId = Intervention.ClientId WHERE [Intervention].District = @District " +
                            "AND [Intervention].[State] != 'Cancelled'";
            SqlParameter[] pars =
            {
                new SqlParameter("@District", SqlDbType.NChar)
            };
            pars[0].Value = district;
            DataTable dt = SQLHelper.Select(sqlStr, pars).Tables[0];
            return ConvertToList(dt);
        }

        /// <summary>
        /// Get a list of approvable interventions for the manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public List<Intervention> GetList(Manager manager)
        {
            string sqlStr = "SELECT [SEName].Name AS [Proposed By]," +
                            "[InterventionType].Name AS [Intervention Type], " +
                            "[User].Name AS [Approved By], [Client].Name AS [Client], Intervention.* " +
                            "FROM Intervention INNER JOIN (SELECT [User].Name, [SiteEngineer].SiteEngineerId, " +
                            "[SiteEngineer].District " +
                            "FROM [User] INNER JOIN SiteEngineer ON [User].UserId = [SiteEngineer].UserId " +
                            ") AS [SEName] ON " +
                            "[SEName].SiteEngineerId = Intervention.ProposedBy LEFT JOIN" +
                            " [InterventionType] ON [InterventionType].InterventionTypeId = Intervention.InterventionTypeId " +
                            "LEFT JOIN [User] ON [User].UserId = Intervention.ApprovedBy LEFT JOIN " +
                            "[Client] ON [Client].ClientId = Intervention.ClientId WHERE [Intervention].District = @District " +
                            "AND [Intervention].[State] = 'Proposed' AND [Intervention].Cost <= @Cost AND" +
                            "[Intervention].LabourHours <= @LabourHours";
            SqlParameter[] pars =
            {
                new SqlParameter("@District", SqlDbType.NChar),
                new SqlParameter("@Cost", SqlDbType.NChar),
                new SqlParameter("@LabourHours", SqlDbType.NChar)

            };
            pars[0].Value = manager.District;
            pars[1].Value = manager.MaxCost;
            pars[2].Value = manager.MaxHours;

            DataTable dt = SQLHelper.Select(sqlStr, pars).Tables[0];
            return ConvertToList(dt);
        }

        /// <summary>
        /// For manager to approve intervention
        /// </summary>
        /// <param name="interventionId"></param>
        public int ApproveIntervention(int interventionId)
        {
            StringBuilder sb = new StringBuilder("UPDATE Intervention SET State = 'Approved', " +
                                                 "ApprovedBy = @ApprovedBy WHERE InterventionId = @InterventionId");
            List<SqlParameter> pars = new List<SqlParameter>
            {
                new SqlParameter("@ApprovedBy", SqlDbType.Int),
                new SqlParameter("@InterventionId", SqlDbType.Int)
            };

            pars[0].Value = ENETCareGlobal.CurrentUser.UserId;
            pars[1].Value = interventionId;

            return SQLHelper.Execute(sb.ToString(), pars.ToArray());
        }

        /// <summary>
        /// Get a list for viewing the associated interventions of a certain client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public List<Intervention> GetList(int clientId)
        {
            if (clientId != -1)
            {
                string sqlStr = "SELECT [SEName].Name AS [Proposed By]," +
                                "[InterventionType].Name AS [Intervention Type], " +
                                "[User].Name AS [Approved By], [Client].Name AS [Client], Intervention.* " +
                                "FROM Intervention INNER JOIN (SELECT [User].Name, [SiteEngineer].SiteEngineerId, " +
                                "[SiteEngineer].District " +
                                "FROM [User] INNER JOIN SiteEngineer ON [User].UserId = [SiteEngineer].UserId " +
                                ") AS [SEName] ON " +
                                "[SEName].SiteEngineerId = Intervention.ProposedBy LEFT JOIN" +
                                " [InterventionType] ON [InterventionType].InterventionTypeId = Intervention.InterventionTypeId " +
                                "LEFT JOIN [User] ON [User].UserId = Intervention.ApprovedBy LEFT JOIN " +
                                "[Client] ON [Client].ClientId = Intervention.ClientId WHERE [Intervention].ClientId = @ClientId " +
                                "AND [Intervention].[State] != 'Cancelled'";
                SqlParameter[] pars =
                {
                    new SqlParameter("@ClientId", SqlDbType.Int)
                };
                pars[0].Value = clientId;
                DataTable dt = SQLHelper.Select(sqlStr, pars).Tables[0];
                return ConvertToList(dt);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get a list of all interventions for the current district for Engineer for the GridView of View All Interventions
        /// </summary>
        /// <returns></returns>
        /// 
        //SQL Queries for Accountant


        public List<Intervention> GetListAcc()
        {
            string sqlStr = "SELECT [InterventionId], [ProposedBy], [LabourHours], [Cost], [DateToPerform]," +
                "[State], [Intervention].[District] AS [InterventionDistrict], [Name] From[Intervention] JOIN[SiteEngineer] ON" +
              "[ProposedBy] = [SiteEngineerId] JOIN[User] ON[SiteEngineer].[UserId] = [User].[UserId]";
            DataTable accReturnData = SQLHelper.Select(sqlStr).Tables[0];
            return accConvertToList(accReturnData); 
        }



        private List<Intervention> accConvertToList(DataTable dataTable)
        {
            List<Intervention> interventions = new List<Intervention>();

            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    State state = (State) Enum.Parse(typeof(State), dataTable.Rows[i]["State"].ToString());
                    Intervention intervention = new Intervention();
                    intervention.District = (string)dataTable.Rows[i]["InterventionDistrict"];
                    intervention.DateToPerform = (string)dataTable.Rows[i]["DateToPerform"];
                    intervention.ProposedBy = new SiteEngineer
                    {
                        SiteEngineerId = (int)dataTable.Rows[i]["ProposedBy"],
                        Name = (string)dataTable.Rows[i]["Name"],
                    };
                    intervention.LabourHours = (int)dataTable.Rows[i]["LabourHours"];
                    intervention.Cost = (decimal)dataTable.Rows[i]["Cost"];
                    intervention.State = state;
                    interventions.Add(intervention);
                }
            }

            return interventions;
        }

        private List<Intervention> ConvertToList(DataTable dataTable)
        {
            List<Intervention> interventions = new List<Intervention>();

            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (dataTable.Rows[i]["ApprovedBy"] == DBNull.Value)
                    {
                        dataTable.Rows[i]["ApprovedBy"] = -1;
                        dataTable.Rows[i]["Approved By"] = "";
                    }
                    State state;
                    State.TryParse((string)dataTable.Rows[i]["State"], out state);
                    Intervention intervention = new Intervention();
                    intervention.InterventionId = (int)dataTable.Rows[i]["InterventionId"];
                    intervention.ApprovedBy = new User
                    {
                        UserId = (int)dataTable.Rows[i]["ApprovedBy"],
                        Name = (string)dataTable.Rows[i]["Approved By"]
                    };
                    intervention.ProposedBy = new SiteEngineer
                    {
                        SiteEngineerId = (int)dataTable.Rows[i]["ProposedBy"],
                        Name = (string)dataTable.Rows[i]["Proposed By"],
                        District = (string)dataTable.Rows[i]["District"]
                    };
                    intervention.Client = new Client
                    {
                        ClientId = (int)dataTable.Rows[i]["ClientId"],
                        Name = (string)dataTable.Rows[i]["Client"]
                    };
                    intervention.Cost = (decimal)dataTable.Rows[i]["Cost"];
                    intervention.DateToPerform = (string)dataTable.Rows[i]["DateToPerform"];
                    intervention.InterventionType = new InterventionType
                    {
                        InterventionTypeId = (int)dataTable.Rows[i]["InterventionTypeId"],
                        Name = (string)dataTable.Rows[i]["Intervention Type"]
                    };
                    intervention.LabourHours = (int)dataTable.Rows[i]["LabourHours"];
                    intervention.MostRecentVisitDate = (string)dataTable.Rows[i]["MostRecentVisitDate"];
                    intervention.Note = (string)dataTable.Rows[i]["Note"];
                    intervention.State = state;
                    if (dataTable.Rows[i]["Life"] == DBNull.Value)
                    {
                        intervention.Life = -1;
                    }
                    else
                    {
                        intervention.Life = (double)dataTable.Rows[i]["Life"];
                    }
                    interventions.Add(intervention);
                }
            }

            return interventions;
        }
    }
}