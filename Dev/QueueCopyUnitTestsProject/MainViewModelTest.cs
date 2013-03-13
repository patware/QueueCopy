using QueueCopy.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using Moq;

namespace QueueCopyUnitTestsProject
{
    /// <summary>
    ///This is a test class for JobTest and is intended
    ///to contain all JobTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainViewModelTest
    {

        private Moq.Mock<QueueCopy.Services.IDataService> _dataService;
        private Moq.Mock<QueueCopy.Services.IDialogService> _dialogService;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dataService = new Moq.Mock<QueueCopy.Services.IDataService>();
            _dialogService = new Moq.Mock<QueueCopy.Services.IDialogService>();
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _dataService.VerifyAll();
            _dialogService.VerifyAll();
        }
        //
        #endregion

        private MainViewModel GetDefaultViewModelConstructor()
        {
            var vm = new MainViewModel(dataService: _dataService.Object, dialogService: _dialogService.Object);

            return vm;
        }

        private QueueCopy.Model.DataItem getEmptyDataItem()
        {
            var di = new QueueCopy.Model.DataItem();
            return di;
        }

        private QueueCopy.Model.DataItem getInitialDataItem()
        {
            var di = new QueueCopy.Model.DataItem();
            di.Favorites.Add("Favorite");
            di.Jobs.Add(new QueueCopy.Model.Job());
            di.Recents.Add("Recent");
            di.SystemFolders.Add("SystemFolder");

            return di;
        }

        [TestMethod()]
        public void MainViewModel_Construction_Test()
        {
            //Arrange
            _dataService
                .Setup(foo => foo.GetData(It.IsAny<Action<QueueCopy.Model.DataItem, Exception>>()))
                .Callback<Action<QueueCopy.Model.DataItem, Exception>>((action) => action(getEmptyDataItem(), null));

            //Act
            var target = GetDefaultViewModelConstructor();

            //Assert
            Assert.IsNotNull(target.Favorites, "Favorites should not be null");
            Assert.IsNotNull(target.Jobs, "Jobs should not be null");
            Assert.IsNotNull(target.Recents, "Recents should not be null");            
            Assert.IsNotNull(target.SystemFolders, "SystemFolders should not be null");
            Assert.IsNull(target.SelectedJob, "SelectedJob should be null");
            Assert.AreEqual(1, target.SelectedTabIndex, "SelectedTabIndex should be equal to 1");
            Assert.IsNotNull(target.AddFavorite, "AddFavorite should not be null");
            Assert.AreEqual(false, target.AutoStartOnDrop, "AutoStartOnDrop should be false");
            Assert.IsNotNull(target.CreateNewEmptyJob, "CreateNewEmptyJob should not be null");
            Assert.AreEqual(string.Empty, target.FavoriteToAdd, "FavoriteToAdd should be string.Empty");
            Assert.IsNull(target.NewJobPath, "NewJobPath should be null");
            Assert.IsNotNull(target.RemoveFavorite, "RemoveFavorite should not be null");
            Assert.IsNotNull(target.TargetBrowse, "TargetBrowse should not be null");
            
        }

        [TestMethod()]
        public void MainViewModel_Construction_WithInitialData_Test()
        {
            //Arrange
            var expectedDataItem = getInitialDataItem();

            _dataService
                .Setup(foo => foo.GetData(It.IsAny<Action<QueueCopy.Model.DataItem, Exception>>()))
                .Callback<Action<QueueCopy.Model.DataItem, Exception>>((action) => action(expectedDataItem, null));

            //Act
            var target = GetDefaultViewModelConstructor();

            //Assert
            Assert.AreEqual(expectedDataItem.Favorites[0], target.Favorites[0]);
            Assert.AreEqual(expectedDataItem.Jobs[0], target.Jobs[0]);
            Assert.AreEqual(expectedDataItem.Recents[0], target.Recents[0]);
            Assert.AreEqual(expectedDataItem.SystemFolders[0], target.SystemFolders[0]);
            Assert.AreEqual(expectedDataItem.Jobs[0], target.SelectedJob);
            
        }



    }
}
