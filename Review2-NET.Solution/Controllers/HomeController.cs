using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review2_NET.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review_2NET.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db = new MyContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
