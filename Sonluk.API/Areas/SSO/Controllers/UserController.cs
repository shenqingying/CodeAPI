using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sonluk.API.Models;
using Sonluk.Entities.Account;
using System.Collections.Specialized;
using Sonluk.Utility.Security;
using Sonluk.Entities.Common;
using System.Text.RegularExpressions;

namespace Sonluk.API.Areas.SSO.Controllers
{
    public class UserController : ApiController
    {
        SSOModels models = new SSOModels();

        [HttpGet]
        public TokenInfo Token(string name, string password)
        {
            return models.User.Token(name, password);
        }

        [HttpPost]
        public TokenInfo Token()
        {
            string name = "";
            string password = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                name = values["name"].ToString();
                password = values["password"].ToString();

            }
            TokenInfo ti = models.User.Token(name, password);
            return ti;
        }


        [HttpGet]
        public AccountInfo AcceptToken(string ptoken)
        {
            return models.User.AcceptToken(ptoken);
        }

        [HttpPost]
        public AccountInfo AcceptToken()
        {
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                ptoken = values["ptoken"].ToString();
            }
            AccountInfo ti = models.User.AcceptToken(ptoken);
            return ti;
        }


        [HttpGet]
        public Boolean ValidateToken(string ptoken)
        {
            return models.User.ValidateToken(ptoken);
        }

        [HttpPost]
        public Boolean ValidateToken()
        {
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                ptoken = values["ptoken"].ToString();
            }
            Boolean ti = models.User.ValidateToken(ptoken);
            return ti;
        }

        [HttpGet]
        public MenuInfo Menu(string ptoken, string parent)
        {
            MenuInfo ti = new MenuInfo();
            AccountInfo ac = models.User.AcceptToken(ptoken);
            //ti.ID = Convert.ToInt32(ac.SN);
            ti = models.Authorization.Menu(Convert.ToInt32(ac.SN), Convert.ToInt32(parent));
            return ti;
        }

        [HttpPost]
        public MenuInfo Menu()
        {
            string ptoken = "";
            string parent = "";
            //int USN;
            //int parent;

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                ptoken = values["ptoken"].ToString();
                parent = values["parent"].ToString();
            }
            AccountInfo ac = models.User.AcceptToken(ptoken);
            MenuInfo ti = models.Authorization.Menu(Convert.ToInt32(ac.SN), Convert.ToInt32(parent));
            return ti;
        }

        [HttpPost]
        public ErrorInfo ChangePassword()
        {
            string ptoken = "";
            string passwordHash = "";
            string newPasswordHash = "";
            ErrorInfo rtn = new ErrorInfo();

            try
            {
                if (Request.Content.IsFormData())
                {
                    NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                    ptoken = values["ptoken"].ToString();
                    passwordHash = values["passwordHash"].ToString();
                    newPasswordHash = values["newPasswordHash"].ToString();
                }
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = false;
                result = Regex.IsMatch(newPasswordHash, pattern);
                if (newPasswordHash.Length < 8)
                {
                    rtn.Errcode = "-1";
                    rtn.Errmsg = "密码长度必须大于8位";
                }
                else if (result == false)
                {
                    rtn.Errcode = "-1";
                    rtn.Errmsg = "密码至少需数字和字符串组合";
                }
                else
                {
                    AccountInfo ac = models.User.AcceptToken(ptoken);
                    passwordHash = MD5Hash.GetMd5Hash(passwordHash).ToUpper();
                    newPasswordHash = MD5Hash.GetMd5Hash(newPasswordHash).ToUpper();
                    Boolean ti = models.User.ChangePassword(ac.SN, passwordHash, newPasswordHash);

                    if (ti)
                    {
                        rtn.Errcode = "1";
                        rtn.Errmsg = "密码修改成功！";
                    }
                    else
                    {
                        rtn.Errcode = "-1";
                        rtn.Errmsg = "密码修改失败！";
                    }
                }
            }
            catch (Exception e)
            {
                rtn.Errcode = "-1";
                rtn.Errmsg = e.Message;
            }
            return rtn;
        }

        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
