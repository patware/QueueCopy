using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Deployment;
using System.Deployment.Application;

namespace QueueCopy
{
    
    public partial class MainForm : Form
    {
        private string _rootDiscoveryMessage = string.Empty;
        public delegate void FileCopiedDelegate(string message);
        private Queue<CopyJob> _jobs = new Queue<CopyJob>();
        private DirectoryInfo _rootFolder = null;
        private Dictionary<string, TreeNode> _fastNodes;

        private void startCopyProcess(DirectoryInfo destination, string[] fileList)
        {
            // For example add all files into a simple label control:
            foreach (string file in fileList)
            {
                DirectoryInfo source = new DirectoryInfo(file);

                CopyJob cj = new CopyJob(source, destination);
                Log(string.Format("adding job: [{0}]", source.FullName));
                _jobs.Enqueue(new CopyJob(source, destination));
            }
            Log("jobs added...");

            if (!uxCopyBackgroundWorker.IsBusy)
                uxCopyBackgroundWorker.RunWorkerAsync();
        }
        private void Log(string message)
        {
            uxFileCopiedListBox.SelectedIndex = uxFileCopiedListBox.Items.Add(message);
        }
        private void setShortcutDropFolders(string current)
        {
            uxShortcutDropFoldersListBox.DataSource = current.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
        private void setCurrentRootFolder(string current)
        {
            uxTreeViewRootLinkLabel.Text = current;
            uxCurrentFolderFileSystemWatcher.IncludeSubdirectories = true;
            uxCurrentFolderFileSystemWatcher.Path = current;
            uxCurrentFolderFileSystemWatcher.EnableRaisingEvents = true;
            uxFolderDiscoveryBackgroundWorker.RunWorkerAsync(current);


        }
        private void loadFoldersInTreeView(List<DirectoryInfo> folders)
        {
            _fastNodes = new Dictionary<string, TreeNode>(folders.Count);

            foreach (DirectoryInfo folder in folders)
            {
                makeSureNodeExists(folder);
            }
        }
        private TreeNode makeSureNodeExists(DirectoryInfo folder)
        {
            TreeNode node = null;

            //first, make sure we didn't reach the rock bottom.
            if (folder.FullName != _rootFolder.FullName)
            {
                //try to find the parent in the super fast dic
                if (_fastNodes.ContainsKey(folder.FullName))
                    node = _fastNodes[folder.FullName];
                else
                {
                    TreeNode parent = makeSureNodeExists(folder.Parent);

                    if (parent == null)
                    {
                        //this means that this folder is a "sub root item" that we need to ensure is in the treeview

                        // try to find this folder in the root nodes
                        if (uxDestinationTreeView.Nodes.ContainsKey(folder.FullName))
                            node = uxDestinationTreeView.Nodes[folder.FullName];
                        else
                        {
                            node = uxDestinationTreeView.Nodes.Add(folder.FullName, folder.Name);
                            node.Tag = folder.FullName;
                            _fastNodes.Add(folder.FullName, node);
                        }
                    }
                    else
                    {
                        //add this node to the parent and to the 
                        node = parent.Nodes.Add(folder.FullName, folder.Name);
                        node.Tag = folder.FullName;
                        //and to the 
                        _fastNodes.Add(folder.FullName, node);
                    }
                }
            }

            return node;
        }
        
        public MainForm()
        {
            InitializeComponent();
        }

        void job_FileCopied(object sender, FileEventHandler e)
        {
            uxFileCopiedListBox.Invoke(new FileCopiedDelegate(this.Log),new object[]{e.File.FullName});
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            uxDestinationTreeView.AllowDrop = true;
            uxDestinationTreeView.DragEnter += new DragEventHandler(uxDestinationTreeView_DragEnter);
            uxDestinationTreeView.DragDrop += new DragEventHandler(uxDestinationTreeView_DragDrop);

            uxCopyBackgroundWorker.RunWorkerAsync();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                uxVersionToolStripStatusLabel.Text = ad.CurrentVersion.ToString();
            }
            else
                uxVersionToolStripStatusLabel.Text = Application.ProductVersion;

        }

        private void uxDestinationTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void uxDestinationTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (uxDestinationTreeView.Nodes.Count > 0)
            {
                TreeNode node = uxDestinationTreeView.GetNodeAt(uxDestinationTreeView.PointToClient(new Point(e.X, e.Y)));
                if (node == null)
                    node = uxDestinationTreeView.Nodes[0];

                DirectoryInfo destination = new DirectoryInfo(node.Tag.ToString());

                // Extract the data from the DataObject-Container into a string list
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                startCopyProcess(destination, fileList);
            }

        }

        private void uxTargetDropListBox_DragDrop(object sender, DragEventArgs e)
        {
            int index = uxShortcutDropFoldersListBox.IndexFromPoint(uxShortcutDropFoldersListBox.PointToClient(new Point(e.X, e.Y)));
            if (index == -1 && uxShortcutDropFoldersListBox.Items.Count > 0)
                index = 0;

            if (index > -1)
            {
                DirectoryInfo destination = new DirectoryInfo((string)uxShortcutDropFoldersListBox.Items[index]);

                // Extract the data from the DataObject-Container into a string list
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                
                startCopyProcess(destination, fileList);
            }

        }

