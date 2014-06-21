
/* SudokuGenerator.cs
 * 
 * Logic for generating SudokuBoard objects
 * Creates both solved boards and different levels of puzzles
 * 
 * Written By Alan Bishop 6/14/14
 */

using System;
using System.Collections.Generic;
using System.Linq;


class SudokuGenerator
{
	private const int EASY_BLANKS = 40;
	private const int MEDIUM_BLANKS = 45;
	private const int HARD_BLANKS = 50;
	private const int EVIL_BLANKS = 55;


	public static Board buildPuzzleBoard(Board solvedBoard, int level)
	{
		Board newBoard = solvedBoard.CopyBoard();

		switch (level)
		{
			case 1:
				BlankNCells(newBoard, EASY_BLANKS);
				break;
			case 2:
				BlankNCells(newBoard, MEDIUM_BLANKS);
				break;
			case 3:
				BlankNCells(newBoard, HARD_BLANKS);
				break;
			case 4:
				BlankNCells(newBoard, EVIL_BLANKS);
				break;
			default:
				//Just do easy
				BlankNCells(newBoard, EASY_BLANKS);
				break;
		}
		//return solvedBoard;
		return newBoard;
	}

	//Generate a new solved board
	public static Board NewSolvedBoard()
	{
		Board newBoard = new Board();

		//Setup possible values for each cell
		List<int>[,] possibilities = GenerateDefaultPossibilities();

		//Create a solved board
		SolveBoard(newBoard, 0, 0, possibilities);

		return newBoard;
	}


	/* This is where all the magic happens...
	 * This function builds the board one cell per recursive call
	 * The key here is the recursion allows for easy backtracking.
	 * For a lot of "valid" options, they will cause an invalid board.
	 * This is why we have backtracking.
	 */
	private static bool SolveBoard(Board board, int row, int column, List<int>[,] p)
	{
		Random rng = new Random(); //Using these rands to pick which number to put in place 


		while (p[row, column].Count > 0)
		{
			//Make copy of p
			List<int>[,] possibilities = new List<int>[9, 9];
			for (int i = 0; i < 9; ++i)
			{
				for (int j = 0; j < 9; ++j)
				{
					possibilities[i, j] = new List<int>();
					for (int k = 0; k < p[i, j].Count; ++k) { possibilities[i, j].Add(p[i, j].ElementAt(k)); }
				}
			}
			int cellValue = board.GetCell(row, column);
			if (cellValue == 0)
			{
				//If we have no possiblities, backtrack
				if (possibilities[row, column].Count == 0)
				{
					//Console.WriteLine("Returning false because [" + row + "," + column + "] has no posssibilties");
					return false;
				}
				//Try a random valid value
				int randomIndex = rng.Next(0, possibilities[row, column].Count - 1);
				cellValue = possibilities[row, column].ElementAt(randomIndex);
				board.SetCell(row, column, cellValue);
				//Console.WriteLine("Trying value " + cellValue + " for [" + row + "," + column + "]");
				//Console.WriteLine(board);
			}

			//Update our values
			RemovePossibiltiesForCell(row, column, cellValue, ref possibilities);
			
			//Recursively build the rest of the board
			if (row == 8 && column == 8) return true;
			else if (column == 8)
			{
				if (SolveBoard(board, row + 1, 0, possibilities)) { return true; }
			}
			else if (SolveBoard(board, row, column + 1, possibilities)) return true;
			//If this failed, the current board is bad, backtrack!
			p[row, column].Remove(cellValue);
			board.SetCell(row, column, 0);
		}
		//Console.WriteLine("Returning false because [" + row + "," + column + "] has no posssibilties");
		return false;
	}



	//Generate base list of possiblities
	private static List<int>[,] GenerateDefaultPossibilities()
	{
		//Create initial list
		List<int>[,] possibilities = new List<int>[9, 9];
		for (int row = 0; row < 9; ++row)
		{
			for (int column = 0; column < 9; ++column)
			{
				possibilities[row, column] = new List<int>();
				for (int k = 1; k <= 9; ++k) { possibilities[row, column].Add(k); }
			}
		}
		return possibilities;
	}

	private static void RemovePossibiltiesForCell(int row, int column, int cellValue, ref List<int>[,] possibilities)
	{
		//Update that cell's row and column of possibilities
		for (int i = 0; i < 9; ++i)
		{
			if (i != column)
			{
				//Console.WriteLine("Removing " + cellValue + "from [" + row + "," + i + "]");
				possibilities[row, i].Remove(cellValue);
			}
			if (i != row)
			{
				//Console.WriteLine("Removing " + cellValue + "from [" + i + "," + column + "]");
				possibilities[i, column].Remove(cellValue);
			}
		}
		//Update that cell's 3x3 grid of possibilities
		int gridRowStart = (row / 3) * 3;
		int gridColStart = (column / 3) * 3;
		for (int i = gridRowStart; i < gridRowStart + 3; ++i)
		{
			for (int j = gridColStart; j < gridColStart + 3; ++j)
			{
				if (i != row || i != column)
				{
					//Console.WriteLine("Removing " + cellValue + "from [" + row + "," + column + "]");
					possibilities[i, j].Remove(cellValue);
				}
			}
		}
	}

	//This doesn't account for backtracking!
	private static void MatchPossiblitiesToBoard(Board board, ref List<int>[,] possibilities)
	{
		for (int row = 0; row < 9; ++row)
		{
			for (int column = 0; column < 9; ++column)
			{
				int cellValue = board.GetCell(row, column);
				if (cellValue != 0) RemovePossibiltiesForCell(row, column, cellValue, ref possibilities);
			}
		}
	}

	private static void BlankNCells(Board board, int numBlanks)
	{
		//Create list of possible blankables (1-81)
		List<int> blankable = new List<int>();
		for (int i = 0; i < 81; ++i) { blankable.Add(i); }

		Random rng = new Random(); //Used to select a cell to blank

		while (board.GetNumBlanks() < numBlanks && blankable.Count > 0)
		{
			//Console.WriteLine("Removing cells..." + (numBlanks - board.GetNumBlanks()) +  " left, " + blankable.Count + " possible blanks");
			//Pick a random cell
			int cellIndex = rng.Next(0, blankable.Count - 1);
			int row = cellIndex / 9;
			int col = cellIndex % 9;

			//Try to remove it 
			if (CanRemove(board, row, col))
			{
				//Console.WriteLine("Successfully removed.[" + row + "," + col + "]");
				//Keep removed if this produces only the unique solution
				board.SetCell(row, col, 0);
			}
			//else Console.WriteLine("Failed to removed.[" + row + "," + col + "]");
			//Remove from possible blankable cells
			blankable.Remove(cellIndex);
		}
	}

	private static bool CanRemove(Board board, int row, int col)
	{
		int currentValue = board.GetCell(row, col);
		if (currentValue == 0) return false; 
		//Console.WriteLine("Trying to remove [" + row + "," + col + "] = " + currentValue);
		//Create a list of possible numbers per cell  
		List<int>[,] possibilities = GenerateDefaultPossibilities();
		MatchPossiblitiesToBoard(board, ref possibilities);

		//This is a little tricky, but we want to see if we CAN'T solve this board without this value
		//If we can't solve the board by changing this value, we have a unique board, we can remove this cell
		return !(SolveBoard(board, 0, 0, possibilities));
	}

}

