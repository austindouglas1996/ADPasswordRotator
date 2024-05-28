using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Service
{
    public class UpdateService
    {
        private readonly HttpClient _httpClient;

        public UpdateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CheckHeartbeatAsync()
        {
            var response = await _httpClient.GetAsync("AD/Update/PerformHeartBeat");
            response.EnsureSuccessStatusCode();
        }
    }
}
