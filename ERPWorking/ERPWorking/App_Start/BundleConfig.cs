using System.Web;
using System.Web.Optimization;

namespace ERPWorking
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/jquery-1.12.4.min.js",
                        "~/Scripts/bootstrap.js",                        
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                         "~/Scripts/jquery-ui-1.12.1.min.js",
                         "~/Scripts/Datatable/jquery.dataTables.min.js" ,
                         "~/Scripts/Datatable/dataTables.bootstrap.min.js",                        
                          "~/Scripts/hoe.js",
                        "~/Scripts/Global.js"       
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Content/site.css",                     
                      "~/Content/datatable/css/jquery.dataTables.min.css",
                      "~/Content/themes/base/jquery-ui.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(      
                "~/Content/sites.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/datatable/css/dataTables.jqueryui.css",                                                                 
                      "~/Content/datatable/css/dataTables.bootstrap.min.css",                                           
                      "~/Content/font-awesome.min.css",                      
                      "~/Content/hoe.css"                                                         
                      ));
        }
    }
}
