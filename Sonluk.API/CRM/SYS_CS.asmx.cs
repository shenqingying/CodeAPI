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
    /// SYS_CS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SYS_CS : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Update(CRM_SYS_CS model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SYS_CS.Update(model);
            }
            return -100;


      
        }
         [WebMethod]
        public List<CRM_SYS_CS> Read(int ID,string ptoken)
        {
            List<CRM_SYS_CS> node = new List<CRM_SYS_CS>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SYS_CS.Read(ID).ToList();
            }
            return node;
            
           
        }
    }
}
