using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.Setting
{
    /// <summary>
    /// Version 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/Setting")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Version : System.Web.Services.WebService
    {
        SettingModels models = new SettingModels();

        [WebMethod]
        public string Read()
        {
            return models.Version.Read();
        }

        [WebMethod]
        public List<string> ReadAll()
        {
            return models.Version.ReadAll().ToList();
        }
    }
}