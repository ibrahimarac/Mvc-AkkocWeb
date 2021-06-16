using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Akkoc.Utils;

namespace Akkoc.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //DataTable
            bundles.Add(
                new ScriptBundle("~/admin/js/dataTable")
                .Include("~/Areas/Admin/Content/plugins/datatables/jquery.dataTables.js",
                "~/Areas/Admin/Content/plugins/datatables-bs4/js/dataTables.bootstrap4.js"));

            bundles.Add(
                   new StyleBundle("~/admin/css/dataTable")
                   .Include("~/Areas/Admin/Content/plugins/datatables-bs4/css/dataTables.bootstrap4.css")
            );
            //JConfirm
            bundles.Add(
                new StyleBundle("~/admin/css/jConfirm")
                .Include("~/Areas/Admin/Content/plugins/jconfirm/jquery-confirm.min.css"));
            bundles.Add(
                new ScriptBundle("~/admin/js/jConfirm")
                .Include("~/Areas/Admin/Content/plugins/jconfirm/jquery-confirm.min.js"));

            //CK Editor için eklendi
            bundles.Add(new ScriptBundle("~/admin/js/ckEditor")
                .Include(
                "~/Areas/Admin/Content/plugins/ckeditor/ckeditor.js",
                "~/Areas/Admin/Content/plugins/ckfinder/ckfinder.js"));

            //select2
            bundles.Add(new StyleBundle("~/admin/css/select2")
                .Include(
                "~/Areas/Admin/Content/plugins/select2/css/select2.min.css",
                "~/Areas/Admin/Content/plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css"));
            bundles.Add(new ScriptBundle("~/admin/js/select2")
                .Include("~/Areas/Admin/Content/plugins/select2/js/select2.full.min.js"));

            //cropper
            bundles.Add(new StyleBundle("~/admin/css/cropper")
                .Include("~/Areas/Admin/Content/plugins/cropper/cropper.css"));
            bundles.Add(new ScriptBundle("~/admin/js/cropper").NonOrdered()
                .Include("~/Areas/Admin/Content/plugins/cropper/cropper.js")
                .Include("~/Areas/Admin/Content/plugins/cropper/jquery-cropper.js")
                );

            //inputmask
            bundles.Add(new ScriptBundle("~/admin/js/inputmask")
                .Include("~/Areas/Admin/Content/plugins/moment/moment.min.js")
                .Include("~/Areas/Admin/Content/plugins/inputmask/min/jquery.inputmask.bundle.min.js").NonOrdered());

            //BundleTable.EnableOptimizations = true;
            
        }
    }
}