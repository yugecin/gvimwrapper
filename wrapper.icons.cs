using System.Drawing;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	ImageList iconlist;
	bool hasunknown;

	void icons_init() {
		iconlist = new ImageList();
		iconlist.Images.Add("empty", new Bitmap(1, 1));
		iconlist.Images.Add("folder", new Icon("gvimwrappericons/folder.ico"));
		iconlist.Images.Add("warning", new Icon("gvimwrappericons/warning.ico"));
		hasunknown = false;
		filetree.ImageList = iconlist;
	}

	string icons_forextension(string extension) {
		if (iconlist.Images.ContainsKey(extension)) {
			return extension;
		}

		if (extension != "warning" && hasunknown) {
			return "unknown";
		}

		return "empty";
	}

}
}
