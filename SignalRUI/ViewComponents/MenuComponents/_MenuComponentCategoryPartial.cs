using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.CategoryDtos;
using System.Net.Http;

namespace SignalRUI.ViewComponents.MenuComponents
{
	public class _MenuComponentCategoryPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _MenuComponentCategoryPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7190/api/Category");
			if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
			{
				// json'dan gelen icerigi string formatinda oku 
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				// Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
