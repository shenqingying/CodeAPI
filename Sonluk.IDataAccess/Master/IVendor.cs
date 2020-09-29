using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Master
{
    public interface IVendor
    {
        CompanyInfo Read(string serialNumber);
    }
}
