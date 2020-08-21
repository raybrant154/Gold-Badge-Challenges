using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1Tests
{
    [TestClass]
    public class Challenge1UnitTests
    {
        private MenuRepo _menuRepo;
        private Menu _menuContent;

        [TestInitialize]

        public void Arrange()
        {
            _menuRepo = new MenuRepo();
            _menuContent = new Menu(2, "Big Burger", "It's a big burger", "ingredient list", 2.45);

            _menuRepo.AddItemToMenu(_menuContent);
        }
        
        [TestMethod]

        public void GetMenu_OutputShowAllMenuItems()
        {
            MenuRepo testRepo = new MenuRepo();
            Menu newMenu = new Menu(2, "Big Burger", "It's a big burger", "ingredient list", 2.45);
            testRepo.AddItemToMenu(newMenu);


            List<Menu> menuList = testRepo.GetMenuList();

            bool menuListAdditions = menuList.Contains(newMenu);

            Assert.IsTrue(menuListAdditions);


        }

        [TestMethod]
        public void GetMenu_RemoveItemFromMenu()
        {
            MenuRepo testRepo = new MenuRepo();
            Menu newMenu = new Menu(2, "Big Burger", "It's a big burger", "ingredient list", 2.45);
            testRepo.RemoveItemFromMenu(2);


            List<Menu> menuList = testRepo.GetMenuList();

            Assert.IsNull(menuList);


        }








    }
}
