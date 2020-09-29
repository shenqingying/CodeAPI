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
    /// HD_NKAXT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HD_NKAXT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create_TT(CRM_HD_NKAXTTT model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Create_TT(model);
            }
            return -100;
           
        }
        [WebMethod]
        public int Update_TT(CRM_HD_NKAXTTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Update_TT(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete_TT(int NKAXTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Delete_TT(NKAXTID);
            }
            return -100;
            
        }






        [WebMethod]
        public int Create_MX(CRM_HD_NKAXTMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Create_MX(model);
            }
            return -100;
           
        }
        [WebMethod]
        public int Update_MX(CRM_HD_NKAXTMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Update_MX(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete_MX(int NKAXTMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HD_NKAXT.Delete_MX(NKAXTMXID);
            }
            return -100;
           
        }




    }
}
