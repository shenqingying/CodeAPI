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
    /// COST_PUBLIC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
 public class COST_PUBLIC : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<CRM_COST_PUBLIC> ReadByPublic(CRM_COST_HXZLTT MODEL, CRM_COST_ZZFTT MODEL_JXS, CRM_COST_ZZFTT MODEL_KA, CRM_COST_ZZFTT MODEL_LKA, CRM_COST_ZZFTT MODEL_ZDWD, int STAFFID, string ptoken)
        {
            List<CRM_COST_PUBLIC> node = new List<CRM_COST_PUBLIC>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_PUBLIC.ReadByPublic(MODEL, MODEL_JXS, MODEL_KA, MODEL_LKA,MODEL_ZDWD, STAFFID).ToList();
            }
            return node;

        }
       
    }
}
