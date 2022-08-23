using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        Inventory _inventory;
        Location _location;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string LongDescription
        {
            get
            {
                string desc = new string("");
                desc = desc + "You are " + Name + ", " + LongDescription + "\nYou are carrying:\n" + _inventory.ItemList;
                return desc;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public void Move(Path path)
        {
            if (path.Destination != null)
            {
                _location = path.Destination;
            }
        }

        public GameObject Take(string id)
        {
            return Inventory.Take(id);
        }
    }
}
