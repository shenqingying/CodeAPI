using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_STAFF_EMTYPE
    {
        private static readonly ISY_STAFF_EMTYPE _DataAccess = RMSDataAccess.CreateEMSY_STAFF_EMTYPE();

        public MES_RETURN Create(EM_SY_STAFF_EMTYPE model)
        {
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(EM_SY_STAFF_EMTYPE model)
        {
            return _DataAccess.Update(model);
        }
        public IList<EM_SY_STAFF_EMTYPE> Read(EM_SY_STAFF_EMTYPE model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(EM_SY_STAFF_EMTYPE model)
        {
            return _DataAccess.Delete(model);
        }
        public EM_SY_EMTYPE_LAY_SELECT SELECT_EMTYPE_ROLE(int STAFFID)
        {
            return _DataAccess.SELECT_EMTYPE_ROLE(STAFFID);
        }
    }
}
