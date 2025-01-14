using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ReviewFlixMobile.Models;

namespace ReviewFlixMobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://192.168.194.253:5284") };
        }

        public async Task<List<Film>> GetFilmsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Film>>("api/films");
        }

        public async Task<List<Review>> GetReviewsAsync(int filmId)
        {
            return await _httpClient.GetFromJsonAsync<List<Review>>($"api/films/{filmId}/reviews");
        }

        public async Task AddReviewAsync(Review review)
        {
            await _httpClient.PostAsJsonAsync("api/reviews", review);
        }

        public async Task<List<Actor>> GetCastAsync(int filmId)
        {
            return await _httpClient.GetFromJsonAsync<List<Actor>>($"api/films/{filmId}/cast");
        }

        public async Task<Finance> GetFinanceAsync(int filmId)
        {
            return await _httpClient.GetFromJsonAsync<Finance>($"api/films/{filmId}/finance");
        }
    }
}