using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KADTTT
    {
        int Create(CRM_COST_KADTTT model);
        int Update(CRM_COST_KADTTT model);
        int UpdateCost(int KADTTTID);
        IList<CRM_COST_KADTTT> ReadByParam(CRM_COST_KADTTT model, int STAFFID);
        IList<CRM_COST_KADTTT> Read_Unconnected(CRM_COST_KADTTT model);
        int Delete(int KADTTTID);


    }
}
