using SQLite.Net.Async;

namespace CodeStock.Core.Data
{
    public interface ISQLitePlatform {
        SQLiteAsyncConnection GetConnection();
    }
}