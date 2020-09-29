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
    /// COST_LKAYEARLIST 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAYEARLIST : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAYEARLIST> ReadByParam(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            List<CRM_COST_LKAYEARLIST> node = new List<CRM_COST_LKAYEARLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int LISTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.Delete(LISTID);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateByTTID(int LKAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.UpdateByTTID(LKAYEARTTID);
            }
            return -100;
        }
        [WebMethod]
        public int DeleteByTTID(int LKAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.DeleteByTTID(LKAYEARTTID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAYEARLIST> ReadListByKHID(int KHID, string YEAR, string ptoken)
        {
            List<CRM_COST_LKAYEARLIST> node = new List<CRM_COST_LKAYEARLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARLIST.ReadListByKHID(KHID, YEAR).ToList();
            }
            return node;
        }
    }
}
