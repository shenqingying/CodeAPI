using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.LE;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IScreen
    {

        IList<ScreenInfo> Read();
        ScreenInfo Read(int ID);
        int Update(ScreenInfo node);

    }
}
