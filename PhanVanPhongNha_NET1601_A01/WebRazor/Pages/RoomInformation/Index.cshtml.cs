using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;
using Newtonsoft.Json;

namespace WebRazor.Pages.RoomInformation
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        public IList<ModelsLayer.BusinessObjects.RoomInformation> RoomInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _client.GetAsync("https://localhost:7098/api/api/RoomInformation/GetRoomInformations");
            
            if (response.IsSuccessStatusCode)
            {
                RoomInformation = JsonConvert.DeserializeObject<IList<ModelsLayer.BusinessObjects.RoomInformation>>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
