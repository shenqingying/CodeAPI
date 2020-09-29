using Sonluk.Entities.Master;
using Sonluk.Entities.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Master
{
    public interface ICustomer
    {
        CompanyInfo Read(string serialNumber);

        CompanyInfo Read(string date, string time);

        CompanyInfo Read3(string date, string time);

        IList<SDInfo> SalesRange(string serialNumber);

        IList<CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division);

        DiscountInfo Discount(string serialNumber);
    }
}
