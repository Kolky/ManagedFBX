partial class FbxForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if(disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
            this.uxFbxTree = new System.Windows.Forms.TreeView();
            this.uxNodeInfo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsShowAllProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsShowMeshDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTriangulateMeshes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxFbxTree
            // 
            this.uxFbxTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxFbxTree.Location = new System.Drawing.Point(16, 33);
            this.uxFbxTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxFbxTree.Name = "uxFbxTree";
            this.uxFbxTree.Size = new System.Drawing.Size(379, 525);
            this.uxFbxTree.TabIndex = 0;
            this.uxFbxTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeSelect);
            // 
            // uxNodeInfo
            // 
            this.uxNodeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNodeInfo.Location = new System.Drawing.Point(404, 33);
            this.uxNodeInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxNodeInfo.Multiline = true;
            this.uxNodeInfo.Name = "uxNodeInfo";
            this.uxNodeInfo.ReadOnly = true;
            this.uxNodeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxNodeInfo.Size = new System.Drawing.Size(644, 525);
            this.uxNodeInfo.TabIndex = 3;
            this.uxNodeInfo.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1065, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.LoadFile);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsShowAllProperties,
            this.settingsShowMeshDetails,
            this.settingsTriangulateMeshes});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // settingsShowAllProperties
            // 
            this.settingsShowAllProperties.CheckOnClick = true;
            this.settingsShowAllProperties.Name = "settingsShowAllProperties";
            this.settingsShowAllProperties.Size = new System.Drawing.Size(213, 26);
            this.settingsShowAllProperties.Text = "Show All Properties";
            // 
            // settingsShowMeshDetails
            // 
            this.settingsShowMeshDetails.CheckOnClick = true;
            this.settingsShowMeshDetails.Name = "settingsShowMeshDetails";
            this.settingsShowMeshDetails.Size = new System.Drawing.Size(213, 26);
            this.settingsShowMeshDetails.Text = "Show Mesh Details";
            // 
            // settingsTriangulateMeshes
            // 
            this.settingsTriangulateMeshes.CheckOnClick = true;
            this.settingsTriangulateMeshes.Name = "settingsTriangulateMeshes";
            this.settingsTriangulateMeshes.Size = new System.Drawing.Size(213, 26);
            this.settingsTriangulateMeshes.Text = "Triangulate Meshes";
            // 
            // FbxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 574);
            this.Controls.Add(this.uxNodeInfo);
            this.Controls.Add(this.uxFbxTree);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FbxForm";
            this.Text = "FbxForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.TreeView uxFbxTree;
	private System.Windows.Forms.TextBox uxNodeInfo;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsShowAllProperties;
    private System.Windows.Forms.ToolStripMenuItem settingsShowMeshDetails;
    private System.Windows.Forms.ToolStripMenuItem settingsTriangulateMeshes;
}