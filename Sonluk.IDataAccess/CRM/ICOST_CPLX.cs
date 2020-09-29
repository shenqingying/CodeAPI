using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CPLX
    {

        int Create(CRM_COST_CPLX model);
        int Update(CRM_COST_CPLX model);
        IList<CRM_COST_CPLX> ReadByParam(CRM_COST_CPLX model);
        int Delete(int CPLXID);






    }
}
