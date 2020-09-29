using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAFYMXTSCL
    {
        int Create(CRM_COST_LKAFYMXTSCL model);
        int Update(CRM_COST_LKAFYMXTSCL model);
        IList<CRM_COST_LKAFYMXTSCL> ReadByParam(CRM_COST_LKAFYMXTSCL model);
        int Delete(int LKATSCLMXID);
        IList<CRM_COST_LKAFYMXTSCL> Read_Unconnected(CRM_COST_LKAFYMXTSCL model);


    }
}
