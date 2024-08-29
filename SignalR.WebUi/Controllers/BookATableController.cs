using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class BookATableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
