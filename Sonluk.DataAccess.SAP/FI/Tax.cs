using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.IDataAccess.FI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.FI
{
    public class Tax:ITax
    {
        public dynamic Rate(string application,string conditionType, string departureCountry, string code)
        {
            IRfcFunction func = RFC.Function("ZTAX_RATE");
            func.SetValue("KAPPL", application);
            func.SetValue("KSCHL", conditionType);
            func.SetValue("ALAND", departureCountry);
            func.SetValue("MWSKZ", code);

            dynamic rate;
            try
            {
                RFC.Invoke(func, false);
                rate =Convert.ToDecimal(func.GetString("KBETR"));
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rate;
        }
    }
}
