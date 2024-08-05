using BlazorMovieLive.Models;
using Moviely.FrontEnd.Services;

namespace Moviely.FrontEnd.Components.Components
{
    
    public partial class MovieSection
    {
       // public PopularMoviePagedResponse popularData { get; set; }

     
    /*    public MovieSection()
        {
            GetPopularData();
        }
      

        public async Task GetPopularData()
        {
            popularData = await TMBD.GetPopularMoviesAsync();
        }
    */
        public PopularMoviePagedResponse popularData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Client == null)
            {
                throw new InvalidOperationException("TMDBClient is not injected properly.");
            }

            await GetPopularData();
        }

        private async Task GetPopularData()
        {
            popularData = await Client.GetPopularMoviesAsync();
        }




    }
}
