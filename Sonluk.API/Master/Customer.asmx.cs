using Sonluk.API.Models;
using Sonluk.Entities.Master;
using Sonluk.Entities.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace Sonluk.API.FI
{
    /// <summary>
    /// Customer 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/Master/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Customer : System.Web.Services.WebService
    {
        MasterModels models = new MasterModels();

        [WebMethod]
        public List<CompanyGeneralInfo> Read(string serialNumber)
        {
            return models.Customer.Read(serialNumber).General.ToList();
        }

        [WebMethod]
        public List<CompanyGeneralInfo> ReadByDateTime(string date, string time)
        {
            return models.Customer.Read(date, time).General.ToList();

        }

         [WebMethod]
        public List<CompanyGeneralInfo> ReadByDateTime3(string date, string time)
        {
            return models.Customer.Read3(date, time).General.ToList();

        }

        [WebMethod]
        public List<CompanyInfo> ShipToParty(string customer, string salesOrganization, string distributionChannel, string division)
        {
            return models.Customer.ShipToParty(customer, salesOrganization, distributionChannel, division).ToList();
        }

        [WebMethod]
        public List<SDInfo> SalesRange(string customer)
        {
            return models.Customer.SalesRange(customer).ToList();
        }

        [WebMethod]
        public List<DiscountInfo> Discount(string serialNumber)
        {
            List<DiscountInfo> nodes = new List<DiscountInfo>();
            nodes.Add(models.Customer.Discount(serialNumber));
            return nodes;
        }
    }
}
