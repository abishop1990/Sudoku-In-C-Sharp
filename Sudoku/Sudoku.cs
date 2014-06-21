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
			ConsoleMode.WelcomeScreen();
			ConsoleMode.MainMenu();
		#else
			GUI game = new GUI();
			Application.Run(game);
			
			//When I'm done, I'll put a GUI mode here, so I can switch between them
		#endif
		
	}
}


