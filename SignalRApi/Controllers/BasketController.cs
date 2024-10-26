using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BussinesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var value = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id).Select(z => new ResultBasketListWithProducts
			{
                BasketId=z.BasketId,
                Count=z.Count, 
                MenuTableId=z.MenuTableId,
                Price=z.Price,
                ProductID=z.ProductID,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.ProductName
			}).ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context=new SignalRContext();
            _basketService.TAdd(new SignalR.EntityLayer.Entities.Basket() 
            {
				ProductID = createBasketDto.ProductID,
				Count = 1,
                MenuTableId = 3,  /* bak*/
                Price =context.Products.Where(x=>x.ProductID==createBasketDto.ProductID).Select(y=>y.Price).FirstOrDefault(),
            TotalPrice=0,
            }); 
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
			var value = _basketService.TGetById(id);
			_basketService.TDelete(value);
			return Ok("Sepetteki Secilen Urun Silindi");
		}

	}
}
