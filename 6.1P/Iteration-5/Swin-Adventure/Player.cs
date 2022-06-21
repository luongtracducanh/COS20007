using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        Inventory _inventory;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string LongDescription
        {
            get => base.LongDescription;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory 
        { 
            get => _inventory; 
        }
    }
}
