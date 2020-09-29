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
    /// HD_ZYCXY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HD_ZYCXY : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create_TT(CRM_HD_ZYCXYTT model ,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Create_TT(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update_TT(CRM_HD_ZYCXYTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Update_TT(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete_TT(int ZYCXYID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Delete_TT(ZYCXYID);
            }
            return -100;
            
        }







        [WebMethod]

        public int Create_MX(CRM_HD_ZYCXYMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Create_MX(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update_MX(CRM_HD_ZYCXYMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Update_MX(model);
            }
            return -100;
           
        }
        [WebMethod]
        public int Delete_MX(int ZYCXYMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_ZYCXY.Delete_MX(ZYCXYMXID);
            }
            return -100;
           
        }
    }
}
