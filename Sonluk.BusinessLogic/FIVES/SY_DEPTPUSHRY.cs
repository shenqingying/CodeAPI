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
    public class SY_DEPTPUSHRY
    {
        private static readonly ISY_DEPTPUSHRY _DataAccess = RMSDataAccess.CreateSY_DEPTPUSHRY();
        public MES_RETURN Create(FIVES_SY_DEPTPUSHRY model)
        {
            return _DataAccess.Create(model);
        }

        public IList<FIVES_SY_DEPTPUSHRY> Read(FIVES_SY_DEPTPUSHRY model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(FIVES_SY_DEPTPUSHRY model)
        {
            return _DataAccess.Delete(model);
        }
    }
}
