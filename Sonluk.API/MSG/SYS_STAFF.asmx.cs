using Sonluk.API.Models;
using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MSG
{
    /// <summary>
    /// SYS_STAFF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SYS_STAFF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MSGModels MSGmodels = new MSGModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(MSG_SYS_STAFF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SYS_STAFF.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(MSG_SYS_STAFF model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SYS_STAFF.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<MSG_SYS_STAFF> ReadByParam(MSG_SYS_STAFF model, string ptoken)
        {
            List<MSG_SYS_STAFF> node = new List<MSG_SYS_STAFF>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SYS_STAFF.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int ID, int XGR, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SYS_STAFF.Delete(ID, XGR);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteBySYSID(int SYSID, int XGR, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SYS_STAFF.DeleteBySYSID(SYSID, XGR);
            }
            return -100;

        }


    }
}
