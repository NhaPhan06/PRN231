using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text;
using BussinessLogic.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;

namespace WebRazor.Pages
{
    public class CreateAccountModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        [BindProperty] public CreateCustomerRequest Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                var response = _client.PostAsync("https://localhost:7098/api/Customer/CreateCustomer", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    var result =
                        JsonSerializer.Deserialize<ErrorResult>(await response.Content.ReadAsStringAsync());
                    throw new Exception(result.Exception);
                }
            }
            catch (Exception e)
            {
                ViewData["notification"] = e.Message;
            }

            return RedirectToPage();
        }
    }
}