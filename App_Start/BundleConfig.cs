using System.Web;
using System.Web.Optimization;

namespace MusicStore
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/musicApp/js").Include(
                      "~/Assets/Modules/*.js",
                      "~/Assets/Services/*.js",
                      "~/Assets/Controllers/*.js"));

            bundles.Add(new StyleBundle("~/bundles/musicApp/css").Include(
                      "~/Content/Site.css"));

        }
	}
}
