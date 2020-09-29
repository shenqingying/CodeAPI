using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLE_CK
    {
        private static readonly IROLE_CK mesdetaAccess = MESDataAccess.CreateROLE_CK();
        public MES_RETURN INSERT(List<MES_ROLE_CK> model)
        {
            if (model.Count > 0)
            {
                DELETE(model[0].ROLEID);
            }
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE(int ROLEID)
        {
            return mesdetaAccess.DELETE(ROLEID);
        }
        public MES_ROLE_CK_LIST SELECT(int ROLEID)
        {
            return mesdetaAccess.SELECT(ROLEID);
        }
    }
}
