using Newtonsoft.Json;
using Sonluk.API.Models;
using Sonluk.BusinessLogic.Helper;
using Sonluk.Entities.Account;
using Sonluk.Entities.API;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sonluk.API.Areas
{
    /// <summary>
    /// 设置项
    /// </summary>
    public static class ApiConfig
    {
        public static string AuthorName = DESE.Decrypt(ConfigurationManager.AppSettings["ApiAuthorName"], key);
        public static string AuthorKey = DESE.Decrypt(ConfigurationManager.AppSettings["ApiAuthorKey"], key);
        private const string key = "Sl20200410";
    }


    /// <summary>
    /// 验证模块
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        delegate void ErrorReturn(HttpActionContext actionContext);

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //设置初始值（角色为空，不允许匿名）
            if (Roles == null) Roles = "";
            bool pass = false;
            ErrorReturn ERA = (a) => { };
            ErrorReturn ERNA = (a) => { };
            Helper_Insights_ApiRequest apiRequestInsights = new Helper_Insights_ApiRequest()
            {
                ID = Convert.ToInt64(actionContext.ControllerContext.Request.Headers.GetValues("Sonluk-ApiRequestInsightsID").Last()),
                ApiName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName.Split('.')[3] + "." + actionContext.ActionDescriptor.ControllerDescriptor.ControllerName + "." + actionContext.ActionDescriptor.ActionName
            };

            //获取请求中的待验证项目
            var authorization = actionContext.Request.Headers.Authorization;//验证头
            string ptokenUrl = ApiReceive.GetQueryToken(actionContext.Request.RequestUri.Query);//地址栏token

            //判断角色并验证
            switch (Roles)
            {
                case "no":
                    pass = true;
                    break;
                case "server":
                    if ((authorization != null) && (authorization.Parameter != null)) if (AuthorHelper.Valid(authorization.Parameter, ApiConfig.AuthorKey) && ApiReceive.GetResult(ptokenUrl)) pass = true;
                    break;
                default:
                    if (ApiReceive.GetResult(ptokenUrl))
                    {
                        apiRequestInsights.StaffID = ApiReceive.GetStaffID(ptokenUrl);
                        pass = true;
                    }
                    else
                    {
                        ERA = (a) =>
                        {
                            a.Response.Content = new StringContent(JsonConvert.SerializeObject(ApiResponse.SingleMsg("00002")));
                            a.Response.StatusCode = HttpStatusCode.OK;
                        };
                    }
                    break;
            }

            //执行验证结果
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                //如果允许匿名访问，则直接调用Api
                apiRequestInsights.Access = "anonymous";
                base.OnAuthorization(actionContext);
            }
            else
            {
                //如果不允许匿名访问，并且验证成功，则调用Api
                if (pass)
                {
                    apiRequestInsights.Access = "passed";
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    apiRequestInsights.Access = "denied";
                    HandleUnauthorizedRequest(actionContext);
                    ERA(actionContext);
                }
            }
            ApiReceive.UpdateInsights(apiRequestInsights);
        }
    }


    /// <summary>
    /// 内容补充模块
    /// </summary>
    public class ApiReturnAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<CustomReturnAttribute>().Any())
            {
                //如果存在[CustomReturn]，则不进行Code翻译操作
            }
            else
            {
                //日志记录初始化
                Helper_Insights_ApiRequest apiRequestInsights = new Helper_Insights_ApiRequest()
                {
                    ID = Convert.ToInt64(actionExecutedContext.Request.Headers.GetValues("Sonluk-ApiRequestInsightsID").Last()),
                    Status = "success",
                    ErrorTag = ""
                };
                if (actionExecutedContext.ActionContext.Response != null && actionExecutedContext.ActionContext.Response.IsSuccessStatusCode)
                {
                    string ptoken = ApiReceive.GetQueryToken(actionExecutedContext.Request.RequestUri.Query);
                    ApiReturn data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<ApiReturn>().Result;
                    if (data.type == null) data.type = "S";
                    if (data.messages != null)
                    {
                        foreach (ApiMessage item in data.messages)
                        {
                            ApiMessage msg = ApiResponse.Msg(item.code, ApiReceive.GetLanguageID(ptoken));
                            string traceMsg = "";
                            data.type = ApiReturn.TopType(data.type, msg.type);
                            if (msg.type != "X") item.type = msg.type;
                            item.message = msg.message;
                            if (item.supply != null && item.supply.Length > 0)
                            {
                                if (MessageSelector.TraceMessage().Contains(item, new MessageSelector.MessageComparer()))
                                {
                                    apiRequestInsights.ErrorTag = apiRequestInsights.ErrorTag + "|" + item.code;
                                    traceMsg = ", Detail:" + item.supply[0].ToString();
                                    item.supply[0] = apiRequestInsights.ID;
                                }
                                item.message = string.Format(item.message, item.supply);
                                item.supply = null;
                            }
                            ApiReceive.CreateInsightsErrorMsg(new Helper_Insights_ApiRequest_ErrorMsg()
                            {
                                AID = apiRequestInsights.ID,
                                Code = item.code,
                                Type = item.type,
                                Message = item.message + traceMsg
                            });
                        }
                    }
                    data.success = ApiReturn.TypeValid(data.type);
                    if (!data.success) apiRequestInsights.ErrorTag = data.type + apiRequestInsights.ErrorTag;
                    ApiReceive.UpdateInsights(apiRequestInsights);
                }
            }
        }
    }
    public class CustomReturnAttribute : ActionFilterAttribute { }


    /// <summary>
    /// 跨域请求模块
    /// </summary>
    public class CORSModule : IHttpModule
    {
        public CORSModule() { }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(this.BeginRequest);
            app.EndRequest += new EventHandler(this.EndRequest);
        }

        public void Dispose() { }

        public void BeginRequest(object resource, EventArgs e)
        {
            HttpApplication app = (HttpApplication)resource;
            app.Request.Headers.Add("Sonluk-ApiRequestInsightsID", "0");

            //跨域请求
            HttpContext context = app.Context;
            context.Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS,POST,GET");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type," + ApiConfig.AuthorName);
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (context.Request.HttpMethod.ToUpper() == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                context.Response.End();
            }

            //Token通用化
            string ptokenUrl = ApiReceive.GetQueryToken(app.Request.Url.Query);
            string ptokenHeader = app.Request.Headers[ApiConfig.AuthorName] ?? "";
            if (ptokenUrl != "") app.Request.Headers.Add(ApiConfig.AuthorName, ptokenUrl);
            else if (ptokenHeader != "")
            {
                if (app.Request.Url.Query == "") app.Context.RewritePath(app.Request.Path, "", "ptoken=" + ptokenHeader + "&");
                else app.Context.RewritePath(app.Request.Path, "", app.Request.Url.Query.Replace("?", "ptoken=" + ptokenHeader + "&"));
            }

            //API日志记录（登陆前）
            string[] requestPath = app.Request.Path.Split('/');
            if ((requestPath.Contains("api") || requestPath.Contains("Api") || requestPath.Contains("API")) && requestPath.Length > 3)
            {
                Helper_Insights_ApiRequest helper_Insights_ApiRequest = new Helper_Insights_ApiRequest()
                {
                    ApiAdress = app.Request.Path,
                    Operation = app.Request.HttpMethod,
                    Host = ApiReceive.GetHostAdress(),
                    Client = app.Request.UserHostAddress,
                    Content = new StreamReader(app.Request.InputStream).ReadToEnd(),
                    Access = "anonymous",
                    Status = "in progress",
                };
                app.Request.InputStream.Position = 0;//恢复InputStream的读取位置
                ApiReturn<long> insightsRst = (ApiReturn<long>)ApiReceive.CreateInsights(helper_Insights_ApiRequest);
                if (insightsRst.success) app.Request.Headers.Add("Sonluk-ApiRequestInsightsID", insightsRst.data.ToString());
            }
        }

        public void EndRequest(object resource, EventArgs e)
        {
            HttpApplication app = (HttpApplication)resource;

            //API日志记录（响应后）
            string[] apiRequestInsightsID = app.Request.Headers.GetValues("Sonluk-ApiRequestInsightsID");
            Helper_Insights_ApiRequest helper_Insights_ApiRequest = new Helper_Insights_ApiRequest()
            {
                ID = Convert.ToInt64(apiRequestInsightsID[apiRequestInsightsID.Length - 1])
            };
            if (app.Response.StatusCode == 200)
            {
                helper_Insights_ApiRequest.Status = "success";
            }
            else
            {
                helper_Insights_ApiRequest.Status = "error";
                helper_Insights_ApiRequest.ErrorTag = app.Response.StatusCode.ToString();
                if (helper_Insights_ApiRequest.ID != 0)
                {
                    ApiReceive.CreateInsightsErrorMsg(new Helper_Insights_ApiRequest_ErrorMsg()
                    {
                        AID = helper_Insights_ApiRequest.ID,
                        Code = app.Response.StatusCode.ToString(),
                        Type = "E",
                        Message = app.Response.StatusDescription.ToString()
                    });
                }
            }
            ApiReceive.UpdateInsights(helper_Insights_ApiRequest);
        }
    }


    /// <summary>
    /// Api接收工具模块
    /// </summary>
    public static class ApiReceive
    {
        private static RMSModels rmsmodel = new RMSModels();
        private static HelperModels helpermodel = new HelperModels();

        /// <summary>
        /// 获取验证结果
        /// </summary>
        /// <param name="ptoken">需要验证的ptoken</param>
        /// <returns></returns>
        public static bool GetResult(string ptoken)
        {
            FullTokenInfo token = rmsmodel.CRM_Login.ReadFullToken(ptoken);
            return token.Valid;
        }

        /// <summary>
        /// 获取Token中的语言
        /// </summary>
        /// <param name="ptoken">需要验证的ptoken</param>
        /// <returns></returns>
        public static int GetLanguageID(string ptoken)
        {
            FullTokenInfo token = rmsmodel.CRM_Login.ReadFullToken(ptoken);
            return token.LanguageID;
        }

        /// <summary>
        /// 获取STAFFID，返回0则表示未找到（可视为无效的ptoken）
        /// </summary>
        /// <param name="ptoken">需要验证的ptoken</param>
        /// <returns></returns>
        public static int GetStaffID(string ptoken)
        {
            FullTokenInfo token = rmsmodel.CRM_Login.ReadFullToken(ptoken);
            if (token.Valid) return token.StaffID;
            else return 0;
        }

        /// <summary>
        /// 获取地址栏中的Token
        /// </summary>
        /// <param name="query">地址栏的参数部分字符串（带问号）</param>
        /// <returns></returns>
        public static string GetQueryToken(string query)
        {
            if (query.Split('?').Length > 1) query = query.Split('?')[1];
            string[] queryParams = query.Split('&');
            for (int i = 0; i < queryParams.Length; i++)
            {
                string[] queryParam = queryParams[i].Split('=');
                if (queryParam[0] == "ptoken" && queryParam.Length == 2)
                {
                    return queryParams[i].Split('=')[1];
                }
            }
            return "";
        }

        /// <summary>
        /// 获取地址栏中的Token
        /// </summary>
        /// <param name="current">当前Http请求</param>
        /// <returns></returns>
        public static string GetQueryToken(HttpContext current)
        {
            return ApiReceive.GetQueryToken(current.Request.Url.Query);
        }

        /// <summary>
        /// 获取上传的文件
        /// </summary>
        /// <param name="current">当前Http请求</param>
        /// <returns></returns>
        public static HttpPostedFile File(string name)
        {
            return HttpContext.Current.Request.Files[name];
        }

        /// <summary>
        /// 插入API访问信息
        /// </summary>
        /// <param name="model">API访问信息类</param>
        /// <returns></returns>
        public static ApiReturn CreateInsights(Helper_Insights_ApiRequest model)
        {
            return helpermodel.Insights.CreateApiRequest(model);
        }

        /// <summary>
        /// 更新API访问信息
        /// </summary>
        /// <param name="model">API访问信息类</param>
        /// <returns></returns>
        public static ApiReturn UpdateInsights(Helper_Insights_ApiRequest model)
        {
            return helpermodel.Insights.UpdateApiRequest(model);
        }

        /// <summary>
        /// 插入API访问错误消息
        /// </summary>
        /// <param name="model">API访问信息类</param>
        /// <returns></returns>
        public static ApiReturn CreateInsightsErrorMsg(Helper_Insights_ApiRequest_ErrorMsg model)
        {
            return helpermodel.Insights.CreateApiRequestErrorMsg(model);
        }

        /// <summary>
        /// 获取服务器地址
        /// </summary>
        /// <returns></returns>
        public static string GetHostAdress()
        {
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return _IPAddress.ToString();
                }
            }
            return "";
        }
    }


    /// <summary>
    /// Api响应工具模块
    /// </summary>
    public static class ApiResponse
    {
        /// <summary>
        /// 返回用于下载的文件流
        /// </summary>
        /// <param name="success">返回成功或失败响应</param>
        /// <param name="path">下载绝对路径</param>
        /// <param name="name">下载文件名（包含扩展名）</param>
        /// <returns></returns>
        public static HttpResponseMessage Download(bool success, string path, string name)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (success)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    response.Content = new StreamContent(fs);
                }
                File.Delete(path);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = name;
            }
            return response;
        }

        /// <summary>
        /// 根据预定编号返回单条消息
        /// </summary>
        /// <param name="code">消息编号</param>
        /// <param name="lang">语言编号（默认为0，中文）</param>
        /// <returns></returns>
        public static ApiReturn SingleMsg(string code, int lang = 0)
        {
            ApiReturn rst = new ApiReturn();
            rst.messages = new List<ApiMessage>();
            rst.messages.Add(MessageSelector.ReadMessage(code, lang));
            rst.type = rst.messages[0].type;
            rst.success = ApiReturn.TypeValid(rst.type);
            return rst;
        }

        /// <summary>
        /// 获取预定编号的消息
        /// </summary>
        /// <param name="code">消息编号</param>
        /// <param name="lang">语言编号（默认为0，中文）</param>
        /// <returns></returns>
        public static ApiMessage Msg(string code, int lang = 0)
        {
            return MessageSelector.ReadMessage(code, lang);
        }
    }
}
