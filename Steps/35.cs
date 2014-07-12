//CodeStock.iOS/Data/SQLiteIosPlatform.cs
using CodeStock.Core.Data;
using System;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net;

namespace CodeStock.iOS.Data
{
    //TODO : Create iOS specific database connection
    public class SQLiteIosPlatform : ISQLitePlatform
    {
        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFilename = "Conferences.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLitePlatformIOS();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                          platform,
                                          new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}