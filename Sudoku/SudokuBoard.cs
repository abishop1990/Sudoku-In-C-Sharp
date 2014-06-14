/*
 * SudokuBoard.cs
 * 
 * Written By Alan Bishop 6/14/14
 * 
 * Class for game boards of Sudoku
 * 
 * 
 */

using System;

class Board
{
    private int [,] cells;
    private bool solved;

    public Board()
    {
        InitGrid();
        solved = false;
    }

    public bool isSolved() { return solved; }

    /* Checks rows, columns, diagonals, grids, updates solved bool */
    public bool CheckSolved()
    {

        return solved;
    }

    /* Okay I admit this is pretty ugly but I'm going to go GUI so this is just temporary..*/
    public override string ToString()
    {
        string str = "";
        string rowSeperator = " |-----------|-----------|-----------| \n";
        string columnSeperator = " | ";
        str += "   ";
        for (int i = 0; i < 9; ++i)
        {
            char column = (char) (((int)'A') + i);
            str += " " + column + " ";
            if((i+1)%3 == 0) str += "   ";
        }
        str += "\n";
        char row = 'A';
        for (int i = 0; i < 9; ++i)
        {
            str += rowSeperator;
            for(int j = 0; j < 9; ++j)
            {
                str += columnSeperator + cells[i, j];
            }
            str += columnSeperator;
            str += row + "\n";
            row++;
        }
        str += rowSeperator;
        return str;
    }

    private void InitGrid()
    {
        cells = new int[9, 9];
        for(int i = 0; i < 9; ++i)
        {
            for(int j = 0; j < 9; ++j)
            {
                cells[i, j] = 0;
            }
        }
    }

}
