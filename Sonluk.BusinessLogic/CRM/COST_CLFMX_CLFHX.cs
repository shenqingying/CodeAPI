using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CLFMX_CLFHX
    {
        private static readonly ICOST_CLFMX_CLFHX _DataAccess = RMSDataAccess.CreateCOST_CLFMX_CLFHX();

        public int Create(CRM_COST_CLFMX_CLFHX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CLFMX_CLFHX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CLFMX_CLFHX> ReadByParam(CRM_COST_CLFMX_CLFHX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_CLFMX_CLFHX> ReadByCLFHXID(int CLFHXID)
        {
            return _DataAccess.ReadByCLFHXID(CLFHXID);
        }
        public IList<CRM_COST_CLFMX_CLFHX> ReadByCLFMXID(int CLFMXID)
        {
            return _DataAccess.ReadByCLFMXID(CLFMXID);
        }
        public int Delete(CRM_COST_CLFMX_CLFHX model)
        {
            return _DataAccess.Delete(model);
        }
        public int DeleteByCLFHXID(int CLFHXID)
        {
            return _DataAccess.DeleteByCLFHXID(CLFHXID);
        }
    }
}
