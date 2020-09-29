using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_GSZCFS
    {

        int Create(CRM_COST_GSZCFS model);
        int Update(CRM_COST_GSZCFS model);
        IList<CRM_COST_GSZCFS> ReadByParam(CRM_COST_GSZCFS model);
        int Delete(int ZCFSID);




    }
}
