using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MSG;
using Sonluk.Entities.WX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// WX_OPENID 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WX_OPENID : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MSGModels msgmodels = new MSGModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_WX_OPENID model, string USE, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.Create(model, USE);
            }
            return -100;




        }
        [WebMethod]
        public int Update(CRM_WX_OPENID model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByID(int ID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.DeleteByID(ID);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(CRM_WX_OPENID model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.Delete(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_WX_OPENID> ReadByParam(CRM_WX_OPENID model, string ptoken)
        {
            List<CRM_WX_OPENID> node = new List<CRM_WX_OPENID>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_WX_OPENIDList> ReadBySTAFFParam(CRM_WX_OPENIDList model, string ptoken)
        {
            List<CRM_WX_OPENIDList> node = new List<CRM_WX_OPENIDList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.ReadBySTAFFParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_WX_OPENIDList> ReadByORDERTTID(int ORDERTTID, string ptoken)
        {
            List<CRM_WX_OPENIDList> node = new List<CRM_WX_OPENIDList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.ReadByORDERTTID(ORDERTTID).ToList();
            }
            return node;
        }
        [WebMethod]
        public string code2session(string APPID, string SECRET, string JSCODE, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.WX_OPENID.code2session(APPID, SECRET, JSCODE);
            }
            return "";
        }
        [WebMethod]
        public WX_MSG_RETURN SendMSG(int STAFFID, WX_MSG wxmsg, string SYS, string TYPE)
        {
            WX_MSG_RETURN model = new WX_MSG_RETURN();
            if (SYS == "AppID")
            {
                string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"]; //微信id
                string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];  //微信secret
                model = models.WX_OPENID.SendMSG(STAFFID, wxmsg, SYS, AppID, AppSecret, 0, TYPE);
            }
            else if (SYS == "CorpID")
            {
                int Agentid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Agentid"]);
                string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"]; //企业微信id
                string secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];  //企业微信号appsecret
                model = models.WX_OPENID.SendMSG(STAFFID, wxmsg, SYS, CorpID, secret, Agentid, "");
            }
            else
            {
                model.errcode = "-1";
                model.errmsg = "API default";
            }

            return model;
        }
        
        [WebMethod]
        public WX_MSG_RETURN SendMSGFromTemp()
        {
            MSG_SEND_INFO cxmodel = new MSG_SEND_INFO();
            cxmodel.SUCCESS = 0;
            cxmodel.ISACTIVE = 1;
            IList<MSG_SEND_INFO> data = msgmodels.SEND_INFO.ReadByParam(cxmodel);

            WX_MSG_RETURN MSG_RETURN = new WX_MSG_RETURN();
            MSG_RETURN.errcode = "0";
            MSG_RETURN.errmsg = "执行成功";

            for (int i = 0; i < data.Count; i++)
            {
                WX_MSG_RETURN temp = new WX_MSG_RETURN();
                if (data[i].SENDWAYSIGN == 2374)
                {
                    string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"]; //微信id
                    string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];  //微信secret
                    temp = models.WX_OPENID.SendMSGFromTemp(data[i],AppID, AppSecret);
                }
                else if (data[i].SENDWAYSIGN == 2375)
                {
                    int Agentid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Agentid"]);
                    string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"]; //企业微信id
                    string secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];  //企业微信号appsecret
                    temp = models.WX_OPENID.SendMSGFromTemp(data[i], CorpID, secret);
                }
                if (temp.errcode != "0")
                {
                    MSG_RETURN = temp;
                }
            }

            return MSG_RETURN;
        }



    }
}
