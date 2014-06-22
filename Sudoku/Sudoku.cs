/* Sudoku.cs
 *
 * Mainline for Sudoku Puzzle program 
 * 
 * Written By Alan Bishop 6/14/14
 */

//Comment/uncomment this to run command line
//#define CONSOLE_MODE

using System;
using System.Windows.Forms;

class Sudoku
{
	static void Main(string[] args)
	{
		#if CONSOLE_MODE
		//Run at Terminal
			ConsoleMode.WelcomeScreen();
			ConsoleMode.MainMenu();
		#else
		//Run in GUI
			GUI game = new GUI();
			Application.Run(game);
		#endif
	}
}


