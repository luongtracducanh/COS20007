using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory;

        public Location(string name, string desc) : base(new string[] {"location", "place", "room"}, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
