using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace QueueCopy.Model
{
    public class Job : ViewModelBase
    {
        
        public Job()
        {
            Sources = new System.Collections.ObjectModel.ObservableCollection<string>();
            this.Sources.CollectionChanged += Sources_CollectionChanged;
        }

        void Sources_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(TitlePropertyName);
        }
        public Job(string destination):this()
        {
            Destination = new System.IO.DirectoryInfo(destination);

            TargetFolder = Destination.FullName;
        }

        public Job(string destination, IEnumerable<string> source) : this(destination)
        {
            foreach (var s in source)
                this.Sources.Add(s);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<string> Sources { get; set; }


        #region Properties

        #region Destination
        /// <summary>
        /// The <see cref="Destination" /> property's name.
        /// </summary>
        public const string DestinationPropertyName = "Destination";

        private System.IO.DirectoryInfo _destination;

        /// <summary>
        /// Sets and gets the Destination property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.IO.DirectoryInfo Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                if (_destination == value)
                {
                    return;
                }

                RaisePropertyChanging(DestinationPropertyName);
                _destination = value;
                _targetFolder = value.FullName;
                RaisePropertyChanged(TargetFolderPropertyName);
                RaisePropertyChanged(DestinationPropertyName);
            }
        }
        #endregion

        /// <summary>
        /// The <see cref="TargetFolder" /> property's name.
        /// </summary>
        public const string TargetFolderPropertyName = "TargetFolder";

        private string _targetFolder;

        /// <summary>
        /// Sets and gets the TargetFolder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TargetFolder
        {
            get
            {
                return _targetFolder;
            }

            set
            {
                if (_targetFolder == value)
                {
                    return;
                }

                RaisePropertyChanging(TargetFolderPropertyName);
                _targetFolder = value;
                _destination = new System.IO.DirectoryInfo(value);
                RaisePropertyChanged(TargetFolderPropertyName);
                RaisePropertyChanged(DestinationPropertyName);
            }
        }

        #region Title
        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return Destination.FullName + " (" + this.Sources.Count + ")";
            }
        }
        #endregion

        #region FoldersToDo

        /// <summary>
        /// The <see cref="FoldersToDo" /> property's name.
        /// </summary>
        public const string FoldersToDoPropertyName = "FoldersToDo";

        private int _foldersToDo = 0;

        /// <summary>
        /// Sets and gets the FoldersToDo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FoldersToDo
        {
            get
            {
                return _foldersToDo;
            }

            set
            {
                if (_foldersToDo == value)
                {
                    return;
                }

                RaisePropertyChanging(FoldersToDoPropertyName);
                _foldersToDo = value;
                RaisePropertyChanged(FoldersToDoPropertyName);
            }
        }
        #endregion

        #region FoldersTotal
        /// <summary>
        /// The <see cref="FoldersTotal" /> property's name.
        /// </summary>
        public const string FoldersTotalPropertyName = "FoldersTotal";

        private int _foldersTotal = 0;

        /// <summary>
        /// Sets and gets the FoldersTotal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FoldersTotal
        {
            get
            {
                return _foldersTotal;
            }

            set
            {
                if (_foldersTotal == value)
                {
                    return;
                }

                RaisePropertyChanging(FoldersTotalPropertyName);
                _foldersTotal = value;
                RaisePropertyChanged(FoldersTotalPropertyName);
            }
        }
        #endregion

        #region FilesToDo
        /// <summary>
        /// The <see cref="FilesToDo" /> property's name.
        /// </summary>
        public const string FilesToDoPropertyName = "FilesToDo";

        private int _filesToDo = 0;

        /// <summary>
        /// Sets and gets the FilesToDo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FilesToDo
        {
            get
            {
                return _filesToDo;
            }

            set
            {
                if (_filesToDo == value)
                {
                    return;
                }

                RaisePropertyChanging(FilesToDoPropertyName);
                _filesToDo = value;
                RaisePropertyChanged(FilesToDoPropertyName);
            }
        }
        #endregion

        #region FilesTotal
        /// <summary>
        /// The <see cref="FilesTotal" /> property's name.
        /// </summary>
        public const string FilesTotalPropertyName = "FilesTotal";

        private int _filesTotal = 0;

        /// <summary>
        /// Sets and gets the FilesTotal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FilesTotal
        {
            get
            {
                return _filesTotal;
            }

            set
            {
                if (_filesTotal == value)
                {
                    return;
                }

                RaisePropertyChanging(FilesTotalPropertyName);
                _filesTotal = value;
                RaisePropertyChanged(FilesTotalPropertyName);
            }
        }
        #endregion

        #region TargetFolderIsReadOnly
        /// <summary>
        /// The <see cref="TargetFolderIsReadOnly" /> property's name.
        /// </summary>
        public const string TargetFolderIsReadOnlyPropertyName = "TargetFolderIsReadOnly";

        private bool _targetFolderIsReadOnly = true;

        /// <summary>
        /// Sets and gets the TargetFolderIsReadOnly property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool TargetFolderIsReadOnly
        {
            get
            {
                return _targetFolderIsReadOnly;
            }

            set
            {
                if (_targetFolderIsReadOnly == value)
                {
                    return;
                }

                RaisePropertyChanging(TargetFolderIsReadOnlyPropertyName);
                _targetFolderIsReadOnly = value;
                RaisePropertyChanged(TargetFolderIsReadOnlyPropertyName);
            }
        }
        #endregion

        #region Step
        /// <summary>
        /// The <see cref="Step" /> property's name.
        /// </summary>
        public const string StepPropertyName = "Step";

        private int _step = 0;

        /// <summary>
        /// Sets and gets the Step property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Step
        {
            get
            {
                return _step;
            }

            set
            {
                if (_step == value)
                {
                    return;
                }

                RaisePropertyChanging(StepPropertyName);
                _step = value;
                RaisePropertyChanged(StepPropertyName);
            }
        }
        #endregion

        #region StepMessage
        /// <summary>
        /// The <see cref="StepMessage" /> property's name.
        /// </summary>
        public const string StepMessagePropertyName = "StepMessage";

        private string _stepMessage = "Not Started";

        /// <summary>
        /// Sets and gets the StepMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StepMessage
        {
            get
            {
                return _stepMessage;
            }

            set
            {
                if (_stepMessage == value)
                {
                    return;
                }

                RaisePropertyChanging(StepMessagePropertyName);
                _stepMessage = value;
                RaisePropertyChanged(StepMessagePropertyName);
            }
        }
        #endregion

        #region Progress
        /// <summary>
        /// The <see cref="Progress" /> property's name.
        /// </summary>
        public const string ProgressPropertyName = "Progress";

        private int _progress = 0;

        /// <summary>
        /// Sets and gets the Progress property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                if (_progress == value)
                {
                    return;
                }

                RaisePropertyChanging(ProgressPropertyName);
                _progress = value;
                RaisePropertyChanged(ProgressPropertyName);
            }
        }
        #endregion

        #region ProgressMessage
        /// <summary>
        /// The <see cref="ProgressMessage" /> property's name.
        /// </summary>
        public const string ProgressMessagePropertyName = "ProgressMessage";

        private string _progressMessage = string.Empty;

        /// <summary>
        /// Sets and gets the ProgressMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ProgressMessage
        {
            get
            {
                return _progressMessage;
            }

            set
            {
                if (_progressMessage == value)
                {
                    return;
                }

                RaisePropertyChanging(ProgressMessagePropertyName);
                _progressMessage = value;
                RaisePropertyChanged(ProgressMessagePropertyName);
            }
        }
        #endregion

        #endregion

    }
}
