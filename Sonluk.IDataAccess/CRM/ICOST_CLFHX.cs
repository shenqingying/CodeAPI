using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CLFHX
    {
        int Create(CRM_COST_CLFHX model);
        int Update(CRM_COST_CLFHX model);
        IList<CRM_COST_CLFHX> ReadByParam(CRM_COST_CLFHX model);
        int Delete(int CLFHXID);
    }
}
