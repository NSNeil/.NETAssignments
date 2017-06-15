using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class Intervention
    {
        public string District { get; set; }
        public SiteEngineer ProposedBy { get; set; }
        public int InterventionId { get; set; }
        public Client Client { get; set; }
        public InterventionType InterventionType { get; set; }
        //string gg = "Approved";
        //State ss;
        //Enum.TryParse(gg,out ss);
        public State State { get; set; }
        public User ApprovedBy { get; set; }
        public string Note { get; set; }
        public double Life { get; set; }
        //RecentDate uses ISO 8610 format, for example: 2017-03-31T01:37:59+00:00
        public string MostRecentVisitDate { get; set; }
        //The adapted cost for the intervention 
        public decimal Cost { get; set; }
        //The adapted hours of labour for the intervention
        public int LabourHours { get; set; }
        public string DateToPerform { get; set; }
    }
}