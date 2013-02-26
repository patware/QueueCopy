using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Model
{
    public class DataItem
    {
        public DataItem()
        {
            Jobs = new List<Model.Job>();
            Favorites = new List<string>();
            Recents = new List<string>();
            SystemFolders = new List<string>();
        }

        public IList<Model.Job> Jobs { get; set; }

        public IList<string> Favorites { get; set; }

        public IList<string> Recents { get; set; }

        public IList<string> SystemFolders { get; set; }
    }
}
