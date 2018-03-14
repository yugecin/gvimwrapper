namespace gvimwrapper
{
	partial class wrapper
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.vimcontainer = new System.Windows.Forms.Panel();
			this.tabpanel = new System.Windows.Forms.Panel();
			this.btnMax = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.filetree = new System.Windows.Forms.TreeView();
			this.ctxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSelectedNodeAsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.ctxTree.SuspendLayout();
			this.SuspendLayout();
			// 
			// vimcontainer
			// 
			this.vimcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vimcontainer.Location = new System.Drawing.Point(0, 26);
			this.vimcontainer.Name = "vimcontainer";
			this.vimcontainer.Size = new System.Drawing.Size(805, 499);
			this.vimcontainer.TabIndex = 1;
			// 
			// tabpanel
			// 
			this.tabpanel.Controls.Add(this.btnMax);
			this.tabpanel.Controls.Add(this.btnClose);
			this.tabpanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabpanel.Location = new System.Drawing.Point(0, 0);
			this.tabpanel.Name = "tabpanel";
			this.tabpanel.Size = new System.Drawing.Size(805, 20);
			this.tabpanel.TabIndex = 0;
			this.tabpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.UI_TabBarPaintRequest);
			this.tabpanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_TabBarClicked);
			this.tabpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UI_TabBarMouseDown);
			this.tabpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UI_TabBarMouseMove);
			this.tabpanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UI_TabBarMouseUp);
			// 
			// btnMax
			// 
			this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMax.Location = new System.Drawing.Point(760, 0);
			this.btnMax.Name = "btnMax";
			this.btnMax.Size = new System.Drawing.Size(22, 20);
			this.btnMax.TabIndex = 1;
			this.btnMax.UseVisualStyleBackColor = true;
			this.btnMax.Click += new System.EventHandler(this.UI_MaximizeButtonClick);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(783, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(22, 20);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "-";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.UI_CloseButtonClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.filetree);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.vimcontainer);
			this.splitContainer1.Panel2.Controls.Add(this.tabpanel);
			this.splitContainer1.Size = new System.Drawing.Size(1009, 525);
			this.splitContainer1.SplitterDistance = 200;
			this.splitContainer1.TabIndex = 2;
			// 
			// filetree
			// 
			this.filetree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
			this.filetree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.filetree.ContextMenuStrip = this.ctxTree;
			this.filetree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filetree.FullRowSelect = true;
			this.filetree.Location = new System.Drawing.Point(0, 0);
			this.filetree.Name = "filetree";
			this.filetree.Size = new System.Drawing.Size(200, 525);
			this.filetree.TabIndex = 0;
			this.filetree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.UI_BeforeExpandTreeNode);
			this.filetree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.UI_TreeNodeDoubleClick);
			// 
			// ctxTree
			// 
			this.ctxTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openSelectedNodeAsFolderToolStripMenuItem});
			this.ctxTree.Name = "ctxTree";
			this.ctxTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ctxTree.Size = new System.Drawing.Size(216, 48);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openFolderToolStripMenuItem.Text = "Open folder";
			this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.UI_OpenFolderClick);
			// 
			// openSelectedNodeAsFolderToolStripMenuItem
			// 
			this.openSelectedNodeAsFolderToolStripMenuItem.Name = "openSelectedNodeAsFolderToolStripMenuItem";
			this.openSelectedNodeAsFolderToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openSelectedNodeAsFolderToolStripMenuItem.Text = "Open selected node as folder";
			this.openSelectedNodeAsFolderToolStripMenuItem.Click += new System.EventHandler(this.UI_OpenSelectedNodeClick);
			// 
			// wrapper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1009, 525);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "wrapper";
			this.Text = "GVIMwrapper";
			this.MaximizedBoundsChanged += new System.EventHandler(this.UI_MaximizedBoundsChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Closing);
			this.ResizeEnd += new System.EventHandler(this.UI_VimContainerResized);
			this.tabpanel.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ctxTree.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel vimcontainer;
		private System.Windows.Forms.Panel tabpanel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView filetree;
		private System.Windows.Forms.ContextMenuStrip ctxTree;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openSelectedNodeAsFolderToolStripMenuItem;
		private System.Windows.Forms.Button btnMax;
		private System.Windows.Forms.Button btnClose;
	}
}

