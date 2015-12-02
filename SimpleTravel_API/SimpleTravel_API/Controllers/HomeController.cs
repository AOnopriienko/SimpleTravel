using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SimpleTravel.Infrastructure;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel_API.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Trip> repository;
        public HomeController(IRepository<Trip> repositoryTrip)
        {
            repository = repositoryTrip;
        }
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            var listItems = repository.GetList();
            return View(listItems);
        }
        public ActionResult Reservation(Guid id)
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
