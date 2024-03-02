using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebRazor.Pages.Admin
{
    public class CustomersModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        public IList<ModelsLayer.BusinessObjects.Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync("https://localhost:7098/api/Customer/GetCustomers");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Customer = JsonConvert.DeserializeObject<List<ModelsLayer.BusinessObjects.Customer>>(jsonString);
            }
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.DeleteAsync($"https://localhost:7098/api/Customer/DeleteCustomer/{id}");
            return RedirectToPage("./Customers");
        }
    }
}
