using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FI
{
    public interface ITax
    {
        dynamic Rate(string application, string conditionType, string departureCountry, string code);
    }
}
