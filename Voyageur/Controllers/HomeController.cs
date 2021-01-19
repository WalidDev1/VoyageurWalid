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
                                ViewBag.User = u;
                                if (u.Type == 0)
                                {
                                    // lien de redirection vers Societe
                                }
                                else
                                {
                                    ViewBag.Client = db.Clients.Where(b => b.id_user == u.Id).FirstOrDefault();
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
            }else  if (societef.Nom != null  && userF.log != null) // connection Societe
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
            ViewBag.Trajet = db.trajets.ToList();
            List<Ville> listeVille = db.Villes.ToList();
            ViewBag.SlectedView = "Home";
            return View(listeVille);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}