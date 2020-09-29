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
    /// KQ_CC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_CC : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Create_MX(CRM_KQ_CCMX model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Create_MX(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Update_MX(CRM_KQ_CCMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Update_MX(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Delete_MX(int ID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Delete_MX(ID);
            }
            return -100;
            
        }
         [WebMethod]
         public List<CRM_KQ_CCMX> Read_MXbyCCID(int CCID, string ptoken)
        {
            List<CRM_KQ_CCMX> node = new List<CRM_KQ_CCMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Read_MXbyCCID(CCID).ToList();
            }
            return node;
            
        }
         [WebMethod]
         public List<CRM_KQ_CCMXList> Read_MXQDbyCCID(int CCID, string ptoken)
         {
             List<CRM_KQ_CCMXList> node = new List<CRM_KQ_CCMXList>();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KQ_CC.Read_MXQDbyCCID(CCID).ToList();
             }
             return node;

         }
         [WebMethod]
         public int Create_TT(CRM_KQ_CCTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Create_TT(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Update_TT(CRM_KQ_CCTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Update_TT(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Delete_TT(int CCID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Delete_TT(CCID);
            }
            return -100;
            
        }
         [WebMethod]
         public List<CRM_KQ_CCTTList> Read_TTbySTAFFID(int STAFFID, int Status, string ptoken)
        {
            List<CRM_KQ_CCTTList> node = new List<CRM_KQ_CCTTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Read_TTbySTAFFID(STAFFID, Status).ToList();
            }
            return node;
            
        }

        [WebMethod]
         public CRM_KQ_CCTT Read_TTbyCCID(int CCID,string ptoken)
         {
             CRM_KQ_CCTT node = new CRM_KQ_CCTT();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KQ_CC.Read_TTbyCCID(CCID);
             }
             return node;
             
         }
        [WebMethod]
        public List<CRM_KQ_CCTTList> Read_TTbyParam(CRM_KQ_CCTT model, int STATUS, string ptoken)
        {
            List<CRM_KQ_CCTTList> node = new List<CRM_KQ_CCTTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_CC.Read_TTbyParam(model,STATUS).ToList();
            }
            return node;
        }

    }
}
