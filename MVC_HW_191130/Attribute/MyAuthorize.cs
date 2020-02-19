using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_HW_191130.Attribute
{
    public class MyAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var allowRoles = Roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (allowRoles.Length > 0)
                {
                    bool hasRole = false;
                    foreach (var rol in allowRoles)
                    {
                        if (filterContext.HttpContext.User.IsInRole(rol))
                        {
                            hasRole = true;
                        }
                    }
                    if (false == hasRole)
                    {
                        RedirectToMyRoute(filterContext);
                    }
                }
            }
            else
            {
                //原本用HandleUnauthorizedRequest(filterContext);發現不會跳回首頁
                RedirectToMyRoute(filterContext);
            }
        }

        private void RedirectToMyRoute(AuthorizationContext filterContext)
        {
            //不曉得有沒有更簡單的方法從area裡面跳到根目錄預設路由
            filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Money",
                            area = ""
                        }
                    )
                );
        }
    }
}