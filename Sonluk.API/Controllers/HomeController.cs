using Sonluk.API.CRM;
using Sonluk.BusinessLogic.SSO;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using Sonluk.Utility.Security;
using System;
using System.Web.Mvc;

namespace Sonluk.API.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("List", "Doc");
        }

        public ActionResult SignIn(string infor = "")
        {
            ViewBag.Infor = infor;
            ViewBag.Url = "";
            if (Session["url"] != null) ViewBag.Url = Session["url"].ToString();
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cookies["token"].Value = "";
            Session.Remove("token");
            if (Session["url"] != null) return Redirect(Session["url"].ToString());
            else return RedirectToAction("SignIn", "Home", new { infor = "Logout" });
        }

        public ActionResult Login()
        {
            bool valid = false;
            if (Session["token"] != null && Session["token"].ToString() != "")
            {
                if (new CRM_Login().ValidateToken(Session["token"].ToString())) valid = true;
                else Session.Remove("token");
            }
            if (Request.Cookies["token"] != null && Request.Cookies["token"].Value != "")
            {
                if (new CRM_Login().ValidateToken(Request.Cookies["token"].Value)) valid = true;
                else Response.Cookies["token"].Value = "";
            }
            if (valid) return RedirectToAction("SignIn", "Home");

            string url = Request.Url.ToString();
            string SSOURL = "http://dev.sonluk.com.cn/SonlukSSO";
            if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1 || url.IndexOf("10.1") != -1) SSOURL = "http://10.1.22.2/SonlukSSO";
            url = DESE.Encrypt(url, "Sonluk@19542014");
            string TOKENID = Request.QueryString["TOKENID"];
            if (!string.IsNullOrEmpty(TOKENID))
            {
                MES_RETURN rst_MES_RETURN_UI = new TOKEN_TOKENIDINFO().SELECT(TOKENID);
                if (rst_MES_RETURN_UI.TYPE == "S")
                {
                    CRM_LoginInfo tokeninfo = new CRM_Login().Login_SSO_TOKEN_LANGUAGE(TOKENID, 1, 0);
                    if (!string.IsNullOrEmpty(tokeninfo.TokenInfo.access_token))
                    {
                        Response.Cookies["token"].Value = rst_MES_RETURN_UI.MESSAGE;
                        Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                        Session["token"] = tokeninfo.TokenInfo.access_token;
                        if (Session["url"] != null) return Redirect(Session["url"].ToString());
                        else return RedirectToAction("SignIn", "Home");
                    }
                }
            }
            return Redirect(SSOURL + "?URL=" + url + "&LOGINTYPE=1");
        }
    }
}
