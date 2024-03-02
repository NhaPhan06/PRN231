using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.BusinessObjects;
using Newtonsoft.Json;

namespace WebRazor.Pages.Customer;

public class ListTypeRoomModel : PageModel
{
    private readonly HttpClient _client = new();
    public IList<RoomType> RoomType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var accessToken = HttpContext.Session.GetString("account");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var list = await _client.GetAsync("https://localhost:7098/api/RoomType/GetRoomTypes");
        if (list.IsSuccessStatusCode)
        {
            var json = await list.Content.ReadAsStringAsync();
            RoomType = JsonConvert.DeserializeObject<List<RoomType>>(json);
        }
    }
}