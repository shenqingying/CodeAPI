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
    /// PRODUCT_GROUP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_GROUP : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_PRODUCT_GROUP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_GROUP.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_PRODUCT_GROUP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_GROUP.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int INVOICEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_GROUP.Delete(INVOICEID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_PRODUCT_GROUP> Read(string ptoken)
        {
            List<CRM_PRODUCT_GROUP> node = new List<CRM_PRODUCT_GROUP>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_GROUP.Read().ToList();
            }
            return node;
        }
        [WebMethod]
        public int ReadByIDGroupName(string GROUPNAME, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_GROUP.ReadByIDGroupName(GROUPNAME);
            }
            return -100;
        }


    }
}
