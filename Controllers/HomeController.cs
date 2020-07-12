using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionnaire.Models;
using Microsoft.EntityFrameworkCore;
using Questionnaire.DBL;

namespace Questionnaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RegisterDBClass rdb = new RegisterDBClass();
        LoginDbClass ldb = new LoginDbClass();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentRegisterClass studentRegister, string buttonType)
        {
            try
            {
                if (buttonType == "Save")
                {
                    string msg = rdb.AddRegisterRecord(studentRegister);
                    TempData["msg"] = msg;
                }

                else if (buttonType == "Login")
                {
                    string Value = ldb.chkLoginDetails(studentRegister);
                    if (Value == null)
                    {
                        TempData["msg"] = "Please enter valid credintials";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}