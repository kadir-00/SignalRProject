using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.TestimonialDtos;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Testimonial");

            // json'dan gelen icerigi string formatinda oku 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);

            return View();
        }
    }
}
