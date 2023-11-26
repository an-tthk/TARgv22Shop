using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.ChuckNorrisDtos;
using Shop.Core.ServiceInterface;
using TARgv22Shop.Models.ChuckNorris;

namespace TARgv22Shop.Controllers
{
	public class ChuckNorrisController : Controller
	{
		private readonly IChuckNorrisServices _chuckNorrisServices;

		public ChuckNorrisController(IChuckNorrisServices chuckNorrisServices)
		{
			_chuckNorrisServices = chuckNorrisServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SearchChuckNorrisJokes(ChuckNorrisViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("Joke", "ChuckNorris");
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Joke()
		{
			ChuckNorrisResultDto dto = new();

			_chuckNorrisServices.ChuckNorrisResult(dto);
			ChuckNorrisViewModel vm = new()
			{
				Categories = dto.Categories,
				CreatedAt = dto.CreatedAt,
				IconUrl = dto.IconUrl,
				Id = dto.Id,
				UpdatedAt = dto.UpdatedAt,
				Url = dto.Url,
				Value = dto.Value
			};

			return View(vm);
		}
	}
}
