using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IGoods
    {
        GoodsInfo Read(string serialNumber);

        int Create(GoodsInfo node);

        int Update(GoodsInfo node);

        IList<GoodsInfo> Type(bool available);
    }
}
