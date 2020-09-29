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
    /// Receiver 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Receiver : System.Web.Services.WebService
    {

        LETRAModels models = new LETRAModels();

        [WebMethod]
        public bool Exists(string serialNumber)
        {
            return models.Receiver.Exists(serialNumber);
        }

        [WebMethod]
        public List<CompanyInfo> Read(int city)
        {
            return models.Receiver.Read(city).ToList();
        }

        [WebMethod]
        public CompanyInfo ReadBySerialNumber(string serialNumber)
        {
            return models.Receiver.Read(serialNumber);
        }

        [WebMethod]
        public List<CompanyInfo> Select(string keyword)
        {
            return models.Receiver.Select(keyword).ToList();
        }
        
        [WebMethod]
        public int Create(CompanyInfo node)
        {
            return models.Receiver.Create(node);
        }

        [WebMethod]
        public int Update(CompanyInfo node)
        {
            return models.Receiver.Update(node);
        }
    }
}
