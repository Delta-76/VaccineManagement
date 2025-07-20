using Microsoft.AspNetCore.Mvc;

namespace VaccineManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
