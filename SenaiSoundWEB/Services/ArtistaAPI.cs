﻿using System.Net.Http.Json;
using SenaiSoundWEB.Requests;
using SenaiSoundWEB.Response;

namespace SenaiSoundWEB.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient;

        public ArtistaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }
        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

        public async Task AddArtistaAsync(ArtistaRequest artista)
        {
            await _httpClient.PostAsJsonAsync("artistas", artista);
        }
        public async Task DeleteArtistaAsync(int id)
        {
            await _httpClient.DeleteAsync($"artistas/{id}");
        }
        public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
        }
        public async Task UpdateArtistaAsync(ArtistaRequestEdit artista)
        {
            await _httpClient.PutAsJsonAsync($"artistas", artista);
        }
    }
}
