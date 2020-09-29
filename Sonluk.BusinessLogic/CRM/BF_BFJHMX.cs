using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BF_BFJHMX
    {
        private static readonly IBF_BFJHMX _DataAccess_BFJH = RMSDataAccess.CreateBF_BFJHMX();
        public int Create(CRM_BF_BFJHMX model)
        {
            return _DataAccess_BFJH.Create(model);
        }
        public int Update(CRM_BF_BFJHMX model)
        {
            return _DataAccess_BFJH.Update(model);
        }
        public int Delete(CRM_BF_BFJHMX model)
        {
            return _DataAccess_BFJH.Delete(model);
        }
        public IList<CRM_BF_BFJHMXList> ReadbyBFJHID(int BFJHID)
        {
            return _DataAccess_BFJH.ReadbyBFJHID(BFJHID);
        }
    }
}
