using DevTeams.Data;
using DevTeams_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevRepoTest
    {
        [TestMethod]
        public void DevListNeedsPluralSight()
        {
            //arrange
            Developer testDev1 = new Developer("Steve", 44, true);
            Developer testDev2 = new Developer("Marge", 33, true);
            Developer testDev3 = new Developer("Pete", 14, false);
            Developer testDev4 = new Developer("Petunia", 55, true);

            DeveloperRepo testDevRepo = new DeveloperRepo();
            testDevRepo.AddDevToDirectory(testDev4);
            testDevRepo.AddDevToDirectory(testDev3);
            testDevRepo.AddDevToDirectory(testDev2);
            testDevRepo.AddDevToDirectory(testDev1);

            //act
            Developer needsPS1 = testDevRepo.GetDevsNeedingPluralSight();

            //assert
            Assert.AreEqual(needsPS1.DeveloperName, "Pete");



            //act
            //Developer searchedDev = testDevRepo.GetDeveloperByName("Marge");

            //Assert
            //Assert.AreEqual(searchedDev.DeveloperName, testDev2.DeveloperName);


        }
        [TestMethod]
        public void UpdateTeamTest()
        {
            //arrange
            Developer testDevOld = new Developer("Steve", 44, true);
            Developer testDevNew = new Developer("Marge", 33, false);
            DeveloperRepo testDevRepo = new DeveloperRepo();
            testDevRepo.AddDevToDirectory(testDevOld);

            //act
            bool updateresult = testDevRepo.UpdateTeam(testDevOld, testDevNew);

            //assert
            Assert.IsTrue(updateresult);

        }

        [TestMethod]
        public void GetDeveloperDetailsbyIDorName()
        {
            //arrange
            Developer testDev1 = new Developer("Steve", 44, true);
            Developer testDev2 = new Developer("Marge", 33, false);
            Developer testDev3 = new Developer("Pete", 14, false);
            Developer testDev4 = new Developer("Petunia", 55, true);

            DeveloperRepo testDevRepo = new DeveloperRepo();
            testDevRepo.AddDevToDirectory(testDev4);
            testDevRepo.AddDevToDirectory(testDev3);
            testDevRepo.AddDevToDirectory(testDev2);

            //act
            Developer searchedDev = testDevRepo.GetDeveloperByName("Marge");

            //Assert
            Assert.AreEqual(searchedDev.DeveloperName, testDev2.DeveloperName);


        }


        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Developer testDeveloper = new Developer("Steve", 42, true);
            DeveloperRepo testDevRepo = new DeveloperRepo();

            //act
            bool success = testDevRepo.AddDevToDirectory(testDeveloper);

            //assert
            Assert.IsTrue(success);

        }
        [TestMethod]
        public void TestMethod1()
        {
            



            //arrange 
            Developer testDev1 = new Developer("Steve", 44, true);
            Developer testDev2 = new Developer("Marge", 33, false);
            Developer testDev3 = new Developer("Pete", 14, false);
            Developer testDev4 = new Developer("Petunia", 55, true);

            DeveloperRepo testDevRepo = new DeveloperRepo();
            testDevRepo.AddDevToDirectory(testDev4);
            testDevRepo.AddDevToDirectory(testDev3);
            testDevRepo.AddDevToDirectory(testDev2);

            //act
            List<Developer> allDevs = testDevRepo.ShowDevelopers();

            bool success = allDevs.Contains(testDev4);

            //assert
            Assert.IsTrue(success);

        }
    }

}
