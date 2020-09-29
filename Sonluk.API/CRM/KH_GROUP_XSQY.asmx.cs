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
    /// KH_GROUP_XSQY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_GROUP_XSQY : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_KH_GROUP_XSQY model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_XSQY.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_KH_GROUP_XSQY model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_XSQY.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int XSQYID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_XSQY.Delete(XSQYID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_KH_GROUP_XSQY> Read(string ptoken)
        {
            List<CRM_KH_GROUP_XSQY> node = new List<CRM_KH_GROUP_XSQY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_XSQY.Read().ToList();
            }
            return node;

        }
    }
}
