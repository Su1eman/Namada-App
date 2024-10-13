using Namada_Maui.Models.Blocks;
using Namada_Maui.Models.Overviews;
using Namada_Maui.Models.Settings;
using Namada_Maui.Models.Validators;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Repository.Database
{
    public static class ConnectionInfo
    {
        public const string DatabaseFilename = "DataBaseSQLite.db3";

        public const SQLiteOpenFlags Flags =
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        //public const SQLiteOpenFlags Flags =

        //    SQLiteOpenFlags.Create |
        //     open the database in read/write mode
        //    SQLiteOpenFlags.NoMutex |
        //     create the database if it doesn't exist
        //    SQLiteOpenFlags.ReadWrite;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }

    public class DBSQLite
    {
        SQLiteAsyncConnection Database;

        public DBSQLite() { }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(ConnectionInfo.DatabasePath, ConnectionInfo.Flags);

            await Database.CreateTableAsync<Overview>();

            await Database.CreateTableAsync<Validator>();

            await Database.CreateTableAsync<Block>();

            await Database.CreateTableAsync<AppConfig>();
        }

        #region Overview

        public Task<Overview> QueryOverview(int id)
        {
            Init();

            return Database.Table<Overview>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertOverview(Overview item)
        {
            Init();

            return Database.InsertAsync(item);
        }

        public Task<int> UpdateOverview(Overview item)
        {
            Init();

            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteOverview(Overview item)
        {
            Init();

            return Database.DeleteAsync(item);
        }

        #endregion

        #region Validator

        public Task<List<Validator>> QueryValidator()
        {
            Init();

            return Database.Table<Validator>().ToListAsync();
        }

        public Task<Validator> QueryValidator(string id)
        {
            Init();

            return Database.Table<Validator>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertAllValidator(List<Validator> items)
        {
            Init();

            return Database.InsertAllAsync(items);
        }

        public Task<int> InsertValidator(Validator item)
        {
            Init();

            return Database.InsertAsync(item);
        }

        public Task<int> UpdateValidator(Validator item)
        {
            Init();

            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteAllValidator()
        {
            Init();

            return Database.DeleteAllAsync<Validator>();
        }

        public Task<int> DeleteValidator(Validator item)
        {
            Init();

            return Database.DeleteAsync(item);
        }

        #endregion

        #region Block

        public Task<int> QueryBlockCount()
        {
            Init();

            return Database.Table<Block>().CountAsync();
        }

        public Task<List<Block>> QueryBlock()
        {
            Init();

            return Database.Table<Block>().ToListAsync();
        }

        public Task<Block> QueryFirstBlock()
        {
            Init();

            return Database.Table<Block>().FirstAsync();
        }

        public Task<Block> QueryBlock(uint id)
        {
            Init();

            return Database.Table<Block>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertBlock(Block item)
        {
            Init();

            return Database.InsertAsync(item);
        }

        public Task<int> UpdateBlock(Block item)
        {
            Init();

            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteAllBlock()
        {
            Init();

            return Database.DeleteAllAsync<Block>();
        }

        public Task<int> DeleteBlock(Block item)
        {
            Init();

            return Database.DeleteAsync(item);
        }

        #endregion

        #region AppConfig

        public Task<AppConfig> QueryAppConfig(int id)
        {
            Init();

            return Database.Table<AppConfig>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertAppConfig(AppConfig item)
        {
            Init();

            return Database.InsertAsync(item);
        }

        public Task<int> UpdateAppConfig(AppConfig item)
        {
            Init();

            return Database.UpdateAsync(item);
        }

        public Task<int> DeleteAppConfig(AppConfig item)
        {
            Init();

            return Database.DeleteAsync(item);
        }

        #endregion
    }
}