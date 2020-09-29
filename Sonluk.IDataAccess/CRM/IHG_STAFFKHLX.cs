using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_STAFFKHLX
    {
        int Create(CRM_HG_STAFFKHLX model);
        int Update(CRM_HG_STAFFKHLX model);
        int Delete(int STAFFKHLXID);
        IList<CRM_HG_STAFFKHLX> Read();
        CRM_HG_STAFFKHLX ReadBySTAFFKHLXID(int STAFFKHLXID);
    }
}
