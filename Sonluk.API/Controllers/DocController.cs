using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sonluk.BusinessLogic.Helper;
using Sonluk.Entities.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Sonluk.API.Controllers
{
    public class DocController : Controller
    {
        const string httpProtocol = "http://";
        const string standardName = "Standard";

        public ActionResult Index()
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav();
            return View();
        }

        public ActionResult WebService()
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav("WebService");
            return View();
        }

        [MVCAuthorize(Users = "admin")]
        public ActionResult OAInfor()
        {
            ViewBag.nav = Nav();
            ViewBag.back = Url.Action("List", "Doc");
            return View();
        }

        [MVCAuthorize(Users = "admin")]
        public ActionResult ApiData()
        {
            ViewBag.nav = Nav();
            ViewBag.back = Url.Action("List", "Doc");
            return View();
        }

        [MVCAuthorize(Users = "admin")]
        public ActionResult Specification()
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav();
            ViewBag.back = Url.Action("List", "Doc");
            return View();
        }

        [MVCAuthorize(Users = "admin")]
        public ActionResult Code()
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav();
            ViewBag.back = Url.Action("List", "Doc");
            List<ApiMessage> apiMessages = MessageSelector.ReadAll();
            ViewBag.apiMessages = JsonConvert.SerializeObject(apiMessages);
            return View();
        }

        public ActionResult List(string system = "", string module = "")
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav(system, module);
            List<string> urlList = new List<string>();
            if (system == "" || module == "")
            {
                ViewBag.thead = "<colgroup><col width=\"180\"><col></colgroup>"
                              + "<thead><tr>"
                              + "<th>目录</th>"
                              + "<th>内容概要</th>"
                              + "</tr></thead>";
                urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"" + Url.Action("Specification", "Doc") + "\">API设计指导书</a></td>"
                        + "<td>用于指示API设计的指导书，包含了API路径和定义等</td>"
                        + "</tr>");
                urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"" + Url.Action("Code", "Doc") + "\">API消息代码对照表</a></td>"
                        + "<td>查询消息代码包含的状态和内容</td>"
                        + "</tr>");
                urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"" + Url.Action("ApiData", "Doc") + "\">API日志</a></td>"
                        + "<td>查询API调用日志</td>"
                        + "</tr>");
                urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"" + Url.Action("OAInfor", "Doc") + "\">OA模板对照表</a></td>"
                        + "<td>查询OA模板以及相关信息</td>"
                        + "</tr>");
                DirectoryInfo TheFolder = new DirectoryInfo(Server.MapPath("~/Content/doc/"));
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    dynamic items = null;
                    using (StreamReader r = new StreamReader(NextFile.FullName))
                    {
                        items = JObject.Parse(r.ReadToEnd());
                    }
                    string method = "POST";
                    if (items.method != null) method = items.method;
                    string title = Path.GetFileNameWithoutExtension(NextFile.FullName);
                    if (items.title != null) title = items.title;
                    urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"Explain?func=" + Path.GetFileNameWithoutExtension(NextFile.FullName) + "\">" + title + "</a></td>"
                        + "<td>" + items.sms + "</td>"
                        + "</tr>");
                }
            }
            else
            {
                ViewBag.thead = "<colgroup><col width=\"180\"><col width=\"180\"><col width=\"120\"><col width=\"320\"><col></colgroup>"
                              + "<thead><tr>"
                              + "<th>名称</th>"
                              + "<th>地址栏参数</th>"
                              + "<th>方法</th>"
                              + "<th>地址</th>"
                              + "<th>描述</th>"
                              + "</tr></thead>";
                DirectoryInfo TheFolder = new DirectoryInfo(Server.MapPath("~/Content/doc/" + system + "/" + module + "/"));
                int row = 0;
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    row++;
                    dynamic items = null;
                    using (StreamReader r = new StreamReader(NextFile.FullName))
                    {
                        items = JObject.Parse(r.ReadToEnd());
                    }
                    string method = "POST";
                    if (items.method != null) method = items.method;
                    string address = httpProtocol + HttpContext.Request.Url.Host;
                    if (items.route != null)
                    {
                        string[] route = ((string)items.route).Split('/');
                        address = address + Url.HttpRouteUrl("DefaultApi", new { action = route[2], controller = route[1], area = route[0] });
                    }
                    else address = address + Url.HttpRouteUrl("DefaultApi", new { action = Path.GetFileNameWithoutExtension(NextFile.FullName), controller = module, area = system });
                    if (items.address != null) address = items.address;
                    string title = Path.GetFileNameWithoutExtension(NextFile.FullName);
                    if (items.title != null) title = items.title;
                    string parameter = "";
                    if (items.unique == null || !(bool)items.unique)
                    {
                        using (StreamReader r = new StreamReader(Server.MapPath("~/Content/doc/" + standardName + ".json")))
                        {
                            dynamic items2 = JObject.Parse(r.ReadToEnd());
                            if (items2.inQuery != null)
                            {
                                foreach (var item in items2.inQuery)
                                {
                                    parameter = parameter + item.Name + ", ";
                                }
                            }
                        }
                    }
                    if (items.inQuery != null)
                    {
                        foreach (var item in items.inQuery)
                        {
                            parameter = parameter + item.Name + ", ";
                        }
                    }
                    if (parameter != "") parameter = parameter.Substring(0, parameter.Length - 2);
                    else parameter = "无参数";
                    urlList.Add("<tr>"
                        + "<td><a style=\"color:#009688;\" href=\"Explain?system=" + system + "&module=" + module + "&func=" + Path.GetFileNameWithoutExtension(NextFile.FullName) + "\">" + title + "</a></td>"
                        + "<td>" + parameter + "</td>"
                        + "<td>" + method + "</td>"
                        + "<td><span onclick='copyOwn()' id='apiAddressRow" + row + "'>" + address + "</span></td>"
                        + "<td>" + items.sms + "</td>"
                        + "</tr>");
                }
            }
            if (urlList.Count == 0)
            {
                urlList.Add("<tr><td>无</td><td>无</td><td>无</td><td>无</td></tr>");
            }
            return View(urlList);
        }

        public ActionResult Explain(string system = "", string module = "", string func = standardName)
        {
            Session["url"] = Request.Url.ToString();
            ViewBag.nav = Nav(system, module);
            ViewBag.back = Url.Action("List", "Doc", new { system = system, module = module });
            ViewBag.api = Url.Action("GetApiInfor", "Doc", new { system = system, module = module, func = func });
            ViewBag.func = func;
            ViewBag.method = "POST";
            ViewBag.creator = "未知";
            ViewBag.address = "无地址";
            ViewBag.date = "未知";
            ViewBag.apiDate = "未知";
            ViewBag.status = "（可能还未创建）";
            string path = Server.MapPath("~/Content/doc/" + func + ".json");
            if (system != "" && module != "" && func != "")
            {
                path = Server.MapPath("~/Content/doc/" + system + "/" + module + "/" + func + ".json");
                ViewBag.address = httpProtocol + HttpContext.Request.Url.Host;
            }
            dynamic items = null;
            using (StreamReader r = new StreamReader(path))
            {
                items = JObject.Parse(r.ReadToEnd());
            }
            ViewBag.lms = items.lms;
            if (items.route != null)
            {
                string[] route = ((string)items.route).Split('/');
                ViewBag.address = ViewBag.address + Url.HttpRouteUrl("DefaultApi", new { action = route[2], controller = route[1], area = route[0] });
            }
            else ViewBag.address = ViewBag.address + Url.HttpRouteUrl("DefaultApi", new { action = func, controller = module, area = system });
            if (items.address != null) ViewBag.address = items.address;
            if (items.method != null) ViewBag.method = items.method;
            if (items.creator != null) ViewBag.creator = items.creator;
            if (items.title != null) ViewBag.func = items.title;
            FileInfo jsonFile = new FileInfo(path);
            if (jsonFile.Exists)
            {
                ViewBag.date = jsonFile.LastWriteTime.ToLocalTime();
                if (items.date != null)
                {
                    ViewBag.apiDate = items.date;
                    try
                    {
                        DateTime apiDate = TimeZoneInfo.ConvertTime(Convert.ToDateTime(items.date), TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"), TimeZoneInfo.Utc);
                        ViewBag.apiDate = apiDate.ToLocalTime();
                        if (ViewBag.apiDate > ViewBag.date) ViewBag.status = "（可能不是最新）";
                        else ViewBag.status = "（最新）";
                    }
                    catch
                    {
                        ViewBag.status = "（可能不是最新）";
                    }
                }
            }
            return View();
        }

        public ActionResult GetApiInfor(string system = "", string module = "", string func = standardName)
        {
            if (system == "" && module == "") return File(Server.MapPath("~/Content/doc/" + func + ".json"), "application/json");
            dynamic items = null;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Content/doc/" + system + "/" + module + "/" + func + ".json")))
            {
                items = JObject.Parse(r.ReadToEnd());
            }
            if (items.unique == null || !(bool)items.unique)
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Content/doc/" + standardName + ".json")))
                {
                    dynamic items2 = JObject.Parse(r.ReadToEnd());
                    items2.temp = items2;
                    if (items.inQuery != null) items2.inQuery.Merge(items.inQuery);
                    if (items.inHeader != null) items2.inHeader.Merge(items.inHeader);
                    if (items.inBody != null) items2.inBody = items.inBody;
                    if (items.outBody != null) items2.outBody.data = items.outBody;
                    else items2.outBody.Remove("data");
                    items = items2;
                }
            }
            return Content(JsonConvert.SerializeObject(items), "application/json");
        }

        private string Nav(string system = "", string module = "")
        {
            //额外列表
            string rst = "";
            if (system == "" && module == "") rst = rst + "<li class=\"layui-nav-item layui-nav-itemed\"><a href=\"" + Url.Action("List", "Doc") + "\">帮助文档</a></li>";
            else rst = rst + "<li class=\"layui-nav-item\"><a href=\"" + Url.Action("List", "Doc") + "\">帮助文档</a></li>";
            if (system == "WebService" && module == "") rst = rst + "<li class=\"layui-nav-item layui-nav-itemed\"><a href=\"" + Url.Action("WebService", "Doc") + "\">Web Service</a></li>";
            else rst = rst + "<li class=\"layui-nav-item\"><a href=\"" + Url.Action("WebService", "Doc") + "\">Web Service</a></li>";
            //Api列表
            DirectoryInfo TheFolder = new DirectoryInfo(Server.MapPath("~/Content/doc/"));
            foreach (DirectoryInfo SFolder in TheFolder.GetDirectories())
            {
                string childBlock = "";
                string layItemed = "";
                if (system == SFolder.Name) layItemed = "layui-nav-itemed";
                foreach (DirectoryInfo MFolder in SFolder.GetDirectories())
                {
                    string layThis = "";
                    if (module == MFolder.Name) layThis = "layui-this";
                    childBlock = childBlock
                               + "<dl class=\"layui-nav-child\">"
                               + "<dd class=\"" + layThis + "\"><a style=\"padding-left:35px\" href=\"List?system=" + SFolder.Name + "&module=" + MFolder.Name + "\">"
                               + MFolder.Name
                               + "</a></dd>"
                               + "</dl>";
                }
                childBlock = "<li class=\"layui-nav-item " + layItemed + "\">"
                           + "<a href=\"javascript:;\">" + SFolder.Name + "</a>"
                           + childBlock
                           + "</li>";
                rst = rst + childBlock;
            }
            return rst;
        }
    }
}
