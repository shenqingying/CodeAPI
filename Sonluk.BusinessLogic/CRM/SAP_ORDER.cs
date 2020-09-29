using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;

namespace Sonluk.BusinessLogic.CRM
{
    public class SAP_ORDER
    {
        private static readonly ISAP_ORDER _SAP_ORDER_DataAccess = RMSDataAccess.CreateISAP_ORDER();
        public IList<SAP_CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division)
        {
            return _SAP_ORDER_DataAccess.ShipToParty(serialNumber, salesOrganization, distributionChannel, division);
        }
        public decimal SAP_Price(string serialNumber, string customer, string salesOrganization, string distributionChannel)
        {
            return _SAP_ORDER_DataAccess.SAP_Price(serialNumber, customer, salesOrganization, distributionChannel);
        }

        public SAP_DiscountInfo SAP_Discount(string customer)
        {
            return _SAP_ORDER_DataAccess.SAP_Discount(Convert.ToDecimal(customer).ToString("0000000000"));
        }
        public decimal SAP_Balance(string customer)
        {
            return _SAP_ORDER_DataAccess.SAP_Balance(customer);
        }
        public string Create(SAP_SOInfo node)
        {
            return _SAP_ORDER_DataAccess.Create(node);
        }
      

    }
}
