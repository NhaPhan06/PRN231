using System.Text;
using BussinessLogic.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebRazor.Pages.Customer
{
    public class BookingRoomModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        [BindProperty]
        public BookingRequest BookingRequest { get; set; } = default!;
        public RoomType typeRoom { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var json = await _client.GetAsync($"https://localhost:7098/api/RoomType/GetRoomTypesByID/{id}");
            if (json.IsSuccessStatusCode)
            {
                typeRoom = JsonConvert.DeserializeObject<RoomType>(await json.Content.ReadAsStringAsync());
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int typeId)
        {
            BookingRequest.BookingDate = DateTime.Now;
            BookingRequest.CustomerId = int.Parse(HttpContext.Session.GetString("account"));
            BookingRequest.RoomType = typeId;
            try
            {
                var json = JsonSerializer.Serialize(BookingRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _client.PostAsync("https://localhost:7098/api/BookingReservation/CreateBookingReservation", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./ListTypeRoom");
                }
                else
                {
                    var result = JsonSerializer.Deserialize<ErrorResult>(await response.Content.ReadAsStringAsync());
                    throw new Exception(result.Exception);
                }
            }
            catch (Exception e)
            {
                ViewData["notification"] = e.Message;
            }
            await OnGetAsync(typeId);
            return Page();
        }
    }
}
