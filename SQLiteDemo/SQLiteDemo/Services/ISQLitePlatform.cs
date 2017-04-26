using SQLite;

namespace SQLiteDemo.Services
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
