using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.OA
{
    /// <summary>
    /// Flow 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/OA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Flow : System.Web.Services.WebService
    {
        OAModels models = new OAModels();
        RMSModels RMS_models = new RMSModels();


        [WebMethod]
        public bool Pull()
        {
            return models.Flow.Pull();
        }

        [WebMethod]
        public bool Push()
        {
            return models.Flow.Push();
        }

        [WebMethod]
        public List<FlowLogInfo> Log(string startDate, string endDate, string keyword)
        {
            return models.Flow.SyncLog(startDate, endDate, keyword).ToList();
        }


        //[WebMethod]
        //public List<OA_QJ_INFO> ReadFROMMAIN_1801(long ID,string ptoken)
        //{
        //    List<OA_QJ_INFO> node = new List<OA_QJ_INFO>();
        //    if (RMS_models.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return models.Flow.ReadFROMMAIN_1801(ID).ToList();
        //    }
        //    return node;
            
        //}

        //[WebMethod]
        //public int ReadOAFinishStatus(long ID, int OACSLB)
        //{
        //    return models.Flow.ReadOAFinishStatus(long.Parse("-730795971312267924"), 92);
        //}
    }
}
