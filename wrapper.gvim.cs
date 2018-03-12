using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	IntPtr vimHandle;
	Process proc;
	bool closerequested;
	bool closing;

	void vim_init() {
		proc = Process.Start(new ProcessStartInfo(@"K:\Program Files (x86)\Vim\vim74\gvim.exe"));
		Task.Factory.StartNew((Action) (() => {
			proc.WaitForInputIdle();
			BeginInvoke((Action) (grab));
		}));
		Task.Factory.StartNew((Action) (() => {
			proc.WaitForExit();
			BeginInvoke((Action) (vim_Exited));
		}));
	}

	void vim_Exited() {
		if (closerequested) {
			if (!closing) {
				this.Close();
			}
			return;
		}
		vim_init();
	}

	void grab() {
		vimHandle = proc.MainWindowHandle;
		uint lng = GetWindowLong(vimHandle, GWL_STYLE);
		lng &= ~(WS_BORDER | WS_SIZEBOX | WS_DLGFRAME);
		SetWindowLong(vimHandle, GWL_STYLE, lng);
		SetParent(vimHandle, vimcontainer.Handle);
		vim_triggerwindowresize();
		//SendMessage(hwnd, WM_SYSCOMMAND, new IntPtr(SC_MAXIMIZE), IntPtr.Zero);
		//proc.Refresh();
		foreach (Tab t in tabs) {
			vim_open(t.filename);
		}
	}

	void UI_VimContainerResized(object sender, EventArgs e) {
		vim_triggerwindowresize();
	}

	void vim_triggerwindowresize() {
		SetWindowPos(
			vimHandle,
			hWndInsertAfter: IntPtr.Zero,
			X: 0,
			Y: 0,
			cx: vimcontainer.Width,
			cy: vimcontainer.Height,
			uFlags: 0
		);
	}

	void vim_open(string file) {
		vim_sendcommand(":e " + escape_filename(file));
	}

	void vim_close(string file) {
		vim_sendcommand(":bd " + escape_filename(file));
	}

	void vim_sendcommand(string cmd) {
		SetForegroundWindow(vimHandle);
		SendKeys.Send(cmd + "{ENTER}");
	}

	string escape_filename(string file) {
		StringBuilder sb = new StringBuilder();
		char[] c = file.ToCharArray();
		for (int i = 0; i < c.Length; i++) {
			if ("{}^+%~][()".Contains(c[i].ToString())) {
				sb.Append("{").Append(c[i]).Append("}");
				continue;
			}
			sb.Append(c[i]);
		}
		return sb.ToString();
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////