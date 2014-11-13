/*
 * Created by SharpDevelop.
 * User: miro
 * Date: 15.03.2014
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FileSearch
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.countfilesLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.timeLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.currentFileLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.ButtonStop = new System.Windows.Forms.Button();
			this.patternBox = new System.Windows.Forms.TextBox();
			this.patternLabel = new System.Windows.Forms.Label();
			this.ButtonSearch = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.rootDirBox = new System.Windows.Forms.TextBox();
			this.ButtonBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(203, 352);
			this.treeView1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(223, 268);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Count files:";
			// 
			// countfilesLabel
			// 
			this.countfilesLabel.Location = new System.Drawing.Point(290, 268);
			this.countfilesLabel.Name = "countfilesLabel";
			this.countfilesLabel.Size = new System.Drawing.Size(75, 16);
			this.countfilesLabel.TabIndex = 10;
			this.countfilesLabel.Text = "label3";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(223, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "Time:";
			// 
			// timeLabel
			// 
			this.timeLabel.Location = new System.Drawing.Point(290, 284);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(75, 18);
			this.timeLabel.TabIndex = 12;
			this.timeLabel.Text = "label4";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(223, 252);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Current file:";
			// 
			// currentFileLabel
			// 
			this.currentFileLabel.AutoSize = true;
			this.currentFileLabel.Location = new System.Drawing.Point(290, 252);
			this.currentFileLabel.Name = "currentFileLabel";
			this.currentFileLabel.Size = new System.Drawing.Size(35, 13);
			this.currentFileLabel.TabIndex = 16;
			this.currentFileLabel.Text = "label6";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(234, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 12);
			this.label4.TabIndex = 32;
			this.label4.Text = "Text";
			// 
			// searchTextBox
			// 
			this.searchTextBox.Location = new System.Drawing.Point(267, 67);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(227, 20);
			this.searchTextBox.TabIndex = 31;
			this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBoxTextChanged);
			// 
			// ButtonStop
			// 
			this.ButtonStop.Location = new System.Drawing.Point(419, 94);
			this.ButtonStop.Name = "ButtonStop";
			this.ButtonStop.Size = new System.Drawing.Size(75, 23);
			this.ButtonStop.TabIndex = 30;
			this.ButtonStop.Tag = "2";
			this.ButtonStop.Text = "Stop!";
			this.ButtonStop.UseVisualStyleBackColor = true;
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStopClick);
			// 
			// patternBox
			// 
			this.patternBox.Location = new System.Drawing.Point(267, 12);
			this.patternBox.Name = "patternBox";
			this.patternBox.Size = new System.Drawing.Size(146, 20);
			this.patternBox.TabIndex = 29;
			this.patternBox.TextChanged += new System.EventHandler(this.PatternBoxTextChanged);
			// 
			// patternLabel
			// 
			this.patternLabel.Location = new System.Drawing.Point(222, 14);
			this.patternLabel.Name = "patternLabel";
			this.patternLabel.Size = new System.Drawing.Size(46, 21);
			this.patternLabel.TabIndex = 28;
			this.patternLabel.Text = "Pattern";
			// 
			// ButtonSearch
			// 
			this.ButtonSearch.Location = new System.Drawing.Point(338, 94);
			this.ButtonSearch.Name = "ButtonSearch";
			this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
			this.ButtonSearch.TabIndex = 27;
			this.ButtonSearch.Tag = "1";
			this.ButtonSearch.Text = "Search";
			this.ButtonSearch.UseVisualStyleBackColor = true;
			this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(234, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "Path:";
			// 
			// rootDirBox
			// 
			this.rootDirBox.Location = new System.Drawing.Point(267, 38);
			this.rootDirBox.Name = "rootDirBox";
			this.rootDirBox.Size = new System.Drawing.Size(146, 20);
			this.rootDirBox.TabIndex = 25;
			this.rootDirBox.TextChanged += new System.EventHandler(this.RootDirBoxTextChanged);
			// 
			// ButtonBrowse
			// 
			this.ButtonBrowse.Location = new System.Drawing.Point(419, 37);
			this.ButtonBrowse.Name = "ButtonBrowse";
			this.ButtonBrowse.Size = new System.Drawing.Size(75, 23);
			this.ButtonBrowse.TabIndex = 24;
			this.ButtonBrowse.Text = "Browse";
			this.ButtonBrowse.UseVisualStyleBackColor = true;
			this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 352);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.searchTextBox);
			this.Controls.Add(this.ButtonStop);
			this.Controls.Add(this.patternBox);
			this.Controls.Add(this.patternLabel);
			this.Controls.Add(this.ButtonSearch);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rootDirBox);
			this.Controls.Add(this.ButtonBrowse);
			this.Controls.Add(this.currentFileLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.timeLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.countfilesLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.treeView1);
			this.Name = "MainForm";
			this.Text = "FileSearch";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label currentFileLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label countfilesLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ButtonStop;
		private System.Windows.Forms.TextBox patternBox;
		private System.Windows.Forms.Label patternLabel;
		private System.Windows.Forms.Button ButtonSearch;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox rootDirBox;
		private System.Windows.Forms.Button ButtonBrowse;
		
	}
}
