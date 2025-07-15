using System;
using System.Collections.Generic;
using System.Linq; // for Sum(), Average(), Max()

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        string userInput;

        Console.WriteLine("Please enter numbers to add to the list.");
        Console.WriteLine("Type '0' when you're done to see the results.");

        while (true)
        {
            try // the try block is used to catch exceptions
            {
                Console.Write("Enter a number: ");
                userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    break; // Stop when user enters 0
                }

                int number = int.Parse(userInput);
                numbers.Add(number);
            }
            catch (FormatException)
            {
                Console.WriteLine(" Invalid input. Please enter a whole number.");
            }
        }

        // After the loop, show results
        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int highest = numbers.Max();

            Console.WriteLine(" You entered the following numbers:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average:F2}"); // rounded to 2 decimal places
            Console.WriteLine($"Maximum: {highest}");
        }
        else
        {
            Console.WriteLine(" No numbers were entered.");
        }
    }
}
