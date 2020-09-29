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
    /// KQ_QD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_QD : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KQ_QD model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KQ_QD model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public CRM_KQ_QD ReadByKQQDID(int KQQDID, string ptoken)
        {
            CRM_KQ_QD node = new CRM_KQ_QD();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.ReadByKQQDID(KQQDID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_KQ_QD> ReadByQDLXandQDGSID(int QDLX, int QDGSID, string ptoken)
        {
            List<CRM_KQ_QD> node = new List<CRM_KQ_QD>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.ReadByQDLXandQDGSID(QDLX, QDGSID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KQ_QD> ReadYCQD_ByDATE(string QDRQ, int SXB, int STAFFID, string ptoken)
        {
            List<CRM_KQ_QD> node = new List<CRM_KQ_QD>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.ReadYCQD_ByDATE(QDRQ, SXB,STAFFID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int KQQDID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.Delete(KQQDID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<string[]> Verify_QD(int STAFFID, string ED, string JD, double WXRC,string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.Verify_QD(STAFFID, ED, JD, WXRC).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int ReadQD_COUNTS(CRM_KQ_QD model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_QD.ReadQD_COUNTS(model);
            }
            return -100;
            
        }
    }
}
