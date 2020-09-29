using Sonluk.API.Models;
using Sonluk.Entities.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.Print
{
    /// <summary>
    /// Layout 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/Print")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Layout : System.Web.Services.WebService
    {
        PrintModels models = new PrintModels();

        [WebMethod]
        public int Create(LayoutInfo node)
        {
            return models.Layout.Create(node);
        }

        [WebMethod]
        public bool Update(LayoutInfo node)
        {
            return models.Layout.Update(node);
        }

        [WebMethod]
        public List<LayoutInfo> Read()
        {
            return models.Layout.Read().ToList();
        }

        [WebMethod]
        public LayoutInfo ReadByID(int ID)
        {
            return models.Layout.Read(ID);
        }

        [WebMethod]
        public LayoutInfo ReadByDocMac(string doc, string mac)
        {
            return models.Layout.Read(doc, mac);
        }

        [WebMethod]
        public bool Delete(int ID)
        {
            return models.Layout.Delete(ID);
        }

    }
}
