namespace QueueCopy
{
    partial class MainForm
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.uxDestinationTreeView = new System.Windows.Forms.TreeView();
            this.uxShortcutDropFoldersListBox = new System.Windows.Forms.ListBox();
            this.uxCopyBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.uxDisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.uxFileCopiedListBox = new System.Windows.Forms.ListBox();
            this.uxMainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uxCurrentStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxProgressToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.uxMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxShortcutDropFoldersLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uxRightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxCurrentFolderLabel = new System.Windows.Forms.Label();
            this.uxTreeViewRootLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uxCurrentFolderFileSystemWatcher = new System.IO.FileSystemWatcher();
            this.uxMainFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.uxFolderDiscoveryBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.uxVersionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxCheckForUpdateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxMainStatusStrip.SuspendLayout();
            this.uxMainSplitContainer.Panel1.SuspendLayout();
            this.uxMainSplitContainer.Panel2.SuspendLayout();
            this.uxMainSplitContainer.SuspendLayout();
            this.uxLeftSplitContainer.Panel1.SuspendLayout();
            this.uxLeftSplitContainer.SuspendLayout();
            this.uxRightSplitContainer.Panel1.SuspendLayout();
            this.uxRightSplitContainer.Panel2.SuspendLayout();
            this.uxRightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxCurrentFolderFileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // uxDestinationTreeView
            // 
            this.uxDestinationTreeView.AllowDrop = true;
            this.uxDestinationTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDestinationTreeView.FullRowSelect = true;
            this.uxDestinationTreeView.HotTracking = true;
            this.uxDestinationTreeView.Location = new System.Drawing.Point(0, 30);
            this.uxDestinationTreeView.Name = "uxDestinationTreeView";
            this.uxDestinationTreeView.Size = new System.Drawing.Size(519, 259);
            this.uxDestinationTreeView.TabIndex = 1;
            this.uxDestinationTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.uxDestinationTreeView_DragDrop);
            this.uxDestinationTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.uxDestinationTreeView_DragEnter);
            // 
            // uxShortcutDropFoldersListBox
            // 
            this.uxShortcutDropFoldersListBox.AllowDrop = true;
            this.uxShortcutDropFoldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxShortcutDropFoldersListBox.FormattingEnabled = true;
            this.uxShortcutDropFoldersListBox.Location = new System.Drawing.Point(0, 30);
            this.uxShortcutDropFoldersListBox.Name = "uxShortcutDropFoldersListBox";
            this.uxShortcutDropFoldersListBox.Size = new System.Drawing.Size(261, 108);
            this.uxShortcutDropFoldersListBox.TabIndex = 2;
            this.uxShortcutDropFoldersListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.uxTargetDropListBox_DragDrop);
            this.uxShortcutDropFoldersListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.uxTargetDropListBox_DragEnter);
            this.uxShortcutDropFoldersListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxTargetDropListBox_KeyPress);
            this.uxShortcutDropFoldersListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uxTargetDropListBox_KeyDown);
            // 
            // uxCopyBackgroundWorker
            // 
            this.uxCopyBackgroundWorker.WorkerReportsProgress = true;
            this.uxCopyBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxCopyBackgroundWorker_DoWork);
            this.uxCopyBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uxCopyBackgroundWorker_RunWorkerCompleted);
            this.uxCopyBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uxCopyBackgroundWorker_ProgressChanged);
            // 
            // uxDisplayTimer
            // 
            this.uxDisplayTimer.Enabled = true;
            this.uxDisplayTimer.Interval = 345;
            this.uxDisplayTimer.Tick += new System.EventHandler(this.uxDisplayTimer_Tick);
            // 
            // uxFileCopiedListBox
            // 
            this.uxFileCopiedListBox.BackColor = System.Drawing.Color.Black;
            this.uxFileCopiedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxFileCopiedListBox.ForeColor = System.Drawing.Color.Lime;
            this.uxFileCopiedListBox.FormattingEnabled = true;
            this.uxFileCopiedListBox.Location = new System.Drawing.Point(0, 0);
            this.uxFileCopiedListBox.Name = "uxFileCopiedListBox";
            this.uxFileCopiedListBox.Size = new System.Drawing.Size(519, 134);
            this.uxFileCopiedListBox.TabIndex = 5;
            // 
            // uxMainStatusStrip
            // 
            this.uxMainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxCurrentStatusToolStripStatusLabel,
            this.uxProgressToolStripProgressBar,
            this.uxVersionToolStripStatusLabel,
            this.uxCheckForUpdateToolStripStatusLabel});
            this.uxMainStatusStrip.Location = new System.Drawing.Point(0, 439);
            this.uxMainStatusStrip.Name = "uxMainStatusStrip";
            this.uxMainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.uxMainStatusStrip.TabIndex = 7;
            this.uxMainStatusStrip.Text = "statusStrip1";
            // 
            // uxCurrentStatusToolStripStatusLabel
            // 
            this.uxCurrentStatusToolStripStatusLabel.Name = "uxCurrentStatusToolStripStatusLabel";
            this.uxCurrentStatusToolStripStatusLabel.Size = new System.Drawing.Size(51, 17);
            this.uxCurrentStatusToolStripStatusLabel.Text = "Nothing";
            // 
            // uxProgressToolStripProgressBar
            // 
            this.uxProgressToolStripProgressBar.Name = "uxProgressToolStripProgressBar";
            this.uxProgressToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.uxProgressToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // uxMainSplitContainer
            // 
            this.uxMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxMainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uxMainSplitContainer.Name = "uxMainSplitContainer";
            // 
            // uxMainSplitContainer.Panel1
            // 
            this.uxMainSplitContainer.Panel1.Controls.Add(this.uxLeftSplitContainer);
            // 
            // uxMainSplitContainer.Panel2
            // 
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxRightSplitContainer);
            this.uxMainSplitContainer.Size = new System.Drawing.Size(784, 439);
            this.uxMainSplitContainer.SplitterDistance = 261;
            this.uxMainSplitContainer.TabIndex = 8;
            // 
            // uxLeftSplitContainer
            // 
            this.uxLeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxLeftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uxLeftSplitContainer.Name = "uxLeftSplitContainer";
            this.uxLeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uxLeftSplitContainer.Panel1
            // 
            this.uxLeftSplitContainer.Panel1.Controls.Add(this.uxShortcutDropFoldersLinkLabel);
            this.uxLeftSplitContainer.Panel1.Controls.Add(this.uxShortcutDropFoldersListBox);
            this.uxLeftSplitContainer.Size = new System.Drawing.Size(261, 439);
            this.uxLeftSplitContainer.SplitterDistance = 142;
            this.uxLeftSplitContainer.TabIndex = 0;
            // 
            // uxShortcutDropFoldersLinkLabel
            // 
            this.uxShortcutDropFoldersLinkLabel.AutoSize = true;
            this.uxShortcutDropFoldersLinkLabel.Location = new System.Drawing.Point(5, 10);
            this.uxShortcutDropFoldersLinkLabel.Name = "uxShortcutDropFoldersLinkLabel";
            this.uxShortcutDropFoldersLinkLabel.Size = new System.Drawing.Size(110, 13);
            this.uxShortcutDropFoldersLinkLabel.TabIndex = 3;
            this.uxShortcutDropFoldersLinkLabel.TabStop = true;
            this.uxShortcutDropFoldersLinkLabel.Text = "Shortcut Drop Folders";
            this.uxShortcutDropFoldersLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uxShortcutDropFoldersLinkLabel_LinkClicked);
            // 
            // uxRightSplitContainer
            // 
            this.uxRightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxRightSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uxRightSplitContainer.Name = "uxRightSplitContainer";
            this.uxRightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uxRightSplitContainer.Panel1
            // 
            this.uxRightSplitContainer.Panel1.Controls.Add(this.uxCurrentFolderLabel);
            this.uxRightSplitContainer.Panel1.Controls.Add(this.uxTreeViewRootLinkLabel);
            this.uxRightSplitContainer.Panel1.Controls.Add(this.uxDestinationTreeView);
            // 
            // uxRightSplitContainer.Panel2
            // 
            this.uxRightSplitContainer.Panel2.Controls.Add(this.uxFileCopiedListBox);
            this.uxRightSplitContainer.Size = new System.Drawing.Size(519, 439);
            this.uxRightSplitContainer.SplitterDistance = 291;
            this.uxRightSplitContainer.TabIndex = 0;
            // 
            // uxCurrentFolderLabel
            // 
            this.uxCurrentFolderLabel.AutoSize = true;
            this.uxCurrentFolderLabel.Location = new System.Drawing.Point(6, 7);
            this.uxCurrentFolderLabel.Name = "uxCurrentFolderLabel";
            this.uxCurrentFolderLabel.Size = new System.Drawing.Size(76, 13);
            this.uxCurrentFolderLabel.TabIndex = 3;
            this.uxCurrentFolderLabel.Text = "Current Folder:";
            // 
            // uxTreeViewRootLinkLabel
            // 
            this.uxTreeViewRootLinkLabel.AutoSize = true;
            this.uxTreeViewRootLinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::QueueCopy.Properties.Settings.Default, "CurrentFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.uxTreeViewRootLinkLabel.Location = new System.Drawing.Point(88, 7);
            this.uxTreeViewRootLinkLabel.Name = "uxTreeViewRootLinkLabel";
            this.uxTreeViewRootLinkLabel.Size = new System.Drawing.Size(22, 13);
            this.uxTreeViewRootLinkLabel.TabIndex = 2;
            this.uxTreeViewRootLinkLabel.TabStop = true;
            this.uxTreeViewRootLinkLabel.Text = global::QueueCopy.Properties.Settings.Default.CurrentFolder;
            this.uxTreeViewRootLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uxTreeViewRootLinkLabel_LinkClicked);
            // 
            // uxCurrentFolderFileSystemWatcher
            // 
            this.uxCurrentFolderFileSystemWatcher.EnableRaisingEvents = true;
            this.uxCurrentFolderFileSystemWatcher.IncludeSubdirectories = true;
            this.uxCurrentFolderFileSystemWatcher.SynchronizingObject = this;
            this.uxCurrentFolderFileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.uxCurrentFolderFileSystemWatcher_Created);
            // 
            // uxFolderDiscoveryBackgroundWorker
            // 
            this.uxFolderDiscoveryBackgroundWorker.WorkerReportsProgress = true;
            this.uxFolderDiscoveryBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uxFolderDiscoveryBackgroundWorker_DoWork);
            this.uxFolderDiscoveryBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uxFolderDiscoveryBackgroundWorker_RunWorkerCompleted);
            this.uxFolderDiscoveryBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uxFolderDiscoveryBackgroundWorker_ProgressChanged);
            // 
            // uxVersionToolStripStatusLabel
            // 
            this.uxVersionToolStripStatusLabel.Name = "uxVersionToolStripStatusLabel";
            this.uxVersionToolStripStatusLabel.Size = new System.Drawing.Size(49, 17);
            this.uxVersionToolStripStatusLabel.Text = "Version:";
            // 
            // uxCheckForUpdateToolStripStatusLabel
            // 
            this.uxCheckForUpdateToolStripStatusLabel.IsLink = true;
            this.uxCheckForUpdateToolStripStatusLabel.Name = "uxCheckForUpdateToolStripStatusLabel";
            this.uxCheckForUpdateToolStripStatusLabel.Size = new System.Drawing.Size(98, 17);
            this.uxCheckForUpdateToolStripStatusLabel.Text = "Check for update";
            this.uxCheckForUpdateToolStripStatusLabel.Click += new System.EventHandler(this.uxCheckForUpdateToolStripStatusLabel_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.uxMainSplitContainer);
            this.Controls.Add(this.uxMainStatusStrip);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.uxMainStatusStrip.ResumeLayout(false);
            this.uxMainStatusStrip.PerformLayout();
            this.uxMainSplitContainer.Panel1.ResumeLayout(false);
            this.uxMainSplitContainer.Panel2.ResumeLayout(false);
            this.uxMainSplitContainer.ResumeLayout(false);
            this.uxLeftSplitContainer.Panel1.ResumeLayout(false);
            this.uxLeftSplitContainer.Panel1.PerformLayout();
            this.uxLeftSplitContainer.ResumeLayout(false);
            this.uxRightSplitContainer.Panel1.ResumeLayout(false);
            this.uxRightSplitContainer.Panel1.PerformLayout();
            this.uxRightSplitContainer.Panel2.ResumeLayout(false);
            this.uxRightSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxCurrentFolderFileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView uxDestinationTreeView;
        private System.Windows.Forms.ListBox uxShortcutDropFoldersListBox;
        private System.ComponentModel.BackgroundWorker uxCopyBackgroundWorker;
        private System.Windows.Forms.Timer uxDisplayTimer;
        private System.Windows.Forms.ListBox uxFileCopiedListBox;
        private System.Windows.Forms.StatusStrip uxMainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel uxCurrentStatusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar uxProgressToolStripProgressBar;
        private System.Windows.Forms.SplitContainer uxMainSplitContainer;
        private System.Windows.Forms.SplitContainer uxLeftSplitContainer;
        private System.Windows.Forms.SplitContainer uxRightSplitContainer;
        private System.Windows.Forms.LinkLabel uxShortcutDropFoldersLinkLabel;
        private System.Windows.Forms.Label uxCurrentFolderLabel;
        private System.Windows.Forms.LinkLabel uxTreeViewRootLinkLabel;
        private System.IO.FileSystemWatcher uxCurrentFolderFileSystemWatcher;
        private System.Windows.Forms.FolderBrowserDialog uxMainFolderBrowserDialog;
        private System.ComponentModel.BackgroundWorker uxFolderDiscoveryBackgroundWorker;
        private System.Windows.Forms.ToolStripStatusLabel uxVersionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel uxCheckForUpdateToolStripStatusLabel;
    }
}

