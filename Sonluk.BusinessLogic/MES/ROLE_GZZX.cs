using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLE_GZZX
    {
        private static readonly IROLE_GZZX mesdetaAccess = MESDataAccess.CreateROLE_GZZX();
        public MES_RETURN INSERT(List<MES_SY_GZZX_LAY> model)
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

        public MES_ROLE_GZZX_SELECT_BYROLEID SELECT_BYROLEID(int ROLEID)
        {
            return mesdetaAccess.SELECT_BYROLEID(ROLEID);
        }
    }
}
