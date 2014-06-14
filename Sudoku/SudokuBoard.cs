using System;

class Board
{
    private Grid[,] grids;
    private bool solved;

    public Board()
    {
        InitGrid();
        solved = false;
    }

    public bool isSolved() { return solved; }


    /* Okay I admit this is pretty ugly but I'm going to go GUI so this is just temporary..*/
    public override string ToString()
    {
        string str = "";
        string seperator = " |-----------|-----------|-----------| \n";
        str += "   ";
        for (int i = 0; i < 9; ++i)
        {
            char column = (char) (((int)'A') + i);
            str += " " + column + " ";
            if((i+1)%3 == 0) str += "   ";
        }
        str += "\n";
        char row = 'A';
        for (int i = 0; i < 3; ++i)
        {
            str += seperator;
            for (int j = 0; j < 3; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    str += " | ";
                    str += grids[i, j].RowToString(k);
                }
                str += " | " + row + "\n";
                row++;
            }
        }
        str += seperator;
        return str;
    }

    private void InitGrid()
    {
        grids = new Grid[3, 3];
        for(int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                grids[i, j] = new Grid();
            }
        }
    }

}

//3x3 Individual Board
class Grid
{
    private Cell[,] cells;

    public Grid()
    {
        InitCells();
    }

    public string RowToString(int row)
    {
        if(row > 2) { return ""; }
        string str = "";
        for(int i = 0; i < 3; ++i)
        {
            str += " " + cells[row,i].ToString() + " ";
        }
        return str;
    }

    private void InitCells()
    {
        cells = new Cell[3, 3];
        for(int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                cells[i, j] = new Cell();
            }
        }
    }

}

//Individual Cell 
class Cell
{
    private int num;
    private bool correct;

    public Cell()
    {
        num = 0;
        correct = false;
    }
    public Cell(int num, bool correct)
    {
        this.num = num;
        this.correct = correct;
    }


    public override string ToString()
    {
        return num.ToString();
    }
}

