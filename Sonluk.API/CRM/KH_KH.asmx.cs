using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// KH_KH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_KH : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        SSOModels tokenModels = new SSOModels();
        private static string user = "00137";
        private static string pwd = "123";
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_KH_KH KH_S, string ptoken)
        {

            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Create(KH_S);
            }
            return -100;
        }
        [WebMethod]
        public int Update(CRM_KH_KH KH_S, string ptoken, bool isKHID)
        {

            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Update(KH_S, isKHID);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateSFCS(CRM_KH_KH KH, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.UpdateSFCS(KH);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_KH_KH> ReadByParmas(CRM_KH_KH keywords, string ptoken)
        {
            List<CRM_KH_KH> node = new List<CRM_KH_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Read(keywords).ToList();
            }
            return node;


        }
        [WebMethod]
        public CRM_KH_KHList ReadByID(int KHID, string ptoken)
        {
            CRM_KH_KHList node = new CRM_KH_KHList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Read(KHID);
            }
            return node;



        }
        [WebMethod]
        public int Delete(int KHID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Delete(KHID);
            }
            return -100;




        }
        [WebMethod]
        public List<CRM_KH_KHList> Report(CRM_Report_KHModel model, int STAFFID, string ptoken)
        {
            List<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            //TokenInfo tokeninfo = tokenModels.User.Token(user, pwd);
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Report(model, STAFFID).ToList();
            }
            return nodes;
        }
        [WebMethod]
        public List<CRM_KH_KHList> Report_PLUS(CRM_Report_KHModel model, int STAFFID, string ptoken)
        {
            List<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            //TokenInfo tokeninfo = tokenModels.User.Token(user, pwd);
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Report_PLUS(model, STAFFID).ToList();
            }
            return nodes;
        }
        [WebMethod]
        public List<CRM_KH_KH_Report_ZDWDList> Report_ZDWD(CRM_KH_KH_Report_ZDWD model, int STAFFID, string ptoken)
        {
            List<CRM_KH_KH_Report_ZDWDList> nodes = new List<CRM_KH_KH_Report_ZDWDList>();
            //TokenInfo tokeninfo = tokenModels.User.Token(user, pwd);
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Report_ZDWD(model, STAFFID).ToList();
            }
            return nodes;
        }
        [WebMethod]
        public List<CRM_KH_KH_Report_LKAList> Report_LKA(CRM_KH_KH_Report_LKA model, int STAFFID, int RightOn, string ptoken)
        {
            List<CRM_KH_KH_Report_LKAList> nodes = new List<CRM_KH_KH_Report_LKAList>();
            //TokenInfo tokeninfo = tokenModels.User.Token(user, pwd);
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Report_LKA(model, STAFFID, RightOn).ToList();
            }
            return nodes;
        }

        //[WebMethod]
        //public bool isSuccess(string u,string p)
        //{
        //    TokenInfo tokeninfo = tokenModels.User.Token(u, p);
        //    return tokenModels.User.ValidateToken(tokeninfo.access_token);
        //}
        [WebMethod]
        public List<string> ReadXSZZ(string ptoken)
        {
            List<string> node = new List<string>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadXSZZ().ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_KH_BankList> Blank_Report(int SFID, int CSID, string ptoken)
        {
            List<CRM_KH_BankList> node = new List<CRM_KH_BankList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.Blank_Report(SFID, CSID).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_KH_KH ReadByCRMID(string CRMID, string ptoken)
        {
            CRM_KH_KH node = new CRM_KH_KH();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadByCRMID(CRMID);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_KH_KH_INFO> ReadBF_KHList(CRM_KH_KH_PARAM model, string ptoken)
        {
            List<CRM_KH_KH_INFO> node = new List<CRM_KH_KH_INFO>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadBF_KHList(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<SAP_KH> ReadKHForSap(int STAFFID, string ptoken)
        {
            List<SAP_KH> node = new List<SAP_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadKHForSap(STAFFID).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KH_KHList> ReadBySTAFFID(int STAFFID, string ptoken)
        {
            List<CRM_KH_KHList> node = new List<CRM_KH_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_KH_KH ReadJXSByKHID(int KHID, string ptoken)
        {
            CRM_KH_KH node = new CRM_KH_KH();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadJXSByKHID(KHID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KH_KH> ReadByJXS(CRM_KH_KH model, string ptoken)
        {
            List<CRM_KH_KH> node = new List<CRM_KH_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadByJXS(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KH_KHList> ReadUser_KH(CRM_Report_KHModel model, string ptoken)
        {
            List<CRM_KH_KHList> node = new List<CRM_KH_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadUser_KH(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KH_KH> ReadSDFbyPKH(string SAPSN, string ptoken)
        {
            List<CRM_KH_KH> node = new List<CRM_KH_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadSDFbyPKH(SAPSN).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_KH_KH ReadBySAPSN(string SAPSN, string ptoken)
        {
            CRM_KH_KH node = new CRM_KH_KH();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadBySAPSN(SAPSN);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KH_KHList> ReadKHAcount(CRM_Report_KHModel model, string ptoken)
        {
            List<CRM_KH_KHList> node = new List<CRM_KH_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KH.ReadKHAcount(model).ToList();
            }
            return node;
        }

    }
}
