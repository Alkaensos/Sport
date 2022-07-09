using Sport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace Sport.Services
{
    public class VereinDataStore : IDataStore<Verein>
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MySportDatabase");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Verein>();
        }
        public async Task<bool> AddItemAsync(Verein verein)
        {
            await Init();
            await db.InsertAsync(verein);
            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            await Init();
            await db.DeleteAsync<Verein>(id);
            return true;
        }

        public async Task<Verein> GetItemAsync(string id)
        {
            await Init();
            return await db.GetAsync<Verein>(id);
        }

        public async Task<IEnumerable<Verein>> GetItemsAsync(bool forceRefresh = false)
        {
            await Init();
            return await db.Table<Verein>().ToListAsync();

        }

        public async Task<bool> UpdateItemAsync(Verein verein)
        {
            await Init();
            await db.UpdateAsync(verein);
            return true;
        }
    }
}
