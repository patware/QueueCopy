using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Messaging
{
    public class FilesDroppedOnFolder : GalaSoft.MvvmLight.Messaging.GenericMessage<KeyValuePair<string, IEnumerable<string>>>
    {
        public FilesDroppedOnFolder(string folder, IEnumerable<string> droppedItems)
            : base(new KeyValuePair<string, IEnumerable<string>>(folder, droppedItems))
        {
        }

    }
}
