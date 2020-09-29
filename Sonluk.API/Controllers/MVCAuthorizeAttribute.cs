using Sonluk.BusinessLogic.CRM;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sonluk.API.Controllers
{
    public class MVCAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            httpContext.Session["url"] = httpContext.Request.Url.ToString();
            bool valid = false;
            string token = "";
            List<int> staffIDs = new List<int>();
            if (!string.IsNullOrEmpty(Users))
            {
                switch (Users)
                {
                    case "admin":
                        staffIDs.Add(35);
                        staffIDs.Add(79);
                        break;
                }
            }
            if (httpContext.Session["token"] != null && httpContext.Session["token"].ToString() != "")
            {
                if (new CRM_Login().ValidateToken(httpContext.Session["token"].ToString()))
                {
                    token = httpContext.Session["token"].ToString();
                    valid = true;
                }
            }
            if (httpContext.Request.Cookies["token"] != null && httpContext.Request.Cookies["token"].Value != "")
            {
                if (new CRM_Login().ValidateToken(httpContext.Request.Cookies["token"].Value))
                {
                    token = httpContext.Request.Cookies["token"].Value;
                    valid = true;
                }
            }
            if (staffIDs.Count > 0)
            {
                valid = false;
                if (staffIDs.Contains(new CRM_Login().ReadSTAFFIDByToken(token))) valid = true;
            }
            if (valid)
            {
                httpContext.Session["token"] = token;
                httpContext.Response.Cookies["token"].Value = token;
                return true;
            }
            else
            {
                httpContext.Session.Remove("token");
                httpContext.Response.Cookies["token"].Value = "";
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "SignIn" }));
        }
    }
}