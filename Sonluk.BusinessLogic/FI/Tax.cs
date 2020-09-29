using Sonluk.DAFactory;
using Sonluk.IDataAccess.FI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.FI
{
    public class Tax
    {
        private static readonly ITax detaAccess = DataAccess.CreateTax();
        public dynamic Rate(string code)
        {
            return Rate("TX","MWVS", "CN", code);
        }

        public dynamic Rate(string application, string conditionType, string departureCountry, string code)
        {
            return detaAccess.Rate(application, conditionType, departureCountry, code);
        }

    }
}
