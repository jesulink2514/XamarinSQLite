using System.IO;
using Windows.Storage;
using SQLite;
using SQLiteDemo.Services;
using SQLiteDemo.UWP.Services;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsSQLitePlatform))]

namespace SQLiteDemo.UWP.Services
{
    public class WindowsSQLitePlatform: ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "somostechies.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return path;
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}