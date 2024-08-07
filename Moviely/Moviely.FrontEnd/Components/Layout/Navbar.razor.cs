using Microsoft.AspNetCore.Components;
using Moviely.FrontEnd.ApplicationState;
using System.ComponentModel;

namespace Moviely.FrontEnd.Components.Layout
{
    public partial class Navbar
    {

        [Inject]
        public AppState applicationState {  get; set; }


        public void test()
        {
            StateHasChanged();
            applicationState.MovieSection = "TopRated";
        }

      






    }

    

}
