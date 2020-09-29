using Sonluk.Entities.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MM
{
    public interface IPurchasingGroup
    {
        PurchasingGroupInfo Read(string serialNumber);
    }
}
