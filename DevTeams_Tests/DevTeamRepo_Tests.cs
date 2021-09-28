using DevTeams.Data;
using DevTeams_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamRepo_Tests
    {
        [TestMethod]
        public void CreateNewDevTeam()
        {
            //arrange
            DeveloperTeam newTeam = new DeveloperTeam();
            DeveloperTeamRepo developerTeamRepo = new DeveloperTeamRepo();

            //act
            bool success = developerTeamRepo.CreateNewDevTeam(newTeam);

            //assert
            Assert.IsTrue(success);

        }

        [TestMethod]
        public void GetListofTeams()
        {
            //arrange
            DeveloperTeam newTeam = new DeveloperTeam("Team Fabu", 4444);
            DeveloperTeam new2Team = new DeveloperTeam("Team Fablue", 4446);
            DeveloperTeamRepo repo = new DeveloperTeamRepo();
            
            

            //act
            List<DeveloperTeam> teamsList = repo.GetTeamsList();
            bool success = teamsList.Contains(newTeam);


            //ASSERT
            Assert.AreEqual(new2Team.TeamName, "Team Fablue");
        }
      


        [TestMethod]
        public void GetDevTeamByTeamID()
        {

        }

        [TestMethod]
        public void GetListofDevsWithTeamID()
        {

        }
    }
}
