using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnotherTravelApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<PopularDirectionsData?> GetPopularDirectionsData(string origin, string currency, string token)
        {
            try
            {
                var apiUrl = $"https://api.travelpayouts.com/v1/city-directions?origin={origin}&currency={currency}&token={token}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<PopularDirectionsData>(content);

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }

            return null;
        }
    }

    public class PopularDirectionsData
    {
        public bool Success { get; set; }
        public List<DirectionDetails> Data { get; set; } = new List<DirectionDetails>();
        public string? Error { get; set; }
        public string? Currency { get; set; }
    }

    public class DirectionDetails
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public int Transfers { get; set; }
        public string Airline { get; set; }
        public int FlightNumber { get; set; }
        public string DepartureAt { get; set; }
        public string ReturnAt { get; set; }
        public string ExpiresAt { get; set; }
    }
}