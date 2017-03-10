using System;
using System.Web.Optimization;

namespace Network.UI.App_Start
{
    public class BundleConfig
    {
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
        }
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/select2.css")
                .Include("~/Content/css/datepicker3.css")
                .Include("~/Content/css/AdminLTE.css")
                .Include("~/Content/css/toastr.min.css")
                .Include("~/Content/css/pace.min.css")
                // .Include("~/Content/css/chosen.css")

                .Include("~/Content/css/skins/skin-blue.css"));
            
            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-2.2.4.min.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.min.js")
                .Include("~/Content/js/plugins/select2/select2.full.min.js")
                .Include("~/Content/js/plugins/knockout/knockout-3.1.0.js")
                .Include("~/Content/js/plugins/knockout/knockout.mapping.js")
                .Include("~/Content/js/plugins/knockout/knockout-select2.js")
                .Include("~/Content/js/plugins/toastr/toastr.min.js")
                //.Include("~/Content/js/plugins/fastclick/fastclick.min.js")
                .Include("~/Content/js/plugins/numeral/numeral.min.js")
                
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.min.js")
                
                .Include("~/Content/js/plugins/moment/moment.min.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.min.js")
             //    .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator/validator.min.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.min.js")
                .Include("~/Content/js/plugins/uuid/uuid-v4.js")

                .Include("~/Content/js/plugins/linq/jquery.linq-vsdoc.js")
                .Include("~/Content/js/plugins/linq/jquery.linq.min.js")
                .Include("~/Content/js/plugins/linq/linq-vsdoc.js")
                .Include("~/Content/js/plugins/linq/linq.min.js")

                .Include("~/Content/js/plugins/pace/pace.min.js")
                //   .Include("~/Content/js/plugins/chosen/chosen.jquery.min.js")

                .Include("~/Content/js/app.js")
                .Include("~/Scripts/app/app.js")
                

                //   .Include("~/Scripts/app/model/person.js")
                .Include("~/Content/js/init.js")
               // .Include("~/Content/js/custom.js")
                 );

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}