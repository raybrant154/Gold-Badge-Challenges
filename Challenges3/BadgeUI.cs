using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges3
{
    public class BadgeUI
    {
        private readonly BadgeRepo _badgeinfo = new BadgeRepo();


        public void Start()
        {

            BadgeMenu();

        }

        private void BadgeMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Badge Menu - What would you like to do?\n" +
                    "1.) Add a badge\n" +
                    "2.) Edit a badge\n" +
                    "3.) List all badges\n" +
                    "4.) Exit");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateBadge();
                        break;

                    case "2":
                        EditBadge();
                        break;

                    case "3":
                        SeeAllBadges();
                        break;

                    case "4":
                        keepRunning = false;
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey();
            }

        }


        //private void DisplayAllBadges()
        //{
        //    Console.Clear();
        //    Dictionary<int, List<string>> allBadges = _badgeinfo.SeeBadgeList();

        //    Dictionary<int, List<string>>.KeyCollection IDs = _badgeinfo._badgeAndDoor.Keys;
        //    Dictionary<int, List<string>>.ValueCollection Doors = _badgeinfo._badgeAndDoor.Values;

        //    foreach (KeyValuePair<int, List<string>> _badgeinfo in allBadges)
        //    {
        //        Console.WriteLine($"{IDs} {Doors}");
        //    }


        //}
        public void SeeAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Key");
            Console.WriteLine($"{"Badge ID",-10}{"Door Access"}");
            Dictionary<int, List<string>> badgeList = _badgeinfo.SeeBadgeList();
            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                string doorPair = string.Join(", ", badge.Value.ToArray());
                Console.WriteLine($"{badge.Key,-10}{doorPair}");
            }
        }



        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you'd like to update?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            if (_badgeinfo.HasKey(badgeID)) ;
            {
                bool stayRunning = true;
                while (stayRunning)
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to edit about this badge?\n" +
                        "1.) Add doors\n" +
                        "2.) Remove a door\n" +
                        "3.) Remove all doors\n" +
                        "4.) Return to menu");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddDoorToBadge(badgeID);
                            Console.WriteLine("The door has been added.");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("Which door do you want to remove");
                            string doorInput = Console.ReadLine();
                            _badgeinfo.RemoveDoor(badgeID, doorInput);
                            Console.WriteLine("The door has been removed");
                            Console.ReadLine();
                            break;

                        case "3":
                            _badgeinfo.EraseAllDoors(badgeID);
                            Console.WriteLine("All doors have been removed");
                            Console.ReadLine();
                            break;

                        case "4":
                            stayRunning = false;
                            break;
                    }
                }
            }




        }

        public void AddDoorToBadge(int badgeID)
        {
            Console.WriteLine("Enter door name");
            string input = Console.ReadLine();

            _badgeinfo.AddDoor(badgeID, input);
        }

        public void CreateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge's ID?");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            List<string> badeList = new List<string>();
            _badgeinfo.NewBadge(badgeID);
            AddDoorToBadge(badgeID);
        }



    }
}
