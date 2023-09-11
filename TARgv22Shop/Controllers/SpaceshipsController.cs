using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using TARgv22Shop.Models;
using TARgv22Shop.Models.Spaceship;

namespace TARgv22Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        
        public SpaceshipsController(ShopContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Passengers = x.Passengers,
                    EnginePower = x.EnginePower,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
