using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList() 
        { 
        var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
   //         Booking booking = new Booking()
   //         {
   //                 Mail=createBookingDto.Mail,
   //                 Date=createBookingDto.Date,
   //                 Name=createBookingDto.Name,
   //                 PersonCount=createBookingDto.PersonCount,
   //                 Phone=createBookingDto.Phone,
			//		Description = createBookingDto.Description
			//};
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Yapildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Siparis Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            //Booking booking = new Booking()
            //{
            //    BookingId = updateBookingDto.BookingId,
            //    Mail = updateBookingDto.Mail,
            //    Date = updateBookingDto.Date,
            //    Name = updateBookingDto.Name,
            //    PersonCount = updateBookingDto.PersonCount,
            //    Phone = updateBookingDto.Phone,
                
            //};
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Guncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id) 
        {
            var value = _bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Aciklamasi Degistirildi");
        }
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.BookingStatusCancelled(id);
			return Ok("Rezervasyon Aciklamasi Degistirildi");
		}
	}
}
//void BookingStatusApproved(int id);
//void BookingStatusCancelled(int id);
