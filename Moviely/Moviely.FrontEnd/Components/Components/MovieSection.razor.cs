using BlazorMovieLive.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Moviely.FrontEnd.ApplicationState;
using Moviely.FrontEnd.Services;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Moviely.FrontEnd.Components.Components
{

    public partial class MovieSection
    {

        //Inject Service

        [Inject]
        protected IMovieService _movieService { get; set; }
        public MoviePagedResponse Data { get; set; }

        [Parameter]
        public string apiDataType { get; set; }

        public int parentPage { get; set; } = 1;


        protected override async Task OnParametersSetAsync()
        {

            if (apiDataType == "Popular")
            {
                nestedPaginationList.Clear();
                Data = await _movieService.GetPopularMoviesAsync(parentPage);
               
            }
            if (apiDataType == "TopRated")
            {
                nestedPaginationList.Clear();
                Data = await _movieService.GetTopRatedMoviesAsync(parentPage);
            }
            if (apiDataType == "upcoming")
            {
                nestedPaginationList.Clear();
                Data = await _movieService.GetUpComingMovieAsync(parentPage);
                
            }
            await fillNestedPaginationList();
            StateHasChanged();
        }


        public List<PopularMovie> nestedPaginationList = new List<PopularMovie>();
        public int nestedPage { get; set; }

        public int nestedItemsPerPage { get; set; } = 5;
        public async Task fillNestedPaginationList()
        {
            var startIndex = (nestedPage - 1) * nestedItemsPerPage;
            var endIndex = startIndex + nestedItemsPerPage;

            if (endIndex > Data.Results.Count())
            {
                return;
            }

            nestedPaginationList.AddRange(Data.Results.Skip(startIndex).Take(nestedItemsPerPage));
            StateHasChanged();

            //nestedPage++;
        }
        
        public async Task nextPage()
        {  
            nestedPage++;
            if (nestedPage == 5 )
            {
                parentPage++;
                nestedPage = 1;
                await OnParametersSetAsync();
                return;
            }
            nestedPaginationList.Clear();
            fillNestedPaginationList();
            StateHasChanged();
        }

        public async Task BeforePage()
        {
            if (nestedPage!=1)
            {
                nestedPage--;
                StateHasChanged();
                fillNestedPaginationList();
               
            }
        }



    }
}
