using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using ENETCare.IMS.BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace ENETCare.Tests
{
    /// <summary>
    /// Summary description for AccountantReportMakerTests
    /// </summary>
    [TestClass]
    public class AccountantReportMakerTests
    {
        public AccountantReportMakerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public List<Intervention> interventionsDummyData = new List<Intervention>();
        public List<Intervention> clientInterventionDummyData = new List<Intervention>();
        List<Intervention> InterventionDummyData = new List<Intervention>();
        SiteEngineer Gary = new SiteEngineer { Name = "Gary Smith" };

        //Initialize the test, intervention1 will always have intervention 1 in it
        [TestInitialize]
        public void CreateDummyDataForAccountantReportTests()
        {
            Intervention intervention1 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 232312982,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager { Name = "John Hewson" },
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/5/2016",
                Cost = 4000,
                LabourHours = 8,
                DateToPerform = "4/2/2017"
            };
            interventionsDummyData.Add(intervention1);
        }

        //first test send GetTotalCostPerEngineer one list of data, checks results are correct
        [TestMethod]
        public void AccountantGetTotalCostPerEngineerTest_OneIntervention_OnSucsess_ReturnCorrectNameAndCost()
        {
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostPerEngineer(interventionsDummyData);
            Assert.AreEqual("Gary Smith", testValues.Rows[0][0]);
            Assert.AreEqual("4000", testValues.Rows[0][1]);
            Assert.AreEqual("8", testValues.Rows[0][2]);
        }


        //Second test adds another intervention to the list checks it works
        [TestMethod]
        public void AccountantGetTotalCostPerEngineerTest_TwoInterventions_OnSuccess_ReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"

            };

            interventionsDummyData.Add(intervention2);
            
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostPerEngineer(interventionsDummyData);
            string testresult2 = (string)testValues.Rows[0][0];
            Assert.AreEqual("Gary Smith", testresult2);
            Assert.AreEqual("11000", testValues.Rows[0][1]);
        }


        //As this is a new test method intervention 2 is forgotten, has to be re-added in the method
        [TestMethod]

        public void AccountantGetTotalCostPerEngineerTest_FourInterventions_OnSuccess_ReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };
            
            Intervention intervention3 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Man" },
                InterventionId = 232367323,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/3/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "5/2/2017"
            };

            Intervention intervention4 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3432311,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/2/2016",
                Cost = 14000,
                LabourHours = 10,
                DateToPerform = "2/3/2018"
            };

            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);
            interventionsDummyData.Add(intervention4);
            
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostPerEngineer(interventionsDummyData);

            Assert.AreEqual("Anthony Man", testValues.Rows[0][0]);
            Assert.AreEqual("7000", testValues.Rows[0][1]);
            Assert.AreEqual("10", testValues.Rows[0][2]);

            Assert.AreEqual("Gary Smith", testValues.Rows[1][0]);
            Assert.AreEqual("11000", testValues.Rows[1][1]);
            Assert.AreEqual("18", testValues.Rows[1][2]);

            Assert.AreEqual("Tam George", testValues.Rows[2][0]);
            Assert.AreEqual("14000", testValues.Rows[2][1]);
            Assert.AreEqual("10", testValues.Rows[2][2]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerEngineerTest_SixInterventions_OnSuccess_ReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };

            Intervention intervention3 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Man" },
                InterventionId = 232367323,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/3/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "5/2/2017"
            };

            Intervention intervention4 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3432311,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/2/2016",
                Cost = 14000,
                LabourHours = 10,
                DateToPerform = "2/3/2018"
            };

            Intervention intervention5 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Mcgoo Man" },
                InterventionId = 3123811,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "10/2/2016",
                Cost = 500,
                LabourHours = 2,
                DateToPerform = "2/6/2019"
            };

            Intervention intervention6 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3467811,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "11/2/2016",
                Cost = 30000,
                LabourHours = 20,
                DateToPerform = "2/6/2018"
            };
            
            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);
            interventionsDummyData.Add(intervention4);
            interventionsDummyData.Add(intervention5);
            interventionsDummyData.Add(intervention6);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostPerEngineer(interventionsDummyData);

            Assert.AreEqual("Anthony Man", testValues.Rows[0][0]);
            Assert.AreEqual("7000", testValues.Rows[0][1]);
            Assert.AreEqual("10", testValues.Rows[0][2]);

            Assert.AreEqual("Gary Smith", testValues.Rows[1][0]);
            Assert.AreEqual("11000", testValues.Rows[1][1]);
            Assert.AreEqual("18", testValues.Rows[1][2]);

            Assert.AreEqual("Mcgoo Man", testValues.Rows[2][0]);
            Assert.AreEqual("500", testValues.Rows[2][1]);
            Assert.AreEqual("2", testValues.Rows[2][2]);

            Assert.AreEqual("Tam George", testValues.Rows[3][0]);
            Assert.AreEqual("44000", testValues.Rows[3][1]);
            Assert.AreEqual("30", testValues.Rows[3][2]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerEngineerTest_EnsureOnlyCompletedReturned_OnSuccessReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Mctinosh" },
                InterventionId = 232367323,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Approved,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/3/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "5/2/2017"
            };

            Intervention intervention3 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3432311,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/2/2016",
                Cost = 14000,
                LabourHours = 10,
                DateToPerform = "2/3/2018"
            };

            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostPerEngineer(interventionsDummyData);

            Assert.AreNotEqual("Anthony Mctinosh", testValues.Rows[0][0]);
            Assert.AreNotEqual("7000", testValues.Rows[0][1]);
            Assert.AreNotEqual("10", testValues.Rows[0][2]);

            Assert.AreEqual("Gary Smith", testValues.Rows[0][0]);
            Assert.AreEqual("4000", testValues.Rows[0][1]);
            Assert.AreEqual("8", testValues.Rows[0][2]);

            Assert.AreEqual("Tam George", testValues.Rows[1][0]);
            Assert.AreEqual("14000", testValues.Rows[1][1]);
            Assert.AreEqual("10", testValues.Rows[1][2]);
        }

        [TestMethod]
        public void AccountantGetAverageCostHoursPerEngineerTest_TestWithOneEngineerTwoEntries_OnSuccessReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetAverageCostNHoursPerEngineer(interventionsDummyData);
            Assert.AreEqual("Gary Smith", testValues.Rows[0][0]);
            Assert.AreEqual("4000", testValues.Rows[0][1]);
            Assert.AreEqual("8", testValues.Rows[0][2]);
        }

        [TestMethod]
        public void AccountantGetAverageCostHoursPerEngineerTest_TestWithOneEngineerThreeEntries_OnSuccessReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };

            Intervention intervention3 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3672423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 10000,
                LabourHours = 18,
                DateToPerform = "7/6/2019"
            };

            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetAverageCostNHoursPerEngineer(interventionsDummyData);
            Assert.AreEqual("Gary Smith", testValues.Rows[0][0]);
            Assert.AreEqual("7000", testValues.Rows[0][1]);
            Assert.AreEqual("12", testValues.Rows[0][2]);
        }


        [TestMethod]
        public void AccountantGetAverageCostHoursPerEngineerTest_TestWithThreeEngineer_OnSuccessReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };

            Intervention intervention3 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Mctinosh" },
                InterventionId = 3672423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 10000,
                LabourHours = 18,
                DateToPerform = "7/6/2019"
            };

            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetAverageCostNHoursPerEngineer(interventionsDummyData);
            
            Assert.AreEqual("Anthony Mctinosh", testValues.Rows[0][0]);
            Assert.AreEqual("10000", testValues.Rows[0][1]);
            Assert.AreEqual("18", testValues.Rows[0][2]);
            Assert.AreEqual("Gary Smith", testValues.Rows[1][0]);
            Assert.AreEqual("4000", testValues.Rows[1][1]);
            Assert.AreEqual("8", testValues.Rows[1][2]);
            Assert.AreEqual("Tam George", testValues.Rows[2][0]);
            Assert.AreEqual("7000", testValues.Rows[2][1]);
            Assert.AreEqual("10", testValues.Rows[2][2]);
        }
        
        [TestMethod]
        public void AccountantGetAverageCostHoursPerEngineerTest_TestWithThreeEngineerFiveEntries_OnSuccessReturnCorrectNameAndCost()
        {
            Intervention intervention2 = new Intervention
            {
                ProposedBy = Gary,
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 7000,
                LabourHours = 10,
                DateToPerform = "7/6/2017"
            };

            Intervention intervention3 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Mctinosh" },
                InterventionId = 3672423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "12/8/2016",
                Cost = 10000,
                LabourHours = 18,
                DateToPerform = "7/6/2019"
            };

            Intervention intervention4 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Tam George" },
                InterventionId = 3432423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "11/8/2016",
                Cost = 9000,
                LabourHours = 12,
                DateToPerform = "4/6/2017"
            };

            Intervention intervention5 = new Intervention
            {
                ProposedBy = new SiteEngineer { Name = "Anthony Mctinosh" },
                InterventionId = 3672423,
                Client = new Client(),
                InterventionType = new InterventionType(),
                State = State.Complete,
                ApprovedBy = new Manager(),
                Note = "wjdwdiwjadijwaid",
                Life = 50,
                MostRecentVisitDate = "2/8/2016",
                Cost = 20000,
                LabourHours = 18,
                DateToPerform = "7/5/2019"
            };

            interventionsDummyData.Add(intervention2);
            interventionsDummyData.Add(intervention3);
            interventionsDummyData.Add(intervention4);
            interventionsDummyData.Add(intervention5);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetAverageCostNHoursPerEngineer(interventionsDummyData);

            Assert.AreEqual("Anthony Mctinosh", testValues.Rows[0][0]);
            Assert.AreEqual("15000", testValues.Rows[0][1]);
            Assert.AreEqual("18", testValues.Rows[0][2]);
            Assert.AreEqual("Gary Smith", testValues.Rows[1][0]);
            Assert.AreEqual("5500", testValues.Rows[1][1]);
            Assert.AreEqual("9", testValues.Rows[1][2]);
            Assert.AreEqual("Tam George", testValues.Rows[2][0]);
            Assert.AreEqual("9000", testValues.Rows[2][1]);
            Assert.AreEqual("12", testValues.Rows[2][2]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerDistrictTest_WithOneDistrict_OnSuccessReturnDistrictNCost()
        {
            Decimal dummy = 0;
            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 12000
            };

            clientInterventionDummyData.Add(intervention1);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostForDistricts(clientInterventionDummyData, ref dummy);
            Assert.AreEqual("Urban Indonesia", testValues.Rows[0][0]);
            Assert.AreEqual("12000", testValues.Rows[0][1]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerDistrictTest_WithThreeDistrict_OnSuccesReturnDistrictNCost()
        {
            Decimal dummy = 0;

            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 12000
            };

            Intervention intervention2 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 15000
            };

            Intervention intervention3 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 16000
            };

            clientInterventionDummyData.Add(intervention1);
            clientInterventionDummyData.Add(intervention2);
            clientInterventionDummyData.Add(intervention3);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostForDistricts(clientInterventionDummyData, ref dummy);
            Assert.AreEqual("Urban Indonesia", testValues.Rows[0][0]);
            Assert.AreEqual("43000", testValues.Rows[0][1]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerDistrictTest_WithThreeDistrictSixEntriees_OnSuccesReturnDistrictNCost()
        {
            Decimal dummy = 0;
            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 12000
            };

            Intervention intervention2 = new Intervention
            {
                District = "Urban Papua New Guinea",
                State = State.Complete,
                Cost = 15000
            };

            Intervention intervention3 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 16000
            };

            Intervention intervention4 = new Intervention
            {
                District = "Sydney",
                State = State.Complete,
                Cost = 12000
            };

            Intervention intervention5 = new Intervention
            {
                District = "Urban Papua New Guinea",
                State = State.Complete,
                Cost = 13050
            };

            Intervention intervention6 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 2000
            };

            clientInterventionDummyData.Add(intervention1);
            clientInterventionDummyData.Add(intervention2);
            clientInterventionDummyData.Add(intervention3);
            clientInterventionDummyData.Add(intervention4);
            clientInterventionDummyData.Add(intervention5);
            clientInterventionDummyData.Add(intervention6);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostForDistricts(clientInterventionDummyData, ref dummy);
            Assert.AreEqual("Urban Indonesia", testValues.Rows[0][0]);
            Assert.AreEqual("30000", testValues.Rows[0][1]);
            Assert.AreEqual("Urban Papua New Guinea", testValues.Rows[1][0]);
            Assert.AreEqual("28050", testValues.Rows[1][1]);
            Assert.AreEqual("Sydney", testValues.Rows[2][0]);
            Assert.AreEqual("12000", testValues.Rows[2][1]);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerDistrictTest_CheckNotCompletedExcluded_OnSuccesReturnDistrictNCost()
        {
            Decimal dummy = 0;

            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 12000
            };

            Intervention intervention2 = new Intervention
            {
                District = "Urban Papua New Guinea",
                State = State.Approved,
                Cost = 15000
            };

            Intervention intervention3 = new Intervention
            {
                District = "Sydney",
                State = State.Complete,
                Cost = 16000
            };

            clientInterventionDummyData.Add(intervention1);
            clientInterventionDummyData.Add(intervention2);
            clientInterventionDummyData.Add(intervention3);
            
            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testValues = testReportMaker1.GetTotalCostForDistricts(clientInterventionDummyData, ref dummy);
            Assert.AreEqual("Urban Indonesia", testValues.Rows[0][0]); ;
            Assert.AreEqual("Sydney", testValues.Rows[1][0]);
            Assert.AreEqual(2, testValues.Rows.Count);
        }

        [TestMethod]
        public void AccountantGetTotalCostPerDistrictTest_CheckTotal_OnSuccessChangeRefValue()
        {
            Decimal districtsTotal = 0;

            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                Cost = 12000
            };

            Intervention intervention2 = new Intervention
            {
                District = "Urban Papua New Guinea",
                State = State.Complete,
                Cost = 15000
            };

            Intervention intervention3 = new Intervention
            {
                District = "Sydney",
                State = State.Complete,
                Cost = 16000
            };

            clientInterventionDummyData.Add(intervention1);
            clientInterventionDummyData.Add(intervention2);
            clientInterventionDummyData.Add(intervention3);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            testReportMaker1.GetTotalCostForDistricts(clientInterventionDummyData, ref districtsTotal);
            Assert.AreEqual(43000, districtsTotal);
        }

        
        [TestMethod]
        public void AccountantTotalCostPerMonthTest_CheckCorrectOutput_ThreeInterventions()
        {


            Intervention intervention1 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                DateToPerform = "12/04/2018",
                Cost = 12000
            };

            Intervention intervention2 = new Intervention
            {
                District = "Urban Indonesia",
                State = State.Complete,
                DateToPerform = "06/04/2018",
                Cost = 15000
            };

            Intervention intervention3 = new Intervention
            {
                District = "Sydney",
                DateToPerform = "03/03/2018", 
                State = State.Complete,
                Cost = 16000
            };

            InterventionDummyData.Add(intervention1);
            InterventionDummyData.Add(intervention2);
            InterventionDummyData.Add(intervention3);

            AccountantReportMaker testReportMaker1 = new AccountantReportMaker();
            DataTable testResult = testReportMaker1.GetTotalCostForEachMonth(InterventionDummyData);
            Assert.AreEqual("4", testResult.Rows[0][0]);
            Assert.AreEqual("2018", testResult.Rows[0][1]);
            Assert.AreEqual("27000", testResult.Rows[0][2]);
            Assert.AreEqual("3", testResult.Rows[1][0]);
            Assert.AreEqual("2018", testResult.Rows[1][1]);
            Assert.AreEqual("16000", testResult.Rows[1][2]);

        }
    }
}
