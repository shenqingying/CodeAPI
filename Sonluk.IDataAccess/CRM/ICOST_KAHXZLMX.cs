using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAHXZLMX
    {
        int Create(CRM_COST_KAHXZLMX model);
        int Update(CRM_COST_KAHXZLMX model);
        int UpdateByKADTTTID(CRM_COST_KAHXZLMX model);
        IList<CRM_COST_KAHXZLMX> ReadByParam(CRM_COST_KAHXZLMX model);
        IList<CRM_COST_KAHXZLMX> ReadByTTID(int HXZLTTID);
        IList<CRM_COST_KAHXZLMX> Read_Unconnected(CRM_COST_KAHXZLMX model);
        int Delete(int HXZLMXID);
        int DeleteByKADTTTID(int KADTTTID);

    }
}
