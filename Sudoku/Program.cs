using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeScreen();
        Console.ReadKey();
        Board gameBoard = new Board();
        Console.Write(gameBoard);
    }

    static void WelcomeScreen()
    {
        Console.WriteLine("Welcome to Sudoku!");
        Console.WriteLine("Written By Alan Bishop");
        Console.WriteLine("\nPress Any Key To Continue");
    }

}


