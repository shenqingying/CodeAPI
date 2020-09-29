using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_MDBS
    {
        int Create(CRM_COST_MDBS model);
        int Update(CRM_COST_MDBS model);
        IList<CRM_COST_MDBS> ReadByParam(CRM_COST_MDBS model, int STAFFID);
        IList<CRM_COST_MDBS> Read_Unconnected(CRM_COST_MDBS model, int STAFFID);
        int Delete(int MDBSID);



    }
}
