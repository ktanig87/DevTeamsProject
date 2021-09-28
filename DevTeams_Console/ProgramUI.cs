using DevTeams.Data;
using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    class ProgramUI
    {
        private DeveloperTeamRepo _devTeamRepo = new DeveloperTeamRepo();
        private DeveloperRepo _devRepo = new DeveloperRepo();

        public void Run()
        {
            SeedData();
            Menu();
        }

        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                (
                   "Developers:\n" +
                   "1. Create a Developer\n" +
                   "2. Show list of all Developers\n" +
                   "3. Show Developer details by Name \n" +
                   "4. Show Developer details by Developer ID \n" +
                   "5. Add/Update Developer's Team\n" +
                   "6. Show list of developers needing PluralSight license \n" +
                   "7. Delete Developer \n\n" +

                   "Teams:\n" +
                   "10. Create a Team\n" +
                   "11. Show list of all Teams\n" +
                   "12. Show Team by ID \n" +
                   "13. Show list of Developers by Team \n" +  //
                   "14. Delete a Team \n" +
                   "15. Exit \n"
                );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        ShowAllDevelopers();
                        break;
                    case "3":
                        GetDevName();
                        break;
                    case "4":
                        GetDevID();
                        break;
                    case "5":
                        UpdateDevsTeam();
                        break;
                    case "6":
                        DevsNeedSight();
                        break;
                    case "7":
                        RemoveDev();
                        break;
                    case "10":
                        CreateDevTeam();
                        break;
                    case "11":
                        ShowAllDeveloperTeams();
                        break;
                    case "12":
                        GetTeamByID();
                        break;
                    case "13":
                        ShowDevsOnTeamList();
                        break;
                    case "14":
                        RemoveTeam();
                        break;
                    case "15":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make selection based on the numbered lists above.  \n" + "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("What is the developer's name?");
            newDev.DeveloperName = Console.ReadLine();

            Console.WriteLine("What is the developer's ID number");
            newDev.DevID = int.Parse(Console.ReadLine());

            Console.WriteLine("Does this developer have access to PluralSight?  Answer True/False");
            newDev.PluralSightAccess = bool.Parse(Console.ReadLine());

            _devRepo.CreateDeveloper(newDev);

            PressAnyKey();
        }


        private void ShowAllDevelopers()
        {
            Console.Clear();
            List<Developer> listAllDevs = _devRepo.ShowDevelopers();

            foreach (Developer developer in listAllDevs)
            {
                DisplayDevelopers(developer);
            }

            PressAnyKey();

        }

        private void GetDevName()
        {
            Console.Clear();
            Console.WriteLine("What Developer are you looking for?");
            string devSought = Console.ReadLine();

            Developer developer = _devRepo.GetDeveloperByName(devSought);

            if (developer != null)
            {
                DisplayDevelopers(developer);
            }
            else Console.WriteLine("Please try another name");

            PressAnyKey();
        }

        private void GetDevID()
        {
            Console.Clear();
            Console.WriteLine("What Developer are you looking for? Please enter ID number.");
            int devSought = int.Parse(Console.ReadLine());

            Developer developer = _devRepo.GetDevDetailsByID(devSought);

            if (developer != null)
            {
                DisplayDevelopers(developer);
            }
            else Console.WriteLine("Please try another ID");

            PressAnyKey();
        }

        //UpdateTeam 
        private void UpdateDevsTeam()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the Developer you want to assign to a team?");
            int developer = int.Parse(Console.ReadLine());

            Developer devToUpdate = _devRepo.GetDevDetailsByID(developer);
            if (devToUpdate == null)
            {
                Console.WriteLine("Try another ID");
                PressAnyKey();
                return;
            }

            Developer updatedDev = new Developer();

            Console.WriteLine($"This developer's current team is {devToUpdate.TeamID}\n\n");
            Console.WriteLine("What Team ID should be assigned to the developer?");
            updatedDev.TeamID = int.Parse(Console.ReadLine());

            DeveloperTeam teamToUpdate = _devTeamRepo.GetDevTeam(updatedDev.TeamID);
            if (teamToUpdate != null)
            {
                teamToUpdate.DevelopersOnList.Add(devToUpdate);
            }
            else
            {
                return;
            }
            if (_devRepo.UpdateTeam(devToUpdate, updatedDev))
            {
                Console.WriteLine("Update Success");
            }
            else
            {
                Console.WriteLine("Failed. womp womp");
            }
            PressAnyKey();
        }

        //DeleteDeveloper
        private void RemoveDev()
        {
            Console.Clear();
            List<Developer> devList = _devRepo.ShowDevelopers();

            int index = 1;

            foreach (Developer dev in devList)
            {
                Console.WriteLine($"{index}. {dev.DeveloperName}");
                index++;
            }

            Console.WriteLine("Which developer would you like to delete? select a number");
            int targetDev = int.Parse(Console.ReadLine());

            int targetIndex = targetDev - 1;

            if (targetIndex >= 0 && targetIndex < devList.Count)
            {
                Developer targetedDev = devList[targetIndex];
                if (_devRepo.DeleteDeveloper(targetedDev))
                {
                    Console.WriteLine($"{targetedDev.DeveloperName} was succuessfully removed");
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

            }
            else
            {
                Console.WriteLine("Please select a number.");
            }
            PressAnyKey();
        }


        //GetDevsNeedingPluralSight
        private void DevsNeedSight()
        {
            Console.Clear();
            List<Developer> listAllDevs = _devRepo.ShowDevelopers();

            foreach (Developer developer in listAllDevs)
            {
                if (developer.PluralSightAccess == false)
                {
                    DisplayDevelopers(developer);
                }
            }

            PressAnyKey();
        }

        public void CreateDevTeam()
        {

            Console.Clear();
            DeveloperTeam newTeam = new DeveloperTeam();

            Console.WriteLine("What is the Team name?");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("What is the Team's ID number");
            newTeam.TeamID = int.Parse(Console.ReadLine());

            _devTeamRepo.CreateNewDevTeam(newTeam);

            PressAnyKey();
        }

        //GetTeamsList

        private void ShowAllDeveloperTeams()
        {
            Console.Clear();
            List<DeveloperTeam> listAllTeams = _devTeamRepo.GetTeamsList();

            foreach (DeveloperTeam developerTeam in listAllTeams)
            {
                DisplayTeams(developerTeam);
            }

            PressAnyKey();
        }

        private void GetTeamByID()
        {
            Console.Clear();
            Console.WriteLine("What Team are you looking for? Please enter ID number.");
            int teamSought = int.Parse(Console.ReadLine());

            DeveloperTeam developerTeam = _devTeamRepo.GetDevTeam(teamSought);
            if (developerTeam != null)
            {
                DisplayTeams(developerTeam);
            }
            else Console.WriteLine("error");

            PressAnyKey();

        }

        private void ShowDevsOnTeamList()
        {
            Console.Clear();
            Console.WriteLine("What Team are you looking for? Please enter ID number.");
            int devTeamID = int.Parse(Console.ReadLine());

            DeveloperTeam developerTeam = _devTeamRepo.GetDevTeam(devTeamID);
            if (developerTeam != null)
            {
                DisplayTeams(developerTeam);
            }
            else Console.WriteLine("error");

            PressAnyKey();

        }

        private void RemoveTeam()
        {
            Console.Clear();
            List<DeveloperTeam> teamsList = _devTeamRepo.GetTeamsList();

            int index = 1;

            foreach (DeveloperTeam devTeam in teamsList)
            {
                Console.WriteLine($"{index}. {devTeam.TeamID} {devTeam.TeamName}");
                index++;
            }
            Console.WriteLine("Which team would you like to remove?");
            int targetTeam = int.Parse(Console.ReadLine());

            int targetIndex = targetTeam - 1;

            if (targetIndex >= 0 && targetIndex < teamsList.Count)
            {
                DeveloperTeam target = teamsList[targetIndex];
                if (_devTeamRepo.DeleteTeam(target))
                {
                    Console.WriteLine($"{target.TeamID} was successfully removed!");
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            else
            {
                Console.WriteLine("Not a valid selection");
            }
            PressAnyKey();
        }

        //helper methods

        private void SeedData()

        {
            Developer devDan = new Developer("DevDan", 42, true);
            Developer devDeb = new Developer("DevDeb", 88, false);
            Developer devDave = new Developer("DevDave", 33, true);
            Developer devDean = new Developer("DevDean", 55, false);
            Developer devDon = new Developer("DevDon", 22, false);
            Developer devDiane = new Developer("DevDaine", 82, true);
            _devRepo.CreateDeveloper(devDean);
            _devRepo.CreateDeveloper(devDave);
            _devRepo.CreateDeveloper(devDeb);
            _devRepo.CreateDeveloper(devDan);
            _devRepo.CreateDeveloper(devDiane);
            _devRepo.CreateDeveloper(devDon);
                        
            DeveloperTeam TeamTriumph = new DeveloperTeam("Team Triumph", 56789);
            
            _devTeamRepo.CreateNewDevTeam(TeamTriumph);
            
            TeamTriumph.DevelopersOnList.Add(devDean);
            TeamTriumph.DevelopersOnList.Add(devDiane);
            TeamTriumph.DevelopersOnList.Add(devDave);
            TeamTriumph.DevelopersOnList.Add(devDeb);
            TeamTriumph.DevelopersOnList.Add(devDon);
            TeamTriumph.DevelopersOnList.Add(devDan);
        }
        private void PressAnyKey()
        {
            Console.WriteLine("press key to continue");
            Console.ReadKey();
        }

        public void DisplayDevelopers(Developer developer)
        {
            Console.WriteLine($"Name:{developer.DeveloperName}\n" +
                $"Developer ID:{developer.DevID}\n" +
                $"Access to PluralSight:{developer.PluralSightAccess}\n" +
                $"Current Team ID:{developer.TeamID}\n\n");
        }

        public void DisplayTeams(DeveloperTeam devTeam)
        {
           //List<DeveloperTeam> listAllDevTeams = _devTeamRepo.GetTeamsList();
           // int index = 1;
           // foreach (DeveloperTeam developerTeam in listAllDevTeams)
           // {
                Console.WriteLine($"Team Name:{devTeam.TeamName}\n" +
                $"Team ID:{devTeam.TeamID}\n" +
                $"Team Members:\n");
                //if (devTeam.DevelopersOnList != null)
                //{
                    //foreach (Developer devI in developerTeam.DevelopersOnList)
                   // {
                  //     Console.WriteLine($"{index}. {devI.DeveloperName}");
                  //      index++;
                  //  }
                //}

            //}
        }
   
    }

}

