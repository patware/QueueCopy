using System;

namespace QueueCopy.Services
{
    public class DataService : IDataService
    {
        public void GetData(Action<Model.DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new Model.DataItem();

            var sl = new System.Collections.Generic.SortedList<string,string>();
                  
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.AdminTools));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CDBurning));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.History));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Recent));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Resources));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.System));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Templates));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            safeAdd(sl,System.Environment.GetFolderPath(Environment.SpecialFolder.Windows));

            item.SystemFolders = sl.Values;

            callback(item, null);
        }

        private void safeAdd(System.Collections.Generic.SortedList<string,string> items, string itemToAdd)
        {
            if (string.IsNullOrEmpty(itemToAdd)) return;

            if (!items.ContainsKey(itemToAdd))
                items.Add(itemToAdd,itemToAdd);

        }
    }
}