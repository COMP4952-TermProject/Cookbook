using System.Web.Optimization;

namespace TechnicalProgrammingProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                    "~/Content/asset/js/datepickerReady.js"));

           

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                     "~/Content/asset/js/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/sidebar").Include(
                     "~/Content/asset/js/leftsidebar.js"));

            bundles.Add(new ScriptBundle("~/bundles/sidebar").Include(
                     "~/Content/asset/js/leftsidebar.js"));
            bundles.Add(new ScriptBundle("~/bundles/top").Include(
                     "~/Content/asset/js/topmsg.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/asset/css/login").Include(
                      "~/Content/asset/css/login.css"));

            bundles.Add(new StyleBundle("~/Content/asset/css/leftsidebar").Include(
                      "~/Content/asset/css/leftsidebar.css"));

            bundles.Add(new StyleBundle("~/Content/asset/css/uploadRecipe").Include(
                      "~/Content/asset/css/uploadRecipe.css"));
            bundles.Add(new StyleBundle("~/Content/asset/css/recipeCard").Include(
                     "~/Content/asset/css/recipeCard.css"));
            bundles.Add(new StyleBundle("~/Content/asset/css/recipeCard_CookBook").Include(
                    "~/Content/asset/css/recipeCard_CookBook.css"));
            bundles.Add(new StyleBundle("~/bundles/recipesapprove").Include(
                   "~/Content/asset/css/recipesApprove.css"));
            bundles.Add(new StyleBundle("~/bundles/hover").Include(
                 "~/Content/asset/css/hover-min.css"));
            bundles.Add(new StyleBundle("~/Content/asset/css/recipedetails").Include(
                   "~/Content/asset/css/recipeDetails.css"));

        }
    }
}