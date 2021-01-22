using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyageur.Models;

namespace Voyageur.Controllers
{
    public class ReservationController : Controller
    {
        private VoyageurEntities3 db = new VoyageurEntities3();
        // GET: Reservation
        public ActionResult Index()
        {
            @ViewBag.SlectedView = "Reservtaion";
            if (db.Reservations.Count() != 0)
            {
                ViewBag.Reservation = db.Reservations;
            }
            return View();
        }
    }
}