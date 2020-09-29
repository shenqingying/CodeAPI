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
    /// HG_TYPE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_TYPE : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_TYPE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_TYPE.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_HG_TYPE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_TYPE.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_HG_TYPE> Read(string ptoken)
        {
            List<CRM_HG_TYPE> node = new List<CRM_HG_TYPE>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_TYPE.Read().ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int Delete(int TYPEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_TYPE.Delete(TYPEID);
            }
            return -100;
            
        }
    }
}
