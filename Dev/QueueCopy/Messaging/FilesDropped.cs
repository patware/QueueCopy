using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Messaging
{
    public class FilesDropped : GalaSoft.MvvmLight.Messaging.GenericMessage<IEnumerable<string>>
    {
        public FilesDropped(IEnumerable<string> files) : base(files)
        {

        }
                
    }
}
