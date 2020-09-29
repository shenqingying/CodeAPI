using Sonluk.DAFactory;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MM
{
    public class PurchasingGroup
    {
        private static readonly IPurchasingGroup detaAccess = DataAccess.CreatePurchasingGroup();

        public PurchasingGroupInfo Read(string serialNumber)
        {
            return detaAccess.Read(serialNumber);
        }
    }
}
