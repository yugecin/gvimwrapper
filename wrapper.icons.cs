using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	ImageList iconlist;
	bool hasunknown;

	void icons_init() {
		iconlist = new ImageList();
		iconlist.Images.Add(".empty", new Bitmap(1, 1));
		try {
			DirectoryInfo dir = new DirectoryInfo("gvimwrappericons");
			foreach (FileInfo file in dir.GetFiles()) {
				if (file.Extension == ".ico") {
					Icon icon = new Icon(file.FullName);
					string name = file.Name;
					name = name.Substring(0, name.Length - 4);
					iconlist.Images.Add("." + name, icon);
				}
			}
		} catch (Exception) { }
		hasunknown = iconlist.Images.ContainsKey(".unknown");
	}

	string icons_forextension(string extension) {
		if (iconlist.Images.ContainsKey(extension)) {
			return extension;
		}

		if (extension != ".warning" && hasunknown) {
			return ".unknown";
		}

		return ".empty";
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////