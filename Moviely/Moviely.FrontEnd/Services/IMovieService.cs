using BlazorMovieLive.Models;

namespace Moviely.FrontEnd.Services
{
    public interface IMovieService
    {
        public Task<MoviePagedResponse?> GetPopularMoviesAsync(int page = 1);
        public Task<MovieDetails?> GetMovieDetailsAsync(int id);

        public Task<MoviePagedResponse> GetTopRatedMoviesAsync(int page = 1);

    }
}
