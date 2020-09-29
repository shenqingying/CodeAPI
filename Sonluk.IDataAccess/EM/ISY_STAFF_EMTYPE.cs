using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_STAFF_EMTYPE
    {
        MES_RETURN Create(EM_SY_STAFF_EMTYPE model);
        MES_RETURN Update(EM_SY_STAFF_EMTYPE model);
        IList<EM_SY_STAFF_EMTYPE> ReadByEMTYPEMS(int staffid, string typems);
        IList<EM_SY_STAFF_EMTYPE> Read(EM_SY_STAFF_EMTYPE model);
        MES_RETURN Delete(EM_SY_STAFF_EMTYPE model);
        EM_SY_EMTYPE_LAY_SELECT SELECT_EMTYPE_ROLE(int STAFFID);
    }
}
