using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLR_GZZX_GW
    {
        private static readonly IROLR_GZZX_GW mesdetaAccess = MESDataAccess.CreateROLR_GZZX_GW();
        public MES_RETURN INSERT(List<MES_ROLR_GZZX_GW> model)
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
        public MES_ROLR_GZZX_GW_LIST SELECT(int ROLEID)
        {
            return mesdetaAccess.SELECT(ROLEID);
        }
    }
}
