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
    /// KH_XSYWJZ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_XSYWJZ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_XSYWJZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_XSYWJZ.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_KH_XSYWJZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_XSYWJZ.Update(model);
            }
            return -100;
        }
        [WebMethod]
        public int Delete(int XSYWJZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_XSYWJZ.Delete(XSYWJZID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_KH_XSYWJZList> ReadByKHID(int KHID, string ptoken)
        {
            List<CRM_KH_XSYWJZList> node = new List<CRM_KH_XSYWJZList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_XSYWJZ.ReadByKHID(KHID).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_KH_XSYWJZ ReadByID(int XSYWJZID, string ptoken)
        {
            CRM_KH_XSYWJZ node = new CRM_KH_XSYWJZ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_XSYWJZ.ReadByID(XSYWJZID);
            }
            return node;
        }


    }
}
