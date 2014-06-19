/* ConsoleMode.cs
 * 
 * Console Game Logic For Sudoku Puzzle Program
 * (Prompts, Game Generation, Flow Of Control)
 * 
 * Written By Alan Bishop 6/14/14
 */ 

using System;

class ConsoleMode
{
	public static void WelcomeScreen()
	{
		Console.Clear();
		Console.WriteLine("Welcome to Simple Sudoku!");
		Console.WriteLine("Version 0.1");
		Console.WriteLine("Written By Alan Bishop");
		PromptToKeyPress();
	}

	public static void MainMenu()
	{
		while (true)
		{
			Console.WriteLine("Select An Option:");
			Console.WriteLine("1. New Puzzle");
			Console.WriteLine("2. How To Play");
			Console.WriteLine("3. Exit");
			Console.Write("Enter Selection: ");
			int cmdN = GetInputInt(1, 3);
			if (cmdN == -1) { DisplayInputError(); continue; }
			if (cmdN == 1)  { SelectPuzzle(); }
			else if (cmdN == 2) { DisplayHelp(); }
			else Environment.Exit(0);
		}
	}

	public static void SelectPuzzle()
	{
		int level = 0;
		while (level < 1 || level > 4)
		{
			Console.Clear();
			Console.Write("Select Puzzle Level:\n" + "1. Easy\n2. Medium\n3. Hard\n4. Evil\n");
			Console.Write("Enter Number: ");
			level = GetInputInt(1, 4);
			if (level == -1) { DisplayInputError(); continue; }
			NewPuzzle(level);
		}
	}

	public static void DisplayHelp()
	{
		Console.Clear();
		Console.WriteLine("Solve a 9x9 grid of numbers by making every, row, column and 3x3 grid contain numbers 1-9");
		Console.WriteLine("Input done via command prompt (Ex: 'A B 4' would place a 4 in row A, column B)");
		Console.WriteLine("Type 'X' to have the computer tell you if you have any errors");
		Console.WriteLine("Type 'S' to have computer solve the puzzle for you");
		Console.WriteLine("Type '?' for help");
		Console.WriteLine("Type 'Q' to quit the program during gameplay");
		PromptToKeyPress();
	}


	public static void NewPuzzle(int puzzleLevel)
	{
		Board solvedBoard = SudokuGenerator.NewSolvedBoard();
		Board puzzleBoard = SudokuGenerator.buildPuzzleBoard(solvedBoard, 1);
		bool solved = false;
		while (!solved)
		{
			Console.Clear();
			Console.WriteLine(puzzleBoard.ToString() + "\n");
			Console.Write("Enter command (Type '?' for help): ");
			string cmd = Console.ReadLine();
			cmd = cmd.ToUpper();
			if (cmd == null) { DisplayInputError(); }
			if (cmd[0] == 'Q') Environment.Exit(0);
			else if (cmd[0] == '?') DisplayHelp();
			else if (cmd[0] == 'S') { DisplaySolvedPuzzle(puzzleBoard, solvedBoard); return; }
			else if (ValidMove(cmd)) solved = puzzleBoard.IsSolved();
			else { DisplayInputError(); continue; }
		}
	}
	public static void DisplaySolvedPuzzle(Board puzzleBoard, Board solvedBoard)
	{
		Console.Clear();
		Console.WriteLine("Puzzle Board:");
		Console.WriteLine(puzzleBoard + "\n");
		Console.WriteLine("Solution:\n");
		Console.WriteLine(solvedBoard + "\n");
		PromptToKeyPress();
	}

	private static void PromptToKeyPress()
	{
		Console.WriteLine("\nPress Any Key To Continue");
		Console.ReadKey();
		Console.Clear();
	}

	public static int GetInputInt(int min, int max)
	{
		int inputValue = 0;
		string input = Console.ReadLine();
		if (!Int32.TryParse(input, out inputValue) || inputValue > max || inputValue < min)
		{
			inputValue = -1;
		}
		return inputValue;
	}

	private static void DisplayInputError()
	{
		Console.WriteLine("Invalid Command, Try Again!");
		PromptToKeyPress();
	}

	private static bool ValidMove(string cmd)
	{
		return false;
	}


}

