using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    public class DeveloperTeam  //DevTeam POCO
    {
        public DeveloperTeam() { }
        public DeveloperTeam(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
            
        }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> DevelopersOnList { get; set; } = new List<Developer>();



    }
}
