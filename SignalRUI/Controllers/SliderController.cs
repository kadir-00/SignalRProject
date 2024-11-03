using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.FeatureDtos;
using SignalRUI.Dtos.SliderDtos;

namespace SignalRUI.Controllers
{
	public class SliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7190/api/Slider");
			if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
			{
				// json'dan gelen icerigi string formatinda oku 
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				// Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
		{
			//createFeatureDto.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSliderDto);
			StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7190/api/Slider", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7190/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7190/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSliderDto);
			StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7190/api/Slider/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
	}
}
