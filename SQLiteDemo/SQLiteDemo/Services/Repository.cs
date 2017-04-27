        using System.Collections.Generic;
        using System.Threading.Tasks;
        using Xamarin.Forms;

        namespace SQLiteDemo.Services
        {
            public class Repository<T> where T:class ,new()
            {
                private readonly ISQLitePlatform _platform;
                public Repository(ISQLitePlatform platform)
                {
                    _platform = platform;
                    var con = _platform.GetConnection();
                    con.CreateTable<T>();
                    con.Close();
                }
                public Repository()
                {
                    _platform = DependencyService.Get<ISQLitePlatform>();
                    var con = _platform.GetConnection();
                    con.CreateTable<T>();
                    con.Close();
                }

                public async Task<bool> AddItemAsync(T item)
                {
                    return (await _platform.GetConnectionAsync().InsertAsync(item)) > 0;
                }

                public async Task<bool> UpdateItemAsync(T item)
                {
                    return (await _platform.GetConnectionAsync().UpdateAsync(item)) > 0;
                }

                public async Task<bool> DeleteItemAsync(T item)
                {
                    return (await _platform.GetConnectionAsync().DeleteAsync(item)) > 0;
                }

                public async Task<IEnumerable<T>> GetItemsAsync()
                {
                    return await _platform.GetConnectionAsync().Table<T>().ToListAsync();
                }
            }
        }
