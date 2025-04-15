using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WildConsulting.WebSite.Core.Pages
{
    public class AppsModel : PageModel
    {
        private readonly ILogger<AppsModel> _logger;

        public AppsModel(ILogger<AppsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}