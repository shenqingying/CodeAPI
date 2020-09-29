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
    /// MSG_TYPE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MSG_TYPE : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MSGModels MSGmodels = new MSGModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(MSG_MSG_TYPE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSG_TYPE.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(MSG_MSG_TYPE model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSG_TYPE.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<MSG_MSG_TYPE> ReadByParam(MSG_MSG_TYPE model, string ptoken)
        {
            List<MSG_MSG_TYPE> node = new List<MSG_MSG_TYPE>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSG_TYPE.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int MSGTYPEID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.MSG_TYPE.Delete(MSGTYPEID);
            }
            return -100;

        }



    }
}
