using DevTeams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperTeamRepo
    {

        //DevTeam CRUD
        public readonly List<DeveloperTeam> _DevTeamDirectory = new List<DeveloperTeam>();
        public readonly DeveloperTeam _developerTeam1 = new DeveloperTeam();
        

        //Create- create teams
        public bool CreateNewDevTeam(DeveloperTeam developerTeam)
        {
            int startCount = _DevTeamDirectory.Count;
            _DevTeamDirectory.Add(developerTeam);

            bool addSuccess = (_DevTeamDirectory.Count > startCount) ? true : false;
            return addSuccess;
        }

        public List<Developer> AddDevelopertoTeamList(Developer developer)
        {
            _developerTeam1.DevelopersOnList.Add(developer);
            return _developerTeam1.DevelopersOnList;
        }

        public List<Developer> ShowDevsOnTeamList(DeveloperTeam devTeamID)
        {
            foreach(Developer dev in _developerTeam1.DevelopersOnList)
            {
                if (dev.TeamID == devTeamID.TeamID)
                {
                    return _developerTeam1.DevelopersOnList;
                }                
            }
            return null;
        }


        //Read- see lists of teams; see list of team members?

        public List<DeveloperTeam> GetTeamsList()
        {
            return _DevTeamDirectory;
        }

        //Get a Developer Team by Team Id
        public DeveloperTeam GetDevTeam(int teamId)
        {
            foreach (DeveloperTeam devTeam in _DevTeamDirectory)
            {
                if (devTeam.TeamID == teamId)
                {
                    return devTeam;
                }
            return null;
            }
            return null;
        }

        public List<Developer> GetListOfDevsWithTeamId(int teamId)
        {
            DeveloperTeam devTeam = GetDevTeam(teamId);
            List<Developer> developers = devTeam.DevelopersOnList;
            return developers;
        }
                
        //Delete- remove team
        public bool DeleteTeam(DeveloperTeam existingTeam)
        {
            bool result = _DevTeamDirectory.Remove(existingTeam);
            return result;
        }
    }

   


}
