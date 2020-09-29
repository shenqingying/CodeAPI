﻿using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAHXZLMD
    {
        private static readonly ICOST_LKAHXZLMD _DataAccess = RMSDataAccess.CreateCOST_LKAHXZLMD();

        public int Create(CRM_COST_LKAHXZLMD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAHXZLMD model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAHXZLMD> ReadByParam(CRM_COST_LKAHXZLMD model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int HXZLMDMXID)
        {
            return _DataAccess.Delete(HXZLMDMXID);
        }






    }
}
