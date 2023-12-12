using Microsoft.AspNetCore.Mvc;

namespace TARgv22Shop.Controllers
{
    public class ChatHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
