﻿using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface ICOST_JXSHXDJMX
    {
        int Create(CRM_COST_JXSHXDJMX model);
        int Update(CRM_COST_JXSHXDJMX model);
        IList<CRM_COST_JXSHXDJMX> ReadByParam(CRM_COST_JXSHXDJMX model);

        int Delete(int HXDJMXID);
    }
}
