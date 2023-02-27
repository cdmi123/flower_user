using Flower_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace Flower_Management.Controllers
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
            if (TempData.Peek("Name") != null)
            {
                ViewBag.Name = TempData.Peek("Name");
            }
            else 
            {
                ViewBag.Name = "";
            }

            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Aboutus()
        {
            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            DataSet ds = loginModel.Login(loginModel.email, loginModel.password);
            ViewBag.user_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.user_data.Rows)
            {
                TempData["user_id"] = dr["user_id"].ToString();
                TempData["Name"] = dr["user_name"].ToString();
                TempData["Email"] = dr["email"].ToString();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            int record = registerModel.Register(registerModel.name, registerModel.email, registerModel.password);

            if (record > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult logout()
        {
            TempData.Remove("user_id");
            TempData.Remove("Name");

            return RedirectToAction("Index");
        }

        public IActionResult forget() 
        {
                return View();
        }
        public IActionResult product_details() 
        { 
            return View();
        }
        public IActionResult cart()
        {
            return View();
        }
        public IActionResult wishlist()
        {
            return View();
        }

        public IActionResult checkout() 
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