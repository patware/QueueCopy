using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueCopy.Messaging
{
    public class FilesDroppedOnJob : GalaSoft.MvvmLight.Messaging.GenericMessage<KeyValuePair<Model.Job, IEnumerable<string>>>
    {
        public FilesDroppedOnJob(Model.Job job, IEnumerable<string> droppedItems)
            : base(new KeyValuePair<Model.Job, IEnumerable<string>>(job, droppedItems))
        {

        }
    }
}
