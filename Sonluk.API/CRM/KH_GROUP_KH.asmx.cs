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
    /// KH_GROUP_KH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_GROUP_KH : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string[]> ReadByKHID(string ptoken, int KHID)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.ReadByKHID(KHID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int Create(int KHID, int GID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Create(KHID, GID);
            }
            return -100;
            
        }
        //[WebMethod]
        //public int Update(int KHID, int GID)
        //{
        //    return models.KH_GROUP_KH.Update(KHID, GID);
        //}
        [WebMethod]
        public int Delete(int KHID, int GID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Delete(KHID, GID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<string[]> Read(string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Read().ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<string[]> ReadByStaffid(int STAFFID,string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.ReadByStaffid(STAFFID).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public int DeletebyKHID(int KHID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.DeletebyKHID(KHID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUP_KHList> ReadStruct(int KHID, int GID, string ptoken)
        {
            List<CRM_KH_GROUP_KHList> node = new List<CRM_KH_GROUP_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.ReadStruct(KHID, GID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Update(int KHID, int oGID, int nGid,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Update(KHID, oGID, nGid);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUP_KHList> Report(string KHMC, int GID,string ptoken)
        {
            List<CRM_KH_GROUP_KHList> node = new List<CRM_KH_GROUP_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Report(KHMC, GID).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_KH_GROUP_KHList> Report2(CRM_KH_GROUP_KHList model, string ptoken)
        {
            List<CRM_KH_GROUP_KHList> node = new List<CRM_KH_GROUP_KHList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_KH.Report2(model).ToList();
            }
            return node;
        }

    }
}
