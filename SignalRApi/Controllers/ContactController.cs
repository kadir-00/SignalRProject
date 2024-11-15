using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
       public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            //_contactService.TAdd(new Contact()
            //{
            //    FooterDescription= createContactDto.FooterDescription,
            //    Location= createContactDto.Location,
            //    Mail= createContactDto.Mail,
            //    Phone= createContactDto.Phone,
            //    FooterTitle= createContactDto.FooterTitle,
            //    OpenDays= createContactDto.OpenDays,
            //    OpenDaysDescription= createContactDto.OpenDaysDescription,
            //    OpenHours= createContactDto.OpenHours,

            //});
            _contactService.TAdd(value);
            return Ok("Iletisim Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Basariyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
   //         _contactService.TUpdate(new Contact()
   //         {
   //             ContactId = updateContactDto.ContactId,
   //             FooterDescription = updateContactDto.FooterDescription,
   //             Location = updateContactDto.Location,
   //             Mail= updateContactDto.Mail,
   //             Phone= updateContactDto.Phone,
			//	FooterTitle = updateContactDto.FooterTitle,
			//	OpenDays = updateContactDto.OpenDays,
			//	OpenDaysDescription = updateContactDto.OpenDaysDescription,
			//	OpenHours = updateContactDto.OpenHours,
			//});
            _contactService.TUpdate(value);
            return Ok("Iletisim Bilgisi Guncellendi");

        }
    }
}
