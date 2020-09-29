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
    /// PRODUCT_HH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_HH : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_PRODUCT_HH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_HH.Create(model);
            }
            return -100;

        }

        [WebMethod]
        public int Update(CRM_PRODUCT_HH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_HH.Update(model);
            }
            return -100;

        }

        [WebMethod]
        public List<CRM_PRODUCT_HH> ReadByParam(CRM_PRODUCT_HH model, int STAFFID, string ptoken)
        {
            List<CRM_PRODUCT_HH> node = new List<CRM_PRODUCT_HH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_HH.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }

        [WebMethod]
        public int Delete(CRM_PRODUCT_HH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_HH.Delete(model);
            }
            return -100;

        }
    }
}
