using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using System.Xml;
using TARgv22Shop.Models.RealEstate;

namespace TARgv22Shop.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopContext _context;
        private readonly IRealEstateServices _realEstateServices;

        public RealEstateController(ShopContext context, IRealEstateServices realEstateServices)
        {
            this._context = context;
            this._realEstateServices = realEstateServices;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    SizeSqrtM = x.SizeSqrtM,
                    RoomCount = x.RoomCount,
                    Floor = x.Floor,
                    BuildingType = x.BuildingType,
                    BuiltInYear = x.BuiltInYear,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrtM = vm.SizeSqrtM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _realEstateServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }


            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrtM = realEstate.SizeSqrtM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrtM = realEstate.SizeSqrtM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrtM = vm.SizeSqrtM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _realEstateServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrtM = realEstate.SizeSqrtM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstateId = await _realEstateServices.Delete(id);

            if (realEstateId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
