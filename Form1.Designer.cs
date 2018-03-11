namespace gvimwrapper
{
	partial class Form1
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
			this.pnl = new System.Windows.Forms.Panel();
			this.pnlTabs = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tree = new System.Windows.Forms.TreeView();
			this.ctxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSelectedNodeAsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnMax = new System.Windows.Forms.Button();
			this.pnlTabs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.ctxTree.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl
			// 
			this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnl.Location = new System.Drawing.Point(0, 26);
			this.pnl.Name = "pnl";
			this.pnl.Size = new System.Drawing.Size(805, 499);
			this.pnl.TabIndex = 1;
			this.pnl.SizeChanged += new System.EventHandler(this.pnl_SizeChanged);
			// 
			// pnlTabs
			// 
			this.pnlTabs.Controls.Add(this.btnMax);
			this.pnlTabs.Controls.Add(this.btnClose);
			this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTabs.Location = new System.Drawing.Point(0, 0);
			this.pnlTabs.Name = "pnlTabs";
			this.pnlTabs.Size = new System.Drawing.Size(805, 20);
			this.pnlTabs.TabIndex = 0;
			this.pnlTabs.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTabs_Paint);
			this.pnlTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlTabs_MouseClick);
			this.pnlTabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTabs_MouseDown);
			this.pnlTabs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTabs_MouseMove);
			this.pnlTabs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTabs_MouseUp);
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
			this.splitContainer1.Panel1.Controls.Add(this.tree);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnl);
			this.splitContainer1.Panel2.Controls.Add(this.pnlTabs);
			this.splitContainer1.Size = new System.Drawing.Size(1009, 525);
			this.splitContainer1.SplitterDistance = 200;
			this.splitContainer1.TabIndex = 2;
			// 
			// tree
			// 
			this.tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
			this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tree.ContextMenuStrip = this.ctxTree;
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.FullRowSelect = true;
			this.tree.Location = new System.Drawing.Point(0, 0);
			this.tree.Name = "tree";
			this.tree.Size = new System.Drawing.Size(200, 525);
			this.tree.TabIndex = 0;
			this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
			this.tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseDoubleClick);
			// 
			// ctxTree
			// 
			this.ctxTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openSelectedNodeAsFolderToolStripMenuItem,
            this.showHiddenToolStripMenuItem});
			this.ctxTree.Name = "ctxTree";
			this.ctxTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ctxTree.Size = new System.Drawing.Size(216, 70);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openFolderToolStripMenuItem.Text = "Open folder";
			this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
			// 
			// openSelectedNodeAsFolderToolStripMenuItem
			// 
			this.openSelectedNodeAsFolderToolStripMenuItem.Name = "openSelectedNodeAsFolderToolStripMenuItem";
			this.openSelectedNodeAsFolderToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openSelectedNodeAsFolderToolStripMenuItem.Text = "Open selected node as folder";
			this.openSelectedNodeAsFolderToolStripMenuItem.Click += new System.EventHandler(this.openSelectedNodeAsFolderToolStripMenuItem_Click);
			// 
			// showHiddenToolStripMenuItem
			// 
			this.showHiddenToolStripMenuItem.Name = "showHiddenToolStripMenuItem";
			this.showHiddenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.showHiddenToolStripMenuItem.Text = "Show hidden";
			this.showHiddenToolStripMenuItem.Click += new System.EventHandler(this.showHiddenToolStripMenuItem_Click);
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
			this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1009, 525);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "Form1";
			this.Text = "GVIMwrapper";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.pnlTabs.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ctxTree.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnl;
		private System.Windows.Forms.Panel pnlTabs;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.ContextMenuStrip ctxTree;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showHiddenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openSelectedNodeAsFolderToolStripMenuItem;
		private System.Windows.Forms.Button btnMax;
		private System.Windows.Forms.Button btnClose;
	}
}

