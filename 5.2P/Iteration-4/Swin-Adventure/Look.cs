using System;

namespace Swin_Adventure
{
    public class Look : Command
    {
        public Look() :
            base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text[0].ToLower() != "look")
                return "Error in look input.";

            if (text[1].ToLower() != "at")
                return "What do you want to look at?";

            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }
            }

            IHaveInventory _container;

            switch (text.Length)
            {
                case 3:
                    _container = p as IHaveInventory;
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    break;

                default:
                    _container = null;
                    break;
            }

            string _itemid = text[2];
            if (_container == null)
                return "Could not find " + text[4] + ".";
            return LookAtIn(_itemid, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).LongDescription;

            return "Could not find " + thingId + ".";
        }
    }
}
