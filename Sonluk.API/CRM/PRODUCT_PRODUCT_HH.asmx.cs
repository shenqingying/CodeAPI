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
    /// PRODUCT_PRODUCT_HH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_PRODUCT_HH : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT_HH.Create(model);
            }
            return -100;

        }

        [WebMethod]
        public int Update(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT_HH.Update(model);
            }
            return -100;

        }

        [WebMethod]
        public List<CRM_PRODUCT_PRODUCT_HH> ReadByParam(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            List<CRM_PRODUCT_PRODUCT_HH> node = new List<CRM_PRODUCT_PRODUCT_HH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT_HH.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_PRODUCT_PRODUCT_HH> ReadByProNum(CRM_PRODUCT_PRODUCT_HH model, string ptoken)
        {
            List<CRM_PRODUCT_PRODUCT_HH> node = new List<CRM_PRODUCT_PRODUCT_HH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT_HH.ReadByProNum(model).ToList();
            }
            return node;

        }

        [WebMethod]
        public int Delete( int ID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_PRODUCT_HH.Delete(ID);
            }
            return -100;

        }
    }
}
