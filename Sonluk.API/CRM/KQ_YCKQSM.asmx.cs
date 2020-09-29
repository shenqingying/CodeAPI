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
    /// KQ_YCKQSM 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_YCKQSM : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KQ_YCKQSM model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KQ_YCKQSM model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KQ_YCKQSMList> ReadBySTAFFID(int STAFFID, string ptoken)
        {
            List<CRM_KQ_YCKQSMList> node = new List<CRM_KQ_YCKQSMList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int Delete(int YCKQID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.Delete(YCKQID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KQ_YCKQList> Report_YC(int STAFFID, string fromdate, string todate,string ptoken)
        {
            List<CRM_KQ_YCKQList> node = new List<CRM_KQ_YCKQList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.Report_YC(STAFFID, fromdate, todate).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KQ_YCKQSMList> ReadByParam(CRM_KQ_YCKQSMList model, string ptoken)
        {
            List<CRM_KQ_YCKQSMList> node = new List<CRM_KQ_YCKQSMList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int UpdateStatus(int YCKQID, int ISACTIVE, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_YCKQSM.UpdateStatus(YCKQID, ISACTIVE);
            }
            return -100;
        }
    }
}
