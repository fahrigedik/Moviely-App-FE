using BlazorMovieLive.Models;

namespace Moviely.FrontEnd.Services
{
    public interface IMovieService
    {
        public Task<PopularMoviePagedResponse?> GetPopularMoviesAsync(int page = 1);
        public Task<MovieDetails?> GetMovieDetailsAsync(int id);


    }
}
