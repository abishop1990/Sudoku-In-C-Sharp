
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
		return solvedBoard;
		//return newBoard;
	}

	//This is a disaster...forgive me
	public static Board newSolvedBoard()
	{
		Board newBoard = new Board();
		Random rng = new Random(); //Using these rands to solve which number to put in place 

		//Create a list of nums per cell  
		List<int>[,] possibilities = new List<int>[9, 9];


		for (int i = 0; i < 9; ++i)
		{
			for (int j = 0; j < 9; ++j)
			{
				possibilities[i, j] = new List<int>();
				for (int k = 1; k <= 9; ++k) { possibilities[i, j].Add(k); }
			}
		}
		SolveBoard(newBoard, 0, 0, possibilities);

		return newBoard;
	}

	private static bool SolveBoard(Board board, int row, int column, List<int>[,] p)
	{
		Random rng = new Random();
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
			if (possibilities[row, column].Count == 0) return false;
			int randomIndex = rng.Next(0, possibilities[row, column].Count - 1);
			
			int cellValue = possibilities[row, column].ElementAt(randomIndex);
			//Console.WriteLine("Trying cellValue = " + cellValue);
			board.SetCell(row, column, cellValue);
			//Update that cell's row and column of possibilities
			for(int i = 0; i < 9; ++i)
			{
				//Console.WriteLine("(Row) Removing from [" + row + "," + i + "]");
				possibilities[row, i].Remove(cellValue);
				//Console.WriteLine("(Column) Removing from [" + i + "," + column + "]");
				possibilities[i, column].Remove(cellValue);
			}

			//Update that cell's 3x3 grid of possibilities
			int gridRowStart = ( row / 3) * 3;
			int gridColStart = ( column / 3) * 3;
		//	Console.WriteLine("gridRowStart = " + gridRowStart + " gridColStart = " + gridColStart);
			for(int i = gridRowStart; i < gridRowStart+3; ++i)
			{
				for(int j = gridColStart; j < gridColStart+3; ++j)
				{
				//	Console.WriteLine("(Grid) Removing from [" + i + "," + j + "]");
					possibilities[i,j].Remove(cellValue);
				}
			}
			if (row == 8 && column == 8) return true;
			else if (column == 8)
			{
				if (SolveBoard(board, row + 1, 0, possibilities)) { return true; }
			}
			else if (SolveBoard(board, row, column + 1, possibilities)) return true;
			//Otherwise this is bad, backtrack!
			p[row, column].Remove(cellValue);
			board.SetCell(row, column, 0);
		}

		return false;
	}

}

