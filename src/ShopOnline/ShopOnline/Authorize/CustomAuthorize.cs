using Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Authorize
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public CustomAuthorize(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/_401.cshtml"
            };
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var role = Roles;
            var roles = HttpContext.Current.Request.Cookies.Get(CookieConst.ROLE);
            if (roles == null)
            {
                return true;
            }
            else
            {
                if (role.Contains(roles.Value)) return true;
                return false;
            }
        }
    }
}