using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace WebRazor.Pages.Admin
{
    public class RoomUpdateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        public List<RoomType> RoomType { get; set; } = default!;

        [BindProperty] public RoomResponse RoomInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var accessToken = HttpContext.Session.GetString("account");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var types = await _client.GetAsync($"https://localhost:7098/api/RoomType/GetRoomTypes");
            if (types.IsSuccessStatusCode)
            {
                var jsonString = await types.Content.ReadAsStringAsync();

                RoomType = JsonConvert.DeserializeObject<List<RoomType>>(jsonString);
            }

            ViewData["RoomTypeId"] = new SelectList(RoomType, "RoomTypeId", "RoomTypeName");

            var room = await _client.GetAsync($"https://localhost:7098/api/RoomInformation/GetRoomInformation/{id}");
            if (types.IsSuccessStatusCode)
            {
                var jsonString = await room.Content.ReadAsStringAsync();
                RoomInformation = JsonConvert.DeserializeObject<RoomResponse>(jsonString);
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var accessToken = HttpContext.Session.GetString("account");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonSerializer.Serialize(RoomInformation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client
                .PutAsync($"https://localhost:7098/api/RoomInformation/UpdateRoomInformation", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./RoomInformations");
            }
            return Page();
        }
    }
}