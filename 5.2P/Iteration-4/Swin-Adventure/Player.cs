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
            get => "You are " + Name + ", a mere shadow in the literature club.";
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            return _inventory.Fetch(id);
        }

        public Inventory Inventory 
        { 
            get => _inventory; 
        }
    }
}
