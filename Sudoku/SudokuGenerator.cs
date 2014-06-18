
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
	const int EASY_BLANKS = 45;
	const int MEDIUM_BLANKS = 50;
	const int HARD_BLANKS  = 55;
	const int JEDI_BLANKS  = 60;


	public static Board buildPuzzleBoard(Board solvedBoard, int level)
	{
		Board newBoard = solvedBoard.copyBoard();

		switch (level)
		{
			case 1:
				BlankNCells(newBoard,EASY_BLANKS);
				break;
			case 2:
				BlankNCells(newBoard,MEDIUM_BLANKS);
				break;
			case 3:
				BlankNCells(newBoard,HARD_BLANKS);
				break;
			case 4:
				BlankNCells(newBoard,JEDI_BLANKS);
				break;
			default:
				//Just do easy
				BlankNCells(newBoard,EASY_BLANKS);
				break;
		}
		return newBoard;
	}

	private static void BlankNCells(Board board, int numBlanks)
	{
		//Create list of possible blankables (1-81)
		List<int> blankable = new List<int>();
		for(int i = 0; i < 81; ++i) { blankable.Add(i);}

		Random rng = new Random(); //Used to select a cell to blank

		while(board.GetNumBlanks() < numBlanks && blankable.Count > 0)
		{
			//Pick a random cell
			int cellIndex = rng.Next(0,blankable.Count-1);
			int row = cellIndex/9;
			int col = cellIndex%9;

				//Try to remove it 
				if(CanRemove(board,row,col))
				{
					//Keep removed if this produces only the unique solution
					board.SetCell(row,col,0);
				}
				//Remove from possible blankable cells
				blankable.Remove(cellIndex);
		}
	}

	private static bool CanRemove(Board board, int row, int col)
	{
		return true;
	}

	//Generate a new solved board
	public static Board newSolvedBoard()
	{
		Board newBoard = new Board();

		//Create a list of possible numbers per cell  
		List<int>[,] possibilities = new List<int>[9, 9];
		for (int i = 0; i < 9; ++i)
		{
			for (int j = 0; j < 9; ++j)
			{
				possibilities[i, j] = new List<int>();
				for (int k = 1; k <= 9; ++k) { possibilities[i, j].Add(k); }
			}
		}
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
		Random rng = new Random(); //Using these rands to solve which number to put in place 
		while(p[row,column].Count > 0)
		{
			//Copy Possibilties
			//Create a list of nums per cell  
			List<int>[,] possibilities = new List<int>[9, 9];
			for (int i = 0; i < 9; ++i)
			{
				for (int j = 0; j < 9; ++j)
				{
					possibilities[i, j] = new List<int>(p[i,j]);
				}
			}
			//Try a random cell
			//If we have no possiblities, backtrack
			if (possibilities[row, column].Count == 0) return false; 
			int randomIndex = rng.Next(0, possibilities[row, column].Count - 1);
			int cellValue = possibilities[row, column].ElementAt(randomIndex);
			board.SetCell(row, column, cellValue);

			//Update that cell's row and column of possibilities
			for(int i = 0; i < 9; ++i)
			{
				possibilities[row, i].Remove(cellValue);
				possibilities[i, column].Remove(cellValue);
			}
			//Update that cell's 3x3 grid of possibilities
			int gridRowStart = ( row / 3) * 3;
			int gridColStart = ( column / 3) * 3;
			for(int i = gridRowStart; i < gridRowStart+3; ++i)
			{
				for(int j = gridColStart; j < gridColStart+3; ++j)
				{
					possibilities[i,j].Remove(cellValue);
				}
			}

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
		return false;
	}

}

