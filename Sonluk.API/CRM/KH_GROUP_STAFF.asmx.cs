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
    /// KH_GROUP_STAFF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_GROUP_STAFF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Create(int STAFFID, int GID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_STAFF.Create(STAFFID, GID);
            }
            return -100;
            
        }
         [WebMethod]
        public int Delete(int STAFFID, int GID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_STAFF.Delete(STAFFID, GID);
            }
            return -100;
            
        }
         [WebMethod]
        public List<string[]> ReadByStaffID(int StaffID,string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_STAFF.ReadByStaffID(StaffID).ToList();
            }
            return node;
            
        }
         [WebMethod]
         public List<string[]> Read(string ptoken)
         {
             List<string[]> node = new List<string[]>();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KH_GROUP_STAFF.Read().ToList();
             }
             return node;
             
         }
        [WebMethod]
         public CRM_KH_GROUP_STAFFList ReadStruct(int STAFFID, int GID,string ptoken)
         {
             CRM_KH_GROUP_STAFFList node = new CRM_KH_GROUP_STAFFList();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KH_GROUP_STAFF.ReadStruct(STAFFID, GID);
             }
             return node;
             
            
         }
        [WebMethod]
        public int Update(int STAFFID, int oGID, int nGid,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_STAFF.Update(STAFFID, oGID, nGid);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_GROUP_STAFFList> Report(string STAFFNAME, int GID,string ptoken)
        {
            List<CRM_KH_GROUP_STAFFList> node = new List<CRM_KH_GROUP_STAFFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GROUP_STAFF.Report(STAFFNAME, GID).ToList();
            }
            return node;
           
        }
    }
}
