using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage?. ");
        string UserInput = Console.ReadLine();
        int grade;
        string letter = "";
        if (int.TryParse(UserInput, out grade))

            if (grade >= 90)
            {
                letter = "A";
            }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }
        
         {
            Console.WriteLine($"your grade is: {letter}");
        }
        
        if (grade > 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("You did not pass the course. Please try again next time.");
        }
    }
}