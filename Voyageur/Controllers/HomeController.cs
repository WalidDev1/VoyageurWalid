using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voyageur.Models;
using Voyageur.Security;

namespace Voyageur.Controllers
{
    public class HomeController : Controller
    {

        private VoyageurEntities3 db = new VoyageurEntities3();
        string[] ListeVille = {
            "Volvo",
            "BMW",
            "Ford",
            "Mazda"
        };

        [Route]
        public ActionResult Index(User userF , Client clientf , Societe societef)
        {
            // verification si lèutilisateur est deja connecter 
            if (Session["Auth"] != null  && (bool)Session["Auth"] == true)
            {
                ViewBag.User = Session["User"];
                ViewBag.Client = Session["Client"];
            }
            else
            {
                // verification des donnees du formulaire
                if (userF.log != null && clientf.Nom == null && societef.Nom == null)
                {
                    User user = new User();
                    try
                    {

                        UpdateModel(user);
                        Password EncryptData = new Password();
                        user.Pass = EncryptData.Encode(user.Pass);
                        foreach (User u in db.Users)
                        {
                            if (u.log.Equals(user.log))
                            {
                                if (u.Pass.Equals(user.Pass))
                                {
                                    Debug.WriteLine("good");
                                    Session["Auth"] = true;
                                    Session["User"] = u;
                                    ViewBag.User = u;
                                   /* System.Diagnostics.Debug.Write(u.log);*/
                                    if (u.Type == 0)
                                    {
                                        ViewBag.Client = db.Clients.Where(b => b.id_user == u.Id).FirstOrDefault();
                                        Session["Client"] = ViewBag.Client;


                                    }
                                    else
                                    {
                                        // lien de redirection vers Societe
                                    }
                                }
                                else
                                {
                                    Debug.WriteLine(" not good");
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                else if (clientf.Nom != null && userF.log != null && societef.adresse == null) // Connection d'un client
                {

                    Debug.WriteLine(" walid 1 ");
                    Client client = new Client();
                    User user = new User();
                    try
                    {
                        //insertion des donne recus dans notre variable
                        UpdateModel(client);
                        UpdateModel(user);
                        client.id_user = user.Id;
                        Password EncryptData = new Password();
                        user.Pass = EncryptData.Encode(user.Pass);
                        client.Date_inscrption = DateTime.Now;
                        db.Users.Add(user);
                        db.Clients.Add(client);
                        db.SaveChanges();
                        Session["Auth"] = true;
                        ViewBag.User = user;
                        ViewBag.Client = client;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                else if (societef.Nom != null && userF.log != null) // connection Societe
                {
                    Societe societe = new Societe();
                    User user = new User();
                    try
                    {
                        Debug.WriteLine(" walid ");
                        // type = 1 Societer
                        //insertion des donne recus dans notre variable
                        UpdateModel(societe);
                        UpdateModel(user);
                        user.Type = 1;
                        societe.id_user = user.Id;
                        societe.mail = user.log;
                        Password EncryptData = new Password();
                        user.Pass = EncryptData.Encode(user.Pass);
                        db.Users.Add(user);
                        db.Societes.Add(societe);
                        db.SaveChanges();
                        // redirection vers le lien de societe
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            
            ViewBag.Trajet = db.trajets;
            List<Ville> listeVille = db.Villes.ToList();
            ViewBag.SlectedView = "Home";
            return View(listeVille);

        }
        
        public ActionResult Rechercher(String id_ville_depart , String id_ville_destination , String date_depart ="", String date_arrivée = "", float prix_max = 0 , float prix_min = 0)
        {
            // Recuperation de tous les trajet
            if (!id_ville_depart.Equals("") && !id_ville_destination.Equals(""))
            {
            int idVilleDepart = Int32.Parse(id_ville_depart);
            int idVilleArriver = Int32.Parse(id_ville_destination);
            DateTime dateDepart ;
            DateTime dateArriver ;
               
           
           
           
            Decimal prixMin = (Decimal)prix_min;
            Decimal prixMax = (Decimal)prix_max;
                List<trajet> trajetTrouver = db.trajets.Where(
               t => t.id_ville_depart == idVilleDepart
               && t.id_ville_destination == idVilleArriver
               ).ToList();

                if (!date_depart.Equals(""))
                {
                    try
                    {
                        dateDepart = Convert.ToDateTime(date_depart);
                        trajetTrouver = trajetTrouver.Where(t => t.date_depart <= dateDepart || t.date_depart <= dateDepart).ToList();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                }

                if (!date_arrivée.Equals(""))
                {
                    try
                    {
                        dateArriver = Convert.ToDateTime(date_arrivée);
                        trajetTrouver = trajetTrouver.Where(t => t.date_arrivée >= dateArriver).ToList();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                }

                if (prix_min != 0)
                {
                    trajetTrouver = trajetTrouver.Where(t => t.prix >= prixMin).ToList();
                }

                if (prix_max != 0)
                {
                    trajetTrouver = trajetTrouver.Where(t => t.prix <= prixMax).ToList();
                }

                TempData["TrajetRecherche"] = trajetTrouver;
                return RedirectToAction("Index","Offre");
            }
           

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Deconnection")]
        public ActionResult Deconnection()
        {
            Session.Clear();
            ViewBag.Trajet = db.trajets.ToList();
            List<Ville> listeVille = db.Villes.ToList();
            ViewBag.SlectedView = "Home";
            return View(listeVille);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}