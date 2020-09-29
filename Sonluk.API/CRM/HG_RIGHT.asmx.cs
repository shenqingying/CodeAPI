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
    /// HG_RIGHT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_RIGHT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_RIGHT model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RIGHT.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_HG_RIGHT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RIGHT.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int RIGHTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RIGHT.Delete(RIGHTID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_HG_RIGHT> ReadByRGROUPID(int RGROUPID, string ptoken)
        {
            List<CRM_HG_RIGHT> node = new List<CRM_HG_RIGHT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RIGHT.ReadByRGROUPID(RGROUPID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_HG_RIGHTList> Read(string ptoken)
        {
            List<CRM_HG_RIGHTList> node = new List<CRM_HG_RIGHTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RIGHT.Read().ToList();
            }
            return node;
           
        }
    }
}
