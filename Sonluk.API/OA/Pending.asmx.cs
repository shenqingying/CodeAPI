using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.OA
{
    /// <summary>
    /// Pending 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/OA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Pending : System.Web.Services.WebService
    {
        OAModels models = new OAModels();

        [WebMethod]
        public List<PendingInfo> Read(string ticketId, int firstNum, int pageSize,string address)
        {
            return models.Pending.Read(ticketId, firstNum, pageSize, address).ToList();
        }

    }
}
