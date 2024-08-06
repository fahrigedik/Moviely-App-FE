using BlazorMovieLive.Models;
using Microsoft.AspNetCore.Components;
using Moviely.FrontEnd.Services;
using System.Runtime.InteropServices;

namespace Moviely.FrontEnd.Components.Components
{

    public partial class MovieSection
    {

        //Inject Service

        [Inject]
        protected IMovieService _movieService { get; set; }

        public PopularMoviePagedResponse popularData { get; set; }

        private async Task GetPopularData()
        {
        }       

        public MovieSection()
        {
        }

        protected override async Task OnInitializedAsync()
        {
           
           // await fillNestedPaginationList();

            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            popularData = await _movieService.GetPopularMoviesAsync();
            if (firstRender)
            {
                await fillNestedPaginationList();
                StateHasChanged(); // İlk render tamamlandıktan sonra durumu güncelleyin
            }
        }


        public List<PopularMovie> nestedPaginationList = new List<PopularMovie>();
        public int nestedPage { get; set; } = 1;

        public int nestedItemsPerPage { get; set; } = 5;
        public async Task fillNestedPaginationList()
        {
            var startIndex = (nestedPage - 1) * nestedItemsPerPage;
            var endIndex = startIndex + nestedItemsPerPage;


            if (endIndex > popularData.Results.Count())
            {
                return;
            }

            nestedPaginationList.AddRange(popularData.Results.Skip(startIndex).Take(nestedItemsPerPage));
            nestedPage++;
        }


       

    }
}
