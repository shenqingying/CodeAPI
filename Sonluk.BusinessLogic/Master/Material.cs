using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Master
{
    public class Material
    {
        private static readonly IMaterial _DetaAccess = DataAccess.CreateMaterial();

        public IList<MaterialInfo> Read()
        {
            return _DetaAccess.Read(1);
        
        }

        public string Read(string serialNumber, string customer, string salesOrganization, string distributionChannel)
        {
            return null;
        }

        public IList<MaterialUnitInfo> UnitConversion(string material,string unit)
        {
            return _DetaAccess.UnitConversion(material, unit);
        }

        public IList<MaterialUnitInfo> UnitConversion(string material, string customer, string salesOrganization, string distributionChannel)
        {
            return _DetaAccess.UnitConversion(material, customer, salesOrganization, distributionChannel);
        }

        public IList<MaterialInfo> SalesOnline(string customer, string salesOrganization, string distributionChannel, string division)
        {
            return _DetaAccess.SalesOnline(customer, salesOrganization, distributionChannel, division);
        }

        public IList<MaterialInfo> Promotion(string salesOrganization, string distributionChannel, string division)
        {
            return _DetaAccess.Promotion(salesOrganization, distributionChannel, division);
        }

        public decimal Price(string serialNumber, string customer, string salesOrganization, string distributionChannel) 
        {
            return _DetaAccess.Price(serialNumber, customer, salesOrganization, distributionChannel);
        }

    }
}
