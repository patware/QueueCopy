using System;
namespace QueueCopy.Services
{
    public interface IMainWindowCodeBehindService
    {
        void Any_DragEnter(System.Windows.DragEventArgs e);
        void GivenJob_Drop(QueueCopy.Model.Job job, System.Windows.DragEventArgs e);
        void NewJob_Drop(System.Windows.DragEventArgs e);
        void Folder_Drop(string folderPath, System.Windows.DragEventArgs e);
    }
}
