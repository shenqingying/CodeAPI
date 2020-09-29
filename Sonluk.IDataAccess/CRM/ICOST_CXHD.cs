using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CXHD
    {

        int Create(CRM_COST_CXHD model);
        int Update(CRM_COST_CXHD model);
        IList<CRM_COST_CXHD> ReadByParam(CRM_COST_CXHD model, int STAFFID);
        int Delete(int CXHDID);




    }
}
