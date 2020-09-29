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
    /// KH_HZHB 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_HZHB : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_HZHB model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int SapDataSynchronization(string CRMID, string SAPSN, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.SapDataSynchronization(CRMID, SAPSN);
            }
            return -100;
          
        }
        [WebMethod]
        public void SapFlow()
        {
            models.KH_HZHB.SAPFlow();
        }



        [WebMethod]
        public List<CRM_KH_HZHBLIST> Read(string SAPSN, string ptoken)
        {
            List<CRM_KH_HZHBLIST> node = new List<CRM_KH_HZHBLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.Read(SAPSN).ToList();
            }
            return node;
            
        }

        [WebMethod]
        public SAP_HZHBList ReadSAPHZHB(string SAPSN,int KHLX, string ptoken)
        {
            SAP_HZHBList node = new SAP_HZHBList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.ReadSAPHZHB(SAPSN, KHLX);
            }
            return node;
        }

        [WebMethod]
        public SAP_HZHBList SyncSapRead(List<SAP_KH> t_KH, int khlx, string ptoken)
        {
            SAP_HZHBList node = new SAP_HZHBList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.SyncSapRead(t_KH, khlx);
            }
            return node;
        }

        [WebMethod]
        public CRM_KH_XSQYSJ ReadBySAPSN(string SAPSN, string ptoken)
        {
            CRM_KH_XSQYSJ node = new CRM_KH_XSQYSJ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_HZHB.ReadBySAPSN(SAPSN);
            }
            return node;
        }

    }
}
