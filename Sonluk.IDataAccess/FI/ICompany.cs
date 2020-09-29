using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FI
{
    public interface ICompany
    {
        CompanyInfo Read(string serialNumber);
    }
}
