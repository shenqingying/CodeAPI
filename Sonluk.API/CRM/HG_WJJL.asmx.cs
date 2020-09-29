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
    /// HG_WJJL 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_WJJL : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_WJmodel model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int JLID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.Delete(JLID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_WJJL> Read(int GSDX, int GSDXID, string ptoken)
        {
            List<CRM_HG_WJJL> node = new List<CRM_HG_WJJL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.Read(GSDX, GSDXID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_HG_WJJL> ReadByParam(CRM_HG_WJJL model, string ptoken)
        {
            List<CRM_HG_WJJL> node = new List<CRM_HG_WJJL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_HG_WJJL> ReadLocation(int GSDX, int GSDXID, string ptoken)
        {
            List<CRM_HG_WJJL> node = new List<CRM_HG_WJJL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.ReadLocation(GSDX, GSDXID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Update_SP(CRM_HG_WJJL model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.Update_SP(model);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_HG_WJJL> DisplayImgReport(CRM_HG_WJJL_KHModel model, int STAFFID, string ptoken)
        {
            List<CRM_HG_WJJL> node = new List<CRM_HG_WJJL>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_WJJL.DisplayImgReport(model, STAFFID).ToList();
            }
            return node;
        }


    }
}
