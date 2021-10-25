using System.Web;
using System.Web.Optimization;

namespace FIT5032_2021S2New
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Date time picker part
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.min.js"));

            //Map
            bundles.Add(new ScriptBundle("~/bundles/map").Include(
                "~/Scripts/map.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/moment.js",
                "~/Scripts/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/fullcalendar.min.css"));

        }
    }
}
