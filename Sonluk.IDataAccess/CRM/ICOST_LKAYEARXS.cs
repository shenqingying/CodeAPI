using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARXS
    {
        int Create(CRM_COST_LKAYEARXS model);
        int Update(CRM_COST_LKAYEARXS model);
        IList<CRM_COST_LKAYEARXS> ReadByParam(CRM_COST_LKAYEARXS model);
        int Delete(int XSID);
        int UpdateSonlukXS(int model);
    }
}
