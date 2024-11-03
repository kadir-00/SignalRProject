using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                Deescription = createDiscountDto.Deescription,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
                Status = false

            });
            return Ok("Indirim Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Basariyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountId = updateDiscountDto.DiscountId,
                Amount = updateDiscountDto.Amount,
                Title = updateDiscountDto.Title,
                ImageUrl= updateDiscountDto.ImageUrl,
                Deescription = updateDiscountDto.Deescription,
                Status=false
            });
            return Ok("Indirim Bilgisi Guncellendi");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        { 
        _discountService.TChangeStatusToTrue(id);
            return Ok("Urun Indirimi Aktif Hale Getirildi");
        }

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Urun Indirimi Pasif Hale Getirildi");
		}

	}
}
