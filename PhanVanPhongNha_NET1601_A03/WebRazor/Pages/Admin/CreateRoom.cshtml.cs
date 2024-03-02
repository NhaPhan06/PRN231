using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebRazor.Pages.Admin
{
    public class CreateRoomModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        
        [BindProperty]
        public CreateRoomRequest RoomInformation { get; set; } = default!;
        public List<RoomType> RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var types = await _client.GetAsync($"https://localhost:7098/api/RoomType/GetRoomTypes");
            if (types.IsSuccessStatusCode)
            {
                var jsonString = await types.Content.ReadAsStringAsync();

                RoomType = JsonConvert.DeserializeObject<List<RoomType>>(jsonString);
            }
            ViewData["RoomTypeId"] = new SelectList(RoomType, "RoomTypeId", "RoomTypeName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonSerializer.Serialize(RoomInformation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("https://localhost:7098/api/RoomInformation/CreateRoomInformation", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./RoomInformations");
            }
            return RedirectToPage();
        }
    }
}
