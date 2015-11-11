using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SimpleTravel.Infrastructure;

namespace SimpleTravel_API.Controllers
{
    public class HomeController : Controller
    {
        public IApartmentRepository repo;
        public IReservation reservation;
        public HomeController(IApartmentRepository r, IReservation res)
        {
            repo = r;
            reservation = res;
        }
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            //Apartment apartment = repo.GetApartment(id);
            return View();
        }
        public ActionResult Reservation(Guid id)
        {
            //Apartment apartment = repo.GetApartment(id);
            //reservation.MakeReservation(apartment);
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            //repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
