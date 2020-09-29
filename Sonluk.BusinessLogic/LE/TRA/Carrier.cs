using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Carrier
    {
        private static readonly ICarrier _DetaAccess = LETRADataAccess.CreateCarrier();

        public IList<CompanyInfo> Read()
        {
            return _DetaAccess.Read(true);
        }

        public CompanyInfo Read(int ID)
        {
            return _DetaAccess.Read(ID);
        }
    }
}
