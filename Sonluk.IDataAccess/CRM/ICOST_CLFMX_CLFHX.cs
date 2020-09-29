using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CLFMX_CLFHX
    {
        int Create(CRM_COST_CLFMX_CLFHX model);
        int Update(CRM_COST_CLFMX_CLFHX model);
        IList<CRM_COST_CLFMX_CLFHX> ReadByParam(CRM_COST_CLFMX_CLFHX model);
        IList<CRM_COST_CLFMX_CLFHX> ReadByCLFHXID(int CLFHXID);
        IList<CRM_COST_CLFMX_CLFHX> ReadByCLFMXID(int CLFMXID);
        int Delete(CRM_COST_CLFMX_CLFHX model);
        int DeleteByCLFHXID(int CLFHXID);
        
    }
}
