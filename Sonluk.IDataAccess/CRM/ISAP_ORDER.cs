using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.CRM;

namespace Sonluk.IDataAccess.CRM
{
    public interface ISAP_ORDER
    {
        IList<SAP_CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division);
        decimal SAP_Price(string serialNumber, string customer, string salesOrganization, string distributionChannel);
        SAP_DiscountInfo SAP_Discount(string customer);
        decimal SAP_Balance(string customer);
        string Create(SAP_SOInfo node);
       
    }
}
