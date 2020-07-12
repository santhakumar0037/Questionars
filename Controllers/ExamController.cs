using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace Questionnaire.Controllers
{
    public class ExamController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}