using BlazorMovieLive.Models;
using System.Net.Http.Headers;

namespace Moviely.FrontEnd.Services
{
    public class TMBDClient
    {
        /*  private readonly HttpClient _httpClient;

          public TMBDClient(HttpClient httpClient, IConfiguration config)
          {
              _httpClient = httpClient;

              _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/trending/movie/day?language=en-US");
              _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

              string apiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
              _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", apiKey  );
          }
        */
        private readonly HttpClient _httpClient;

        public TMBDClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            // BaseAddress'ı burada değiştirmeyin, DI üzerinden sağlanmalıdır.
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string apiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        }
        public Task<MoviePagedResponse?> GetPopularMoviesAsync(int page = 1)
        {
            if (page < 1) page = 1;
            if (page > 500) page = 500;

            return _httpClient.GetFromJsonAsync<MoviePagedResponse>($"movie/popular?page={page}");
        }

        public Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
        }
    }
}
