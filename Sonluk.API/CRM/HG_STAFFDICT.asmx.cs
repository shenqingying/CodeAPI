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
    /// HG_STAFFDICT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_STAFFDICT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_HG_STAFFDICT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDICT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_STAFFDICT> ReadByParam(CRM_HG_STAFFDICT model, string ptoken)
        {
            List<CRM_HG_STAFFDICT> node = new List<CRM_HG_STAFFDICT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDICT.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int STAFFID, int DICID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDICT.Delete(STAFFID, DICID);
            }
            return -100;

        }












    }
}
