using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXZLTT
    {
        int Create(CRM_COST_LKAHXZLTT model);
        int Update(CRM_COST_LKAHXZLTT model);
        IList<CRM_COST_LKAHXZLTT> ReadByParam(CRM_COST_LKAHXZLTT model, int STAFFID);
        int Delete(int HXZLTTID);
        CRM_COST_LKAHXZLTT ReadTTGLinfo(CRM_COST_LKAHXZLTT model);
        IList<CRM_COST_HXZLTT> ReadByPublic(CRM_COST_HXZLTT model, int STAFFID);



    }
}
