using System.Web;
using System.Web.Optimization;

namespace AnyOffice.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //jQuery easy ui
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                        "~/Scripts/easyui/jquery.easyui.js",
                        "~/Scripts/easyui/locale/easyui-lang-zh_CN.js"));

            //jQuery验证
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            //jQuery easy ui css
            bundles.Add(new StyleBundle("~/Content/easyui").Include(
                        "~/Content/easyui/themes/bootstrap/easyui.css",
                        "~/Content/easyui/themes/icon.css"));

            //Custom css
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}