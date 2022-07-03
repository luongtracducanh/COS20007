using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {

            if (_items.Count == 0)
                return false;

            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                    return true;
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Item itemFound = i;
                    _items.Remove(i);
                    return itemFound;
                }
            }
            return null;
        }

        public Item Fetch(String id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                    return i;
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string list = string.Empty;
                foreach (Item i in _items)
                {
                    list = list + "    " + i.ShortDescription + System.Environment.NewLine;
                }
                return list;
            }
        }

        public int Count
        {
            get { return _items.Count; }
        }
    }
}
