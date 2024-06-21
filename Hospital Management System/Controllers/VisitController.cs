using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
