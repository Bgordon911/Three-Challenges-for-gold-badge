using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadgeRepo;

namespace BadgeAppConsole
{
    class ProgramUI
    {
        private BadRepository _badgeRepo = new BadRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Badges\n" +
                    "2. Update Existing Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateExistingBadge();
                        //Get a badge number

                        //Which door is accesable 
                        //Ask user to remove or a add single door
                        //option 1; add
                        //  Get door from user 
                        //  Add to list and dictionary
                        //option 2; remove
                        //  Get door from user
                        //   Check doors is in list
                        //  if true remove door
                        // else tell user u need help
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;



                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        public void CreateNewBadge()
        {
            Console.Clear();
            Badge userBadge = new Badge();
            //Ask user for new badge number
            Console.WriteLine("What is the number on the badge?: ");
            //assign user response to userBadge.BadgeID
            string userInputID = Console.ReadLine();
            int inputIdAsInt = int.Parse(userInputID);
            userBadge.BadgeID = inputIdAsInt;
            //Continue asking for doors (loop) as they want to add.
            bool keepAsking = true;
            while (keepAsking)
            {
                //Ask user for a door they want to add
                Console.WriteLine("What doors do you want to add?");
                //Add door to userBadge.Doors
                string Door = Console.ReadLine();
                userBadge.Doors.Add(Door);
                //Ask the user to continue?
                Console.WriteLine("Do you want to add another door? y/n");
                string userContinue = Console.ReadLine().ToUpper();
                //if not yes, keepAsking is false
                if (!(userContinue == "Y"))
                {
                    keepAsking = false;
                }
            }
            //Add the badge to the Dictionay and Repo.
            _badgeRepo.AddToDictionary(userBadge);

        }
        private void UpdateExistingBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int userinput = Int32.Parse(Console.ReadLine());
            Badge badge = _badgeRepo.GetbadgebyNumber(userinput);
            Console.WriteLine(badge.BadgeID + "has acesss to doors");
            foreach (string door in badge.Doors) { Console.WriteLine(door); }
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");
            userinput = int.Parse(Console.ReadLine());
            switch (userinput)
            {
                case 1:
                    Console.WriteLine("What door would you like to remove?");
                    string doorToRemove = Console.ReadLine();
                    badge.Doors.Remove(doorToRemove);
                    Console.WriteLine("Door has been successfully removed");
                    Console.WriteLine(badge.BadgeID + "has acesss to doors");
                    foreach (string door in badge.Doors) { Console.WriteLine(door); }
                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("What door would you like to Add?");
                    string doorToAdd = Console.ReadLine();
                    badge.Doors.Add(doorToAdd);
                    Console.WriteLine("Door has been successfully Added");
                    Console.WriteLine(badge.BadgeID + "has acesss to doors");
                    foreach (string door in badge.Doors) { Console.WriteLine(door); }
                    Console.ReadLine();
                    break;

            }




        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> _badges = _badgeRepo.ReturnDictionary();
            List<int> keys = _badges.Keys.ToList();
            foreach (int key in keys)
            {
                List<string> doors = _badges[key];
                Console.WriteLine(key + ":");
                foreach (string door in doors)
                {
                    Console.WriteLine(door + "");
                }

            }
            Console.WriteLine("Press Any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void SeedContent()
        {
            Badge newBadgeOne = new Badge(13546, new List<string>() { "A1", "A2" },"Badge1");
            Badge newBadgeTwo = new Badge(24357, new List<string>() { "A1", "A2", "B1" },"Badge2");
            _badgeRepo.AddToDictionary(newBadgeOne);
            _badgeRepo.AddToDictionary(newBadgeTwo);
        }
    }
}




