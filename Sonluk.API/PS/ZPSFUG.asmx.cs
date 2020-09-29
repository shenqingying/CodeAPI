using Sonluk.API.Models;
using Sonluk.Entities.PS;
using Sonluk.Entities.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.PS
{
    /// <summary>
    /// ZPSFUG 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ZPSFUG : System.Web.Services.WebService
    {
        PSModels models = new PSModels();
        [WebMethod]
        public List<ZSL_XMXX> XMXX(string POSID, string PSPID)
        {
            return models.ZPSFUG.ZPSFUG_Q_XMXXOA(POSID, PSPID);
        }
    }
}
