using MenuLogic;
using System;
using System.Collections.Generic;

namespace Menu
{
    /// <summary>
    /// Menu class that inhereits from Dish, able to adapt based on new entries coming from 
    /// derived class is constant updates.
    /// </summary>
    public class Menu : MenuLogic.Dish
    {
        public Menu(string a, double b, TimeSpan c, string[] d, List<Ingredient> e) : base(a, b, c, d, e)
        {
            List<Dish> TheOrder = new List<Dish>();
            Ingredient I1 = new Ingredient("Eggs", 0.0, 0.0);
            Ingredient I2 = new Ingredient("Bacon", 0.0, 0.0);
            Ingredient I3 = new Ingredient("Flour", 0.0, 0.0);


            TimeSpan ts = new TimeSpan(0);
            List<Ingredient> L1 = new List<Ingredient>();
            List<Ingredient> L2 = new List<Ingredient>();
            List<Ingredient> L3 = new List<Ingredient>();
            L1.Add(I1);
            L2.Add(I2);
            L3.Add(I3);

            Dish d1 = new Dish("Waffles", 5.99, ts, null, L1);
            Dish d2 = new Dish("Bacon", 6.00, ts, null, L2);
            Dish d3 = new Dish("Pancakes", 5.99, ts, null, L3);

            Dishname.Add(1, d1);
            Dishname.Add(2, d2);
            Dishname.Add(3, d3);

            string option;
            Console.WriteLine("Choose From the following Menu: \n");
            foreach (KeyValuePair<int, Dish> entry in Dishname)
            {
                string Display = string.Format("Dish: {0} DishObject: {1}", entry.Key, entry.Value);
                Console.WriteLine(Display);
                Console.WriteLine("Information On Dish: ");
                entry.Value.DishSummary(entry.Value);
                Console.WriteLine("------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter Option...");
            option = Console.ReadLine();
            int.TryParse(option, out int choice);

            if (choice == 1)
            {
                Dishname.Add(1, d1);
            }
            else if (choice == 2)
            {
                Dishname.Add(2, d2);
            }
            else if (choice == 3)
            {
                Dishname.Add(3, d3);
            }
            else
            {
                Console.WriteLine("Not a valid choice.\n");
            }

        }




        /// <summary>
        /// Dictionary that will hold the style of food and the accomodating List that it can carry.
        /// </summary>
        private Dictionary<int, Dish> Dishname = new Dictionary<int, Dish>();

        /// <summary>
        /// Property setter for our dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDish(int key, Dish value)
        {
            if (Dishname.ContainsKey(key))
            {
                Dishname[key] = value;
            }
            else
            {
                Dishname.Add(key, value);
            }
        }

        /// <summary>
        /// Property getter for our dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dish GetDish(int key)
        {
            if (Dishname.ContainsKey(key))
            {
                return Dishname[key];
            }

            return null;
        }

        /// <summary>
        /// Add dish based on style (Appetizer, entree etc) into it's possible combinations (list)
        /// return bool on success or failure
        /// </summary>
        /// <param name="table"></param>
        /// <param name="newDish"></param>
        /// <returns></returns>
        bool AddDish(int index, Dish newDish)
        {
            if (Dishname.ContainsKey(index))
            {
               // Dishname.Add(newDish);
              
                return true;
            }
            return false;
        }

        /// <summary>
        /// C# trick to return a pair of key,value if ever required.
        /// </summary>
        public KeyValuePair<int, Dish> Users
        {
            set
            {
                SetDish(value.Key, value.Value);
            }
        }


    }
}
