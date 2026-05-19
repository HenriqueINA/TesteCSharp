using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace simpleapp.Namespace
{
    public class InfodragonballModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InfodragonballModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string Name  { get; set; }
        public string Description  { get; set; }
        public string Image  { get; set; }
        public string Affiliation  { get; set; }

        public async Task<IActionResult> OnGetAsync (string name, string description, string image, string affiliation)
        {
            Name = name;
            Description = description;
            Image = image;
            Affiliation = affiliation;
            var client = _httpClientFactory.CreateClient("DragonBall");

            return Page();
        }
    }
}