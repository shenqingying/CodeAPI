using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_ZZFTT
    {
        int Create(CRM_COST_ZZFTT model);
        int Update(CRM_COST_ZZFTT model);
        IList<CRM_COST_ZZFTT> ReadByParam(CRM_COST_ZZFTT model, int STAFFID);
        IList<CRM_COST_ZZFTT> Read_KA(CRM_COST_ZZFTT model, int STAFFID);
        IList<CRM_COST_ZZFTT> Read_LKA(CRM_COST_ZZFTT model, int STAFFID);
        IList<CRM_COST_ZZFTT> ReadByCostitemid(CRM_COST_ZZFTT model);
        IList<CRM_COST_ZZFTT> Read_LKAUnconnected(CRM_COST_ZZFTT model);
        IList<CRM_COST_ZZFTT> Read_KAUnconnected(CRM_COST_ZZFTT model);
        int Delete(int TTID);
        int UpdateTBSJ(int TTID);
        IList<CRM_COST_ZZFTT> Read_Unconnected(CRM_COST_ZZFTT model);
        IList<CRM_COST_ZZFTT> Read_Unconnected2(CRM_COST_ZZFTT model);
    }
}
