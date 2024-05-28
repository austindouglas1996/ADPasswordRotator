using ADPasswordRotator.Shared.Model;
using System.Net.Http.Json;

namespace ADPasswordRotator.Frontend.Services
{
    public class LocationService(HttpClient client)
    {
        private readonly HttpClient _httpClient = client;

        public async Task<IEnumerable<Location>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Location>>("AD/Location");
        }

        public async Task Add(Location newLoc)
        {
            var response = await _httpClient.PostAsJsonAsync("AD/Location", newLoc);
            response.EnsureSuccessStatusCode();
        }
    }
}
