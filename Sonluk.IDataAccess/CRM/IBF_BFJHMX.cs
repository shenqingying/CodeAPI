using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBF_BFJHMX
    {
        int Create(CRM_BF_BFJHMX model);
        int Update(CRM_BF_BFJHMX model);
        int Delete(CRM_BF_BFJHMX model);
        IList<CRM_BF_BFJHMXList> ReadbyBFJHID(int BFJHID);
    }
}
