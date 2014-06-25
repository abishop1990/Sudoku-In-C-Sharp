
using System.Windows.Forms;
partial class GUI
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.evilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.evilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(965, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.solveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.evilToolStripMenuItem,
            this.evilToolStripMenuItem1});
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
			this.newGameToolStripMenuItem.Text = "New Game";
			// 
			// easyToolStripMenuItem
			// 
			this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
			this.easyToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
			this.easyToolStripMenuItem.Text = "Easy";
			// 
			// mediumToolStripMenuItem
			// 
			this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
			this.mediumToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
			this.mediumToolStripMenuItem.Text = "Medium";
			// 
			// evilToolStripMenuItem
			// 
			this.evilToolStripMenuItem.Name = "evilToolStripMenuItem";
			this.evilToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
			this.evilToolStripMenuItem.Text = "Hard";
			// 
			// evilToolStripMenuItem1
			// 
			this.evilToolStripMenuItem1.Name = "evilToolStripMenuItem1";
			this.evilToolStripMenuItem1.Size = new System.Drawing.Size(133, 24);
			this.evilToolStripMenuItem1.Text = "Evil";
			// 
			// solveToolStripMenuItem
			// 
			this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
			this.solveToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
			this.solveToolStripMenuItem.Text = "Solve";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitGame);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// howToPlayToolStripMenuItem
			// 
			this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
			this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
			this.howToPlayToolStripMenuItem.Text = "How To Play";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(12, 570);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 45);
			this.panel1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 33);
			this.button2.TabIndex = 1;
			this.button2.Text = "Check Puzzle";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(158, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "Solve Puzzle";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);

			// 
			// GUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 618);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "GUI";
			this.Text = "Sudoku by Alan Bishop";
			this.Load += new System.EventHandler(this.GUI_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem evilToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem evilToolStripMenuItem1;
	private System.Windows.Forms.ToolStripMenuItem solveToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	private Panel panel1;
	private Button button1;
	private Button button2;

}
