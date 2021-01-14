using System.Web;
using System.Web.Optimization;

namespace TechnicalEmploymentTest
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.5.1.min.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));



            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                 "~/Scripts/js/jquery-easing/jquery.easing.min.js",
                 "~/Scripts/js/sb-admin-2.min.js",
                 "~/Scripts/js/datatables/jquery.dataTables.min.js",
                 "~/Scripts/js/datatables/dataTables.bootstrap4.min.js",
                 "~/Scripts/js/demo/datatables-demo.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/css/sb-admin-2.min.css"

                      ));

         
        }
    }
}
