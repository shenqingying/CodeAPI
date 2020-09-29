using Sonluk.API.Models;
using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.Master
{
    /// <summary>
    /// Material 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/Master/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Material : System.Web.Services.WebService
    {
        MasterModels models = new MasterModels();

        [WebMethod]
        public List<MaterialInfo> Read()
        {
            return models.Material.Read().ToList();
        }

        [WebMethod]
        public List<MaterialUnitInfo> UnitConversion(string material, string customer, string salesOrganization, string distributionChannel)
        {
            return models.Material.UnitConversion(material, customer, salesOrganization, distributionChannel).ToList();
        }

        [WebMethod]
        public List<MaterialInfo> SalesOnline(string customer, string salesOrganization, string distributionChannel, string division)
        {
            return models.Material.SalesOnline(customer, salesOrganization, distributionChannel, division).ToList();
        }

        [WebMethod]
        public List<MaterialInfo> Promotion(string salesOrganization, string distributionChannel, string division)
        {
            return models.Material.Promotion(salesOrganization, distributionChannel, division).ToList();
        }

        [WebMethod]
        public decimal Price(string serialNumber, string customer, string salesOrganization, string distributionChannel)
        {
            decimal price = models.Material.Price(serialNumber, customer, salesOrganization, distributionChannel);
            return price;
        }
    }
}
