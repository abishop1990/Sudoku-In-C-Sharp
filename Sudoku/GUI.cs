using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public partial class GUI : Form
{
	public GUI()
	{
		InitializeComponent();
		Board solvedBoard = SudokuGenerator.NewSolvedBoard();
		Board newBoard = SudokuGenerator.buildPuzzleBoard(solvedBoard, 1);
		GUI_BuildSudokuGrid();
		GUI_LoadBoard(newBoard);
	}

	private DataGridView sudokuGrid;
	private DataGridViewTextBoxColumn[] sudokuColumns;
	public void GUI_BuildSudokuGrid()
	{
		this.sudokuGrid = new System.Windows.Forms.DataGridView();
		this.sudokuColumns = new DataGridViewTextBoxColumn[9];
		for (int column = 0; column < 9; ++column)
		{
			sudokuColumns[column] = new System.Windows.Forms.DataGridViewTextBoxColumn();
			sudokuColumns[column].HeaderText = "" + (char)((int)'A' + column);
			sudokuColumns[column].MaxInputLength = 1;
			sudokuColumns[column].Name = sudokuColumns[column].HeaderText;
			sudokuColumns[column].Width = 50;
			sudokuColumns[column].DefaultCellStyle.Font = new Font("Arial", 32F, GraphicsUnit.Pixel);
		}

		((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).BeginInit();


		this.sudokuGrid.ColumnHeadersVisible = false;
		this.sudokuGrid.Columns.AddRange(sudokuColumns);
		//Put cells into board
		for (int column = 0; column < 9; ++column)
		{
			string[] colCells = new string[9];
			for (int row = 0; row < 9; ++row) { colCells[row] = "0"; }
			sudokuGrid.Rows.Add(colCells);
		}

		sudokuGrid.Location = new System.Drawing.Point(12, 43);
		sudokuGrid.Margin = new System.Windows.Forms.Padding(1);
		sudokuGrid.AllowUserToAddRows = false;
		sudokuGrid.AllowUserToDeleteRows = false;
		sudokuGrid.AllowUserToResizeRows = false;
		sudokuGrid.AllowUserToResizeColumns = false;
		sudokuGrid.RowHeadersVisible = false;
		sudokuGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
		sudokuGrid.Name = "dataGridView1";

		sudokuGrid.RowTemplate.Height = 100;
		foreach (DataGridViewRow row in sudokuGrid.Rows) { row.Height = 50; }
		sudokuGrid.Size = new System.Drawing.Size(941, 500);
		sudokuGrid.TabIndex = 2;
		sudokuGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

		Controls.Add(this.sudokuGrid);
		((System.ComponentModel.ISupportInitialize)(this.sudokuGrid)).EndInit();

	}

	public void GUI_LoadBoard(Board board)
	{
		//Put values into board
		for (int column = 0; column < 9; ++column)
		{
			for (int row = 0; row < 9; ++row)
			{
				sudokuGrid.Rows[row].Cells[column].Value = board.GetCellString(row, column);
				if (sudokuGrid.Rows[row].Cells[column].Value.ToString() != "")
				{
					sudokuGrid.Rows[row].Cells[column].ReadOnly = true;
				}
				else sudokuGrid.Rows[row].Cells[column].ReadOnly = false;
			}
		}
	}

	private void GUI_Load(object sender, EventArgs e)
	{

	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{

	}

	private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{

	}

	private void button1_Click(object sender, EventArgs e)
	{

	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{

	}
}

