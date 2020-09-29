using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARMD
    {
        int Create(CRM_COST_LKAYEARMD model);
        int Update(CRM_COST_LKAYEARMD model);
        int UpdateMDSL(int LKAYEARTTID);
        IList<CRM_COST_LKAYEARMD> ReadByParam(CRM_COST_LKAYEARMD model);
        int Delete(int MDID);
        IList<CRM_COST_LKAYEARMD> ReadMDQKbyKHID(int KHID);
    }
}
