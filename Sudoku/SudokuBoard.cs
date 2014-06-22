/* SudokuBoard.cs
 *
 * Main board structure for Sudoku game application
 * 
 * Written By Alan Bishop 6/14/14
 */

using System;

public class Board
{
	private int[,] cells;
	private bool solved;

	public Board() { InitGrid(); solved = false; }

	private void InitGrid()
	{
		cells = new int[9, 9];
		for (int i = 0; i < 9; ++i)
		{
			for (int j = 0; j < 9; ++j) { cells[i, j] = 0; }
		}
	}

	public int GetCell(int row, int column) { return cells[row, column]; }
	public string GetCellString(int row, int column)
	{
		string str = "";
		if (cells[row, column] != 0) { str += cells[row, column]; }
		return str;
	}
	public void SetCell(int row, int column, int val)
	{
		if (val > 9 || val < 0) return;
		cells[row, column] = val;
	}

	public int GetNumBlanks()
	{
		int numBlanks = 0;
		for(int r = 0; r < 9; ++r)
		{
			for (int c = 0; c < 9; ++c)
			{
				if (cells[r, c] == 0) numBlanks++;
			}
		}
		return numBlanks;
	}

	public bool SetCellAndCheckSolved(int row, int column, int val)
	{
		SetCell(row, column, val);
		return CheckSolved();
	}
	public bool IsSolved() { return solved; }



	///////////////////////////SOLVING RELATED STUFF//////////////////////////////////////////////////

	/* Checks rows, columns, diagonals, grids, updates solved bool */
	//(If there are 0s AKA blanks, will return false)
	public bool CheckSolved()
	{
		if (!CheckRows() || !CheckColumns() || !CheckGrids()) { solved = false; }
		else solved = true;
		return solved;
	}

	//Check each row for if it has a valid solution
	//(If there are 0s AKA blanks, will return false)
	private bool CheckRows()
	{
		bool[] hasValue = new bool[10]; //Checking for this value (Ex: hasValue[1] = there is a 1 in row)
		for (int i = 0; i < 9; ++i)
		{
			//Init check values
			for (int k = 1; k < 10; ++k) { hasValue[k] = false; }
			for (int j = 0; j < 9; ++j)
			{
				if (hasValue[cells[i, j]] == true) { return false; }
				else hasValue[cells[i, j]] = true;
			}
		}
		return true;
	}
	//Check each column for if it has a valid solution
	//Pretty much copy-pasta of checkRows, only indexing col/row switched
	//(If there are 0s AKA blanks, will return false)
	private bool CheckColumns()
	{
		bool[] hasValue = new bool[10]; //Checking for this value (Ex: hasValue[1] = there is a 1 in row)
		for (int i = 0; i < 9; ++i)
		{
			//Init check values
			for (int k = 1; k < 10; ++k) { hasValue[k] = false; }
			for (int j = 0; j < 9; ++j)
			{
				if (hasValue[cells[j, i]] == true) { return false; }
				else hasValue[cells[j, i]] = true;
			}
		}
		return true;
	}

	//Check each 3x3 box for if it has a valid solution
	//(If there are 0s AKA blanks, will return false)
	private bool CheckGrids()
	{
		bool[] hasValue = new bool[10]; //Checking for this value (Ex: hasValue[1] = there is a 1 in row)

		//Each grid is a 3x3 that must contain each 1-9 element
		int xstart = 0;
		int ystart = 0;
		for (int i = 0; i < 3; ++i)
		{
			for (int j = 0; j < 3; ++j)
			{
				if (CheckSubGrid(xstart, ystart) == false) return false;
				ystart += 3;
			}
			ystart = 0;
			xstart += 3;
		}
		return true;
	}

	private bool CheckSubGrid(int xstart, int ystart)
	{
		bool[] hasValue = new bool[10]; //Checking for this value (Ex: hasValue[1] = there is a 1 in row)
		for (int i = xstart; i < (xstart + 3); ++i)
		{
			for (int j = ystart; j < (ystart + 3); ++j)
			{
				if (hasValue[cells[j, i]] == true) { return false; }
				hasValue[cells[j, i]] = true;
			}
		}
		return true;
	}


	/////////////////////////////END SOLVING RELATED STUFF///////////////////////////////////////////////////


	/* Okay I admit this is pretty ugly but I'm going to go GUI so this is just temporary..*/
	public override string ToString()
	{
		string str = "";
		string rowSeperator = " |-----------|-----------|-----------| \n";
		string columnSeperator = " | ";
		str += "   ";
		for (int i = 0; i < 9; ++i)
		{
			char column = (char)(((int)'A') + i);
			str += " " + column + " ";
			if ((i + 1) % 3 == 0) str += "   ";
		}
		str += "\n";
		char row = 'A';
		for (int i = 0; i < 9; ++i)
		{
			str += rowSeperator;
			for (int j = 0; j < 9; ++j) 
			{
				str += columnSeperator;
				if (cells[i, j] != 0) str += cells[i, j];
				else str += " ";
			}
			str += columnSeperator;
			str += row + "\n";
			row++;
		}
		str += rowSeperator;
		return str;
	}

	//I've heard online about implementing Cloneable interface...but this is simple enough for now
	public Board CopyBoard()
	{
		Board newBoard = new Board();
		for (int i = 0; i < 9; ++i )
		{
			for(int j = 0; j < 9; ++j) { newBoard.SetCell(i,j,cells[i, j]); }
		}		
		newBoard.CheckSolved();
		return newBoard;
	}

}
