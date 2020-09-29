using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_STAFFKHLX
    {
        private static readonly IHG_STAFFKHLX _DataAccess = RMSDataAccess.CreateHG_STAFFKHLX();
        public int Create(CRM_HG_STAFFKHLX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_STAFFKHLX model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int STAFFKHLXID)
        {
            return _DataAccess.Delete(STAFFKHLXID);
        }
        public IList<CRM_HG_STAFFKHLX> Read()
        {
            return _DataAccess.Read();
        }
        public CRM_HG_STAFFKHLX ReadBySTAFFKHLXID(int STAFFKHLXID)
        {
            return _DataAccess.ReadBySTAFFKHLXID(STAFFKHLXID);
        }
    }
}
