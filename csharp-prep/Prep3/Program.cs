using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;
        while (guess != magicNumber)
        {
            Console.Write("What is the Magic Number? ");
            guess = int.Parse(Console.ReadLine());
            if (guess > magicNumber)
            {
                Console.Write("Lower. ");
            }
            else if (guess < magicNumber)
            {
                Console.Write("Higher! ");
            }
            else
            {
                Console.Write("You guessed it!");
            }

        }
    }
}