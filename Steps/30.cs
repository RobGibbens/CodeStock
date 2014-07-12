//CodeStock.Core/Data/ISQLitePlatform
using SQLite.Net.Async;

namespace CodeStock.Core.Data
{
	//TODO : Create interface to abstract platform specific database connections
    public interface ISQLitePlatform {
        SQLiteAsyncConnection GetConnection();
    }
}