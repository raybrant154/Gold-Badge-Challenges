using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class MenuRepo
    {
        private List<Menu> _content = new List<Menu>();

        //Create
        public void AddItemToMenu(Menu content)
        {
            
            _content.Add(content);
        }

        //Read
        public List<Menu> GetMenuList()
        {
            return _content;
        }

        //Update

        public bool UpdateMenu(int originalMealNumber, Menu newItem)
        {
            Menu oldItem = GetItemByNumber(originalMealNumber);

            if(oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveItemFromMenu(int mealNumber)
        {
            Menu content = GetItemByNumber(mealNumber);

            if(content == null)
            {
                return false;
            }

            int menuCount = _content.Count;
            _content.Remove(content);

            if(menuCount > _content.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Helper method
        public Menu GetItemByNumber(int mealNumber)
        {
            foreach (Menu content in _content)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }

            return null;
        }
        
    }
}
