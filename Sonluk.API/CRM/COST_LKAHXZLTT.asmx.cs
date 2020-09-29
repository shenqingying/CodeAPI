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
    /// COST_LKAHXZLTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAHXZLTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAHXZLTT> ReadByParam(CRM_COST_LKAHXZLTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_LKAHXZLTT> node = new List<CRM_COST_LKAHXZLTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int HXZLTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.Delete(HXZLTTID);
            }
            return -100;

        }
        [WebMethod]
        public CRM_COST_LKAHXZLTT ReadTTGLinfo(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            CRM_COST_LKAHXZLTT node = new CRM_COST_LKAHXZLTT();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.ReadTTGLinfo(model);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_HXZLTT> ReadByPublic(CRM_COST_HXZLTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_HXZLTT> node = new List<CRM_COST_HXZLTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLTT.ReadByPublic(model, STAFFID).ToList();
            }
            return node;

        }






    }
}
