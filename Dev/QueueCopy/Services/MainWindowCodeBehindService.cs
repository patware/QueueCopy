using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace QueueCopy.Services
{
    public class MainWindowCodeBehindService : QueueCopy.Services.IMainWindowCodeBehindService
    {
        public void Any_DragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;

            e.Handled = true;

        }

        public void NewJob_Drop(DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                var fd = new Messaging.FilesDropped(files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDropped>(fd);
            }

            e.Handled = true;

        }

        public void GivenJob_Drop(Model.Job job, DragEventArgs e)
        {

            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                var fd = new Messaging.FilesDroppedOnJob(job, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnJob>(fd);
            }

            e.Handled = true;            
        }

        public void Folder_Drop(string folderPath, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                var fd = new Messaging.FilesDroppedOnFolder(folderPath, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnFolder>(fd);
            }

            e.Handled = true;
        }


    }
}
