using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;

namespace SimpleTravel_API.Controllers
{
    public class HomeController : Controller
    {
        IAccommodationRepository repo;
        IReservation reservation;
        public HomeController(IAccommodationRepository r, IReservation res)
        {
            repo = r;
            reservation = res;
        }
        public ActionResult Index()
        {
            var accommodation = repo.GetAccommodationList();
            return View();
        }
        public ActionResult Reservation(Guid id)
        {
            Accommodation accommodation = repo.GetAccommodation(id);
            reservation.MakeReservation(accommodation);
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
