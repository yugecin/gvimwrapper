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
		tree_init();
		removetitlebar();
	}

	protected override void WndProc(ref Message m) {
		base.WndProc(ref m);
		if (m.Msg == WM_ACTIVATE && m.WParam.ToInt32() == WA_ACTIVE) {
			vim_grabfocus();
		}
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
	Point movestartlocation;
	int moveOffsetX, moveOffsetY;
	bool suppressnexttabclick;

	void UI_TabBarMouseDown(object sender, MouseEventArgs e) {
		//if (e.Button != System.Windows.Forms.MouseButtons.Right) {
		//	return;
		//}
		moveForm = true;
		movestartlocation = this.Location;
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
		if (Math.Abs(this.Location.X - movestartlocation.X) > 6 ||
			Math.Abs(this.Location.Y - movestartlocation.Y) > 6)
		{
			suppressnexttabclick = true;
		}
		moveForm = false;
	}

	void UI_CloseButtonClick(object sender, EventArgs e) {
		this.Close();
	}

	void UI_MaximizeButtonClick(object sender, EventArgs e) {
		FormWindowState newstate = FormWindowState.Maximized;
		if (this.WindowState == FormWindowState.Maximized) {
			newstate = FormWindowState.Normal;
		}
		this.WindowState = newstate;
		vim_triggerwindowresize();
	}

	void UI_Resized(object sender, EventArgs e) {
		UI_TabBarResized(sender, e);
		UI_VimContainerResized(sender, e);
	}

	void UI_Closing(object sender, FormClosingEventArgs e) {
		closerequested = true;
		if (proc.HasExited) {
			return;
		}
		proc.CloseMainWindow();
		Thread.Sleep(100);
		if (!proc.HasExited) {
			e.Cancel = true;
			return;
		}
		closing = true;
		proc.Close();
	}

	void UI_OpenPathClick(object sender, EventArgs e) {
		txtPath.Visible = true;
		txtPath.Location = new Point(txtPath.Location.X, (Height - txtPath.Height) / 2);
		txtPath.Focus();
		txtPath.Select(0, txtPath.TextLength);
	}

	private void UI_OpenPathUnfocused(object sender, EventArgs e) {
		txtPath.Visible = false;
	}

	private void UI_OpenPathKeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Escape) {
			e.Handled = true;
			e.SuppressKeyPress = true;
			txtPath.Visible = false;
			splitContainer1.Focus();
			return;
		}

		if (e.KeyCode == Keys.Enter) {
			e.Handled = true;
			e.SuppressKeyPress = true;
			txtPath.Visible = false;
			splitContainer1.Focus();
			try {
				tree_fill(txtPath.Text);
			} catch (Exception t) {
				MessageBox.Show("cannot open path (" + t.Message + ")");
			}
			return;
		}

		if (e.KeyCode == Keys.A && (e.Modifiers & Keys.Control) > 0) {
			e.Handled = true;
			e.SuppressKeyPress = true;
			txtPath.Select(0, txtPath.TextLength);
			return;
		}
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////