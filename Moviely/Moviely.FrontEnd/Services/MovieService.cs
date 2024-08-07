using BlazorMovieLive.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace Moviely.FrontEnd.Services
{
    public class MovieService : IMovieService
    {

        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            // BaseAddress'ı burada değiştirmeyin, DI üzerinden sağlanmalıdır.
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string apiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        }

        public async Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
                return await _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
        }

        public async Task<MoviePagedResponse?> GetPopularMoviesAsync(int page = 1)
        {
            if (page < 1) page = 1;
            if (page > 500) page = 500;
            return await _httpClient.GetFromJsonAsync<MoviePagedResponse>($"movie/popular?page={page}");
        }

        public async Task<MoviePagedResponse> GetTopRatedMoviesAsync(int page = 1)
        {
            if (page < 1) page = 1;
            if (page > 500) page = 500;
            return await _httpClient.GetFromJsonAsync<MoviePagedResponse>($"movie/top_rated?page={page}");
            
        }
    }
}
