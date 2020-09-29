using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CLFMX
    {
        int Create(CRM_COST_CLFMX model);
        int Update(CRM_COST_CLFMX model);
        IList<CRM_COST_CLFMX> ReadByParam(CRM_COST_CLFMX model);
        IList<CRM_COST_CLFMX> ReadPart(CRM_COST_CLFMX model);
        IList<CRM_COST_CLFMX> ReadByTTID(int CLFTTID);
        int Delete(int CLFMXID);
    }
}
