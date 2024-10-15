using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.FeatureDtos;

namespace SignalRUI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7190/api/Feature");
			if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
			{
				// json'dan gelen icerigi string formatinda oku 
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				// Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			//createFeatureDto.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7190/api/Feature", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		public async Task<IActionResult> DeleteFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7190/api/Feature/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7190/api/Feature/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7190/api/Feature/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
	}
}
