using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace SimpleTravel_API.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ActionResult Login(string Username, string Password)
        {
            return View();
        }
    }
}
