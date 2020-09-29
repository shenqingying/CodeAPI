using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// BF_BF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BF_BF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create_BFDJ(CRM_BF_BFDJ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Create_BFDJ(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update_BFDJ(CRM_BF_BFDJ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Update_BFDJ(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete_BFDJ(int BFDJID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Delete_BFDJ(BFDJID);
            }
            return -100;

        }
        [WebMethod]

        public int Create_BFJH(CRM_BF_BFJH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Create_BFJH(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update_BFJH(CRM_BF_BFJH model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Update_BFJH(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete_BFJH(int BFJHID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Delete_BFJH(BFJHID);
            }
            return -100;

        }
        //[WebMethod]
        //public List<CRM_BF_BFJHList> Report_BFJH(CRM_BF_BFJH model, string ptoken)
        //{
        //    List<CRM_BF_BFJHList> node = new List<CRM_BF_BFJHList>();
        //    if (models.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return models.BF_BF.Report_BFJH(model).ToList();
        //    }
        //    return node;
        //}
        [WebMethod]
        public List<CRM_BF_STAFFList> Report_STAFF(CRM_BF_STAFFList model, string ptoken)
        {

            List<CRM_BF_STAFFList> node = new List<CRM_BF_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Report_STAFF(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BF_KHList> Report_KH(CRM_BF_KHList model, string ptoken)
        {
            List<CRM_BF_KHList> node = new List<CRM_BF_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Report_KH(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_BF_BFDJList> Report_BFDJ(CRM_BF_BFDJList model, string ptoken)
        {
            List<CRM_BF_BFDJList> node = new List<CRM_BF_BFDJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Report(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public CRM_BF_BFDJ ReadByBFDJID(int BFDJID, string ptoken)
        {
            CRM_BF_BFDJ node = new CRM_BF_BFDJ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadByBFDJID(BFDJID);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_BF_REPORTSUMMARY> Report_Summary(CRM_BF_ReportParam model, string ptoken)
        {
            List<CRM_BF_REPORTSUMMARY> node = new List<CRM_BF_REPORTSUMMARY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Report_Summary(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_BF_REPORTDETAIL> Report_Detail(CRM_BF_ReportParam model, string ptoken)
        {
            List<CRM_BF_REPORTDETAIL> node = new List<CRM_BF_REPORTDETAIL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Report_Detail(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_BF_BFJHList> ReadByParams(int BFLX, string BFJHMC, string FROMDATE, string TODATE, int STAFFID, string ptoken)
        {
            List<CRM_BF_BFJHList> node = new List<CRM_BF_BFJHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Read_BFJHByParams(BFLX, BFJHMC, FROMDATE, TODATE,STAFFID).ToList();
            }
            return node;
            
        }

       [WebMethod]
        public CRM_BF_BFJH Read_BFJDByID(int BFJHID,string ptoken)
        {
            CRM_BF_BFJH node = new CRM_BF_BFJH();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.Read_BFJDByID(BFJHID);
            }
            return node;
            
        }
        [WebMethod]
       public List<CRM_BF_BFDJList> Read(CRM_BF_BFDJ_PARAMS model, int isGun, string ptoken)
       {
           List<CRM_BF_BFDJList> node = new List<CRM_BF_BFDJList>();
           if (models.CRM_Login.ValidateToken(ptoken))
           {
               return models.BF_BF.Read(model,isGun).ToList();
           }
           return node;
           
       }
         [WebMethod]
        public List<CRM_KHDJ_REPORT_SUMMARY> ReadKHBF_BFDJ_SUMMARY(CRM_KHDJ_REPORT_PARAMS model,string ptoken)
        {
            List<CRM_KHDJ_REPORT_SUMMARY> node = new List<CRM_KHDJ_REPORT_SUMMARY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadKHBF_BFDJ_SUMMARY(model).ToList();
            }
            return node;
            
        }
         [WebMethod]
        public List<CRM_KHDJ_REPORT_DETAIL> ReadKHBF_BFDJ_DETAIL(CRM_KHDJ_REPORT_PARAMS model,string ptoken)
        {
            List<CRM_KHDJ_REPORT_DETAIL> node = new List<CRM_KHDJ_REPORT_DETAIL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadKHBF_BFDJ_DETAIL(model).ToList();
            }
            return node;
            
        }
        [WebMethod]
         public List<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> ReadKHBF_ReportByStaff_SummaryTotal(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
         {
             List<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> node = new List<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL>();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.BF_BF.ReadKHBF_ReportByStaff_SummaryTotal(model).ToList();
             }
             return node;

         }
        [WebMethod]
        public List<CRM_BF_REPORT_BYSTAFF_SUMMARY> ReadKHBF_ReportByStaff_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {
            List<CRM_BF_REPORT_BYSTAFF_SUMMARY> node = new List<CRM_BF_REPORT_BYSTAFF_SUMMARY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadKHBF_ReportByStaff_Summary(model).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_BF_BFDJList> ReadKHBF_ReportByStaff_Detail(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {
            List<CRM_BF_BFDJList> node = new List<CRM_BF_BFDJList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadKHBF_ReportByStaff_Detail(model).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public DataTable ReadKHBF_ReportByDate_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {
            DataTable node = new DataTable();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BF.ReadKHBF_ReportByDate_Summary(model);
            }
            return node;
        }
    }
}
