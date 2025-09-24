using System.Net.Http.Json;
using Test_App_DOOMM.Models;

namespace Test_App_DOOMM.Services
{
    public class CatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact?> GetRandomFactAsync()
        {
            // Using catfact.ninja API
            try
            {
                var resp = await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
                return resp;
            }
            catch
            {
                return null;
            }
        }
    }
}
