using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Bag : Item
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
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

        public string FullDescription
        {
            get => "A bag endorned with a six-sided star inside a circle";
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}
