using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRUI.Dtos.CategoryDtos;

namespace SignalRUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IActionResult> Index()
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

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();

        }

        [HttpPost]
		public async Task< IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,System.Text.Encoding.UTF8,"application/json" );
            var responseMessage = await client.PostAsync("https://localhost:7190/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            { 
            return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7190/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        { 
        var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            { 
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData,System.Text.Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7190/api/Category/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            { 
            return RedirectToAction("Index");
            }
            return View();

        }

	}
}
