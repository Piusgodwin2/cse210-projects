using System;

class Program
{
    static void Main(string [] args)
    {
         Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random random = new Random();
        int magicNumber = random.Next(1, 100); // 1 to 100 inclusive

        int guess;
        int guessCount = 0; // keep track of guesses.

        Console.WriteLine("I Guessed a number between 1 and 100.");
        Console.WriteLine("Try to guess it!");

        // Loop until the correct guess is made
        while (true)
        {
            try // this try block to handle any potential errors in user input
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine()); // may throw an error

                guessCount++; // Increses the guess count

                if (guess < magicNumber)
                {
                    Console.WriteLine("Guess higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Guess lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! Congratulations! you made {guessCount} attempts.");
                    break; // Exit the loop
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
            
        }
    }
}
