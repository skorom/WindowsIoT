using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Storage;


namespace ReadWrite
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            FileKezeles();
        }
        public async void FileKezeles()
        {
            StorageFolder taroloMappa = ApplicationData.Current.LocalFolder;
            StorageFile tesztFile = await taroloMappa.CreateFileAsync("sample.txt", 
                                                    CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(tesztFile, DateTime.Today.ToString());

            string tesztTartalom = await FileIO.ReadTextAsync(tesztFile);

        }
    }
}
