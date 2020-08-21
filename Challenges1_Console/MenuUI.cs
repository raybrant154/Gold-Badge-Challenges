using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Challenges1_Console
{
    class MenuUI
    {
        private readonly MenuRepo _content = new MenuRepo();

        public void Start()
        {
            FillMenu();
            ManagerMenu();
        }

        private void ManagerMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Manager Menu Controller - What would you like to do?\n" +
                    "1.) Create new menu item\n" +
                    "2.) Update a menu item\n" +
                    "3.) Delete a menu item\n" +
                    "4.) Display full menu\n" +
                    "5.) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewItem();
                        break;

                    case "2":
                        UpdateMenuItem();
                        break;

                    case "3":
                        DeleteMenuItem();
                        break;

                    case "4":
                        DisplayFullMenu();
                        break;

                    case "5":
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select an option from the list");
                        break;
                }

                Console.Clear();
               
            }
        }

        private void CreateNewItem()
        {
            Menu newItem = new Menu();

            Console.WriteLine("What is the meals number? ");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the meals name?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the meals description?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("What are the ingredients in the meal?");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the price of the meal?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            _content.AddItemToMenu(newItem);


        }

        private void DisplayFullMenu()
        {
            Console.Clear();
            List<Menu> fullMenu = _content.GetMenuList();

            foreach(Menu content in fullMenu)
            {
                Console.WriteLine($"The meal name is {content.MealName}. The description is {content.Description}. The ingredients include {content.Ingredients}. The meal number is {content.MealNumber}. The price for the meal is {content.Price}.");
            }

            Console.ReadLine();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            DisplayFullMenu();
            Console.WriteLine("What is the meal number of the meal you wish to delete?");

            int input = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _content.RemoveItemFromMenu(input);

            if (wasDeleted)
            {
                Console.WriteLine("The meal has been terminated.");
            }
            else
            {
                Console.WriteLine("The meal was not able to be terminated.");
            }
            Console.ReadLine();
        }

        private void UpdateMenuItem()
        {
            Console.Clear();
            DisplayFullMenu();
            Console.WriteLine("What is the meal number of the meal you'd like to update?");

            int input = Convert.ToInt32(Console.ReadLine());

            Menu newItem = new Menu();

            Console.WriteLine("What is the meals updated number? ");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the meals updated name?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the meals updated description?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("What are the updated ingredients in the meal?");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the updated price of the meal?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

          bool wasUpdated =  _content.UpdateMenu(input, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("The item has been updated");
            }
            else
            {
                Console.WriteLine("There was an issue updating the item. Please try again.");
            }
            Console.ReadLine();
        }

        private void FillMenu()
        {
            Menu bigBurger = new Menu(5, "Big Burger", "It's a big burger with a side of fries", "Insert the ingredients for your favorite burger here", 4.99);

            _content.AddItemToMenu(bigBurger);
            
        }


    }
}
