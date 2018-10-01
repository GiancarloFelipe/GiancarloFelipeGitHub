using System.Web;
using System.Web.Optimization;

namespace PetService.MVC
{
    /// <summary>
    /// Registers all the listed bundles for the PetSure Web Application System.
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Set the script bundle for jquery...
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            // Set the script bundle for jqueryui...
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            // Set the script bundle for jqueryval...
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            // Set the script bundle for dropzonescripts...
            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                "~/Scripts/dropzone/dropzone.js"));

            // Set the style bundle for dropzonescss...
            bundles.Add(new StyleBundle("~/Content/dropzonescss").Include(
                "~/Scripts/dropzone/dropzone.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            // Set the script bundle for bootstrap...
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            // Set the style bundle for css...
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/font-awesome.css",
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            // Set the style bundle for base css...
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css"));

            // Set the script bundle for angularjs...
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/petsure/petsure.module.js",
                "~/Scripts/petsure/petsure.controller.js",
                "~/Scripts/petsure/petsure.service.js"));
        }
    }
}