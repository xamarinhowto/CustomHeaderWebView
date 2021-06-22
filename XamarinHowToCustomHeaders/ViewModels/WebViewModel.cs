using System;
namespace XamarinHowToCustomHeaders.ViewModels
{
    public class WebViewModel
    {
        public string AuthToken { get; set; }
        public string WebpageUri { get; set; }

        public WebViewModel()
        {
            AuthToken = "Bearer MyCustomAuthorizationToken";
            WebpageUri = "https://manytools.org/http-html-text/http-request-headers/";
        }
    }
}
