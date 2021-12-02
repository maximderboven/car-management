using Insurance.BL;
using Microsoft.AspNetCore.Mvc;

namespace UI.MVC.Controllers
{
    public class CarController : Controller
    {
        public CarController()
        {
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}