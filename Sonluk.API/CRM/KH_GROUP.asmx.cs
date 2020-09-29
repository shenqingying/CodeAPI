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
    /// KH_GROUP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_GROUP : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_GROUP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KH_GROUP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUPList> Read(string ptoken)
        {
            List<CRM_KH_GROUPList> node = new List<CRM_KH_GROUPList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.Read().ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUPList> ReadByParam(CRM_KH_GROUPList model, string ptoken)
        {
            List<CRM_KH_GROUPList> node = new List<CRM_KH_GROUPList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.ReadByParam(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delect(int GID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.Delect(GID);
            }
            return -100;
            
        }

        [WebMethod]
        public CRM_KH_GROUPList ReadbyGId(int GID, string ptoken)
        {
            CRM_KH_GROUPList node = new CRM_KH_GROUPList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.ReadbyGId(GID);
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUPList> ReadBySTAFFID(int STAFFID, string ptoken)
        {
            List<CRM_KH_GROUPList> node = new List<CRM_KH_GROUPList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int ReadGidByGNAME(string gname,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP.ReadGidByGNAME(gname);
            }
            return -100;
           
        }

       
    }
}
