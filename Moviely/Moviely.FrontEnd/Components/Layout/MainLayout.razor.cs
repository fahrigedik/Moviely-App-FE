using Microsoft.AspNetCore.Components;
using Moviely.FrontEnd.ApplicationState;

namespace Moviely.FrontEnd.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public AppState appState {  get; set; }



        public void changePopular()
        {
            appState.MovieSection = "Popular";
            StateHasChanged();
        }

        public void changeTopRated()
        {
            appState.MovieSection = "TopRated";
            StateHasChanged();
        }



    }
}
