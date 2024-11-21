using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinesLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		
		}

		[HttpGet]
		public IActionResult MenuTablesList()
		{


			var values = _menuTableService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateMenuTables(CreateMenuTableDto createMenuTableDto )
		{
			createMenuTableDto.Status = false;
			var value = _mapper.Map<MenuTable>(createMenuTableDto);
			//MenuTable menuTable = new MenuTable()
			//{
			//	Name = createMenuTableDto.Name,
			//	Status = false
			//};
			_menuTableService.TAdd(value);
			return Ok("Masa  Basarili Bir Sekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Masa Basarili Bir Sekilde Silindi");
		}

		[HttpPut] //Guncelleme islemi icin 
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var value = _mapper.Map<MenuTable>(updateMenuTableDto);
			//MenuTable menuTable = new MenuTable()
			//{
			//	 MenuTableId = updateMenuTableDto.MenuTableId,
			//	 Name = updateMenuTableDto.Name,
			//	 Status = updateMenuTableDto.Status
			//};

			_menuTableService.TUpdate(value);
			return Ok("Masa Bilgisi Guncellendi");
		}

		//API de bir attiribut iki kere kullanilirsa hata veriyor o yuzden GET'e bir isim ekliyecegiz
		[HttpGet("{Id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}

		[HttpGet("ChangeMenuTableStatusToTrue")]
		public IActionResult ChangeMenuTableStatusToTrue(int id)
		{
			 _menuTableService.TChangeMenuTableStatusToTrue(id);
			return Ok("Islem Basarili");
		}
        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("Islem Basarili");
        }
    }
}
