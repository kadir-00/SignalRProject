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

		public MenuTablesController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
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
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTables(CreateMenuTableDto createMenuTableDto )
		{
			MenuTable menuTable = new MenuTable()
			{

				Name = createMenuTableDto.Name,
				Status = false
			};

			_menuTableService.TAdd(menuTable);
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
			MenuTable menuTable = new MenuTable()
			{
				 MenuTableId = updateMenuTableDto.MenuTableId,
				 Name = updateMenuTableDto.Name,
				 Status = updateMenuTableDto.Status
			};

			_menuTableService.TUpdate(menuTable);
			return Ok("Masa Bilgisi Guncellendi");
		}

		//API de bir attiribut iki kere kullanilirsa hata veriyor o yuzden GET'e bir isim ekliyecegiz
		[HttpGet("{Id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
