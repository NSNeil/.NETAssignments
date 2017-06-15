using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class AccountantReportMaker
    {
        public DataTable GetTotalCostPerEngineer(List<Intervention> engineerData)
        {
            //Create a datatable that will be returned with a name and total cost
            DataTable returnData = new DataTable();
            returnData.Clear();

            returnData.Columns.Add("Name");
            returnData.Columns.Add("TotalCost");
            returnData.Columns.Add("TotalHours");

            decimal costSum = 0;
            int labourSum = 0;

            //Do a groupBy (essentially) so that all the hypothetical rows in intervention that have
            //the same SiteEngineer Name stick together, order by ascending
            var result =
                from Intervention in engineerData
                where Intervention.State == State.Complete
                orderby Intervention.ProposedBy.Name ascending
                group Intervention by Intervention.ProposedBy.Name;

            //iterate through these groups by SiteEngineer Name
            foreach (var group in result)
            {
                //get the sum for each "row"
                foreach (Intervention element in group)
                {
                    costSum += element.Cost;
                }

                foreach (Intervention element in group)
                {
                    labourSum += element.LabourHours;
                }

                //add the name of the group (the site engineer name)
                //and the sum of all the cost rows together on a row in the new table
                //then the sum of all the hours
                returnData.Rows.Add(group.Key, costSum, labourSum);
                costSum = 0;
                labourSum = 0;
            }

            return returnData;
        }

        //Method which returns a list returning the average cost and Labour for each engineer

        public DataTable GetAverageCostNHoursPerEngineer(List<Intervention> engineerData)
        {
            DataTable returnData = new DataTable();
            returnData.Clear();

            returnData.Columns.Add("Name");
            returnData.Columns.Add("AverageCost");
            returnData.Columns.Add("AverageHours");

            //Linq query that groups data by engineer, suming the cost and labour hours for each row that contains the engineer's id
            var result =
            from Intervention in engineerData
            where Intervention.State == State.Complete
            orderby Intervention.ProposedBy.Name ascending
            group Intervention by new { Name = Intervention.ProposedBy.Name } into names
            select new
            {
                Name = names.Key.Name,
                AverageHours = names.Average(x => x.LabourHours),
                AverageCost = names.Average(z => z.Cost)
            };

            
            foreach (var Name in result)
            {
                returnData.Rows.Add(Name.Name, Name.AverageCost, Name.AverageHours);
            }

            return returnData;
        }

        //Method that gets the total cost of all districts and the total cost for all enet districts
        public DataTable GetTotalCostForDistricts(List<Intervention> clientData, ref Decimal districtsTotal)
        {
            DataTable returnData = new DataTable();
            returnData.Clear();

            returnData.Columns.Add("District");
            returnData.Columns.Add("TotalCost");

            //select district and total cost for that district
            var result =
                from Intervention in clientData
                where Intervention.State == State.Complete
                group Intervention by new { District = Intervention.District } into districts
                select new
                {
                    District = districts.Key.District,
                    TotalCost = districts.Sum(x => x.Cost)
                };

            foreach (var District in result)
            {
                returnData.Rows.Add(District.District, District.TotalCost);
            }

            //add all district total costs to reference variable, to get total cost for all districts 
            foreach (var District in result)
            {
                districtsTotal += District.TotalCost;
            }

            return returnData;
        }

        //struct which stores data for method below
        private struct InterventionWithDateTime
        {
            private decimal cost;
            private DateTime time;
            private State state; 

            public decimal Cost
            {
                get
                {
                    return this.cost; 
                }

                set
                {
                    this.cost = value; 
                }
            }

            public DateTime Time
            {
                get
                {
                    return this.time;
                }

                set
                {
                    this.time = value;
                }
            }

            public State State
            {
                get
                {
                    return this.state;
                }

                set
                {
                    this.state = value;
                }
            }
        }


        //method that returns a datatable containing each month present in intervention DateToPerform and sum of the money spend in
        //that month
        public DataTable GetTotalCostForEachMonth(List<Intervention> interventionDateData)
        {
            DataTable returnData = new DataTable();
            returnData.Clear();

            returnData.Columns.Add("Month");
            returnData.Columns.Add("Year");
            returnData.Columns.Add("TotalCost");

            //create a list of structs that have a dateTime format and not a string for thier time field, copy needed info and DateTo
            //Perform into structs and add those structs to a list. Makes it easier for linq query
            List<InterventionWithDateTime> dateTimeInterventionList = new List<InterventionWithDateTime>();
            foreach (Intervention intervention in interventionDateData)
            {
                
                InterventionWithDateTime tempDateTimeIntervention = new InterventionWithDateTime();
                tempDateTimeIntervention.Cost = intervention.Cost;
                string temp = intervention.DateToPerform.Trim(); 
                tempDateTimeIntervention.Time = DateTime.ParseExact(temp, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                tempDateTimeIntervention.State = intervention.State;
                dateTimeInterventionList.Add(tempDateTimeIntervention); 
            }

            //use the list of structs to carry out linq query and read data into dataTable, which is returned with the data for the report
            var result =
                from InterventionWithDateTime in dateTimeInterventionList
                where InterventionWithDateTime.State == State.Complete
                group InterventionWithDateTime by new { Performed = InterventionWithDateTime.Time.Month, Year = InterventionWithDateTime.Time.Year } into monthPerformed
                select new
                {
                    MonthPerformed = monthPerformed.Key.Performed,
                    Year = monthPerformed.Key.Year, 
                    TotalCost = monthPerformed.Sum(x => x.Cost)
                };

            foreach (var Performed in result)
            {
                returnData.Rows.Add(Performed.MonthPerformed.ToString(), Performed.Year.ToString(), Performed.TotalCost);
            }


    
            return returnData; 


        }
    }
}
