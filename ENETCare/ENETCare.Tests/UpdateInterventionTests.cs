using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENETCare.Tests
{
    [TestClass]
    public class UpdateInterventionTests
    {
        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod]
        public void EngineerApproveIntervention_OnSuccess_ReturnTrue()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Approved", "Proposed", "Rural Indonesia", 100,10000,out msg);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void EngineerApproveIntervention_OnDifferentDistrict_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesi",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Approved", "Proposed", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EngineerApproveIntervention_OnEnginnerMaxCostInsufficient_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 10,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Approved", "Proposed", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EngineerApproveIntervention_OnEnginnerMaxLabourHoursInsufficient_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Approved", "Proposed", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EngineerApproveIntervention_OnLifeInputInvalid_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "Invalid", "Approved", "Proposed", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EngineerCompleteIntervention_OnCurrentEngineerDifferentThanProposedBy_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 2,
                UserId = 2
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Complete", "Approved", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EngineerCancelIntervention_OnCurrentEngineerDifferentThanProposedBy_ReturnFalse()
        {
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 2,
                UserId = 2
            };
            string msg = "";
            bool result = new InterventionManager().EvaluateUpdates(1, "1", "Cancelled", "Approved", "Rural Indonesia", 100, 10000, out msg);
            Assert.IsFalse(result);
        }
    }
}
