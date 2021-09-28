using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    public class Developer  //Developer POCO
    {
        public Developer() { }
        public Developer(string devName, int devID, bool pluralSightAccess)
        {
            DeveloperName = devName;
            DevID = devID;
            PluralSightAccess = pluralSightAccess;
            
        }
        
        public string DeveloperName { get; set; }
        public int DevID { get; set; }
        public bool PluralSightAccess { get; set; }
        public int TeamID { get; set; }  //current team   

    }

    
}
