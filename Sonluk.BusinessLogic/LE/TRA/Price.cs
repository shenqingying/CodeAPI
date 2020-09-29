using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Price
    {
        private static readonly IPrice _DetaAccess = LETRADataAccess.CreatePrice();

        public IList<PriceInfo> Read(int routeID) 
        {
            return _DetaAccess.Read(routeID);
        }

        public int Create(IList<PriceInfo> nodes)
        {
            int ID = 0;
            foreach (PriceInfo node in nodes)
            {
                ID = Create(node);
            }
            return ID;
        }

        public int Create(PriceInfo node)
        {
            if (node.UnitID == 0)
            {
                node.UnitID = 1;
                node.Unit = "KG";
            }
            return _DetaAccess.Create(node);
        }

        public int Delete(int routeID)
        {
            return _DetaAccess.Delete(routeID);
        }
    }
}
