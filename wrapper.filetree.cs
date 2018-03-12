using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gvimwrapper {
partial class wrapper {

	void tree_init() {
		filetree.ImageList = iconlist;
	}

	void tree_fill(string path) {
		filetree.Nodes.Clear();
		tree_fill(path, filetree.Nodes, true);
	}

	void tree_fill(string path, TreeNodeCollection nodes, bool showparent = false) {
		nodes.Clear();

		DirectoryInfo dir = new DirectoryInfo(path);
		if (showparent && dir.Parent != null) {
			tree_makenode(nodes, "..", dir.Parent.FullName, ".folder");
		}

		DirectoryInfo[] subdirs = dir.GetDirectories();
		foreach (DirectoryInfo subdir in subdirs) {
			bool canexpand;
			try {
				canexpand =
					subdir.GetFiles().Length > 0 ||
					subdir.GetDirectories().Length > 0;
			} catch (Exception) {
				tree_makenode(nodes, "(err) " + subdir.Name, null, ".warning");
				continue;
			}

			var child = tree_makenode(nodes, subdir.Name, subdir.FullName, ".folder");
			if (canexpand) {
				child.Nodes.Add(new TreeNode());
			}
		}

		foreach (FileInfo file in dir.GetFiles()) {
			try {
				tree_makenode(nodes, file.Name, file, file.Extension);
			} catch (Exception) {
				tree_makenode(nodes, "(exc)", null, ".warning");
			}
		}
	}

	TreeNode tree_makenode(
		TreeNodeCollection parent,
		string text,
		object tag,
		string extension)
	{
		TreeNode child = new TreeNode(text);
		child.Tag = tag;
		if (text.StartsWith(".")) {
			child.ForeColor = Color.Gray;
		}
		if (tag == null) {
			child.ForeColor = Color.DarkRed;
		}
		child.SelectedImageKey = child.ImageKey = icons_forextension(extension);
		parent.Add(child);
		return child;
	}

	void UI_BeforeExpandTreeNode(object sender, TreeViewCancelEventArgs e) {
		if (e.Node.Tag == null) {
			return;
		}

		if (e.Node.Text == "..") {
			tree_fill((string) e.Node.Tag, filetree.Nodes, true);
			e.Cancel = true;
			return;
		}

		tree_fill((string) e.Node.Tag, e.Node.Nodes);
	}

	void UI_TreeNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
		if (e.Node.Tag != null && e.Node.Tag is FileInfo) {
			string file = ((FileInfo) e.Node.Tag).FullName;
			if (File.Exists(file)) {
				tab_open(file, iconlist.Images[e.Node.ImageKey]);
				vim_open(file);
			}
		}
	}

	void UI_OpenFolderClick(object sender, EventArgs e) {
		FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
		folderBrowser.RootFolder = Environment.SpecialFolder.DesktopDirectory;
		folderBrowser.ShowNewFolderButton = false;
		folderBrowser.Description = "Gimme folder";
		if (folderBrowser.ShowDialog() == DialogResult.OK) {
			tree_fill(folderBrowser.SelectedPath);
		}
	}

	void UI_OpenSelectedNodeClick(object sender, EventArgs e) {
		TreeNode node = filetree.SelectedNode;
		if (node != null && node.Tag is string) {
			tree_fill((string) node.Tag);
		}
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////