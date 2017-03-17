using System.Web;
using System.Web.Optimization;

namespace CMS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts section
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-validate").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/editor").Include(
                        "~/Areas/Administrator/Scripts/tinymce/tinymce.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                        "~/Areas/Administrator/Scripts/custom.js"));

            //Styles section
            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/styles/font-awesome").Include(
                        "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/styles/admin").Include(
                        "~/Areas/Administrator/Content/custom.css"));
        }
    }
}
