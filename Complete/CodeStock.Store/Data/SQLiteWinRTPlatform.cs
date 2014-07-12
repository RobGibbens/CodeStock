using System.IO;
using Windows.Storage;
using CodeStock.Core.Data;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

namespace CodeStock.Store.Data
{
    public class SQLiteWinRTPlatform : ISQLitePlatform
    {
        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFilename = "Conferences.db3";

            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var platform = new SQLitePlatformWinRT();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                          platform,
                                          new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}