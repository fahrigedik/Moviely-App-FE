using BlazorMovieLive.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;

namespace Moviely.FrontEnd.Components.Components
{
    public partial class MovieCard
    {
        [Parameter]
        public PopularMovie PopularMovieData { get; set; }

        [Inject]
        private IConfiguration Configuration { get; set; }

        public string BaseUrl { get; set; } = "https://api.themoviedb.org/3/trending/movie/day?language=en-US";
        
       
    }
}
