using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QueueCopy
{
    class CopyJob
    {
        public delegate void FileCopiedEventHandler(object sender, FileEventHandler e);
        public event FileCopiedEventHandler FileCopied;
        public DirectoryInfo SourceFolder;
        public DirectoryInfo DestinationFolder;
        public long BytesCopied = 0;
        public DateTime StartedAt = DateTime.MinValue;
        public DateTime FinishedAt = DateTime.MinValue;

        public CopyJob(DirectoryInfo source, DirectoryInfo destination)
        {
            SourceFolder = source;
            DestinationFolder = destination;
        }

        public void Copy()
        {
            this.StartedAt = DateTime.Now;

            createFolderStructure(this.SourceFolder, this.DestinationFolder);

            copyFiles(this.SourceFolder, this.DestinationFolder.GetDirectories(this.SourceFolder.Name)[0]);

            this.FinishedAt = DateTime.Now;

        }

        private void copyFiles(DirectoryInfo source, DirectoryInfo destination)
        {
            FileInfo[] files = source.GetFiles();

            foreach (FileInfo file in files)
            {
                FileInfo newFile = new FileInfo(destination.FullName + "\\" + file.Name);
                if (newFile.Exists)
                {
                    if (file.Length > newFile.Length)
                    {
                        newFile.Delete();
                        file.CopyTo(newFile.FullName);
                        if (FileCopied != null)
                            FileCopied(this,new FileEventHandler(newFile));
                    }
                }
                else
                {
                    file.CopyTo(newFile.FullName);
                    if (FileCopied != null)
                        FileCopied(this, new FileEventHandler(newFile));
                }

            }

            DirectoryInfo[] dis = source.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                copyFiles(di, new DirectoryInfo(destination.FullName + "\\" + di.Name));
            }
        }

        private void createFolderStructure(DirectoryInfo source, DirectoryInfo destination)
        {
            DirectoryInfo newDirectory = new DirectoryInfo(destination.FullName + "\\" + source.Name);

            if (!newDirectory.Exists)
            {
                newDirectory.Create();
            }

            DirectoryInfo[] dis = source.GetDirectories("*");

            foreach (DirectoryInfo di in dis)
            {
                createFolderStructure(di, newDirectory);
            }

        }        
    }
}
