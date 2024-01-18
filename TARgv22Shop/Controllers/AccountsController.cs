using Microsoft.AspNetCore.Mvc;

namespace TARgv22Shop.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
