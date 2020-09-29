using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_ZZFMX
    {
        int Create(CRM_COST_ZZFMX model);
        int Update(CRM_COST_ZZFMX model);
        IList<CRM_COST_ZZFMX> ReadByParam(CRM_COST_ZZFMX model);
        int Delete(int MXID);
    }
}
