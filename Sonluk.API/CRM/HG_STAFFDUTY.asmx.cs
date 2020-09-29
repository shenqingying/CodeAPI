using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// HG_STAFFDUTY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_STAFFDUTY : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(int STAFFID, int DUTYID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDUTY.Create(STAFFID, DUTYID);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int STAFFID, int DUTYID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDUTY.Delete(STAFFID, DUTYID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<string[]> ReadBySTAFFID(int STAFFID, string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDUTY.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
            
        }
          [WebMethod]
        public int DeleteByStaffid(int STAFFID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFDUTY.DeleteByStaffid(STAFFID);
            }
            return -100;
            
        }


    }
}
