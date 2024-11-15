using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            //_sliderService.TAdd(new Slider()
            //{
            //    Title1 = createSliderDto.Title1,
            //    Description1 = createSliderDto.Description1,
            //    Description2 = createSliderDto.Description2,
            //    Description3 = createSliderDto.Description3,
            //    Title2 = createSliderDto.Title2,
            //    Title3 = createSliderDto.Title3,  
            //});
            _sliderService.TAdd(value);
            return Ok("Feature Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Basariyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(_mapper.Map<GetSlideDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(UpdateSlider);
            //_sliderService.TUpdate(new Slider()
            //{
            //    SliderId = updateSliderDto.SliderId,
            //    Title1 = updateSliderDto.Title1,
            //    Description1 = updateSliderDto.Description1,
            //    Description2 = updateSliderDto.Description2,
            //    Description3 = updateSliderDto.Description3,
            //    Title2 = updateSliderDto.Title2,
            //    Title3 = updateSliderDto.Title3,
            //});
            _sliderService.TUpdate(value);
            return Ok("Feature Bilgisi Guncellendi");

        }
    }
}
