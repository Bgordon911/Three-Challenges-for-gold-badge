using CafeChallenge;
using MenuRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeUnitTest
{

    [TestClass]
    public class CafeTest
    {
        private MenuRepo _repo = new MenuRepo();
        //private Menu _menu;

        [TestMethod]
        public void AddTooList_ShouldGetNotNull()
        {

            Menu newItem = new Menu();
            newItem.MealNumber = 1;
            newItem.MealName = "steak";

            _repo.AddMealsToLists(newItem);
            Menu mealFromDirectory = _repo.GetMealbyNumber(1);

            Assert.IsNotNull(mealFromDirectory);

        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        { Menu meal = new Menu();
            meal.MealNumber = 2;
            _repo.AddMealsToLists(meal);
            bool deleteResult = _repo.RemovMealFromList(meal.MealNumber);
            Assert.IsTrue(deleteResult);
        }

        


    }
}
