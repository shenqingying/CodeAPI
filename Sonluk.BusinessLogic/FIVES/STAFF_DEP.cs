using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.FIVES
{
    public class STAFF_DEP
    {
        private static readonly ISTAFF_DEP _DataAccess = RMSDataAccess.CreateSTAFF_DEP();
        public MES_RETURN Create(FIVES_STAFF_DEP model)
        {
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(FIVES_STAFF_DEP model)
        {
            return _DataAccess.Update(model);
        }
        public IList<FIVES_STAFF_DEP> Read(FIVES_STAFF_DEP model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(FIVES_STAFF_DEP model)
        {
            return _DataAccess.Delete(model);
        }
    }
}
