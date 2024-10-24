using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.ProductDtos;
using SignalRUI.Dtos.SliderDtos;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Product");

            // json'dan gelen icerigi string formatinda oku 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);

            return View();
        }
    }
}
