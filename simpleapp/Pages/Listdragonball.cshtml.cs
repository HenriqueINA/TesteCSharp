using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using simpleapp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace simpleapp.Pages;

public class DragonBallModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public DragonBallModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public List<DragonBall> Dragonball { get; set; } = new();
    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient("DragonBall");
        var response = await client.GetAsync("https://dragonball-api.com/api/characters?race=Saiyan&affiliation=Z%20fighter");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dados = JsonSerializer.Deserialize<List<DragonballApiResponse>>(json, options);

            Dragonball = dados.Select(d => new DragonBall
            {
                id = d.id,
                name = d.name?.official,
                image = d.characters?.png
            }).ToList();
        }
    }
}