using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.DEV
{
    /// <summary>
    /// Table 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/DEV/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Table : System.Web.Services.WebService
    {
        DEVModels models = new DEVModels();

        [WebMethod]
        public string Read(string name)
        {
            return models.Table.Read(name);
        }
    }
}
