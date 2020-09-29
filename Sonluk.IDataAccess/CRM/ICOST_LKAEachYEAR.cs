using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAEachYEAR
    {
        int Create(CRM_COST_LKAEachYEAR model);
        int UpdateByTTID(int LKAYEARTTID);
        IList<CRM_COST_LKAEachYEAR> ReadByParam(CRM_COST_LKAEachYEAR model);
        int DeleteByTTID(int LKAYEARTTID);


    }
}
