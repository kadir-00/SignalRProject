using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            //_testimonialService.TAdd(new Testimonial()
            //{
            //   Comment = createTestimonialDto.Comment,
            //   ImageUrl = createTestimonialDto.ImageUrl,
            //   Name = createTestimonialDto.Name,
            //   Status = createTestimonialDto.Status,
            //   Title = createTestimonialDto.Title,
            //});
            _testimonialService.TAdd(value);
            return Ok("Referans Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans Basariyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            //_testimonialService.TUpdate(new Testimonial()
            //{
            //    TestimonialId= updateTestimonialDto.TestimonialId,
            //    Comment = updateTestimonialDto.Comment,
            //    ImageUrl = updateTestimonialDto.ImageUrl,
            //    Name = updateTestimonialDto.Name,
            //    Status = updateTestimonialDto.Status,
            //    Title = updateTestimonialDto.Title,
            //});
            _testimonialService.TUpdate(value);
            return Ok("Referans Bilgisi Guncellendi");

        }
    }
}
