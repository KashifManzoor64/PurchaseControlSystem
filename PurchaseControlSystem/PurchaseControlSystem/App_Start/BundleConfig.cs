using System.Web;
using System.Web.Optimization;

namespace PurchaseControlSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/assets/js/jquery-3.3.1.js",
                        "~/Content/assets/js/jquery.ajax.min.js",
                        "~/Content/assets/js/main.js",
                        "~/Content/assets/js/custom.js"                        
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/assets/js/jquery.validate*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/assets/js/modernizr-2.8.3.js-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/css").Include(
                      "~/Content/assets/css/bootstrap.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/fonts/css/font-awesome.min.css",
                      "~/Content/assets/js/bootstrap.js"
                      ));
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
