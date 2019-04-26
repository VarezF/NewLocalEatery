using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuLogic;

namespace Actors
{
    internal class Cook : User
    {
        /// <summary>
        /// Constructor for a 'cook' user object.
        /// </summary>
        /// <param name="_name">Name of the cook.</param>
        public Cook (String _name)
        {
            this.setName(_name);
        }

        public bool ReceiveOrder(Order newOrder)
        {
            if (newOrder != null)
            {
                newOrder.PlaceOrder(newOrder);
                return true;
            }
            return false;
        }
    }
}
