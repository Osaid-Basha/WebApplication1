using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public ViewResult Index()
        {


            string name = "osaid N basha";

            
            return View("Index",name);
        }
    }
}
