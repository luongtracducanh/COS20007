using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Take : Command
    {
        public Take() : base(new string[] { "take" })
        {
        }

        bool ContainsString(string searched, string[] value)
        {
            foreach (string s in value)
            {
                if (searched.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private String TakeItemFrom(Player p, string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return "Could not find " + thingId + "\n";
            }

            GameObject _itemFound = container.Locate(thingId);
            Item _itemGrabbed = container.Take(thingId) as Item;

            if (_itemGrabbed == null)
            {
                return "You can't take " + _itemFound.ShortDescription + " with you.";
            }

            p.Inventory.Put(_itemGrabbed);
            return "You have taken the " + thingId + ".";
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;
            string _itemid;
            string _error = "Error in take input.";

            switch (text.Length)
            {
                case 1:
                    return "What do you want to take?";

                case 2:
                    if (ContainsString(text[1].ToLower(), new string[] { "north", "south", "east", "west", "up", "down" }))
                    {
                        return "Cannot " + text[0] + " direction!";
                    }
                    else
                    {
                        _itemid = text[1];
                        _container = p.Location;
                    }
                    break;

                case 3:
                    if (text[1].ToLower() != "at")
                    {
                        return "What do you want take from?";
                    }
                    _container = p;
                    _itemid = text[2];
                    break;

                case 4:
                    _container = FetchContainer(p, text[3]);
                    if (_container == null)
                    {
                        return "Could not find " + text[3] + ".";
                    }
                    _itemid = text[1];
                    break;

                default:
                    _container = null;
                    return _error;
            }
            return TakeItemFrom(p, _itemid, _container);
        }
    }
}
