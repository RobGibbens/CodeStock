using System.IO;
using Windows.Storage;
using CodeStock.Core.Data;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WindowsPhone8;

namespace CodeStock.Phone.Data
{
    public class SQLiteWP8Platform : ISQLitePlatform
    {
        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFilename = "Conferences.db3";
          
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var platform = new SQLitePlatformWP8();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                          platform,
                                          new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}