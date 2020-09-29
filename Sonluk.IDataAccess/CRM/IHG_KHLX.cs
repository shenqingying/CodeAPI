using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.CRM;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_KHLX
    {
        int Create(int STAFFKHLXID, int DICID);
        IList<CRM_HG_KHLXList> Read(int STAFFKHLXID, int DICID);
        int Delete(int STAFFKHLXID, int DICID);
    }
}
