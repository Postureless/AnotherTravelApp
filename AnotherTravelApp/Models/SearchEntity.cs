using SQLite;

namespace AnotherTravelApp.Models;

public class SearchEntity
{
    [PrimaryKey]
    public int SearchId { get; set; }
    public string From { get; set; }
    public string Where { get; set; }
    public string Date { get; set; }
    public string Passangers { get; set; }
}