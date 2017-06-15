using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCare.IMS.BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENET.Tests
{
    [TestClass]
    public class CreateInterventionTests
    {
        [TestInitialize]
        public void Setup()
        {
        }
        [TestMethod]
        public void CreateIntervention_OnSuccess_ReturnNewInterventionAndTrue()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 10000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Proposed", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsTrue(result);
            Assert.IsNotNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnStateInvalid_ReturnNullAndOutputFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 10000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 100,
                MaxCost = 10000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "I'm just Invalid", 100,10000,
                "OK",dateToPerform,client,out msg,out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnApprovedStateWithInsufficientMaxLabourHours_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 10000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1,
                MaxCost = 10000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Approved", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnApprovedStateWithInsufficientMaxCost_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 1000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 10000,
                MaxCost = 1,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Approved", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnInvalidDate_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 1000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(1991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Approved", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnClientDistrictDifferentThanEngineer_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 1000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Different district",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Approved", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnCostInputLowerThanDefault_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 1000000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1,
                MaxCost = 10000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Proposed", 100, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }

        [TestMethod]
        public void CreateIntervention_OnLabourHoursInputLowerThanDefault_ReturnNullAndFalse()
        {
            bool result = false;
            string msg = "";
            InterventionType type = new InterventionType
            {
                DefaultCost = 10000,
                DefaultLabourHours = 100,
                InterventionTypeId = 1,
                Name = "Supply and Install Portable Toilet"
            };
            Client client = new Client
            {
                Address = "Pitt St",
                ClientId = 1,
                District = "Rural Indonesia",
                Name = "John Lennon"
            };
            ENETCareGlobal.CurrentUser = new SiteEngineer
            {
                District = "Rural Indonesia",
                MaxHours = 1000,
                MaxCost = 100000,
                Name = "Neil",
                SiteEngineerId = 1,
                UserId = 1
            };
            DateTime dateToPerform = new DateTime(2991, 9, 23);
            Intervention intervention = new InterventionManager().CreateIntervention(type, "Proposed", 1, 10000,
                "OK", dateToPerform, client, out msg, out result);
            Assert.IsFalse(result);
            Assert.IsNull(intervention);
        }
    }
}
