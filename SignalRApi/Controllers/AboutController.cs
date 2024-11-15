using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);

            //About about = new About()
            //{
            //    ImageUrl = createAboutDto.ImageUrl,
            //    Description = createAboutDto.Description,
            //    Title = createAboutDto.Title,
            //};
            _aboutService.TAdd(value);
            return Ok("Hakkimda Kismi Basarili Bir Sekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkimda Alani Basarili Bir Sekilde Silindi");
        }

        [HttpPut] //Guncelleme islemi icin 
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            //About about = new About()
            //{
            //    AboutId = updateAboutDto.AboutId,
            //    ImageUrl = updateAboutDto.ImageUrl,
            //    Description = updateAboutDto.Description,
            //    Title = updateAboutDto.Title
            //};

            _aboutService.TUpdate(value);
            return Ok("Hakkimda Alani Guncellendi");
        }

        //API de bir attiribut iki kere kullanilirsa hata veriyor o yuzden GET'e bir isim ekledik
        [HttpGet("{Id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}
