using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Unit
    {
        private static readonly IUnit _DetaAccess = LETRADataAccess.CreateUnit();

        public IList<UnitInfo> Read()
        {
            return _DetaAccess.Read(true);
        }

        public UnitInfo Read(int ID)
        {
            return _DetaAccess.Read(ID);
        }

        public int Create(UnitInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public int Update(GoodsInfo node)
        {
            return _DetaAccess.Update(node);
        }

        public int Delete(int ID)
        {
            return _DetaAccess.Delete(ID);
        }
    }
}
