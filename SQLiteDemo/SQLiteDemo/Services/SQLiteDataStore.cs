using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteDemo.Models;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLiteDemo.Services.SQLiteDataStore))]
namespace SQLiteDemo.Services
{
    public class SQLiteDataStore : IDataStore<Item>
    {
        private readonly ISQLitePlatform _platform;
        public SQLiteDataStore(ISQLitePlatform platform)
        {
            _platform = platform;
            var con = _platform.GetConnection();
            con.CreateTable<Item>();
            con.Close();
        }
        public SQLiteDataStore()
        {
            _platform = DependencyService.Get<ISQLitePlatform>();
            var con = _platform.GetConnection();
            con.CreateTable<Item>();
            con.Close();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            return (await _platform.GetConnectionAsync().InsertAsync(item)) > 0;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            return (await _platform.GetConnectionAsync().UpdateAsync(item)) > 0;
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            return (await _platform.GetConnectionAsync().DeleteAsync(item)) > 0;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await _platform.GetConnectionAsync()
                .Table<Item>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _platform.GetConnectionAsync().Table<Item>().ToListAsync();
        }
    }
}
