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
    /// QYJS_MENU 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class QYJS_MENU : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int Create(CRM_QYJS_MENU model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.QYJS_MENU.Create(model);
            }
            return -100;
        }

        [WebMethod]
        public int Update(CRM_QYJS_MENU model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.QYJS_MENU.Update(model);
            }
            return -100;
        }

        [WebMethod]
        public int Delete(int CATALOGID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.QYJS_MENU.Delete(CATALOGID);
            }
            return -100;
        }

        [WebMethod]
        public CRM_QYJS_MENU ReadbyID(int CATALOGID, string ptoken)
        {
            CRM_QYJS_MENU node = new CRM_QYJS_MENU();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.QYJS_MENU.ReadbyID(CATALOGID);
            }
            return node;
        }

        [WebMethod]
        public List<CRM_QYJS_MENU> ReadTTbyParam(CRM_QYJS_MENU model, string ptoken)
        {
            List<CRM_QYJS_MENU> node = new List<CRM_QYJS_MENU>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.QYJS_MENU.ReadTTbyParam(model).ToList();
            }
            return node;

        }





    }
}
