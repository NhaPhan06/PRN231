using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;

namespace WebRazor.Pages.Admin
{
    public class RoomInformationsModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        public IList<RoomResponse> RoomInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _client.GetAsync("https://localhost:7098/api/RoomInformation/GetRoomInformations");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                RoomInformation = JsonConvert.DeserializeObject<List<RoomResponse>>(jsonString);
            }
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _client.DeleteAsync($"https://localhost:7098/api/RoomInformation/DeleteRoomInformation/{id}");
            return RedirectToPage("./RoomInformations");
        }
    }
}
