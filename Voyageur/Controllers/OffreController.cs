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
            Client cli = (Client)Session["Client"];
            List<Ville> listeVille = db.Villes.ToList();
          
            if ((List<trajet>)TempData["TrajetRecherche"] == null)
            { 
                ViewBag.Trajet = db.trajets.ToList();
            }
            else
            {
                ViewBag.Trajet = (List<trajet>)TempData["TrajetRecherche"];
            }
            

            @ViewBag.SlectedView = "Offre";
            if (Session["Auth"] != null && (bool)Session["Auth"] == true)
            {
                List<Reservation> res = db.Reservations.Where(r => r.id_client == cli.Id).ToList();
                if (res.Count != 0)
                {
                    ViewBag.Reservation = res;
                }
            }
            
            return View(listeVille);
        }

        [Route("Reserver{id}")]
        public ActionResult Reservation(int id)
        {
            Reservation res = new Reservation();
            Client client = (Client)Session["Client"];
            res.id_client = client.Id;
            res.id_trajet = id;
            res.date_reservation = DateTime.Now;
            db.Reservations.Add(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Annuler{id}")]
        public ActionResult Annulation(int id)
        {
            db.Reservations.Remove(db.Reservations.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}