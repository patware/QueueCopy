using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using QueueCopy.ViewModel;

namespace QueueCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public QueueCopy.Services.IMainWindowCodeBehindService MainWindowCodeBehindService;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            MainWindowCodeBehindService = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<QueueCopy.Services.IMainWindowCodeBehindService>();

            if (MainWindowCodeBehindService == null)
                MainWindowCodeBehindService = new Services.MainWindowCodeBehindService();
        }

        private void JobList_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);
        }

        private void JobList_Drop(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.NewJob_Drop(e);
        }

        private void JobItem_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);
            
        }

        private void JobItem_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.GivenJob_Drop(fe.DataContext as Model.Job,e);
        }

        private void SystemFolder_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);
            
        }

        private void SystemFolder_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.Folder_Drop(fe.DataContext.ToString(), e);
        }

        private void ComputerFolder_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);
        }

        private void ComputerFolder_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.Folder_Drop(fe.DataContext.ToString(), e);
        }

        private void RecentItem_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);

        }

        private void RecentItem_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.Folder_Drop(fe.DataContext.ToString(), e);
        }

        private void FavoriteItem_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);

        }

        private void FavoriteItem_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.Folder_Drop(fe.DataContext.ToString(), e);
        }

        private void SelectedJobDetail_DragEnter(object sender, DragEventArgs e)
        {
            MainWindowCodeBehindService.Any_DragEnter(e);
        }

        private void SelectedJobDetail_Drop(object sender, DragEventArgs e)
        {
            var fe = sender as FrameworkElement;

            MainWindowCodeBehindService.GivenJob_Drop(fe.DataContext as Model.Job, e);

        }

        
        
    }
}