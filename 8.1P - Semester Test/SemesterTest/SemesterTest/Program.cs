using System;

namespace SemesterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Swinburne Library");
            Book book1 = new Book("Diary of a Wimpy Kid", "Jeff Kinney", "1439582637");
            Book book2 = new Book("Moby-Dick", "Herman Melville", "1503280780");
            Game game1 = new Game("PlayerUnknown's Battlegrounds", "KRAFTON, PUBG Corporation", "4/5");
            Game game2 = new Game("Fortnite", "Epic Games, People Can Fly", "3/5");

            library.AddResource(book1);
            library.AddResource(book2);
            library.AddResource(game1);
            library.AddResource(game2);

            book1.OnLoan = false;
            game1.OnLoan = false;
            
            book2.OnLoan = true;
            game2.OnLoan = true;

            Console.WriteLine("Diary of a Wimpy Kid is not on loan, should print true.");
            Console.WriteLine(library.HasResource("Diary of a Wimpy Kid"));

            Console.WriteLine("PlayerUnknown's Battlegrounds is not on loan, should print true.");
            Console.WriteLine(library.HasResource("PlayerUnknown's Battlegrounds"));

            Console.WriteLine("Moby-Dick is on loan, should print false.");
            Console.WriteLine(library.HasResource("Moby-Dick"));

            Console.WriteLine("Fortnite is on loan, should print false.");
            Console.WriteLine(library.HasResource("Fortnite"));

            Console.ReadKey();
        }
    }
}
