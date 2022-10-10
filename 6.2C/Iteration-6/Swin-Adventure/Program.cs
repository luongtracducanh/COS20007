using System;

namespace Swin_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _input;
            Console.WriteLine("Welcome to Swin Adventure!\nYou have arrived in the Hallway.");
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine("How would you describe yourself?");
            string description = Console.ReadLine();
            Console.WriteLine("Welcome " + name + ", the " + description + "! Let's get into the game, shall we?");

            Player player = new Player(name, description);
            Bag bag = new Bag(new string[] {"small", "cloth", "bag"}, "bag", "A small cloth bag that can be used to carry items.");
            Item Gem = new Item(new string[] { "gem" }, "gem", "A gem that could be used to trade items.");
            Item Sword = new Item(new string[] { "sword" }, "sword", "A sword that can be wield to defeat enemies.");
            Item Shield = new Item(new string[] { "shield" }, "shield", "A shield that can protect you from enemies.");
            Item Poison = new Item(new string[] { "poison" }, "poison", "A dangerous potion that can be used to defeat enemies.");
            Location PotionRoom = new Location("potion room", "You're at potion room, a place where you can find different potions.");


            player.Inventory.Put(Sword);
            player.Inventory.Put(Shield);
            player.Inventory.Put(bag);
            bag.Inventory.Put(Gem);
            PotionRoom.Inventory.Put(Poison);
            player.Location = PotionRoom;
            player.Inventory.Put(Poison);

            Command l = new Look();

            while (true)
            {
                Console.Write("Command -> ");
                _input = Console.ReadLine();
                if (_input.ToLower() != "quit")
                {
                    Console.WriteLine(l.Execute(player, _input.Split()));
                }
                else
                {
                    Console.WriteLine("Quitting the game...");
                    break;
                }
            }
        }
    }
}
