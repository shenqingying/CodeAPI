﻿using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAHXDJMX
    {
        private static readonly ICOST_LKAHXDJMX _DataAccess = RMSDataAccess.CreateCOST_LKAHXDJMX();

        public int Create(CRM_COST_LKAHXDJMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAHXDJMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAHXDJMX> ReadByParam(CRM_COST_LKAHXDJMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int HXDJMXID)
        {
            return _DataAccess.Delete(HXDJMXID);
        }






    }
}
