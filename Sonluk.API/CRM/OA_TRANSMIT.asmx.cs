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
    /// OA_TRANSMIT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class OA_TRANSMIT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_OA_TRANSMIT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.OA_TRANSMIT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_OA_TRANSMIT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.OA_TRANSMIT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int ID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.OA_TRANSMIT.Delete(ID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_OA_TRANSMIT> Read(int Status, string ptoken)
        {
            List<CRM_OA_TRANSMIT> node = new List<CRM_OA_TRANSMIT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.OA_TRANSMIT.Read(Status).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_OA_TRANSMIT> ReadByParam(CRM_OA_TRANSMIT model, string ptoken)
        {
            List<CRM_OA_TRANSMIT> node = new List<CRM_OA_TRANSMIT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.OA_TRANSMIT.ReadByParam(model).ToList();
            }
            return node;
        }
    }
}
