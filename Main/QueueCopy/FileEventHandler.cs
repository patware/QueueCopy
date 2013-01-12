using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QueueCopy
{
    class FileEventHandler : EventArgs
    {
        public FileInfo File;

        public FileEventHandler(FileInfo file)
        {
            File = file;
        }
    }
}
