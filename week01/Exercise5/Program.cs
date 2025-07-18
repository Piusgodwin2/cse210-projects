using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program! ");
        }

        UserName();

        static void UserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }

        // Call the SquareNumber method
        {
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine()); // to covert input to int

            int squared = SquareNumber(input);

            Console.WriteLine($"The square of {input} is {squared}");
        }

        //  This accepts an int and returns the square
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // DisplayResult - Accepts the user's name and the squared number and displays them.
    {
        // Ask for the user's name
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        // Ask for a number to square
        Console.Write("Enter a number to square: ");
        string input = Console.ReadLine();

        try
        {
            int number = int.Parse(input);         // Convert input to int
            int squared = SquaredNumber(number);    // Call square method
            Console.WriteLine($"Hello {userName}, the square of your number is {squared}.");
        }
        catch (FormatException)
        {
            Console.WriteLine(" Please enter a valid whole number.");
        }
    }

    // return the square of a number
    static int SquaredNumber(int number)
    {
        return number * number;
    }
}


    

    }