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
    /// PRODUCT_PRODUCT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_PRODUCT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int PRODUCTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.Delete(PRODUCTID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_PRODUCT_PRODUCT> ReadByParam(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            List<CRM_PRODUCT_PRODUCT> node = new List<CRM_PRODUCT_PRODUCT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_PRODUCT_PRODUCT ReadByID(int PRODUCTID, string ptoken)
        {
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.ReadByID(PRODUCTID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_PRODUCT_PRODUCT> ReadByRight(int KHID, string SDF, int CPLX, int ORDERTTID, string CPMC, string ptoken)
        {
            List<CRM_PRODUCT_PRODUCT> node = new List<CRM_PRODUCT_PRODUCT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.ReadByRight(KHID,SDF, CPLX, ORDERTTID, CPMC).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_PRODUCT_PRODUCT> ReadCPLXByRight(int KHID, string ptoken)
        {
            List<CRM_PRODUCT_PRODUCT> node = new List<CRM_PRODUCT_PRODUCT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT.ReadCPLXByRight(KHID).ToList();
            }
            return node;
        }


    }
}
