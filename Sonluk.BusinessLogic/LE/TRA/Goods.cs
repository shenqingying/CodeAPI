using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Goods
    {
        private static readonly IGoods _DetaAccess = LETRADataAccess.CreateGoods();

        public GoodsInfo Read(string serialNumber)
        {
            return _DetaAccess.Read(serialNumber);
        }

        public int Create(GoodsInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public int Update(GoodsInfo node)
        {
            return _DetaAccess.Update(node);
        }

        public IList<GoodsInfo> Type()
        {
            return _DetaAccess.Type(true);
        }
    }
}
