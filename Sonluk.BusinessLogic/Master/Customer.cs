using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Master
{
    public class Customer
    {
        private static readonly ICustomer detaAccess = DataAccess.CreateCustomer();

        public CompanyInfo Read(string serialNumber)
        {
            return detaAccess.Read(Convert.ToDecimal(serialNumber).ToString("0000000000"));
        }

        public CompanyInfo Read(string date, string time)
        {
            return detaAccess.Read(date,time);
        }

        public CompanyInfo Read3(string date, string time)
        {
            return detaAccess.Read3(date, time);
        }

        public IList<SDInfo> SalesRange(string serialNumber)
        {
            return detaAccess.SalesRange(serialNumber);
        }

        public IList<CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division)
        {
            return detaAccess.ShipToParty(serialNumber, salesOrganization, distributionChannel, division);
        }

        public DiscountInfo Discount(string serialNumber)
        {
            return detaAccess.Discount(Convert.ToDecimal(serialNumber).ToString("0000000000"));
        }

        public IList<CompanyInfo> Read()
        {
            return null;
        }
    }
}
