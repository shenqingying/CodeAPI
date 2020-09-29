using Sonluk.API.Models;
using Sonluk.Entities.KQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.KQ
{
    /// <summary>
    /// KQinfo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/KQ/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQinfo : System.Web.Services.WebService
    {
        KQModels kqmodels = new KQModels();
        [WebMethod]
        public KQINFO getKQINFO(string date)
        {
            return kqmodels.KQinfo.getKQINFO(date);
        }
        [WebMethod]
        public string StaffCardID(string cardno)
        {
            return kqmodels.KQinfo.StaffCardID(cardno);
        }
    }
}
