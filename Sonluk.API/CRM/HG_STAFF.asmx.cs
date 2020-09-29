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
    /// HG_STAFF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_STAFF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_STAFF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_HG_STAFF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int STAFFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.Delete(STAFFID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_STAFFList> Report(CRM_Report_STAFFModel model, string TYPE, string ptoken)
        {
            List<CRM_HG_STAFFList> node = new List<CRM_HG_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.Report(model, TYPE).ToList();
            }
            return node;

        }
        [WebMethod]
        public CRM_HG_STAFF ReadBySTAFFID(int STAFFID, string ptoken)
        {
            CRM_HG_STAFF node = new CRM_HG_STAFF();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.RaedBySTAFFID(STAFFID);
            }
            return node;

        }
        [WebMethod]
        public CRM_HG_STAFF ReadBySTAFFNO(string STAFFNO, string ptoken)
        {
            CRM_HG_STAFF node = new CRM_HG_STAFF();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadBySTAFFNO(STAFFNO);
            }
            return node;
        }
        [WebMethod]
        public CRM_HG_STAFF ReadByROLEID(int ROLEID, string ptoken)
        {
            CRM_HG_STAFF node = new CRM_HG_STAFF();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadByROLEID(ROLEID);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_STAFF> ReadByDUTYID(int DUTYID, string ptoken)
        {
            List<CRM_HG_STAFF> node = new List<CRM_HG_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadByDUTYID(DUTYID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_STAFFList> ReadByParam(CRM_HG_STAFF model, string ptoken)
        {
            List<CRM_HG_STAFFList> node = new List<CRM_HG_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_STAFFList> ReadUser(string ptoken)
        {
            List<CRM_HG_STAFFList> node = new List<CRM_HG_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadUser().ToList();
            }
            return node;
        }
        [WebMethod]
        public List<STAFFDUTY_KH> ReadSTAFFBYKHIDANDDUTY(int KHID, int DUTYID, string ptoken)
        {
            List<STAFFDUTY_KH> node = new List<STAFFDUTY_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadSTAFFBYKHIDANDDUTY(KHID, DUTYID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_STAFF> ReadSTAFF_KHGOURPBYSTAFFID(int STAFFID, string ptoken)
        {
            List<CRM_HG_STAFF> node = new List<CRM_HG_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(STAFFID).ToList();
            }
            return node;

        }

        [WebMethod]
        public List<CRM_HG_STAFF> ReadSTAFF_KHGroupByStaffidAndDuty(int STAFFID, int DUTYID, string ptoken)
        {
            List<CRM_HG_STAFF> node = new List<CRM_HG_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadSTAFF_KHGroupByStaffidAndDuty(STAFFID, DUTYID).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<CRM_HG_STAFF> ReadStaff_BYDEPID(int STAFFID, string ptoken)
        {
            List<CRM_HG_STAFF> node = new List<CRM_HG_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadStaff_BYDEPID(STAFFID).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_HG_STAFFList> ReadUser_STAFF(CRM_Report_STAFFModel model, string ptoken)
        {
            List<CRM_HG_STAFFList> node = new List<CRM_HG_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFF.ReadUser_STAFF(model).ToList();
            }
            return node;
        }

    }
}
