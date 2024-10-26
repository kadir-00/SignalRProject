using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Basket/BasketListByMenuTableWithProductName?id=3");
            if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
            {
                // json'dan gelen icerigi string formatinda oku 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
                var values = JsonConvert.DeserializeObject<List<ResultBasketDtos>>(jsonData);
                return View(values);
            }
            return View(); 
        }

        


        public async Task<IActionResult> DeleteBasket(int id)
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7190/api/Basket/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return NoContent();
		}
       
    }
}
