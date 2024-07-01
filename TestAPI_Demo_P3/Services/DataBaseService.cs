using SQLite;
using TestAPI_Demo_P3.MVVM.Models;

namespace TestAPI_Demo_P3.Services;

public class DataBaseService
{
    private readonly SQLiteAsyncConnection _database;
    
    public DataBaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<SWCharacters>().Wait();
    }
    
    public Task<List<SWCharacters>> GetSWCharactersAsync()
    {
        return _database.Table<SWCharacters>().ToListAsync();
    }
    
    public Task<int> SaveSWCharactersAsync(SWCharacters swCharacters)
    {
        if (swCharacters.Id != 0)
        {
            return _database.UpdateAsync(swCharacters);
        }
        else
        {
            return _database.InsertOrReplaceAsync(swCharacters);
        }
    }
    
    public Task<int> DeleteSWCharactersAsync(SWCharacters swCharacters)
    {
        return _database.DeleteAsync(swCharacters);
    }
}