using DeveloperRepository;
using DevTeamRepo;
using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{ 
    class ProgramUI
    {
        // Load Needed Resources
        public DeveloperContentRepo _contentDeveloperRepo = new DeveloperContentRepo();
        public TeamContentRepo _contentTeamRepo = new TeamContentRepo();

        // Run Start Menu
        public void Run()
        {
            SeedPeopleList();
            SeedTeamList();
            StartMenu();
        }

        // Start Menu
        private void StartMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("              Welcome to the Komodo Insurance Developer App.\n" +
                                  "-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-\n");
                Console.WriteLine("Please Login to Get Started!");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Login\n" +
                                  "0. Exit");
                string inputA = Console.ReadLine();

                switch (inputA)
                {
                    case "1":
                        // Login
                        Login();
                        break;
                    case "0":
                        // Exit
                        Console.Clear();
                        Console.WriteLine("See you again soon");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Login Function
        // (while loop)
        private void Login()
        {
            Console.Clear();
            Console.WriteLine("Please enter your user ID and Password.\n" +
                              "[ 'IDK' and 'MyPassword' to bypass ]");
            Console.WriteLine("IDK:");
            string newID = Console.ReadLine();
            Console.WriteLine("MyPassword");
            string newPassword = Console.ReadLine();

            if (newID == "IDK" && newPassword == "MyPassword")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Please enter a valid ID and password.");
            }
        }

        // Main Menu 
        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Main Menu. Choose an option.");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Developer Options\n" +
                                  "2. Team Options\n" +
                                  "0. Log Out");
                string inputA2 = Console.ReadLine();

                switch (inputA2)
                {
                    case "1":
                        PeopleMenu();
                        break;
                    case "2":
                        TeamMenu();
                        break;
                    case "0":
                        StartMenu();
                        break;
                    default:
                        Console.WriteLine("Enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Developer Menu
        private void PeopleMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Developer Menu please choose an option.");
                Console.WriteLine("Select a menu option.:\n" +
                                  "1. Add a Developer\n" +
                                  "2. View All Developers\n" +
                                  "3. Single Developer by IDNumber\n" +
                                  "4. Display PluralSight Report\n" +
                                  "5. Update a Developer\n" +
                                  "6. Delete a Developer\n" +
                                  "0. Return to Previous Menu");
                string inputA3 = Console.ReadLine();

                switch (inputA3)
                {
                    case "1":
                        // Add a Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // Display All Devs
                        DisplayAllIDNumberFullNameIDContent();
                        break;
                    case "3":
                        // Display a Single Dev by IDNumber
                        DisplayADeveloperByIdNumber();
                        break;
                    case "4":
                        // Display PluralSight Report
                        DisplayPluralsightReport();
                        break;
                    case "5":
                        // Update a Developer
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                        // Delete a Developer
                        DeleteExistingDeveloper();
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Enter a valid number");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new Person 
        private void CreateNewDeveloper()
        {
            Console.Clear();
            DeveloperContent newContent = new DeveloperContent();

            //First name
            Console.WriteLine("Enter First Name of Developer");
            string firstName = Console.ReadLine();
            newContent.FirstName = firstName;

            //Last name
            Console.WriteLine("Enter Last Name of Developer");
            string lastName = Console.ReadLine();
            newContent.LastName = lastName;

            //Full name
            string fullName = $"{lastName}, {firstName}";
            newContent.FullName = fullName;

            //ID Number 
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "These IdNumbers are already in use\n" +
                              "What IDNumber would you like to assign to Developer\n" +
                              "A new one is suggested");
            string chosenNumber = Console.ReadLine();
            int idNumber = int.Parse(chosenNumber);
            newContent.IDNumber = idNumber;

            //ID
            string lastFour = lastName.Substring(0, lastName.Length > 4 ? 4 : lastName.Length);
            string id = $"{idNumber}{lastFour}";
            newContent.ID = id;

            //Pluralsight
            Console.WriteLine("Does the Developer have access to Pluralsight? (y/n):");
            string pluralAsString = Console.ReadLine().ToLower();

            if (pluralAsString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }
        }

        //Display all Developers
        private void DisplayAllIDNumberFullNameIDContent()
        {
            Console.Clear();
            List<DeveloperContent> listOfContent = _contentDeveloperRepo.GetPeopleList();

            foreach (DeveloperContent content in listOfContent)
            {
                Console.WriteLine($"IDNumber: {content.IDNumber}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"ID: {content.ID}");
            }
        }

        //Display a single developer by IDNumber
        private void DisplayADeveloperByIdNumber()
        {
            Console.Clear();
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you want");

            string IDNumber = Console.ReadLine();
            int IDNumberParsed = int.Parse(IDNumber);


            DeveloperContent content = _contentDeveloperRepo.GetPeopleByIdNumber(IDNumberParsed);

            if (content != null)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"Pluralsight: {content.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No user with that ID.");
            }
        }
        private void DisplayPluralsightReport()
        {
            Console.Clear();
            List<DeveloperContent> listOfContent = _contentDeveloperRepo.GetPeopleList();

            foreach (DeveloperContent content in listOfContent)
            {
                Console.WriteLine($"ID: {content.ID}\n" +
                                  $"Full Name: {content.FullName}\n" +
                                  $"Has Pluralsight Access: {content.PluralsightAccess}");
            }
        }

        // Update Existing Developer
        private void UpdateExistingDeveloper()
        {
            // Display People
            DisplayAllIDNumberFullNameIDContent();

            // Options
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you would like to update");
            string oldIDNumber = Console.ReadLine();
            int oldIDNumberParsed = int.Parse(oldIDNumber);

            // Create 
            DeveloperContent newContent = new DeveloperContent();

            //First name
            Console.WriteLine("Enter First Name of Developer");
            string newFirstName = Console.ReadLine();
            newContent.FirstName = newFirstName;

            //Last name
            Console.WriteLine("Enter Last Name of Developer");
            string newLastName = Console.ReadLine();
            newContent.LastName = newLastName;

            //Full name
            string newfullName = $"{newLastName}, {newFirstName}";
            newContent.FullName = newfullName;

            //ID Number
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "These are all used IDNumbers.\n" +
                              "What IDNumber would you like to assign to this Developer?\n" +
                              "[The one they have now is suggested.]:");
            string chosenNumber = Console.ReadLine();
            int idNumber = int.Parse(chosenNumber);
            newContent.IDNumber = idNumber;

            //ID
            string lastFour = newLastName.Substring(0, newLastName.Length > 4 ? 4 : newLastName.Length);
            string id = $"{idNumber}{lastFour}";
            newContent.ID = id;

            //Password
            Console.WriteLine("Set a password for this Developer\n" +
                              "If unsure, put Mypassword");
            newContent.Password = Console.ReadLine();

            //Pluralsight
            Console.WriteLine("Does this Developer have access to Pluralsight? (y/n):");
            string pluralAsString = Console.ReadLine().ToLower();

            if (pluralAsString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }

            // Delete Old Content
            _contentDeveloperRepo.RemoveContentFromList(oldIDNumberParsed);
            // Add New Content
            _contentDeveloperRepo.AddDeveloperToList(newContent);
        }

        // Delete Existing Developer
        private void DeleteExistingDeveloper()
        {
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              "Enter the IDNumber of the Developer you would like to remove");

            string input = Console.ReadLine();
            int parsedInput = int.Parse(input);

            bool wasDeleted = _contentDeveloperRepo.RemoveContentFromList(parsedInput);

            if (wasDeleted)
            {
                Console.WriteLine($"{input} They were deleted.");
            }
            else
            {
                Console.WriteLine($"{input} Thats not a valid ID.");
            }
        }

        // Seed People Method
        private void SeedPeopleList()
        {
            DeveloperContent superadmin = new DeveloperContent(0, "Jeffrey", "Bezos", "Bezos, Jeffrey", "UltimatePassword", "CEO",
                true);
            DeveloperContent danny = new DeveloperContent(1, "Danny", "Way", "Way, Danny", "Way2go", "password", true);
            DeveloperContent frank = new DeveloperContent(2, "Frank", "Sinatra", "Sinatra, Frank", "Flymetothefrank", "password", true);

            _contentDeveloperRepo.AddDeveloperToList(superadmin);
            _contentDeveloperRepo.AddDeveloperToList(danny);
            _contentDeveloperRepo.AddDeveloperToList(frank);
        }

        // Team Menu - (while loop) (needs closed)
        private void TeamMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Team Management Menu");
                Console.WriteLine("Select a menu option:\n" +
                                  "1. Add a Team\n" +
                                  "2. Display All Teams\n" +
                                  "3. Display a Team Roster\n" +
                                  "4. Update a Team\n" +
                                  "5. Delete a Team\n" +
                                  "0. Return to Previous Menu");
                string inputA4 = Console.ReadLine();

                switch (inputA4)
                {
                    case "1":
                        // Add a Team
                        CreateNewTeam();
                        break;
                    case "2":
                        // Display All Teams
                        DisplayAllTeams();
                        break;
                    case "3":
                        // Display a Single Team in Depth
                        DisplaySingleTeam();
                        break;
                    case "4":
                        // Update a Team
                        UpdateATeam();
                        break;
                    case "5":
                        // Delete a team
                        DeleteATeam();
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Enter a valid number");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create a New Team
        private void CreateNewTeam()
        {
            Console.Clear();
            TeamContent newContent = new TeamContent();

            // Team Number
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "Assign TeamIdNumber to this Team\n" +
                              "[Please use a different number.]");
            string tInput = Console.ReadLine();
            int parsedTInput = int.Parse(tInput);

            newContent.TeamNumber = parsedTInput;

            // Team Name
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "Assign TeamName to this Team");
            string nInput = Console.ReadLine();

            newContent.TeamName = nInput;

            // Team Members
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              $"Which Developer or Developers would you like to add to the {nInput}s\n" +
                              "[Format is IDNumbers separated by spaces 'IDNumber IDNumber etc' ie '1 2 3 4']\n" +
                              "[If you don't want to add any leave it blank]\n" +
                              "[If you want to add one list one]");

            string input = Console.ReadLine();
            string[] pieces = input.Split(' ');

            List<int> intsList = new List<int>();
            int aNum;

            foreach (string s in pieces)
            {
                if (Int32.TryParse(s, out aNum))
                    intsList.Add(aNum);
            }

            int[] magicArray = intsList.ToArray();

            newContent.TeamMembers = magicArray;
            _contentTeamRepo.AddTeamToList(newContent);
        }

        // Display All Teams
        private void DisplayAllTeams()
        {
            Console.Clear();
            List<TeamContent> listOfContent = _contentTeamRepo.GetTeamList();

            foreach (TeamContent content in listOfContent)
            {
                Console.WriteLine($"Team Number: {content.TeamNumber}\n" +
                                  $"Team Name: {content.TeamName}");
            }
        }

        // Display a Single Team 
        private void DisplaySingleTeam()
        {
            Console.Clear();
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "Enter the Team Number of the Team you want");
            string teamNumber = Console.ReadLine();
            int teamNumberParsed = int.Parse(teamNumber);

            TeamContent teamContent = _contentTeamRepo.GetTeamByTeamNumber(teamNumberParsed);

            if (teamContent != null)
            {
                Console.WriteLine($"Team Number: {teamContent.TeamNumber}\n" +
                                  $"Team Name: {teamContent.TeamName}");
                for (int i = 0; i < teamContent.TeamMembers.Length; i++)
                {
                    DeveloperContent peopleContent = _contentDeveloperRepo.GetPeopleByIdNumber(teamContent.TeamMembers[i]);

                    if (peopleContent != null)
                    {
                        Console.WriteLine($"ID Number: {peopleContent.IDNumber}\n" +
                                          $"Full Name: {peopleContent.FullName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Team with that TeamNumber");
            }
        }

        // Update a Team
        private void UpdateATeam()
        {
            // Display all teams
            DisplayAllTeams();

            // Ask for TeamNumber of team to update
            Console.WriteLine("\n" +
                              "Enter the TeamNumber of the Team you want to update");

            // Get Number
            string oldTeamNumber = Console.ReadLine();
            int oldTeamNumberParsed = int.Parse(oldTeamNumber);

            // Make new object
            TeamContent newContent = new TeamContent();

            // Team Number
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What TeamNumber do you want to assign to this Team\n" +
                              "[Please try a different number.]");
            string tInput = Console.ReadLine();
            int parsedTInput = int.Parse(tInput);

            newContent.TeamNumber = parsedTInput;

            // Team Name
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What TeamName do you want to assign to this Team");
            string nInput = Console.ReadLine();

            newContent.TeamName = nInput;

            // Team Members
            DisplayAllIDNumberFullNameIDContent();
            Console.WriteLine("\n" +
                              $"Which Developer or developers would you like to add to the {nInput}s\n" +
                              "[Format is IDNumbers separated by spaces 'IDNumber IDNumber etc' ie '1 2 3 4']\n" +
                              "[If you don't want to add any leave it blank]\n" +
                              "[If you want to add one list one]");

            string input = Console.ReadLine();
            string[] pieces = input.Split(' ');

            List<int> intsList = new List<int>();
            int aNum;

            foreach (string s in pieces)
            {
                if (Int32.TryParse(s, out aNum))
                    intsList.Add(aNum);
            }

            int[] magicArray = intsList.ToArray();

            newContent.TeamMembers = magicArray;

            _contentTeamRepo.RemoveTeamFromList(oldTeamNumberParsed);
            _contentTeamRepo.AddTeamToList(newContent);

            Console.WriteLine("Team Updated! Press any key");
            Console.ReadLine();
        }

        // Delete a Team
        private void DeleteATeam()
        {
            // show all teams
            DisplayAllTeams();
            Console.WriteLine("\n" +
                              "What Team would you like to remove?");

            // team number
            string input = Console.ReadLine();
            int parsedInput = int.Parse(input);

            bool wasDeleted = _contentTeamRepo.RemoveTeamFromList(parsedInput);

            // Content was Deleted 
            if (wasDeleted)
            {
                Console.WriteLine("The content was deleted");
            }

            // Content was not deleted
            else
            {
                Console.WriteLine("The content was not deleted");
            }
        }

        // Seed Team Method
        public void SeedTeamList()
        {

            int[] blueTeam = { 1 };
            int[] redTeam = { 2 };

            TeamContent Blue = new TeamContent(1, "Blue", blueTeam);
            TeamContent Red = new TeamContent(2, "Red", redTeam);


            _contentTeamRepo.AddTeamToList(Blue);
            _contentTeamRepo.AddTeamToList(Red);
        }

       //Closing things out Finalllllllyyyyy
        private void LogMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Log. Choose an option.");
                Console.WriteLine("Select a menu option\n" +
                                  "1. Display Recent Log\n" +
                                  "2. Display Entire Log\n" +
                                  "3. Display Log for a Person\n" +
                                  "4. Display Log for an Action\n" +
                                  "0. Return to Previous Menu");
                string inputA5 = Console.ReadLine();

                switch (inputA5)
                {
                    case "1":
                        // Display Recent Log
                        break;
                    case "2":
                        // Display Entire Log
                        break;
                    case "3":
                        // Display Log for a Person
                        break;
                    case "4":
                        break;
                    case "0":
                        // Exit
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
            }

            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
    /*                 |`._         |\
                 `   `.  .    | `.    |`.
                  .    `.|`-. |   `-..'  \           _,.-'
                  '      `-. `.           \ /|   _,-'   /
              .--..'        `._`           ` |.-'      /
               \   |                                  /
            ,..'   '                                 /
            `.                coded by gengar       /                          
            _`.---                                 /
        _,-'               `.                 ,-  /"-._
      ,"                   | `.             ,'|   `    `.
    .'                     |   `.         .'  |    .     `.
  ,'                       '   (@`.     ,'@)  '    |       `.
'-.                    |`.  `.....-'    -----' _   |         .
 / ,   ________..'     '  `-._              _.'/   |         :
 ` '-"" _,.--"'         \   | `"+--......-+' //   j `"--.. , '
    `.'"    .'           `. |   |     |   / //    .       ` '
      `.   /               `'   |    j   /,.'     '
        \ /                  `-.|_   |_.-'       /\
         /                        `""          .'  \
        j                                           .
        |                                 _,        |
        |             ,^._            _.-"          '
        |          _.'    `'""`----`"'   `._       '
        j__     _,'                         `-.'-."`
          ',-.,' J */
}
                        
                        

