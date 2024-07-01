using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SQLite;

namespace TestAPI_Demo_P3.MVVM.Models;

public class SWCharacters
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Mass { get; set; }
    public string Gender { get; set; }
    public string Birth_Year { get; set; }
    public int ApiId { get; set; }
}