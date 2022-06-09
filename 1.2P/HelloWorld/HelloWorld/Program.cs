using System;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[4];
            string name;

            myMessage = new Message("Hello World - from Message Object");
            myMessage.Print();

            messages[0] = new Message("Welcome back oh great educator!");
            messages[1] = new Message("What a lovely name");
            messages[2] = new Message("Great name");
            messages[3] = new Message("That is a silly name");

            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();

            if (name.ToLower() == "bach")
            {
                messages[0].Print();
            }

            else if (name.ToLower() == "minh")
            {
                messages[1].Print();
            }

            else if (name.ToLower() == "tuan")
            {
                messages[2].Print();
            }

            else
            {
                messages[3].Print();
            }

            Console.ReadLine();
        }
    }
}
