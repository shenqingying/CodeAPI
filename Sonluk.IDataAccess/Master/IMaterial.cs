using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Master
{
    public interface IMaterial
    {
        IList<MaterialInfo> Read(int language);

        IList<MaterialUnitInfo> UnitConversion(string serialNumber,string unit);

        IList<MaterialUnitInfo> UnitConversion(string serialNumber, string customer, string salesOrganization, string distributionChannel);

        IList<MaterialInfo> SalesOnline(string customer, string salesOrganization, string distributionChannel, string division);

        IList<MaterialInfo> Promotion(string salesOrganization, string distributionChannel, string division);

        decimal Price(string serialNumber, string customer, string salesOrganization, string distributionChannel);
    }
}
