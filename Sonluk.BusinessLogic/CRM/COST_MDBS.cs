﻿using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sonluk.BusinessLogic.CRM
{
    public class COST_MDBS
    {
        private static readonly ICOST_MDBS _DataAccess = RMSDataAccess.CreateCOST_MDBS();


        public int Create(CRM_COST_MDBS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_MDBS model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_MDBS> ReadByParam(CRM_COST_MDBS model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public IList<CRM_COST_MDBS> Read_Unconnected(CRM_COST_MDBS model, int STAFFID)
        {
            return _DataAccess.Read_Unconnected(model, STAFFID);
        }
        public int Delete(int MDBSID)
        {
            return _DataAccess.Delete(MDBSID);
        }




    }
}
