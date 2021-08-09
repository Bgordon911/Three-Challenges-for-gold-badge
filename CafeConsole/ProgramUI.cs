using CafeChallenge;
using MenuRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Class
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add meal to menu\n" +
                    "2. Veiw all meals\n" +
                    "3. View meal by meal number\n" +
                    "4. Delete Exisiting Meal\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Create new meal
                        CreateNewMeal();
                        break;
                    case "2":
                        //View all meals
                        DisplayAllMeals();
                        break;
                    case "3":
                        //View all meals by number
                        DisplayMealsByNumber();
                        break;
                    case "4":
                        //Delete a meal
                        DeleteMeals();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid choice!");
                        break;
                }


                Console.ReadKey();
                Console.Clear();
            }
        }


        private void CreateNewMeal()
        {

            Console.Clear();
            Menu newMeal = new Menu();

            Console.WriteLine("Enter the number for the meals:");
            string numberAsString = Console.ReadLine();
            newMeal.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the name of the meal:");

            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of the meal:");
            newMeal.MealDiscription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the meals:");



            newMeal.MealIngredients = Console.ReadLine();
            Console.WriteLine("Enter the price of the meal:");
            string priceAsString = Console.ReadLine();
            newMeal.MealPrice = double.Parse(priceAsString);

            _menuRepo.AddMealsToLists(newMeal);
        }
        private void DisplayAllMeals()
        {
            Console.Clear();
            List<Menu> listOfMenu = _menuRepo.GetMealList();
            foreach (Menu meal in listOfMenu)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n");
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
        private void DisplayMealsByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you wish to see:");
            string numberAsString = Console.ReadLine();
            int mealNumber = int.Parse(numberAsString);

            Menu meal = _menuRepo.GetMealbyNumber(mealNumber);
            if (meal != null)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                    $"Meal Name: {meal.MealName}\n" +
                    $"Meal Description: {meal.MealDiscription}\n" +
                    $"Meal Ingredients: {meal.MealIngredients}\n" +
                    $"Meal Price: ${meal.MealPrice}");
            }
            else
            {
                Console.WriteLine("No meal by that number!");
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();

        }
        private void DeleteMeals()
        {
            DisplayAllMeals();
            Console.WriteLine("Enter thenumber of the meal you wish to remove:");
            string numAsString = Console.ReadLine();

            int mealNumber = int.Parse(numAsString);
            bool wasDeleted = _menuRepo.RemovMealFromList(mealNumber);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was removed successfully!");
            }
            else
            {
                Console.WriteLine("The meal could not be removed!");
            }
        }


        private void SeedContent()
        {
            Menu cheeseburger = new Menu(1, "cheeseburger", "bun", "cheese", 3.00);
            _menuRepo.AddMealsToLists(cheeseburger);
        }
    }
}
