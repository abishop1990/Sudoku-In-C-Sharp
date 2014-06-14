
/* SudokuGenerator.cs
 * 
 * Logic for generating SudokuBoard objects
 * Creates both solved boards and different levels of puzzles
 * 
 * Written By Alan Bishop 6/14/14
 */ 

using System;

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

		return newBoard;
	}

	public static Board newSolvedBoard()
	{
		Board newBoard = new Board();

		return newBoard;
	}
}

