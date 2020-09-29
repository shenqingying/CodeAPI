using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.Master;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Master
{
    public class Vendor
    {
        private static readonly IVendor detaAccess = DataAccess.CreateVendor();

        public CompanyInfo Read(string serialNumber) 
        {
            return detaAccess.Read(serialNumber);
        }
    }
}
