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
    public class SY_STAFFIDBINDPB
    {
        private static readonly ISY_STAFFIDBINDPB _DataAccess = RMSDataAccess.CreateEMSY_STAFFIDBINDPB();

        public MES_RETURN Create(EM_SY_STAFFIDBINDPB model)
        {
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(EM_SY_STAFFIDBINDPB model)
        {
            return _DataAccess.Update(model);
        }
        public IList<EM_SY_STAFFIDBINDPB> Read(EM_SY_STAFFIDBINDPB model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(EM_SY_STAFFIDBINDPB model)
        {
            return _DataAccess.Delete(model);
        }
    }
}
