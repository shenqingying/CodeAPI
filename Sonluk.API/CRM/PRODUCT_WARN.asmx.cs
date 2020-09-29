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
    /// PRODUCT_WARN 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_WARN : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_PRODUCT_WARN model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_PRODUCT_WARN model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int PROWARNID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.Delete(PROWARNID);
            }
            return -100;

        }
        [WebMethod]
        public CRM_PRODUCT_WARN ReadByID(int PROWARNID, string ptoken)
        {
            CRM_PRODUCT_WARN node = new CRM_PRODUCT_WARN();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.ReadByID(PROWARNID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_PRODUCT_WARN> ReadByParam(CRM_PRODUCT_WARN model, string ptoken)
        {
            List<CRM_PRODUCT_WARN> node = new List<CRM_PRODUCT_WARN>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_PRODUCT_WARN> ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID, string ptoken)
        {
            List<CRM_PRODUCT_WARN> node = new List<CRM_PRODUCT_WARN>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_WARN.ReadByKHIDandPRODUCTID(KHID, PRODUCTID).ToList();
            }
            return node;
        }


    }
}
