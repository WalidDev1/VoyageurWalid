using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyageur.Models;

namespace Voyageur.Controllers
{
    public class OffreController : Controller
    {

        private VoyageurEntities3 db = new VoyageurEntities3();
        // GET: Offre
        public ActionResult Index()
        {
            ViewBag.Trajet = db.trajets.ToList();
            @ViewBag.SlectedView = "Offre";
            return View();
        }
    }
}