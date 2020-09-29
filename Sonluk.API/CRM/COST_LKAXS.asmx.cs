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
    /// COST_LKAXXTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAXS : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int CreateTT(CRM_COST_LKAXSTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.CreateTT(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateTT(CRM_COST_LKAXSTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.UpdateTT(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAXSTT> ReadTTByParam(CRM_COST_LKAXSTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_LKAXSTT> node = new List<CRM_COST_LKAXSTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.ReadTTByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int DeleteTT(int LKAXSTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.DeleteTT(LKAXSTTID);
            }
            return -100;

        }
        
        [WebMethod]
        public List<CRM_COST_LKAXSTT> ReadKHbasic(CRM_COST_LKAXSTT model, string ptoken)
        {
            List<CRM_COST_LKAXSTT> node = new List<CRM_COST_LKAXSTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.ReadKHbasic(model).ToList();
            }
            return node;

        }
        
        [WebMethod]
        public int CreateMX(CRM_COST_LKAXSMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.CreateMX(model);
            }
            return -100;

        }
            
        [WebMethod]
        public int UpdateMX(CRM_COST_LKAXSMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.UpdateMX(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAXSMX> ReadMXByTTID(CRM_COST_LKAXSMX model, string ptoken)
        {
            List<CRM_COST_LKAXSMX> node = new List<CRM_COST_LKAXSMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.ReadMXByTTID(model).ToList();
            }
            return node;

        }
            
        [WebMethod]
        public int DeleteMX(int LKAXSMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAXS.DeleteMX(LKAXSMXID);
            }
            return -100;

        }








    }
}
