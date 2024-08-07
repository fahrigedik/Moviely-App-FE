using BlazorMovieLive.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Moviely.FrontEnd.Services;
using System.Runtime.InteropServices;

namespace Moviely.FrontEnd.Components.Components
{

    public partial class MovieSection
    {

        //Inject Service

        [Inject]
        protected IMovieService _movieService { get; set; }
        public MoviePagedResponse popularData { get; set; }

        
        

        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                popularData = await _movieService.GetPopularMoviesAsync();
                await fillNestedPaginationList();
                StateHasChanged(); // İlk render tamamlandıktan sonra durumu güncelleyin
            }
            else
            {
              //  await fillNestedPaginationList();
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
            StateHasChanged();

            //nestedPage++;
        }
        
        public async Task nextPage()
        {
           
            nestedPage++;
            nestedPaginationList.Clear();
            StateHasChanged();
            fillNestedPaginationList();
            
        }

        public async Task BeforePage()
        {
            if (nestedPage!=1)
            {
                nestedPage--;
                nestedPaginationList.Clear();
                StateHasChanged();
                fillNestedPaginationList();
               
            }
        }



    }
}
