using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.CocktailsDtos;
using Shop.Core.ServiceInterface;
using TARgv22Shop.Models.Cocktails;

namespace TARgv22Shop.Controllers
{
	public class CocktailsController : Controller
	{
		private readonly ICocktailServices _cocktailServices;

		public CocktailsController(ICocktailServices cocktailServices)
		{
			_cocktailServices = cocktailServices;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SearchCocktails(SearchCocktailViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("Cocktail", "Cocktails", new {cocktail = model.SearchCocktail});
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Cocktail(string cocktail)
		{
			CocktailResultDto dto = new()
			{
				StrDrink = cocktail
			};

			_cocktailServices.GetCocktails(dto);
			CocktailViewModel vm = new()
			{
				IdDrink = dto.IdDrink,
				StrDrink = dto.StrDrink,
				StrDrinkAlternate = dto.StrDrinkAlternate,
				StrTags = dto.StrTags,
				StrVideo = dto.StrVideo,
				StrCategory = dto.StrCategory,
				StrIBA = dto.StrIBA,
				StrAlcoholic = dto.StrAlcoholic,
				StrGlass = dto.StrGlass,
				StrInstructions = dto.StrInstructions,
				StrInstructionsES = dto.StrInstructionsES,
				StrInstructionsDE = dto.StrInstructionsDE,
				StrInstructionsFR = dto.StrInstructionsFR,
				StrInstructionsIT = dto.StrInstructionsIT,
				StrInstructionsZHHANS = dto.StrInstructionsZHHANS,
				StrInstructionsZHHANT = dto.StrInstructionsZHHANT,
				StrDrinkThumb = dto.StrDrinkThumb,
				StrIngredient1 = dto.StrIngredient1,
				StrIngredient2 = dto.StrIngredient2,
				StrIngredient3 = dto.StrIngredient3,
				StrIngredient4 = dto.StrIngredient4,
				StrIngredient5 = dto.StrIngredient5,
				StrIngredient6 = dto.StrIngredient6,
				StrIngredient7 = dto.StrIngredient7,
				StrIngredient8 = dto.StrIngredient8,
				StrIngredient9 = dto.StrIngredient9,
				StrIngredient10 = dto.StrIngredient10,
				StrIngredient11 = dto.StrIngredient11,
				StrIngredient12 = dto.StrIngredient12,
				StrIngredient13 = dto.StrIngredient13,
				StrIngredient14 = dto.StrIngredient14,
				StrIngredient15 = dto.StrIngredient15,
				StrMeasure1 = dto.StrMeasure1,
				StrMeasure2 = dto.StrMeasure2,
				StrMeasure3 = dto.StrMeasure3,
				StrMeasure4 = dto.StrMeasure4,
				StrMeasure5 = dto.StrMeasure5,
				StrMeasure6 = dto.StrMeasure6,
				StrMeasure7 = dto.StrMeasure7,
				StrMeasure8 = dto.StrMeasure8,
				StrMeasure9 = dto.StrMeasure9,
				StrMeasure10 = dto.StrMeasure10,
				StrMeasure11 = dto.StrMeasure11,
				StrMeasure12 = dto.StrMeasure12,
				StrMeasure13 = dto.StrMeasure13,
				StrMeasure14 = dto.StrMeasure14,
				StrMeasure15 = dto.StrMeasure15,
				StrImageSource = dto.StrImageSource,
				StrImageAttribution = dto.StrImageAttribution,
				StrCreativeCommonsConfirmed = dto.StrCreativeCommonsConfirmed,
				DateModified = dto.DateModified
			};

			return View(vm);
		}
	}
}
