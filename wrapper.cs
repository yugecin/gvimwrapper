using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace gvimwrapper {
partial class wrapper : Form {

	[STAThread]
	static void Main() {
		Application.VisualStyleState = VisualStyleState.NoneEnabled;
		Application.Run(new wrapper());
	}

	wrapper() {
		InitializeComponent();
		icons_init();
		tab_init();
		vim_init();
		removetitlebar();
	}

	void removetitlebar() {
		uint lng = GetWindowLong(this.Handle, GWL_STYLE) & ~(WS_CAPTION);
		SetWindowLong(this.Handle, GWL_STYLE, lng);
		SetWindowPos(
			hWnd: this.Handle,
			hWndInsertAfter: IntPtr.Zero,
			X: 0,
			Y: 0,
			cx: 0,
			cy: 0,
			uFlags: SWP_NOSIZE | SWP_NOMOVE | SWP_FRAMECHANGED
		);
	}

	bool moveForm;
	int moveOffsetX, moveOffsetY;

	void UI_TabBarMouseDown(object sender, MouseEventArgs e) {
		//if (e.Button != System.Windows.Forms.MouseButtons.Right) {
		//	return;
		//}
		moveForm = true;
		moveOffsetY = e.Location.Y;
		moveOffsetX = e.Location.X;
	}

	void UI_TabBarMouseMove(object sender, MouseEventArgs e) {
		if (moveForm) {
			this.Location = new Point(
				this.Location.X + (e.Location.X - moveOffsetX),
				this.Location.Y + (e.Location.Y - moveOffsetY)
			);
		}
	}

	void UI_TabBarMouseUp(object sender, MouseEventArgs e) {
		moveForm = false;
	}

	void openFolderToolStripMenuItem_Click(object sender, EventArgs e) {
		FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
		folderBrowser.RootFolder = Environment.SpecialFolder.DesktopDirectory;
		folderBrowser.ShowNewFolderButton = false;
		folderBrowser.Description = "Gimme folder";
		if (folderBrowser.ShowDialog() == DialogResult.OK) {
			tree_fill(folderBrowser.SelectedPath);
		}
	}

	void openSelectedNodeAsFolderToolStripMenuItem_Click(object sender, EventArgs e) {
		TreeNode node = filetree.SelectedNode;
		if (node != null && node.Tag is string) {
			tree_fill((string) node.Tag);
		}
	}

	void UI_CloseButtonClick(object sender, EventArgs e) {
		this.Close();
	}

	void UI_MaximizeButtonClick(object sender, EventArgs e) {
		if (this.WindowState == FormWindowState.Maximized) {
			this.WindowState = FormWindowState.Normal;
			return;
		}
		this.WindowState = FormWindowState.Maximized;
	}

	void UI_Resized(object sender, EventArgs e) {
		UI_TabBarResized(sender, e);
		UI_VimContainerResized(sender, e);
	}

	void UI_Closing(object sender, FormClosingEventArgs e) {
		if (!proc.HasExited) {
			proc.CloseMainWindow();
		}
		Thread.Sleep(100);
		if (!proc.HasExited) {
			e.Cancel = true;
			return;
		}
		proc.Close();
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////