using DevTeams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepo
    {
        public readonly List<Developer> _DeveloperDirectory = new List<Developer>();

        //Developer CRUD

        //Create- add new developer
        public bool CreateDeveloper(Developer developer)
        {
            int startingCount = _DeveloperDirectory.Count;
            _DeveloperDirectory.Add(developer);

            bool addSuccess = (_DeveloperDirectory.Count > startingCount) ? true : false;
            return addSuccess;
        }

        //Read- see list of all developers; see one developers details

        public List<Developer> ShowDevelopers()
        {
            return _DeveloperDirectory;
        }


        //Read- one devs details by name

        public Developer GetDeveloperByName(string devRequired)
        {
            foreach (Developer devPlease in _DeveloperDirectory)
            {
                if (devPlease.DeveloperName.ToLower() == devRequired.ToLower())
                {
                    return devPlease;
                }

            }
            return null;
        }


        //Read- one devs details by ID
        public Developer GetDevDetailsByID(int idRequired)
        {
            foreach (Developer devByID in _DeveloperDirectory)
            {
                if (devByID.DevID == idRequired)
                {
                    return devByID;
                }
            }
            return null;
        }


        

        //Update- add developers to teams from list of devs

        public bool UpdateTeam(Developer currentTeam, Developer newTeam)
        {
            foreach (Developer changeTeam in _DeveloperDirectory)
            {
                if (changeTeam.TeamID != null)
                {
                    currentTeam.TeamID = newTeam.TeamID;
                    return true;
                }
                
            }
            return false;

        }

        //Delete- 
        public bool DeleteDeveloper(Developer existingDev)
        {
            bool result = _DeveloperDirectory.Remove(existingDev);
            return result;
        }


        //Bonus- 
        //Read- see list of Devs that don't currently have Pluralsight 

        public Developer GetDevsNeedingPluralSight()
        {
            foreach (Developer needsLicense in _DeveloperDirectory)
            {
                if (needsLicense.PluralSightAccess == false)
                {
                    return needsLicense;
                }
            }
            return null;
        }

    }
}
