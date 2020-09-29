using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CLFTT_STAFF
    {
        int Create(CRM_COST_CLFTT_STAFF model);
        int Update(CRM_COST_CLFTT_STAFF model);
        IList<CRM_COST_CLFTT_STAFF> ReadByParam(CRM_COST_CLFTT_STAFF model);
        int Delete(int ID);




    }
}
