using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Akkoc.Utils.Binders
{
    public class CustomModelBinder : DefaultModelBinder
    {
       
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            controllerContext.Controller.TempData["model"] = bindingContext.Model;          
            
            base.OnModelUpdated(controllerContext, bindingContext);
        }


    }
}
