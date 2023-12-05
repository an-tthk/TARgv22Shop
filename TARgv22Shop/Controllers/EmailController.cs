using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto;
using Shop.Core.Dto.AccuWeatherDtos;
using Shop.Core.ServiceInterface;
using TARgv22Shop.Models.AccuWeathers;
using TARgv22Shop.Models.Email;

namespace TARgv22Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailDto dto = new EmailDto()
                {
                    To = model.To,
                    Subject = model.Subject,
                    Body = model.Body
                };

                _emailServices.SendEmail(dto);
                return View(nameof(Index));
            }

            return View(model);
        }
    }
}
