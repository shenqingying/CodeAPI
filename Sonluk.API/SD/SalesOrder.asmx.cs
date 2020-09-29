using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.SD;

namespace Sonluk.API.SD
{
    /// <summary>
    /// SalesOrder 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://sonluk.com/API/SD/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SalesOrder : System.Web.Services.WebService
    {
        SDModels models = new SDModels();

        [WebMethod]
        public string Create(SOInfo node)
        {
            return models.SalesOrder.Create(node);
        }

        [WebMethod]
        public List<SOItemInfo> Read(SOKeywordInfo keyword)
        {
            return models.SalesOrder.Read(keyword).ToList();
        }

        [WebMethod]
        public string ProcessingRecords(List<SOItemInfo> nodes)
        {
            return models.SalesOrder.ProcessingRecords(nodes);
        }
    }
}
