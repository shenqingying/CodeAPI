using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.BusinessLogic;
using Sonluk.API.Models;
using Sonluk.Entities.CRM;
namespace Sonluk.API.CRM
{
    /// <summary>
    /// CRM_KH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_KH : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //[WebMethod]
        //public DataTable test()
        //{
            
        //    return models.CRM_KH.GetJL_MeasureTypedes();
        //}
        [WebMethod]
        public List<UserModel> UserName()
        {
            return models.CRM_KH.GetUser().ToList();
        }
        

        [WebMethod]

        public int InsertKH_KH(CRM_KH_KH KH_S)
        {
            return models.CRM_KH.InsertKH_KH(KH_S);
        }
        [WebMethod]

        public List<CRM_KH_KH> SelectKH_KH(string id)
        {
            return null;
        }
        [WebMethod]
        public string SelectKH_KHForKHLXandMC(int KHLX, string mc,int MCLC)
        {
            return models.CRM_KH.SelectKH_KHForKHLXandMC(KHLX, mc, MCLC);
        }
        [WebMethod]
        public int ModifyKH_KH(CRM_KH_KH KH_S)
        {
            return models.CRM_KH.ModifyKH_KH(KH_S);
        }
        [WebMethod]
        public string SelectReportWithReportModel(CRM_Report_KHModel model)
        {
            return models.CRM_KH.SelectKHReportWithReportModel(model);
        }

        [WebMethod]
        public int InsertCRM_KH_GXQY(CRM_KH_GXQY model)
        {
            return models.CRM_KH.InsertCRM_KH_GXQY(model);
        }
        [WebMethod]
        public int InsertCRM_KH_LXR(CRM_KH_LXR model)
        {
            return models.CRM_KH.InsertCRM_KH_LXR(model);
        }
        [WebMethod]
        public int InsertKH_KHQTXX(CRM_KH_KHQTXX model)
        {
            return models.CRM_KH.InsertKH_KHQTXX(model);
        }

        [WebMethod]
        public DataTable SelectKH_KHForKHID(int KHID)
        {
            return models.CRM_KH.SelectKH_KHForKHID(KHID);
        }
        [WebMethod]
        public int InsertClXX(CRM_KH_KHQTXX model, int GSDX, string ml)
        {
            return models.CRM_KH.InsertClXX(model, GSDX, ml);
        }
        [WebMethod]
        public string SelectKH_KHQTXX(int KHID, int XXLB, int ISACTIVE)
        {
            return models.CRM_KH.SelectKH_KHQTXX(KHID, XXLB, ISACTIVE);
        }
       
    }
}
