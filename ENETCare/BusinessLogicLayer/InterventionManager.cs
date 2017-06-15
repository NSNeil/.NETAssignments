using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class InterventionManager
    {
        public InterventionManager()
        {
            
        }
        
        public Intervention CreateIntervention(InterventionType interventionType, string state, int labourHours, 
            decimal cost, string note, DateTime dateToPerform, Client client, out string msg, out bool result)
        {
            SiteEngineer proposedBy = ENETCareGlobal.CurrentUser as SiteEngineer;

            if (client == null)
            {
                msg = "Please choose a client!";
            }
            if (interventionType == null)
            {
                msg = "Type is wrong!";
            }
            if (labourHours < interventionType.DefaultLabourHours)
            {
                msg = "Labour hour is less than the default hour of this type or invalid number";
                result = false;
                return null;
            }
            if (cost < interventionType.DefaultCost)
            {
                msg = "Cost is less than the default cost of this type or invalid number";
                result = false;
                return null;
            }
            if (dateToPerform.Date < DateTime.Now)
            {
                msg = "Date is wrong";
                result = false;
                return null;
            }
            if (state == "Approved" || state == "Complete")
            {
                if (labourHours > proposedBy.MaxHours || cost > proposedBy.MaxCost)
                {
                    msg = "Cost or Labour Hours is beyond your limit";
                    result = false;
                    return null;
                }
            }
            else if(state != "Proposed")
            {
                msg = "Invalid state";
                result = false;
                return null;
            }
            if (client.District != proposedBy.District)
            {
                msg = "Client is not in your district";
                result = false;
                return null;
            }
            Intervention newIntervention = new Intervention
            {
                InterventionType = interventionType,
                LabourHours = labourHours,
                Cost = cost,
                ProposedBy = proposedBy,
                Note = note,
                DateToPerform = dateToPerform.ToShortDateString(),
                Client = client,
                MostRecentVisitDate = DateTime.Now.ToShortDateString(),
                ApprovedBy = null,
                State = State.Proposed,
                District = client.District,
                Life = 0
            };
            msg = "Success";
            result = true;
            return newIntervention;
        }

        /// <summary>
        /// This method is only used by the site engineer to evaluate whether the update inputs are valid
        /// </summary>
        /// <param name="proposedById"></param>
        /// <param name="life"></param>
        /// <param name="newState"></param>
        /// <param name="oldState"></param>
        /// <param name="interventionDistrict"></param>
        /// <param name="labourHours"></param>
        /// <param name="cost"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool EvaluateUpdates(int proposedById, string life, string newState, string oldState, string interventionDistrict, int labourHours, decimal cost, out string msg)
        {
            SiteEngineer currentUser = ENETCareGlobal.CurrentUser as SiteEngineer;
            double numericLife = -2;
            bool result = double.TryParse(life, out numericLife);
            if (!result)
            {
                msg = "Invalid life!";
                return false;
            }

            if (numericLife > 1)
            {
                msg = "Invalid life! Please enter a number less than 1";
                return false;
            }
            if (numericLife < 0)
            {
                msg = "Invalid life! Please enter a number larger than 0";
                return false;
            }

            if (oldState == "Approved")
            {
                if (newState == "Proposed")
                {
                    msg = "Can't change state backwards!";
                    return false;
                }
                if (newState == "Cancelled" || newState == "Complete")
                {
                    if (currentUser.SiteEngineerId != proposedById)
                    {
                        msg = "An intervention that has been “Approved” can only be “Cancelled” or “Completed” by the " +
                              "Site Engineer that proposed the intervention";
                        return false;
                    }
                }
            }
            if (oldState == "Complete")
            {
                if (newState == "Proposed" || newState == "Approved")
                {
                    msg = "Can't change state backwards!";
                    return false;
                }
            }
            if (oldState == "Proposed")
            {
                if (newState == "Approved" || newState == "Complete" || newState == "Cancelled")
                {
                    if (currentUser.District != interventionDistrict)
                    {
                        msg = "Intervention not in your district";
                        return false;
                    }
                    if (currentUser.MaxHours < labourHours || currentUser.MaxCost < cost)
                    {
                        msg = "You can't perform this action due to cost or hours limit";
                        return false;
                    }

                }
            }
           
            msg = "Success";
            return true;
        }
    }
}