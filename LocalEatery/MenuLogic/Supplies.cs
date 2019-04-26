using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLogic
{
    class Supplies
    {
        private Dictionary<string, Ingredient> supply;

        public Supplies()
        {
            this.supply.Add("eggs", new Ingredient("Eggs", 0.0, 20));
            this.supply.Add("Milk", new Ingredient("Eggs", 0.0, 30));
            this.supply.Add("Lettuce", new Ingredient("Eggs", 0.0, 5));
            // etc.
        }

        /// <summary>
        /// Event Handler to Notify Inventory Ran Out of Supply
        /// </summary>
        /// <param name="sender">Supplies</param>
        /// <param name="e">Message</param>
        public delegate void SupplyRanOut(object sender, EventArgs e);
        public event SupplyRanOut OnSupplyDimenished;
        
        // Methods

        /// <summary>
        /// Update the supply ammount for an ingredient
        /// </summary>
        /// <param name="i"></param>
        public void Update(Ingredient i)
        {
            this.supply[i.Name].UnitAmmount -= i.UnitAmmount;
            if (this.supply[i.Name].UnitAmmount <= 5)
            {
                // throw event, ingredient low
            }
        }
    }
}
