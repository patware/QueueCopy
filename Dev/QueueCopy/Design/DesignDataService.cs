using System;
using QueueCopy.Model;

namespace QueueCopy.Design
{
    public class DesignDataService : Services.IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem();

            item.Jobs.Add(
                new Model.Job(
                    "D:\\Temp", 
                    new string[] { "Foo", "Bar", "John", "Jane", "snafu.mp3" }) 
                    { 
                        FoldersToDo=1, 
                        FoldersTotal=2, 
                        FilesToDo=3, 
                        FilesTotal=4, 
                        Step=5,  
                        StepMessage="Step 5",
                        Progress=6,
                        ProgressMessage="Copying File Beurk.krueB",
                        TargetFolderIsReadOnly=false
                    });

            item.Jobs.Add(new Model.Job("D:\\Foo"));
            item.Jobs.Add(new Model.Job("D:\\Bar"));

            item.Favorites.Add(@"h:\Favorite John");
            item.Favorites.Add(@"h:\Favorite Jane");

            item.Recents.Add(@"h:\Recent Foo");
            item.Recents.Add(@"h:\Recent Bar");

            item.SystemFolders.Add(@"C:\Windows");
            item.SystemFolders.Add(@"C:\Program Files");
            
            callback(item, null);
        }
    }
}