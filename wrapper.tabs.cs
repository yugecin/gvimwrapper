using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	class Tab {
		public string filename;
		public string title;
		public Image icon;
		public int width;
		public Rectangle location;
	}

	List<Tab> tabs;
	Font tabfont;

	void tab_init() {
		tabfont = new Font("Tahoma", 9f);
		tabs = new List<Tab>();
	}

	Tab tab_forfile(string filename) {
		foreach (Tab t in tabs) {
			if (t.filename == filename) {
				return t;
			}
		}
		return null;
	}

	void tab_open(string filename, Image icon) {
		Tab t = tab_forfile(filename);
		if (t == null) {
			t = new Tab();
			t.filename = filename;
			t.title = filename.Substring(filename.LastIndexOf('\\') + 1);
			t.icon = icon;
			t.width = 0;
			t.location = new Rectangle();
			tabs.Add(t);
		}
		tabpanel.Refresh();
	}

	void UI_TabBarPaintRequest(object sender, PaintEventArgs e) {
		int x = 0;
		int y = 0;
		const int LINEHEIGHT = 20;
		int LINEWIDTH = tabpanel.Width - 25 * 2;

		SolidBrush brush = new SolidBrush(Color.Black);
		foreach (Tab t in tabs) {
			if (t.width == 0) {
				t.width = (int) e.Graphics.MeasureString(t.title, tabfont).Width + 20 + 16;
			}
			if (t.width > LINEWIDTH - x) {
				int prevx = x;
				y += LINEHEIGHT;
				x = 0;
				if (t.width > LINEWIDTH) {
					x = prevx;
					y -= LINEHEIGHT;
					continue;
				}
			}
			t.location.Height = LINEHEIGHT;
			t.location.Width = t.width;
			t.location.X = x;
			t.location.Y = y;
			e.Graphics.DrawRectangle(Pens.Black, t.location);
			e.Graphics.DrawImage(t.icon, new Point(x + 8, y + 2));
			e.Graphics.DrawString(t.title, tabfont, brush, new PointF(x + 16 + 10, y + 2));
			x += t.width;
		}

		y += LINEHEIGHT;
		tabpanel.Height = y;
		int origheight = vimcontainer.Height;
		int newheight = splitContainer1.Panel2.Height - tabpanel.Height;
		if (origheight != newheight) {
			vimcontainer.Height = newheight;
			vimcontainer.Location = new Point(vimcontainer.Location.X, y);
		}
	}

	void UI_TabBarClicked(object sender, MouseEventArgs e) {
		if (suppressnexttabclick) {
			suppressnexttabclick = false;
			return;
		}

		Rectangle pos = new Rectangle(e.X, e.Y, 1, 1);
		foreach (Tab t in tabs) {
			if (t.location.IntersectsWith(pos)) {
				if (e.Button == MouseButtons.Middle) {
					tabs.Remove(t);
					vim_close(t.filename);
					tabpanel.Refresh();
					return;
				}
				vim_open(t.filename);
				return;
			}
		}
	}

	void UI_TabBarResized(object sender, EventArgs e) {
		tabpanel.Refresh();
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////