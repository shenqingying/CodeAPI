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
    /// CRM_PENDING 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_PENDING : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<CRM_PENDING_SUMMARY> Read_Summary(int STAFFID,string ptoken)
        {
            List<CRM_PENDING_SUMMARY> node = new List<CRM_PENDING_SUMMARY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_PENDING.Read_Summary(STAFFID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_PENDING_DETAIL> Read_Detail(int STAFFID, int SummaryID,string ptoken)
        {
            List<CRM_PENDING_DETAIL> node = new List<CRM_PENDING_DETAIL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_PENDING.Read_Detail(STAFFID,SummaryID).ToList();
            }
            return node;
           
        }
    }
}
