using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcproje.Models;

namespace mvcproje.Controllers
{

    public class KadroController : Controller
    {


        public IActionResult Index()
        {
            return View(Repository.Kadros);
        }
        public IActionResult Info(int id)
        {

            return View(Repository.GetKadroById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}