using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ScreenSound.Web.Response;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Net.Http.Json;


namespace ScreenSound.Web.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient;
        public ArtistaAPI(IHttpClientFactory httpCfactory)
        {
            _httpClient = httpCfactory.CreateClient("API");
        }

        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

        


    }
}