using System;
using System.IO;
using SQLite;
using SQLiteDemo.iOS.Services;
using SQLiteDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSQLitePlatform))]
namespace SQLiteDemo.iOS.Services
{
    public class iOSSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "somostechies.db3";
            string personalFolder =Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
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