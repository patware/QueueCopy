using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using QueueCopy.ViewModel;

namespace QueueCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void JobList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            //e.Handled = true;
            
        }

        private void JobList_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                var fd = new Messaging.FilesDropped(files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDropped>(fd);
            }

            e.Handled = true;
        }

        private void JobItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            //e.Handled = true;
        }

        private void JobItem_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                System.Windows.Controls.TextBlock tb = sender as System.Windows.Controls.TextBlock;
                var foo = tb.DataContext as Model.Job;

                var fd = new Messaging.FilesDroppedOnJob(foo, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnJob>(fd);
            }

            e.Handled = true;
        }

        private void SystemFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            //e.Handled = true;

        }

        private void SystemFolder_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                FrameworkElement fe = sender as FrameworkElement;
                var foo = fe.DataContext.ToString();

                var fd = new Messaging.FilesDroppedOnFolder(foo, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnFolder>(fd);
            }

            e.Handled = true;
        }

        private void ComputerFolder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void ComputerFolder_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                FrameworkElement fe = sender as FrameworkElement;
                var foo = fe.DataContext.ToString();

                var fd = new Messaging.FilesDroppedOnFolder(foo, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnFolder>(fd);
            }

            e.Handled = true;
        }

        private void RecentItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            //e.Handled = true;

        }

        private void RecentItem_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                FrameworkElement fe = sender as FrameworkElement;
                var foo = fe.DataContext.ToString();

                var fd = new Messaging.FilesDroppedOnFolder(foo, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnFolder>(fd);
            }

            e.Handled = true;
        }

        private void FavoriteItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            e.Handled = true;

        }

        private void FavoriteItem_Drop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;

            if (files != null)
            {
                FrameworkElement fe = sender as FrameworkElement;
                var foo = fe.DataContext.ToString();

                var fd = new Messaging.FilesDroppedOnFolder(foo, files);

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FilesDroppedOnFolder>(fd);
            }

            e.Handled = true;
        }

        private void SelectedJobDetail_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            //e.Handled = true;

        }

        private void SelectedJobDetail_Drop(object sender, DragEventArgs e)
        {

        }

        
        
    }
}