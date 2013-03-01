using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Services
{
    public class DialogService : QueueCopy.Services.IDialogService
    {
        public string BrowseFolder(string initialFolder)
        {
            return initialFolder;
        }
    }
}
