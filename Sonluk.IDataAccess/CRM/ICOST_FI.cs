﻿using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_FI
    {
        int Create(CRM_COST_FI model);
        int Update(CRM_COST_FI model);
        IList<CRM_COST_FI> ReadByParam(CRM_COST_FI model);
        int Delete(int CWHSBH);




    }
}
