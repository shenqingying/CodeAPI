﻿using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_ZZFTT_KAHXDJMX
    {
        int Create(CRM_COST_ZZFTT_KAHXDJMX model);
        IList<CRM_COST_ZZFTT_KAHXDJMX> ReadByParam(CRM_COST_ZZFTT_KAHXDJMX model);
        int Delete(int HXDJMXID, int TTID);
        int DeleteByHXDJMXID(int HXDJMXID);

    }
}
