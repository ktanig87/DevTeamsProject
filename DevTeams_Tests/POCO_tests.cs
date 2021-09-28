using DevTeams.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevTeams_Tests
{
    [TestClass]
    public class POCO_tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Developer testDev = new Developer();

            //act
            testDev.DeveloperName = "steve";
            testDev.DevID = 42;
            testDev.PluralSightAccess = true;


            //assert
            string expectedName = "steve";
            string actualName = testDev.DeveloperName;

            Assert.AreEqual(expectedName, actualName);

            int expectedDevID = 42;
            int actualDevID = testDev.DevID;

            Assert.AreEqual(expectedDevID, testDev.DevID);

            Assert.IsTrue(testDev.PluralSightAccess);

            
        }

        [TestMethod]
        public void DeveloperTeamTest()
        {
            //arrange
            DeveloperTeam devTeam = new DeveloperTeam();

            //act
            devTeam.TeamID = 42;
            devTeam.TeamName = "Unicorny Glory";

            //assert
            int expectedTeamId = 42;
            string expectedTeamName = "Unicorny Glory";
            Assert.AreEqual(expectedTeamId, devTeam.TeamID);
            Assert.AreEqual(expectedTeamName, devTeam.TeamName);

        }
    }
}
