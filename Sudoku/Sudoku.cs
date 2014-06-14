using System;

class Sudoku
{
	static void Main(string[] args)
	{
		WelcomeScreen();
		MainMenu();
		//Board gameBoard = new Board();
		//Console.Write(gameBoard);
	}

	static void WelcomeScreen()
	{
		Console.Clear();
		Console.WriteLine("Welcome to Simple Sudoku!");
		Console.WriteLine("Version 0.1");
		Console.WriteLine("Written By Alan Bishop");
		PromptToKeyPress();
	}

	static void PromptToKeyPress()
	{
		Console.WriteLine("\nPress Any Key To Continue");
		Console.ReadKey();
		Console.Clear();
	}

	static void MainMenu()
	{
		while (true)
		{
			Console.WriteLine("Select An Option:");
			Console.WriteLine("1. New Puzzle");
			Console.WriteLine("2. How To Play");
			Console.WriteLine("3. Exit");
			Console.Write("Enter Selection: ");
			string cmd = Console.ReadLine();
			int cmdN = 0;
			if (!Int32.TryParse(cmd, out cmdN) || cmdN > 3 || cmdN < 1)
			{
				DisplayInputError();
				continue;
			}
			if (cmdN == 1) { NewPuzzle(); }
			else if (cmdN == 2) { DisplayHelp(); }
			else Environment.Exit(0);
		}
	}

	static void DisplayHelp()
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


	static void NewPuzzle()
	{
		Board solvedBoard = newSolvedBoard();
		Board puzzleBoard = buildPuzzleBoard(solvedBoard,1);
		bool solved = false;
		while(!solved)
		{
			Console.Clear();
			Console.WriteLine(puzzleBoard.ToString() + "\n");
			Console.Write("Enter command (Type '?' for help): ");
			string cmd = Console.ReadLine();
			cmd = cmd.ToUpper();
			if (cmd[0] == 'Q') Environment.Exit(0);
			else if (cmd[0] == '?') DisplayHelp();
			else
			{
				DisplayInputError();
				continue;
			}
		}
	}

	static void DisplayInputError()
	{
		Console.WriteLine("Invalid Command, Try Again!");
		PromptToKeyPress();
	}

	public static Board buildPuzzleBoard(Board solvedBoard, int level)
	{
		Board newBoard = solvedBoard.copyBoard();

		switch (level)
		{
			case 1:

				break;
			case 2:

				break;
			case 3:

				break;
			case 4:

				break;
			default:
				//Just do easy
				break;
		}

		return newBoard;
	}

	public static Board newSolvedBoard()
	{
		Board newBoard = new Board();

		return newBoard;
	}

}


