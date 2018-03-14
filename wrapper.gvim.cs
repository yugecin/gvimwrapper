using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	const string settingsfile = "gvimwrapper.ini";

	IntPtr vimHandle;
	Process proc;
	bool closerequested;
	bool closing;
	bool vimready;
	string cd;
	string vimlocation;

	void vim_init() {
		try {
			proc = Process.Start(new ProcessStartInfo(vimlocation));
		} catch (Exception e) {
			MessageBox.Show("could not launch vim: " + e.Message);
			return;
		}
		Task.Factory.StartNew((Action) (() => {
			proc.WaitForInputIdle();
			vimready = true;
			BeginInvoke((Action) (grab));
		}));
		Task.Factory.StartNew((Action) (() => {
			proc.WaitForExit();
			vimready = false;
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
		if (!vimready) {
			return;
		}

		vimHandle = proc.MainWindowHandle;
		uint lng = GetWindowLong(vimHandle, GWL_STYLE);
		lng &= ~(WS_BORDER | WS_SIZEBOX | WS_DLGFRAME);
		SetWindowLong(vimHandle, GWL_STYLE, lng);
		SetParent(vimHandle, vimcontainer.Handle);
		vim_triggerwindowresize();
		//SendMessage(hwnd, WM_SYSCOMMAND, new IntPtr(SC_MAXIMIZE), IntPtr.Zero);
		//proc.Refresh();
		if (cd != null) {
			vim_cd(cd);
		}
		foreach (Tab t in tabs) {
			vim_open(t.filename);
		}
	}

	void vim_getlocation() {
		if (File.Exists(settingsfile)) {
			try {
				string [] lines = File.ReadAllLines(settingsfile);
				if (lines.Length > 0 && File.Exists(lines[0])) {
					vimlocation = lines[0];
					return;
				}
			} catch (Exception e) {
				MessageBox.Show("could not read settings: " + e.Message);
			}
		}
		OpenFileDialog ofd = new OpenFileDialog();
		ofd.Title = "Select your gvim executable";
		ofd.Multiselect = false;
		ofd.Filter = "executables|*.exe";
		if (ofd.ShowDialog() != DialogResult.OK) {
			return;
		}
		vimlocation = ofd.FileName;
		try {
			File.WriteAllLines(settingsfile, new string[] {ofd.FileName});
		} catch (Exception e) {
			MessageBox.Show("could not save settings: " + e.Message);
		}
	}

	void UI_VimContainerResized(object sender, EventArgs e) {
		vim_triggerwindowresize();
	}

	void vim_triggerwindowresize() {
		if (!vimready) {
			return;
		}

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

	void vim_cd(string dir) {
		cd = dir;
		if (!dir.EndsWith("\\") && !dir.EndsWith("//")) {
			cd += "\\";
		}
		vim_sendcommand(":cd " + escape_filename(dir));
	}

	void vim_open(string file) {
		vim_sendcommand(":e " + escape_filename(makerelative(file)));
	}

	void vim_close(string file) {
		vim_sendcommand(":bd " + escape_filename(makerelative(file)));
	}

	void vim_grabfocus() {
		if (vimready) {
			SetForegroundWindow(vimHandle);
		}
	}

	void vim_sendcommand(string cmd) {
		if (!vimready) {
			return;
		}

		SuspendLayout();
		vim_grabfocus();
		SendKeys.Send(cmd + "{ENTER}");
		ResumeLayout();
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

	string makerelative(string path) {
		if (cd == null) {
			return path;
		}

		if (path.Substring(0, 2) != cd.Substring(0, 2)) {
			return path;
		}

		try {
			Uri workingdir = new Uri(cd);
			string relpath = workingdir.MakeRelativeUri(new Uri(path)).ToString();
			return Uri.UnescapeDataString(relpath);
		} catch (Exception) {
		      return path;
		}
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////