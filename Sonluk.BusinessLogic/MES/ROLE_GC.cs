using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLE_GC
    {
        private static readonly IROLE_GC mesdetaAccess = MESDataAccess.CreateROLE_GC();
        public MES_RETURN INSERT(List<MES_ROLE_GC> model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE(int STAFFID)
        {
            return mesdetaAccess.DELETE(STAFFID);
        }
    }
}
