using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLE_RY_ASSEMBLE
    {
        private static readonly IROLE_RY_ASSEMBLE mesdetaAccess = MESDataAccess.CreateROLE_RY_ASSEMBLE();
        public MES_RETURN INSERT(List<MES_ROLE_RY_ASSEMBLE> model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE(int STAFFID)
        {
            return mesdetaAccess.DELETE(STAFFID);
        }
    }
}
