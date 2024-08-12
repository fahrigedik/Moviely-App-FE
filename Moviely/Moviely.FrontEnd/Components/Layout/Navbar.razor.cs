using Microsoft.AspNetCore.Components;
using Moviely.FrontEnd.ApplicationState;
using System.ComponentModel;

namespace Moviely.FrontEnd.Components.Layout
{
    public partial class Navbar
    {


        [Parameter]
        public EventCallback<string> OnMenuItemClicked { get; set; }

        private async Task HandleMenuItemClick(string menuItem)
        {
            if (OnMenuItemClicked.HasDelegate)
            {
                await OnMenuItemClicked.InvokeAsync(menuItem);
            }
        }








    }

    

}
