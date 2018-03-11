using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gvimwrapper
{
	public partial class Form1 : Form
	{

		const int GWL_HWNDPARENT = (-8);

		const int GWL_ID = (-12);
		const int GWL_STYLE = (-16);
		const int GWL_EXSTYLE = ( -20 );

		// Window Styles 
		const UInt32 WS_OVERLAPPED = 0;
		const UInt32 WS_POPUP = 0x80000000;
		const UInt32 WS_CHILD = 0x40000000;
		const UInt32 WS_MINIMIZE = 0x20000000;
		const UInt32 WS_VISIBLE = 0x10000000;
		const UInt32 WS_DISABLED = 0x8000000;
		const UInt32 WS_CLIPSIBLINGS = 0x4000000;
		const UInt32 WS_CLIPCHILDREN = 0x2000000;
		const UInt32 WS_MAXIMIZE = 0x1000000;
		const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
		const UInt32 WS_BORDER = 0x800000;
		const UInt32 WS_DLGFRAME = 0x400000;
		const UInt32 WS_VSCROLL = 0x200000;
		const UInt32 WS_HSCROLL = 0x100000;
		const UInt32 WS_SYSMENU = 0x80000;
		const UInt32 WS_THICKFRAME = 0x40000;
		const UInt32 WS_GROUP = 0x20000;
		const UInt32 WS_TABSTOP = 0x10000;
		const UInt32 WS_MINIMIZEBOX = 0x20000;
		const UInt32 WS_MAXIMIZEBOX = 0x10000;
		const UInt32 WS_TILED = WS_OVERLAPPED;
		const UInt32 WS_ICONIC = WS_MINIMIZE;
		const UInt32 WS_SIZEBOX = WS_THICKFRAME;

		// Extended Window Styles 
		const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
		const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
		const UInt32 WS_EX_TOPMOST = 0x0008;
		const UInt32 WS_EX_ACCEPTFILES = 0x0010;
		const UInt32 WS_EX_TRANSPARENT = 0x0020;
		const UInt32 WS_EX_MDICHILD = 0x0040;
		const UInt32 WS_EX_TOOLWINDOW = 0x0080;
		const UInt32 WS_EX_WINDOWEDGE = 0x0100;
		const UInt32 WS_EX_CLIENTEDGE = 0x0200;
		const UInt32 WS_EX_CONTEXTHELP = 0x0400;
		const UInt32 WS_EX_RIGHT = 0x1000;
		const UInt32 WS_EX_LEFT = 0x0000;
		const UInt32 WS_EX_RTLREADING = 0x2000;
		const UInt32 WS_EX_LTRREADING = 0x0000;
		const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
		const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
		const UInt32 WS_EX_CONTROLPARENT = 0x10000;
		const UInt32 WS_EX_STATICEDGE = 0x20000;
		const UInt32 WS_EX_APPWINDOW = 0x40000;
		const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
		const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
		const UInt32 WS_EX_LAYERED = 0x00080000;
		const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
		const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
		const UInt32 WS_EX_COMPOSITED = 0x02000000;
		const UInt32 WS_EX_NOACTIVATE = 0x08000000;

		const UInt32 SWP_NOSIZE = 0x0001;
		const UInt32 SWP_NOMOVE = 0x0002;
		const UInt32 SWP_NOZORDER = 0x0004;
		const UInt32 SWP_NOREDRAW = 0x0008;
		const UInt32 SWP_NOACTIVATE = 0x0010;
		const UInt32 SWP_DRAWFRAME = 0x0020;
		const UInt32 SWP_FRAMECHANGED = 0x0020;
		const UInt32 SWP_SHOWWINDOW = 0x0040;
		const UInt32 SWP_HIDEWINDOW = 0x0080;
		const UInt32 SWP_NOCOPYBITS = 0x0100;
		const UInt32 SWP_NOOWNERZORDER = 0x0200;
		const UInt32 SWP_NOREPOSITION = 0x0200;
		const UInt32 SWP_NOSENDCHANGING = 0x0400;
		const UInt32 SWP_DEFERERASE = 0x2000;
		const UInt32 SWP_ASYNCWINDOWPOS = 0x4000;

		const UInt32 WM_SYSCOMMAND = 0x112;
		const UInt32 SC_MAXIMIZE = 0xF030;
		const UInt32 SC_MINIMIZE = 0xF020;
		const UInt32 SC_RESTORE  = 0xF050;

		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll")]
		public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, UInt32 uFlags);

		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(IntPtr point);

		private Process proc;
		private delegate void Grab();
		private Grab grabdel;

		private IntPtr hwnd;
		private Timer tmrResize;
		private ImageList treeImgs;

		class Tab
		{
			public string filename;
			public string title;
			public Image icon;
			public int width;
			public Rectangle location;
		}

		private List<Tab> tabs;
		private Font tabfont;

		public Form1()
		{
			InitializeComponent();
			tabfont = new Font( "Tahoma", 9f );
			tabs = new List<Tab>();
			treeImgs = new ImageList();
			treeImgs.Images.Add( "folder", new Icon("gvimwrappericons/folder.ico") );
			treeImgs.Images.Add( "warning", new Icon("gvimwrappericons/warning.ico") );
			tree.ImageList = treeImgs;
			grabdel = grab;
			tmrResize = new Timer();
			tmrResize.Interval = 600;
			tmrResize.Tick += tmrResize_Tick;
			hwnd = this.Handle;
			long l = GetWindowLong( hwnd, GWL_STYLE );
			l &= ~( WS_CAPTION );
			SetWindowLong( hwnd, GWL_STYLE, (int) l );
			SetWindowPos( hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_FRAMECHANGED );
			ProcessStartInfo p = new ProcessStartInfo( @"K:\Program Files (x86)\Vim\vim74\gvim.exe" );
			//ProcessStartInfo p = new ProcessStartInfo( @"F:\Program Files (x86)\Vim\vim80\gvim.exe" );
			proc = Process.Start(p);
			Task.Factory.StartNew( grabwindow );
		}

		void tmrResize_Tick( object sender, EventArgs e )
		{
			SetWindowPos( hwnd, IntPtr.Zero, 0, 0, pnl.Width, pnl.Height, 0 );
			tmrResize.Stop();
		}

		public void grab()
		{
			uint l;

			hwnd = proc.MainWindowHandle;
			l = GetWindowLong( hwnd, GWL_STYLE );
			l &= ~( WS_BORDER | WS_SIZEBOX | WS_DLGFRAME );
			SetWindowLong( hwnd, GWL_STYLE, (int) l );
			//SetWindowPos( hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_FRAMECHANGED | SWP_NOMOVE | SWP_NOSIZE );
			// not needed because setparent refreshes it ig
			SetParent( hwnd, pnl.Handle );
			SetWindowPos( hwnd, IntPtr.Zero, 0, 0, pnl.Width, pnl.Height, 0 );
			//SendMessage( hwnd, WM_SYSCOMMAND, new IntPtr(SC_MAXIMIZE), IntPtr.Zero );
			//proc.Refresh();
		}

		private void grabwindow()
		{
			proc.WaitForInputIdle();
			this.BeginInvoke( grabdel );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void pnl_SizeChanged( object sender, EventArgs e )
		{
			if( tmrResize.Enabled )
			{
				tmrResize.Stop();
			}
			tmrResize.Start();
		}

#region move
		private bool moveForm;
		private int moveOffsetX;
		private int moveOffsetY;

		private void pnlTabs_MouseDown( object sender, MouseEventArgs e )
		{
			//if( e.Button == System.Windows.Forms.MouseButtons.Right )
			//{
				moveForm = true;
				moveOffsetY = e.Location.Y;
				moveOffsetX = e.Location.X;
			//}
		}

		private void pnlTabs_MouseMove( object sender, MouseEventArgs e )
		{
			if (moveForm)
			{
				this.Location = new Point(this.Location.X + (e.Location.X - moveOffsetX), this.Location.Y + (e.Location.Y - moveOffsetY));
			}
		}

		private void pnlTabs_MouseUp( object sender, MouseEventArgs e )
		{
			moveForm = false;
		}
#endregion

		private void openFolderToolStripMenuItem_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
			folderBrowser.RootFolder = Environment.SpecialFolder.DesktopDirectory;
			folderBrowser.ShowNewFolderButton = false;
			folderBrowser.Description = "Gimme folder";
			if(folderBrowser.ShowDialog() == DialogResult.OK)
			{
				tree.Nodes.Clear();
				fillTree(folderBrowser.SelectedPath, tree.Nodes, true);
			}
		}


		private void fillTree(string path, TreeNodeCollection nodes, bool showparent = false)
		{
			nodes.Clear();

			TreeNode child;
			DirectoryInfo dir = new DirectoryInfo(path);
			if( showparent && dir.Parent != null )
			{
				child = new TreeNode( ".." );
				child.Tag = dir.Parent.FullName;
				child.ImageKey = "folder";
				child.Nodes.Add( new TreeNode() );
				child.SelectedImageKey = child.ImageKey;
				nodes.Add( child );
			}
			DirectoryInfo[] subdirs = dir.GetDirectories();
			foreach (DirectoryInfo subdir in subdirs)
			{
				try
				{
					if( !showHiddenToolStripMenuItem.Checked && subdir.Name.StartsWith( "." ) )
					{
						continue;
					}
					child = new TreeNode( subdir.Name );
					child.Tag = subdir.FullName;
					child.ImageKey = "folder";
					if( subdir.GetFiles().Length > 0 || subdir.GetDirectories().Length > 0 )
					{
						child.Nodes.Add( new TreeNode() );
					}
					child.SelectedImageKey = child.ImageKey;
					nodes.Add( child );
				}
				catch( Exception e )
				{
					child = new TreeNode( "(err) " + subdir.Name );
					child.ImageKey = "warning";
					child.SelectedImageKey = child.ImageKey;
					nodes.Add( child );
				}
			}

			foreach (FileInfo file in dir.GetFiles())
			{
				try
				{
					child = new TreeNode(file.Name);
					child.Tag = file;
					if(treeImgs.Images.ContainsKey(file.Extension))
					{
						child.ImageKey = file.Extension;
					}
					else
					{
						child.ImageKey = ".unk";
					}
					child.SelectedImageKey = child.ImageKey;
					nodes.Add(child);
				}
				catch( Exception e )
				{
					child = new TreeNode( "exc" );
					child.ImageKey = "warning";
					child.SelectedImageKey = child.ImageKey;
					nodes.Add( child );
				}
			}
		}

		private void tree_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			if(e.Node.Tag != null)
			{
				if( e.Node.Text == ".." )
				{
					fillTree( (string) e.Node.Tag, tree.Nodes, true );
					e.Cancel = true;
					return;
				}
				fillTree((string) e.Node.Tag, e.Node.Nodes);
			}
		}

		private void showHiddenToolStripMenuItem_Click( object sender, EventArgs e )
		{
			showHiddenToolStripMenuItem.Checked = !showHiddenToolStripMenuItem.Checked;
		}

		private void tree_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			if (e.Node.Tag == null || !(e.Node.Tag is FileInfo))
			{
				return;
			}
			string file = ((FileInfo) e.Node.Tag).FullName;
			if( File.Exists( file ) )
			{
				openTab( file, treeImgs.Images[e.Node.ImageKey] );
				openFile( file );
			}
		}

		private void openSelectedNodeAsFolderToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = tree.SelectedNode;
			if( node == null || node.Tag == null || !( node.Tag is string ) )
			{
				return;
			}
			fillTree( (string) node.Tag, tree.Nodes, true );
		}

		private void btnClose_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void btnMax_Click( object sender, EventArgs e )
		{
			if( this.WindowState == FormWindowState.Maximized )
			{
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.WindowState = FormWindowState.Maximized;
			}
		}

		private Tab getTab( string filename )
		{
			foreach (Tab t in tabs)
			{
				if( t.filename == filename )
				{
					return t;
				}
			}
			return null;
		}

		private void openTab( string filename, Image icon )
		{
			Tab t = getTab( filename );
			if( t == null )
			{
				t = new Tab();
				t.filename = filename;
				t.title = filename.Substring( filename.LastIndexOf( '\\' ) + 1 );
				t.icon = icon;
				t.width = 0;
				t.location = new Rectangle();
				tabs.Add(t);
			}
			pnlTabs.Refresh();
		}

		private void pnlTabs_Paint( object sender, PaintEventArgs e )
		{
			int x = 0;
			int y = 0;
			const int LINEHEIGHT = 20;
			int LINEWIDTH = pnlTabs.Width - 25 * 2;

			SolidBrush brush = new SolidBrush(Color.Black);
			foreach (Tab t in tabs)
			{
				if (t.width == 0)
				{
					t.width = (int) e.Graphics.MeasureString( t.title, tabfont ).Width + 20 + 16;
				}
				if( t.width > LINEWIDTH - x )
				{
					int prevx = x;
					y += LINEHEIGHT;
					x = 0;
					if( t.width > LINEWIDTH )
					{
						x = prevx;
						y -= LINEHEIGHT;
						continue;
					}
				}
				t.location.Height = LINEHEIGHT;
				t.location.Width = t.width;
				t.location.X = x;
				t.location.Y = y;
				e.Graphics.DrawRectangle( Pens.Black, t.location );
				e.Graphics.DrawImage( t.icon, new Point(x + 8, y + 2) );
				e.Graphics.DrawString( t.title, tabfont, brush, new PointF(x + 16 + 10, y + 2) );
				x += t.width;
			}

			y += LINEHEIGHT;
			pnlTabs.Height = y;
			int origheight = pnl.Height;
			int newheight = splitContainer1.Panel2.Height - pnlTabs.Height;
			if( origheight != newheight )
			{
				pnl.Height = newheight;
				pnl.Location = new Point(pnl.Location.X, y);
			}
		}

		private void pnlTabs_MouseClick( object sender, MouseEventArgs e )
		{
			Rectangle pos = new Rectangle(e.X, e.Y, 1, 1);
			foreach (Tab t in tabs)
			{
				if( t.location.IntersectsWith( pos ) )
				{
					openFile( t.filename );
					if( e.Button == System.Windows.Forms.MouseButtons.Middle )
					{
						tabs.Remove( t );
						closeFile();
						pnlTabs.Refresh();
					}
					return;
				}
			}
		}

		private void openFile( string file )
		{
			SetForegroundWindow( hwnd );
			char[] c = file.ToCharArray();
			file = "";
			for( int i = 0; i < c.Length; i++ )
			{
				if( "{}^+%~][()".Contains( c[i].ToString() ) )
				{
					file += "{" + c[i] + "}";
				}
				else
				{
					file += c[i];
				}
			}
			SendKeys.Send(":e " + file + "{ENTER}");
		}

		private void closeFile()
		{
			SetForegroundWindow( hwnd );
			SendKeys.Send( ":bd{ENTER}" );
		}

		private void Form1_ResizeEnd( object sender, EventArgs e )
		{
			pnlTabs.Refresh();
		}

		private void Form1_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( !proc.HasExited )
			{
				proc.CloseMainWindow();
			}
			System.Threading.Thread.Sleep( 100 );
			if( !proc.HasExited )
			{
				e.Cancel = true;
				return;
			}
			proc.Close();
		}

	}
}
