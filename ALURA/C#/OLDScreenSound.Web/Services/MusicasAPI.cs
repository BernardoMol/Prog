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
    public class MusicasAPI
    {
        private readonly HttpClient _httpClient;
        public MusicasAPI(IHttpClientFactory httpCfactory)
        {
            _httpClient = httpCfactory.CreateClient("API");
        }

        public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }

        


    }
}