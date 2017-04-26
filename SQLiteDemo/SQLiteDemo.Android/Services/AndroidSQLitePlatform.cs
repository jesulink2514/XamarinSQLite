using System.IO;
using SQLite;
using SQLiteDemo.Droid.Services;
using SQLiteDemo.Services;
[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLitePlatform))]
namespace SQLiteDemo.Droid.Services
{
    public class AndroidSQLitePlatform: ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "somostechies.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
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