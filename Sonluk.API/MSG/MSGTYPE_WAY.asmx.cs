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
    /// MSGTYPE_WAY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MSGTYPE_WAY : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MSGModels MSGmodels = new MSGModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(MSG_MSGTYPE_WAY model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSGTYPE_WAY.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public List<MSG_MSGTYPE_WAY> ReadByParam(MSG_MSGTYPE_WAY model, string ptoken)
        {
            List<MSG_MSGTYPE_WAY> node = new List<MSG_MSGTYPE_WAY>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSGTYPE_WAY.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(MSG_MSGTYPE_WAY model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSGTYPE_WAY.Delete(model);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByTYPEID(int TYPEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSGTYPE_WAY.DeleteByTYPEID(TYPEID);
            }
            return -100;

        }



    }
}
