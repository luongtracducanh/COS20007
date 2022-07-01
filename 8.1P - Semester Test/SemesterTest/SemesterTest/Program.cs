using System;

namespace SemesterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Swinburne Library");
            Game pubg = new Game("PlayerUnknown's Battlegrounds", "KRAFTON, PUBG Corporation", "4/5");
            Game fn = new Game("Fortnite", "Epic Games, People Can Fly", "3/5");
            Book doawk = new Book("Diary of a Wimpy Kid", "Jeff Kinney", "1439582637");
            Book md = new Book("Moby-Dick", "Herman Melville", "1503280780");

            library.AddResource(pubg);
            library.AddResource(fn);
            library.AddResource(doawk);
            library.AddResource(md);

            pubg.OnLoan = true;
            md.OnLoan = true;

            Console.WriteLine("Fortnite is not on loan, should print true.");
            Console.WriteLine(library.HasResource("Fortnite"));
            Console.WriteLine("Moby-Dick is on loan, should print false.");
            Console.WriteLine(library.HasResource("Moby-Dick"));
            Console.ReadKey();
        }
    }
}
