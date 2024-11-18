using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.BasketDtos;
using SignalRUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRUI.Controllers
{
    public class MenuController : Controller
    { // SignalR kullanilarak SIparis verilecek olan sayfa burasi 
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Product/ProductListWithCategory");

            // json'dan gelen icerigi string formatinda oku 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
		//[HttpPost]
		//public async Task<IActionResult> AddBasket(int id)
		//{
		//          CreateBasketDto createBasketDto = new CreateBasketDto();
		//          createBasketDto.ProductID = id;

		//	var client = _httpClientFactory.CreateClient();
		//	var jsonData = JsonConvert.SerializeObject(createBasketDto);
		//	StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
		//	var responseMessage = await client.PostAsync("https://localhost:7190/api/Basket", stringContent);
		//	if (responseMessage.IsSuccessStatusCode)
		//	{
		//		return RedirectToAction("Index");
		//	}
		//	return Json(createBasketDto);
		//}

		[HttpPost]
		public async Task<IActionResult> AddBasket(int id)
		{
			CreateBasketDto createBasketDto = new CreateBasketDto();
			createBasketDto.ProductID = id;

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBasketDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7190/api/Basket/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return Json(createBasketDto);
		}
	}
}
