using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        PromtUserBirthYear(out int birthYear);
        int squared = SquareNumber(favoriteNumber);
        DisplayResult(name, squared, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter in your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squared, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
        int age = DateTime.Now.Year - birthYear;
        Console.WriteLine($"{name} you will turn {age} this year!");
    }
}
