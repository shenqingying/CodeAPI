using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.FI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.FI
{
    public class Company
    {
        private static readonly ICompany detaAccess = DataAccess.CreateCompany();
        public CompanyInfo Read(string serialNumber)
        {
            return detaAccess.Read(serialNumber);
        }
    }
}
