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
    /// COST_CXHDPGHZ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_CXHDPGHZ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_CXHDPGHZ> ReadByParam(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            List<CRM_COST_CXHDPGHZ> node = new List<CRM_COST_CXHDPGHZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int PGHZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.Delete(PGHZID);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByCXHDID(int CXHDID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.DeleteByCXHDID(CXHDID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_CXHDPGHZ> GetReport(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            List<CRM_COST_CXHDPGHZ> node = new List<CRM_COST_CXHDPGHZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.GetReport(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int AutoUpdate(int CXHDID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDPGHZ.AutoUpdate(CXHDID);
            }
            return -100;
        }



    }
}
