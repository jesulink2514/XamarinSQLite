using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDemo.Models;

namespace SQLiteDemo.Services
{
    public class SQLiteItemStore: IDataStore<Item>
    {
        public SQLiteItemStore()
        {
            
        }
        public Task<bool> AddItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
