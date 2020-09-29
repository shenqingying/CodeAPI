using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IWL_TT
    {
        int Create(CRM_WL_TT model);
        int Update(CRM_WL_TT model);
        IList<CRM_WL_TT> ReadByParam(CRM_WL_TT model);
        int Delete(int TTID);
    }
}
