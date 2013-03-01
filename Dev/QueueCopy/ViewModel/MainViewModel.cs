using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QueueCopy.Model;

namespace QueueCopy.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly Services.IDataService _dataService;
        private readonly Services.IDialogService _dialogService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(Services.IDataService dataService,Services.IDialogService dialogService)
        {

            _favorites = new System.Collections.ObjectModel.ObservableCollection<string>();

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FilesDropped>(this, files_Dropped);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FilesDroppedOnJob>(this, files_DroppedOnJob);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FilesDroppedOnFolder>(this, files_DroppedOnFolder);

            _dataService = dataService;
            _dialogService = dialogService;
            
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    _jobs = new System.Collections.ObjectModel.ObservableCollection<Model.Job>(item.Jobs);

                    if (_jobs.Count > 0) _selectedJob = _jobs[0];

                    _favorites = new System.Collections.ObjectModel.ObservableCollection<string>(item.Favorites);

                    _recents = new System.Collections.ObjectModel.ObservableCollection<string>(item.Recents);

                    _systemFolders = new System.Collections.ObjectModel.ObservableCollection<string>(item.SystemFolders);
                });

            //select the "favorites"
            _selectedTabIndex = 1;

            this.PropertyChanged += MainViewModel_PropertyChanged;
        }

        void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case SelectedJobPropertyName:
                    this.SelectedTabIndex = 0;
                    break;
            }
        }


        #region Properties

        #region Jobs
        /// <summary>
        /// The <see cref="Jobs" /> property's name.
        /// </summary>
        public const string JobsPropertyName = "Jobs";

        private System.Collections.ObjectModel.ObservableCollection<Model.Job> _jobs;

        /// <summary>
        /// Sets and gets the Jobs property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Model.Job> Jobs
        {
            get
            {
                return _jobs;
            }

            set
            {
                if (_jobs == value)
                {
                    return;
                }

                RaisePropertyChanging(JobsPropertyName);
                _jobs = value;
                RaisePropertyChanged(JobsPropertyName);
            }
        }
        #endregion

        #region SelectedJob
        /// <summary>
        /// The <see cref="SelectedJob" /> property's name.
        /// </summary>
        public const string SelectedJobPropertyName = "SelectedJob";

        private Model.Job _selectedJob;

        /// <summary>
        /// Sets and gets the SelectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Model.Job SelectedJob
        {
            get
            {
                return _selectedJob;
            }

            set
            {
                if (_selectedJob == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedJobPropertyName);
                _selectedJob = value;
                RaisePropertyChanged(SelectedJobPropertyName);
            }
        }
        #endregion

        #region Favorites
        /// <summary>
        /// The <see cref="Favorites" /> property's name.
        /// </summary>
        public const string FavoritesPropertyName = "Favorites";

        private System.Collections.ObjectModel.ObservableCollection<string> _favorites ;

        /// <summary>
        /// Sets and gets the Favorites property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<string> Favorites
        {
            get
            {
                return _favorites;
            }

            set
            {
                if (_favorites == value)
                {
                    return;
                }

                RaisePropertyChanging(FavoritesPropertyName);
                _favorites = value;
                RaisePropertyChanged(FavoritesPropertyName);
            }
        }
        #endregion

        #region FavoriteToAdd
        /// <summary>
        /// The <see cref="FavoriteToAdd" /> property's name.
        /// </summary>
        public const string FavoriteToAddPropertyName = "FavoriteToAdd";

        private string _favoriteToAdd = string.Empty;

        /// <summary>
        /// Sets and gets the FavoriteToAdd property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FavoriteToAdd
        {
            get
            {
                return _favoriteToAdd;
            }

            set
            {
                if (_favoriteToAdd == value)
                {
                    return;
                }

                RaisePropertyChanging(FavoriteToAddPropertyName);
                _favoriteToAdd = value;
                RaisePropertyChanged(FavoriteToAddPropertyName);
            }
        }
        #endregion

        #region Recents

        /// <summary>
        /// The <see cref="Recents" /> property's name.
        /// </summary>
        public const string RecentsPropertyName = "Recents";

        private System.Collections.ObjectModel.ObservableCollection<string> _recents;

        /// <summary>
        /// Sets and gets the Recents property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<string> Recents
        {
            get
            {
                return _recents;
            }

            set
            {
                if (_recents == value)
                {
                    return;
                }

                RaisePropertyChanging(RecentsPropertyName);
                _recents = value;
                RaisePropertyChanged(RecentsPropertyName);
            }
        }

        #endregion

        #region SystemFolders
        /// <summary>
        /// The <see cref="SystemFolders" /> property's name.
        /// </summary>
        public const string SystemFoldersPropertyName = "SystemFolders";

        private System.Collections.ObjectModel.ObservableCollection<string> _systemFolders;

        /// <summary>
        /// Sets and gets the SystemFolders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<string> SystemFolders
        {
            get
            {
                return _systemFolders;
            }

            set
            {
                if (_systemFolders == value)
                {
                    return;
                }

                RaisePropertyChanging(SystemFoldersPropertyName);
                _systemFolders = value;
                RaisePropertyChanged(SystemFoldersPropertyName);
            }
        }
        #endregion

        #region AutoStartOnDrop
        /// <summary>
        /// The <see cref="AutoStartOnDrop" /> property's name.
        /// </summary>
        public const string AutoStartOnDropPropertyName = "AutoStartOnDrop";

        private bool _autoStartOnDrop;

        /// <summary>
        /// Sets and gets the AutoStartOnDrop property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool AutoStartOnDrop
        {
            get
            {
                return _autoStartOnDrop;
            }

            set
            {
                if (_autoStartOnDrop == value)
                {
                    return;
                }

                RaisePropertyChanging(AutoStartOnDropPropertyName);
                _autoStartOnDrop = value;
                RaisePropertyChanged(AutoStartOnDropPropertyName);
            }
        }
        #endregion		
		
        #region SelectedTabIndex
        /// <summary>
        /// The <see cref="SelectedTabIndex" /> property's name.
        /// </summary>
        public const string SelectedTabIndexPropertyName = "SelectedTabIndex";

        private int _selectedTabIndex;

        /// <summary>
        /// Sets and gets the SelectedTabIndex property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SelectedTabIndex
        {
            get
            {
                return _selectedTabIndex;
            }

            set
            {
                if (_selectedTabIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedTabIndexPropertyName);
                _selectedTabIndex = value;
                RaisePropertyChanged(SelectedTabIndexPropertyName);
            }
        }
        #endregion

        #region NewJobPath
        /// <summary>
        /// The <see cref="NewJobPath" /> property's name.
        /// </summary>
        public const string NewJobPathPropertyName = "NewJobPath";

        private string _newJobPath;

        /// <summary>
        /// Sets and gets the NewJobPath property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NewJobPath
        {
            get
            {
                return _newJobPath;
            }

            set
            {
                if (_newJobPath == value)
                {
                    return;
                }

                RaisePropertyChanging(NewJobPathPropertyName);
                _newJobPath = value;
                RaisePropertyChanged(NewJobPathPropertyName);
            }
        }
        #endregion
        #endregion

        #region Commands

        #region TargetBrowse
        private RelayCommand _targetBrowse;

        /// <summary>
        /// Gets the TargetBrowse.
        /// </summary>
        public RelayCommand TargetBrowse
        {
            get
            {
                return _targetBrowse
                    ?? (_targetBrowse = new RelayCommand(
                                          () =>
                                          {
                                              
                                          },
                                          () => true));
            }
        }
        #endregion

        #region AddFavorite

        private RelayCommand _addFavorite;

        /// <summary>
        /// Gets the AddFavorite.
        /// </summary>
        public RelayCommand AddFavorite
        {
            get
            {
                return _addFavorite
                    ?? (_addFavorite = new RelayCommand(
                                          () =>
                                          {
                                              this.Favorites.Add(this.FavoriteToAdd.Trim());                                              
                                          },
                                          () => this.FavoriteToAdd.Trim().Length > 0));
            }
        }
        #endregion

        #region RemoveFavorite
        private RelayCommand<string> _removeFavorite;

        /// <summary>
        /// Gets the RemoveFavorite.
        /// </summary>
        public RelayCommand<string> RemoveFavorite
        {
            get
            {
                return _removeFavorite
                    ?? (_removeFavorite = new RelayCommand<string>(
                                          (favorite) =>
                                          {
                                              this.Favorites.Remove(favorite);
                                          }));
            }
        }
        #endregion

        #region CreateNewEmptyJob
        private RelayCommand _createNewEmptyJob;

        /// <summary>
        /// Gets the CreateNewEmptyJob.
        /// </summary>
        public RelayCommand CreateNewEmptyJob
        {
            get
            {
                return _createNewEmptyJob
                    ?? (_createNewEmptyJob = new RelayCommand(
                                          () =>
                                          {
                                              this.Jobs.Add(new Model.Job());
                                              this.SelectedJob = this.Jobs[this.Jobs.Count - 1];
                                          }));
            }
        }
        #endregion
        #endregion

        #region Messaging
        private void files_Dropped(Messaging.FilesDropped e)
        {
            this.Jobs.Add(new Model.Job(e.Content));
        }

        private void files_DroppedOnJob(Messaging.FilesDroppedOnJob e)
        {
            if (e.Content.Key != null)
            {
                var job = e.Content.Key;

                foreach (var file in e.Content.Value)
                {
                    job.Sources.Add(file);
                }
            }
        }

        private void files_DroppedOnFolder(Messaging.FilesDroppedOnFolder e)
        {
            foreach (var job in this.Jobs)
            {
                if (job.TargetFolder == e.Content.Key)
                {
                    foreach (var file in e.Content.Value)
                    {
                        job.Sources.Add(file);
                    }
                    return;
                }
            }

            //obviously, the job was not found.... 
            this.Jobs.Add(new Job(e.Content.Key, e.Content.Value));

        }
        #endregion

    }
}