        private void uxTargetDropListBox_DragEnter(object sender, DragEventArgs e)
        {
            int index = uxShortcutDropFoldersListBox.IndexFromPoint(uxShortcutDropFoldersListBox.PointToClient(new Point(e.X, e.Y)));
            if (index == -1 && uxShortcutDropFoldersListBox.Items.Count > 0)
                index = 0;

            if (index > -1 && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            
        }

        private void uxTargetDropListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete && uxShortcutDropFoldersListBox.SelectedIndex > -1)
                uxShortcutDropFoldersListBox.Items.RemoveAt(uxShortcutDropFoldersListBox.SelectedIndex);

        }

        private void uxTargetDropListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && uxShortcutDropFoldersListBox.SelectedIndex > -1)
                uxShortcutDropFoldersListBox.Items.RemoveAt(uxShortcutDropFoldersListBox.SelectedIndex);

            if (e.KeyCode == Keys.Insert)
            {
                using (InputBox box = new InputBox("Add folder"))
                {
                    DialogResult dr = box.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        uxShortcutDropFoldersListBox.Items.Add(box.ReturnValue);
                    }
                }
            }

        }

        private void uxCopyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_jobs.Count > 0)
            {
                CopyJob job = _jobs.Dequeue();

                job.FileCopied += new CopyJob.FileCopiedEventHandler(job_FileCopied);
                job.Copy();
                Application.DoEvents();
            }

        }

        private void uxDisplayTimer_Tick(object sender, EventArgs e)
        {
            if (uxCopyBackgroundWorker.IsBusy)
                uxCurrentStatusToolStripStatusLabel.Text = string.Format("Items in queue: [{0}]", _jobs.Count);
            else
                if (uxFolderDiscoveryBackgroundWorker.IsBusy)
                {
                    uxCurrentStatusToolStripStatusLabel.Text = _rootDiscoveryMessage;
                }
                else
                {
                    if (uxCurrentStatusToolStripStatusLabel.Text != "Worker process not... working!")
                        uxCurrentStatusToolStripStatusLabel.Text = "Worker process not... working!";
                }
        }

        private void uxCopyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log("All Copying Jobs done...");
        }

        private void uxShortcutDropFoldersLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string current = global::QueueCopy.Properties.Settings.Default.ShortcutDropFolders;

            InputBox box = new InputBox("Enter the folders (one per line)", current);
            box.IsMultiline = true;
            if (box.ShowDialog() == DialogResult.OK)
            {
                current = box.ReturnValue;

                global::QueueCopy.Properties.Settings.Default.ShortcutDropFolders = current;

                setShortcutDropFolders(current);

            }

        }

        private void uxTreeViewRootLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string current = global::QueueCopy.Properties.Settings.Default.CurrentFolder;

            uxMainFolderBrowserDialog.Description = "Choose the root target folder";
            uxMainFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            uxMainFolderBrowserDialog.SelectedPath = current;

            if (uxMainFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                current = uxMainFolderBrowserDialog.SelectedPath;

                setCurrentRootFolder(current);
            }



        }

        private void uxCurrentFolderFileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {                
                DirectoryInfo di = new DirectoryInfo(e.FullPath);

                if ((di.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {               
                    TreeNode node = makeSureNodeExists(di);
                    node.EnsureVisible();
                }
            }
        }

        private void uxFolderDiscoveryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _rootFolder = new DirectoryInfo(e.Argument.ToString());
            List<DirectoryInfo> allFolders = new List<DirectoryInfo>();

            _rootDiscoveryMessage = string.Format("discovering sub folders under {0}", _rootFolder.FullName);

            Queue<DirectoryInfo> foldersToDiscover = new Queue<DirectoryInfo>();

            foldersToDiscover.Enqueue(_rootFolder);
            allFolders.Add(_rootFolder);

            uxFolderDiscoveryBackgroundWorker.ReportProgress(0);

            DirectoryInfo currentFolder;

            while (foldersToDiscover.Count > 0)
            {
                uxFolderDiscoveryBackgroundWorker.ReportProgress(Convert.ToInt32(100.0 * Convert.ToDouble(allFolders.Count - foldersToDiscover.Count) / allFolders.Count));

                currentFolder = foldersToDiscover.Dequeue();
                DirectoryInfo[] childFolders = null;

                try
                {
                    childFolders = currentFolder.GetDirectories();
                    allFolders.AddRange(childFolders);

                    for (int i = 0; i < childFolders.Length; i++)
                    {
                        foldersToDiscover.Enqueue(childFolders[i]);
                    }

                }
                catch (System.Security.SecurityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            e.Result = allFolders;
        }

        private void uxFolderDiscoveryBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _rootDiscoveryMessage = "";
            uxProgressToolStripProgressBar.Value = 0;

            uxDestinationTreeView.BeginUpdate();
            uxDestinationTreeView.Nodes.Clear();
            loadFoldersInTreeView(e.Result as List<DirectoryInfo>);
            uxDestinationTreeView.EndUpdate();
        }

        private void uxCopyBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uxProgressToolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void uxFolderDiscoveryBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uxProgressToolStripProgressBar.Value = e.ProgressPercentage;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void saveSettings()
        {
            global::QueueCopy.Properties.Settings.Default.Save();
        }

        private void uxCheckForUpdateToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm();
            form.StartPosition = FormStartPosition.CenterParent;

            form.ShowDialog();
        }


    }
}