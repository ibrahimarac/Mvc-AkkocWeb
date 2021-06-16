using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Akkoc.Utils
{
    public static class ModelExtensions
    {
        public static string ParseModelErrors(this ModelStateDictionary states)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var modelStates in states.Values)
            {
                foreach (var error in modelStates.Errors)
                {
                    sb.AppendFormat("{0}<br/>", error.ErrorMessage);
                }
            }

            return sb.ToString();

        }

        public static string ParseDbEntityValidationErrors(this DbEntityValidationException ex)
        {
            var sb = new StringBuilder();
            foreach (var failure in ex.EntityValidationErrors)
            {
                foreach (var error in failure.ValidationErrors)
                {
                    sb.AppendFormat("{0}</br>", error.ErrorMessage);
                }
            }
            return sb.ToString();
        }
    }
}
