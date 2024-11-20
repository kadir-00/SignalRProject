using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.MenuTableDtos;
using System.Net.Http;

namespace SignalRUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory ;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> CustomerTableList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/MenuTables");
            if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
            {
                // json'dan gelen icerigi string formatinda oku 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
