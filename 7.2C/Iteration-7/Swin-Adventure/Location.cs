using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory;
        List<Path> _paths;

        public Location(string name, string desc) : base(new string[] { "location", "place", "room", "around" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Location(string name, string desc, List<Path> paths) : this(name, desc)
        {
            _paths = paths;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }

            return _inventory.Fetch(id);
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
    }    
}
