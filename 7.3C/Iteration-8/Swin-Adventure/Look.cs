using System;

namespace Swin_Adventure
{
    public class Look : Command
    {
        public Look() : base(new string[] { "look" })
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

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string _itemid;
            string error = "Error in look input.";

            switch (text.Length)
            {
                case 1:
                    _container = p;
                    switch (text[0])
                    {
                        case "look":
                            _itemid = "room";
                            break;
                        default:
                            _itemid = text[0];
                            break;
                    }
                    break;

                case 2:
                    if (ContainsString(text[1].ToLower(), new string[] {"north", "south", "east", "west", "up", "down", "around"  }))
                    {
                        _itemid = text[1];
                        _container = p;
                    }
                    else
                    {
                        _itemid = text[1];
                        _container = p;
                    }
                    break;

                case 3:
                    if (text[1].ToLower() != "at")
                    {
                        return "What do you want to look at?";
                    }
                    _container = p;
                    _itemid = text[2];
                    break;

                case 4:
                    switch (text[0])
                    {
                        case "examine":
                            _container = FetchContainer(p, text[3]);
                            if (_container == null)
                            {
                                return "Could not find " + text[3] + ".";
                            }
                            _itemid = text[1];
                            break;
                        default:
                            return error;
                    }
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                    {
                        return "Could not find " + text[4] + ".";
                    }
                    _itemid = text[2];
                    break;

                default:
                    return error;
            }
            return LookAtIn(_itemid, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p != null)
            {
                return p.Locate(containerId) as IHaveInventory;
            }
            return null;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).LongDescription;
            }
            return "Could not find " + thingId + ".";
        }
    }
}
