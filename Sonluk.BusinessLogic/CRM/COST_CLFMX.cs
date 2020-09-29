using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CLFMX
    {
        private static readonly ICOST_CLFMX _DataAccess = RMSDataAccess.CreateCOST_CLFMX();

        public int Create(CRM_COST_CLFMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CLFMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CLFMX> ReadByParam(CRM_COST_CLFMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_CLFMX> ReadPart(CRM_COST_CLFMX model)
        {
            return _DataAccess.ReadPart(model);
        }
        public IList<CRM_COST_CLFMX> ReadByTTID(int CLFTTID)
        {
            return _DataAccess.ReadByTTID(CLFTTID);
        }
        public int Delete(int CLFMXID)
        {
            return _DataAccess.Delete(CLFMXID);
        }
    }
}
