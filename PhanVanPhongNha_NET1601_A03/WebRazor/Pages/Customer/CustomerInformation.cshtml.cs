
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace WebRazor.Pages.Customer
{
    public class CustomerInformationModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public ModelsLayer.BusinessObjects.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetString("account");
            if (id == null)
            {
                return RedirectToPage("../Index");
            }
            var list = await _client.GetAsync($"https://localhost:7098/api/Customer/GetCustomer/{id}");
            if (list.IsSuccessStatusCode)
            {
                var json = await list.Content.ReadAsStringAsync();
                Customer = JsonConvert.DeserializeObject<ModelsLayer.BusinessObjects.Customer>(json);
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                var json = JsonSerializer.Serialize(Customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _client.PutAsync("https://localhost:7098/api/Customer/UpdateCustomer", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Page();
                }
            }
            catch (Exception e)
            {
                ViewData["notification"] = e.Message;
            }
            return Page();
        }
    }
}
