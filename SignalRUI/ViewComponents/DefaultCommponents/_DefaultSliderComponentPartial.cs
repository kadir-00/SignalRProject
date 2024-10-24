using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.SliderDtos;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Slider");
           
                // json'dan gelen icerigi string formatinda oku 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            
            return View();
        }

    }
}
