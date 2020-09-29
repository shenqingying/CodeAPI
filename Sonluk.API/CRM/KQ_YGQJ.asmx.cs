using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// KQ_YGQJ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_YGQJ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KQ_YGQJ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_KQ_YGQJ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int YGQJID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.Delete(YGQJID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_KQ_YGQJList> ReadBySTAFFID(int STAFFID, int STATUS, string ptoken)
        {
            List<CRM_KQ_YGQJList> node = new List<CRM_KQ_YGQJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.ReadBySTAFFID(STAFFID, STATUS).ToList();
            }
            return node;

        }

        [WebMethod]
        public int Verify_QJ(string beginTime, string endTime, int STAFFID,int YGQJID, int CCID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.Verify_QJ(beginTime, endTime, STAFFID, YGQJID, CCID);
            }
            return -100;

        }
        [WebMethod]
        public CRM_KQ_YGQJ ReadByYGQJID(int YGQJID,string ptoken)
        {
            CRM_KQ_YGQJ node = new CRM_KQ_YGQJ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.ReadByYGQJID(YGQJID);
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KQ_YGQJList> ReadByDepartRight(CRM_KQ_YGQJ model, string ptoken)
        {
            List<CRM_KQ_YGQJList> node = new List<CRM_KQ_YGQJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.ReadByDepartRight(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KQ_YGQJList> Read(CRM_KQ_YGQJ model, string ptoken)
        {
            List<CRM_KQ_YGQJList> node = new List<CRM_KQ_YGQJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YGQJ.Read(model).ToList();
            }
            return node;
           
        }
    }
}
