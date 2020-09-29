using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_MDBSHX
    {
        int Create(CRM_COST_MDBSHX model);
        int Update(CRM_COST_MDBSHX model);
        IList<CRM_COST_MDBSHX> ReadByParam(CRM_COST_MDBSHX model, int STAFFID);
        int Delete(int MDBSHXID);
        IList<CRM_COST_MDBSHX> Read_Unconnected(CRM_COST_MDBSHX model);


    }
}
