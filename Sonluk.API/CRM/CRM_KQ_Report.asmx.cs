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
    /// CRM_KQ_Report 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_KQ_Report : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]

        public List<CRM_KQ_COLLECTList> CRM_KQ_REPORT_SUMMARY(int STAFFID, int DEPID, int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime, int OnlyQQ, string ptoken)
        {
            List<CRM_KQ_COLLECTList> node = new List<CRM_KQ_COLLECTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_REPORT_SUMMARY(STAFFID,STAFFLX, STAFFNAME, STAFFNO, beginTime, endTime, DEPID, OnlyQQ).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_KQ_YGQJList> CRM_KQ_Detail_QJ(int STAFFID, string Begintime, string Endtime, string ptoken)
        {
            List<CRM_KQ_YGQJList> node = new List<CRM_KQ_YGQJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_Detail_QJ(STAFFID, Begintime, Endtime).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KQ_CCTTList> CRM_KQ_Detail_CC(int STAFFID, string Begintime, string Endtime, string ptoken)
        {
            List<CRM_KQ_CCTTList> node = new List<CRM_KQ_CCTTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_Detail_CC(STAFFID, Begintime, Endtime).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_KQ_YCKQSM> CRM_KQ_Detail_YC(int STAFFID, string Begintime, string Endtime, string ptoken)
        {
            List<CRM_KQ_YCKQSM> node = new List<CRM_KQ_YCKQSM>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_Detail_YC(STAFFID, Begintime, Endtime).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_KQ_QDList> CRM_KQ_Detail_QD(int STAFFID, string Begintime, string Endtime, string ptoken)
        {
            List<CRM_KQ_QDList> node = new List<CRM_KQ_QDList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_Detail_QD(STAFFID, Begintime, Endtime).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_KQ_QQList> CRM_KQ_Detail_QQ(int STAFFID, string Begintime, string Endtime, string ptoken)
        {
            List<CRM_KQ_QQList> node = new List<CRM_KQ_QQList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_KQ_Report.CRM_KQ_Detail_QQ(STAFFID, Begintime, Endtime).ToList();
            }
            return node;
           
        }
    }
}
