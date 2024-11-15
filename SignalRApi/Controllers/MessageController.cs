using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
		 createMessageDto.Status = false;
			createMessageDto.MessageSendDate = DateTime.UtcNow; 
			var value = _mapper.Map<Message>(createMessageDto);
			//Message message = new Message()
			//{
			//	Mail = createMessageDto.Mail,
			//	MessageContent = createMessageDto.MessageContent,
			//	MessageSendDate = DateTime.UtcNow,
			//	NameSurname = createMessageDto.NameSurname,
			//	Phone = createMessageDto.Phone,
			//	Status = false,
			//	Subject = createMessageDto.Subject,
			//};
			_messageService.TAdd(value);
			return Ok("Mesaj Kismi Basarili Bir Sekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Hakkimda Alani Basarili Bir Sekilde Silindi");
		}

		[HttpPut] //Guncelleme islemi icin 
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			//Message message = new Message()
			//{
			//	Mail = updateMessageDto.Mail,
			//	MessageContent = updateMessageDto.MessageContent,
			//	MessageSendDate = updateMessageDto.MessageSendDate,
			//	NameSurname = updateMessageDto.NameSurname,
			//	Phone = updateMessageDto.Phone,
			//	Status = false,
			//	Subject = updateMessageDto.Subject,
			//	MessageId = updateMessageDto.MessageId
			//};

			_messageService.TUpdate(value);
			return Ok("Hakkimda Alani Guncellendi");
		}

		//API de bir attiribut iki kere kullanilirsa hata veriyor o yuzden GET'e bir isim ekliyecegiz
		[HttpGet("{Id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(_mapper.Map<GetByIdMesssageDto>(value));
		}
	}
}
