using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.CRM;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// SAP_ORDER 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SAP_ORDER : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();

        [WebMethod]
        public List<SAP_CompanyInfo> ShipToParty(string customer, string salesOrganization, string distributionChannel, string division, string ptoken)
        {
            List<SAP_CompanyInfo> node = new List<SAP_CompanyInfo>();
            if (models.CRM_Login.ValidateToken(ptoken))
        {
            return models.SAP_ORDER.ShipToParty(customer, salesOrganization, distributionChannel, division).ToList();
        }
      return node;
    }

        [WebMethod]
        public decimal SAP_Price(string serialNumber, string customer, string salesOrganization, string distributionChannel, string ptoken)
        {
         
            if (models.CRM_Login.ValidateToken(ptoken))
        {
            decimal price = models.SAP_ORDER.SAP_Price(serialNumber, customer, salesOrganization, distributionChannel);
            return price;

        }
            return -100;
        }

        [WebMethod]
        public List<SAP_DiscountInfo> SAP_Discount(string customer, string ptoken)
        {
            List<SAP_DiscountInfo> node = new List<SAP_DiscountInfo>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                node.Add(models.SAP_ORDER.SAP_Discount(customer));
            }
            return node;
        }

        [WebMethod]
        public decimal SAP_Balance(string customer, string ptoken)
        {

            if (models.CRM_Login.ValidateToken(ptoken))
            {
                decimal balance = models.SAP_ORDER.SAP_Balance(customer);
                return balance;

            }
            return -100;
        }

        [WebMethod]
        public string Create(SAP_SOInfo node, string ptoken)
        {
          if (models.CRM_Login.ValidateToken(ptoken))
           {
            return models.SAP_ORDER.Create(node);
           }
          return "-100";
         }

      
       
    }
}
