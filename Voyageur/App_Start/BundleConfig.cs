using System.Web;
using System.Web.Optimization;

namespace Voyageur
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/Script").Include(
                "~/ClientFiles/vendor/jquery/jquery.min.js"                      ,
                "~/ClientFiles/vendor/bootstrap/js/bootstrap.bundle.min.js"      ,
                "~/ClientFiles/vendor/jquery.easing/jquery.easing.min.js"        ,
                "~/ClientFiles/vendor/php-email-form/validate.js"                ,
                "~/ClientFiles/vendor/waypoints/jquery.waypoints.min.js"         ,
                "~/ClientFiles/vendor/counterup/counterup.min.js"                ,
                "~/ClientFiles/vendor/venobox/venobox.min.js"                    ,
                "~/ClientFiles/vendor/owl.carousel/owl.carousel.min.js"          ,
                "~/ClientFiles/vendor/isotope-layout/isotope.pkgd.min.js"        ,
                "~/ClientFiles/vendor/aos/aos.js",
                "~/Script/Client/DatePicker.js"
                ));
            

             bundles.Add(new StyleBundle("~/bundles/ClientFiles").Include(
                 "~/ClientFiles/vendor/bootstrap/css/bootstrap.min.csss",
                 "~/ClientFiles/vendor/icofont/icofont.min.cs",
                 "~/ClientFiles/vendor/boxicons/css/boxicons.min.css",
                 "~/ClientFiles/vendor/venobox/venobox.css",
                 "~/ClientFiles/vendor/line-awesome/css/line-awesome.min.css",
                 "~/ClientFiles/vendor/owl.carousel/owl.carousel.min.css",
                 "~/ClientFiles/vendor/aos/aos.css"/*,
                 "~/Content/Client/style.css",
                 "~/Content/Client/DatePicker.css"*/
                 )) ;
        }
    }
}
