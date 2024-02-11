using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataAccessLayer dataAccess=new DataAccessLayer();
            dataAccess.GetAllEmployee();
            return View();
        }

        public IActionResult ViewEmployee()
        {
            DataAccessLayer dataAccess = new DataAccessLayer();
            IEnumerable<Employee> list = new List<Employee>();
            list=dataAccess.GetAllEmployee();            
            return View(list);
        }

        public IActionResult AddEmployee() 
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            DataAccessLayer dataAccess = new DataAccessLayer();
            int result = dataAccess.AddEmployee(employee);
            RedirectToAction("ViewEmployee");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}