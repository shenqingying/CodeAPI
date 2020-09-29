using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARLIST
    {
        int Create(CRM_COST_LKAYEARLIST model);
        int Update(CRM_COST_LKAYEARLIST model);
        IList<CRM_COST_LKAYEARLIST> ReadByParam(CRM_COST_LKAYEARLIST model);
        int Delete(int LISTID);
        int DeleteByTTID(int LKAYEARTTID);
        IList<CRM_COST_LKAYEARLIST> ReadListByKHID(int KHID, string YEAR);
    }
}
