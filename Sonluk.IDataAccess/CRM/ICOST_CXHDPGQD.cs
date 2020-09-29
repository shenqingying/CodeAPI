using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CXHDPGQD
    {

        int Create(CRM_COST_CXHDPGQD model);
        int Update(CRM_COST_CXHDPGQD model);
        IList<CRM_COST_CXHDPGQD> ReadByParam(CRM_COST_CXHDPGQD model);
        int Delete(int PGQDID);
        int DeleteByCXHDID(int CXHDID);


    }
}
