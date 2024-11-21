﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.EntityLayer.Entities;
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


        public async Task<IActionResult> Index(int id)
        {
			ViewBag.v = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Product/ProductListWithCategory");

            // json'dan gelen icerigi string formatinda oku 
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // Deserialize json data'yi normal metine , Serelize da normal metini json formatina cevirir
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

		[HttpPost]
		public async Task<IActionResult> AddBasket(int id, int menuTableId)
		{
			if (menuTableId == 0)
			{
				return BadRequest("MenuTableId 0 geliyor.");
			}

			CreateBasketDto createBasketDto = new CreateBasketDto
			{
				ProductID = id,
				MenuTableId = menuTableId // Gelen MenuTableID burada kullanılıyor
			};

			 
			

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBasketDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7190/api/Basket", stringContent);

			var client2 = _httpClientFactory.CreateClient();
			//var jsonData2 = JsonConvert.SerializeObject(updateCategoryDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			await client2.GetAsync("https://localhost:7190/api/MenuTables/ChangeMenuTableStatusToTrue?id=" + menuTableId);

			var client3 = _httpClientFactory.CreateClient();
			await client3.GetAsync("https://localhost:7190/api/MenuTables/ChangeMenuTableStatusToFalse?id=" + menuTableId);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return Json(createBasketDto);
		}

		//[HttpPost]
		//public async Task<IActionResult> AddBasket(int id,int menuTableId)
		//{
		//	if (menuTableId == 0) 
		//	{
		//		return BadRequest("MenuTableId 0 Geliyor");
		//	}
		//	CreateBasketDto createBasketDto = new CreateBasketDto() 
		//	{ 
		//	ProductID = id,
		//	MenuTableId = menuTableId

		//	};

		//          var client = _httpClientFactory.CreateClient();
		//          var jsonData = JsonConvert.SerializeObject(createBasketDto);
		//          StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
		//          var responseMessage = await client.PutAsync("https://localhost:7190/api/Basket/", stringContent);


		//          //createBasketDto.ProductID = id;
		//          //createBasketDto.MenuTableId = int.Parse( TempData["x"].ToString());
		//          // masa numarasi atanmali 
		//          var client2 = _httpClientFactory.CreateClient();
		//          //var jsonData2 = JsonConvert.SerializeObject(createBasketDto);
		//          //StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
		//          await client2.GetAsync("https://localhost:7190/api/MenuTables/ChangeMenuTableStatusToFalse?id= "+menuTableId);

		//          if (responseMessage.IsSuccessStatusCode)
		//	{
		//		return RedirectToAction("Index");
		//	}
		//	return Json(createBasketDto);
		//}
	}
}
