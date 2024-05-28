using ADPasswordRotator.Shared;
using ADPasswordRotator.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.SharedWeb.Services
{
    public class DomainControllerService(HttpClient client)
    {
        private readonly HttpClient _httpClient = client;

        private async Task<IEnumerable<DomainController>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DomainController>>("AD/Controllers/GetAll");
        }

        private async Task<IEnumerable<DomainController>> Update(DomainController controller)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DomainController>>("AD/Controllers/Update");
        }
    }
}
