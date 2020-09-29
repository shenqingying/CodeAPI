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
    /// HG_ROLE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_ROLE : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_ROLE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_HG_ROLE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int ROLEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Delete(ROLEID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_ROLE> Read(string ptoken)
        {
            List<CRM_HG_ROLE> node = new List<CRM_HG_ROLE>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Read().ToList();
            }
            return node;

        }
        //role相关
        [WebMethod]
        public int Create_STAFFROLE(int STAFFID, int ROLEID, string ptoken)
        {

            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Create_STAFFROLE(STAFFID, ROLEID);
            }
            return -100;

        }
        [WebMethod]
        public List<string[]> Read_STAFFROLEbyROLEID(int ROLEID, string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Read_STAFFROLEbyROLEID(ROLEID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete_STAFFROLE(int STAFFID, int ROLEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Delete_STAFFROLE(STAFFID, ROLEID);
            }
            return -100;

        }
        [WebMethod]
        public int Create_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Create_ROLERIGHT(ROLEID, RIGHTID);
            }
            return -100;

        }
        [WebMethod]
        public List<string[]> Read_ROLERIGHTByRIGHTID(int RIGHTID, string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Read_ROLERIGHTByRIGHTID(RIGHTID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Delete_ROLERIGHT(ROLEID, RIGHTID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_STAFFROLEList> Read_STAFFROLEbySTAFFID(int STAFFID, string ptoken)
        {
            List<CRM_HG_STAFFROLEList> node = new List<CRM_HG_STAFFROLEList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Read_STAFFROLEbySTAFFID(STAFFID).ToList();
            }
            return node;

        }
         [WebMethod]
        public int Delete_STAFFROLEByStaffid(int STAFFID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_ROLE.Delete_STAFFROLEByStaffid(STAFFID);
            }
            return -100;
           
        }
        [WebMethod]
         public List<int>Read_ROLERIGHTByROLEID(int ROLEID,string ptoken)
         {
             List<int> node = new List<int>();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.HG_ROLE.Read_ROLERIGHTByROLEID(ROLEID).ToList();
             }
             return node;
            
         }
    }
}
