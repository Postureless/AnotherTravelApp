using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnotherTravelApp.Services
{
    public class ApiService 
    {
        private readonly HttpClient _httpClient = new();
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        public async Task<PopularDirectionsData?> GetPopularDirectionsData(string origin, string currency, string token)
        {
            try
            {
                var apiUrl =
                    $"https://api.travelpayouts.com/v1/city-directions?origin={origin}&currency={currency}&token={token}";

                var response = await _httpClient.GetAsync(apiUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();   
            
                    Console.WriteLine("Attempting to deserialize JSON content.");
                    try
                    {
                        var result = JsonSerializer.Deserialize<PopularDirectionsData>(content, options);
                        Console.WriteLine("Deserialization complete.");
                        Console.WriteLine($"Data count: {result.Data.Keys.Count}");
                        return result;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Deserialization failed: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }

            return null;
        }
    
        public async Task<ResponseData?> GetCalendarPricesData(string origin, string destination, string departDate, string returnDate, string currency, string token)
        {
            try
            {

                var apiUrl = $"https://api.travelpayouts.com/v1/prices/calendar?depart_date={departDate}&origin={origin}&return_date={returnDate}&destination={destination}&calendar_type=departure_date&currency={currency}&token={token}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    
                    try 
                    {
                        var result = JsonSerializer.Deserialize<ResponseData>(content, options);
                        return result;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Deserialization failed: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }

            return null;
        }
    }
}
    
public class PopularDirectionsData
{
    public Dictionary<string, DirectionDetails> Data { get; set; }
    public string Currency { get; set; }
    public bool Success { get; set; }
}

public class DirectionDetails
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Airline { get; set; }
    public string  DepartureAt { get; set; }
    public string  ReturnAt { get; set; }
    
    public string  ExpiresAt { get; set; }
    public int Price { get; set; }
    public int FlightNumber { get; set; }
    public int Transfers { get; set; }
}

public class ResponseData
{
    public Dictionary<string, DirectionDetails> Data { get; set; }
    public string Currency { get; set; }
    public bool Success { get; set; }
}