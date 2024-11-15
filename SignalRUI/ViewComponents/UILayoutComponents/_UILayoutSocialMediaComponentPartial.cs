using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.SocialMediaDtos;

namespace SignalRUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7190/api/SocialMedia");
			if (responseMessage.IsSuccessStatusCode) // eger responseMessage 200 donerse 
			{
				// json'dan gelen icerigi string formatinda oku 
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				// Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
