using CafeChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRep
{
    public class MenuRepo
    {
        private List<Menu> _listOfMenu = new List<Menu>();
        

        // Create
        public void AddMealsToLists(Menu meal)
        {
            _listOfMenu.Add(meal);
        }

        // Read
        public List<Menu> GetMealList()
        {
            return _listOfMenu;
        }

        // Delete
        public bool RemovMealFromList(int mealNumber)
        {
            Menu meal = GetMealbyNumber(mealNumber);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _listOfMenu.Count;
            _listOfMenu.Remove(meal);

            if (initialCount > _listOfMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper
        public Menu GetMealbyNumber(int mealNum)
        {
            foreach (Menu meal in _listOfMenu)
            {
                if (meal.MealNumber == mealNum)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}