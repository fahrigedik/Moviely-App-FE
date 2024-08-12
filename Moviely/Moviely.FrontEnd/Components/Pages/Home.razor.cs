using Microsoft.AspNetCore.Components;
using Moviely.FrontEnd.ApplicationState;

namespace Moviely.FrontEnd.Components.Pages
{
    public partial class Home
    {
        public string apiDataType { get; set; }

        protected override void OnInitialized()
        {
            apiDataType = "Popular";
        }
      
        private void UpdateApiDataType(string newApiDataType)
        {
            this.apiDataType = newApiDataType;
            StateHasChanged();
        }



    }
}
