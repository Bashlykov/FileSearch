/*
 * Created by SharpDevelop.
 * User: miro
 * Date: 15.03.2014
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text;

namespace FileSearch
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	    private DirectoryInfo beginDir; // стартовая папка
	   	private static int countfiles = 0; // счетчик файлов
	   	private const string DATA = @"last.log"; // имя файла для сохранения текущих критериев поиска
	   	private TreeNode[] dirNodeTree = new TreeNode[100]; // массив нод папок
	   	private static int indx; // индекс для сохранения нодов папок
	   	private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
	   	private static bool pressStop = false; // флаг нажатия останова поиска
	   	private static int sec = 0; // счетчик таймера
	   	private static int min = 0;
	    
	   	
	    private bool ScanDirectory(DirectoryInfo dir, TreeNode dirNode)
	    {                  	    	
	    	if ( pressStop ) // нажата кнопка стоп - выходим
	    		return false;
	    	
	    	timeLabel.Text = min.ToString() + " : " + sec.ToString();
	    	
	    	FileInfo[] files;

	    	try
	    	{	    		
	    		dirNodeTree[indx] = dirNode; // сохраним ноду в массив
	    		
	    		TreeNode curDirNode = new TreeNode(dir.Name);

	    		files = dir.GetFiles(patternBox.Text); // файлы из текущей папки
	    		
	    		if ( patternBox.Text == "" )
	    		{
	    			MessageBox.Show("Input pattern for search");
	    			return false;
	    		}
	    		
	    		if ( searchTextBox.Text == "" && files.Length > 0) // ищем только файлы по критерию
	    		{    				
    					int j = 0;
	    				while ( j < indx ) // строим дерево 
	    				{	    		
							try
	    					{
								dirNodeTree[j].Nodes.Add( dirNodeTree[++j] );
								Application.DoEvents();
	    					}
	    					catch{ }	    					
	    				}

						dirNodeTree[j].Nodes.Add( curDirNode ); // папка в которой файлы
    					
						for(int i = 0; i < files.Length; i++) // ветка файлов
			        	{
							TreeNode fileNode = new TreeNode(files[i].Name); 
				        	curDirNode.Nodes.Add( fileNode ); 	// добавим в дерево файл    						
		    				
				        	AddToLabels( ++countfiles, files[i].Name );
				        	Application.DoEvents();
						}
	    		}
		       	else // ищем текст в найденых файлах
		       	{
			        for(int i = 0; i < files.Length; i++)
			        {
			        	if ( SearchText(files[i]) ) // в файле есть текст
			        	{
	    					int j = 0;
		    				while ( j < indx ) // строим дерево папок
		    				{	    		
								try
		    					{
									dirNodeTree[j].Nodes.Add( dirNodeTree[++j] );
									Application.DoEvents();
		    					}
		    					catch{}
		    				}
							dirNodeTree[j].Nodes.Add( curDirNode ); // папка в которой нашилсь файлы			        									
							TreeNode fileNode = new TreeNode(files[i].Name);  	
				        	curDirNode.Nodes.Add( fileNode ); 	// добавим в дерево файл   		                 
				        	
				        	dirNodeTree[j].Parent.Expand();
				        	curDirNode.Parent.Expand();
				        	fileNode.Parent.Expand();
				        	
					        for(int k = ++i; k < files.Length; k++) // смотрим дальше файлы в текущей папке
					        {
					        	if ( SearchText(files[k]) ) // в файле есть текст
					        	{
					        		TreeNode _fileNode = new TreeNode(files[k].Name);  
				        			curDirNode.Nodes.Add( _fileNode ); // добавим файл 
					        	}
					        	
					        	AddToLabels( ++countfiles, files[i].Name );	
								Application.DoEvents();					        	
					        }	
			        	}
	  					
			        	AddToLabels( ++countfiles, files[i].Name );	
						Application.DoEvents();			        	
			        }
		       	}
		       	
	    		DirectoryInfo[] dirs = dir.GetDirectories(); // папки в текущей папке
	    		
		        for(int i = 0; i < dirs.Length; i++)
		        {
		        	indx++; // на уровень вниз
		        	ScanDirectory(dirs[i], curDirNode);	// уходим в подпапку	
					Application.DoEvents();		        	
		        }		        
	    	}
	    	catch{}
	    	
	    	indx--;	// на уровень вверх   	
	    	
	    	return true;
	    }
	    
	    private void AddToLabels(int count, string fileName)
	   	{
        	countfilesLabel.Text = count.ToString();
        	currentFileLabel.Text = fileName;	
	   	}
	   	
	    private bool SearchText(FileInfo file) // поиск текста в фале
	    {
	        string line;
	        StreamReader sr = file.OpenText();
	        while( (line = sr.ReadLine()) != null )
	        {
	        	if ( line.IndexOf(searchTextBox.Text.Trim()) != -1 ) // текст найден
	        	{
	        		sr.Close(); // закрываем файл
	        		return true; // и выходим
	        	}	    
				Application.DoEvents();	        	
	        }
	        sr.Close();
	        return false;
	    }
	    	    
		private void SaveData( string dataField, int num )
		{
			string searchData = File.ReadAllText(DATA);
			string[] searchArr = searchData.Split(new char[] {';'});
			
			switch( num )
			{
				case 0:
					File.WriteAllText(DATA, dataField+";"+searchArr[1]+";"+searchArr[2]+";");
					break;
				case 1:
					File.WriteAllText(DATA, searchArr[0]+";"+dataField+";"+searchArr[2]+";");
					break;
				case 2:
					File.WriteAllText(DATA, searchArr[0]+";"+searchArr[1]+";"+dataField+";");			
					break;				
			}				
		}
		
		private void SearchTimer(Object obj, EventArgs e)
		{					
			sec++;
			if ( sec == 60 )
			{
				min++;
				sec = 0;
			}
		}
		
		public MainForm()
		{
			// Call is required for Windows Forms designer support.			
			InitializeComponent();
			
			countfilesLabel.Text = countfiles.ToString();
			timeLabel.Text = "0 : 0";
			currentFileLabel.Text = "";
			timer.Interval = 1000;
			timer.Tick += new EventHandler( SearchTimer );
			
			if ( !File.Exists(DATA) ) // создаем файл для сохранения критериев поиска
			{
				using ( FileStream fs = File.Create(DATA) )
				{
					byte[] startSyms = new UTF8Encoding(true).GetBytes(";;;");
					fs.Write(startSyms, 0, startSyms.Length);
					fs.Close();
				}			
			}
			else // выгружаем данные из файла в поля
			{
				string searchData = File.ReadAllText(DATA);
				string[] searchArr = searchData.Split(new char[] {';'});
				patternBox.Text = searchArr[0];
				rootDirBox.Text = searchArr[1];
				searchTextBox.Text = searchArr[2];				
			}
		}
		
		void ButtonBrowseClick(object sender, EventArgs e)
		{	
			FolderBrowserDialog dlg = new FolderBrowserDialog();

		    if(dlg.ShowDialog(this) == DialogResult.OK)
		    {
				if ( !dlg.SelectedPath.Equals(""))
				{					
					rootDirBox.Text = dlg.SelectedPath;					
				}
		    }	
		}
		
		void ButtonSearchClick(object sender, EventArgs e)
		{			
			if ( rootDirBox.Text == "" )
			{
				MessageBox.Show("Input path");
				return;
			}
			countfiles = 0;
			indx = 0;
			sec = 0;
			min = 0;
			pressStop = false;
			
			treeView1.Nodes.Clear();			
			TreeNode dirNode = new TreeNode(rootDirBox.Text);
			treeView1.Nodes.Add( dirNode );
			
			beginDir = new DirectoryInfo(rootDirBox.Text);
			
			timer.Start();
						
			ScanDirectory(beginDir, dirNode);	
			
			MessageBox.Show("Search is completed");
		}
		
		void ButtonStopClick(object sender, EventArgs e)
		{
			countfiles = 0;
			sec = 0;
			min = 0;
			pressStop = true;
			timer.Stop();
		}		
		
		void PatternBoxTextChanged(object sender, EventArgs e)
		{		
			SaveData( patternBox.Text, 0 );
		}
		
		void RootDirBoxTextChanged(object sender, EventArgs e)
		{
			SaveData( rootDirBox.Text, 1 );				
		}
		
		void SearchTextBoxTextChanged(object sender, EventArgs e)
		{
			SaveData( searchTextBox.Text, 2 );			
		}
	}
}