using Sonluk.API.Models;
using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.LE.TRA
{
    /// <summary>
    /// Carrier 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Carrier : System.Web.Services.WebService
    {
        LETRAModels models = new LETRAModels();

        [WebMethod]
        public List<CompanyInfo> Read() 
        {
            return models.Carrier.Read().ToList();
        }
    }
}
