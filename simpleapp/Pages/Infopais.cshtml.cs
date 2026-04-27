using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace simpleapp.Namespace
{
    public class InfopaisModel : PageModel
    {
        /*public void OnGet()
        {
        }*/
        private readonly IHttpClientFactory _httpClientFactory;

        public InfopaisModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string CodigoPais { get; set; }

        public async Task<IActionResult> OnGetAsync (string cod)
        {
            CodigoPais = cod;
            var client = _httpClientFactory.CreateClient("RestCountries");

            return Page();
        }
    }
}