using Sonluk.DAFactory;
using Sonluk.Entities.PS;
using Sonluk.IDataAccess.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.PS
{
    public class NetWork
    {
        private static readonly INetWork detaAccess = PSDataAccess.CreateNetWork();

        public NetworkRead read(string aufnr)
        {
            return detaAccess.NetWork_READ(aufnr);
        }

        public string confirm(Ps_work ps_work, Ps_staff ps_staff)
        {
            return detaAccess.NetWork_CONFIRM(ps_work, ps_staff);
        }

        public IList<PS_SXXGOA> readXMXX(string PSPID, string POSID, string PSPIDPO, string POSIDPO)
        {
            return detaAccess.PS_OA_XMXX(PSPID, POSID, PSPIDPO, POSIDPO);
        }

        public IList<PS_wlXX> readwlXX(string MATNR, string MAKTX)
        {
            return detaAccess.PS_OA_wlxx(MATNR, MAKTX);
        }

        public IList<ZSL_PSS_OUT_NAME> PS_OA_GYSMC(string I_EBELN)
        {
            return detaAccess.PS_OA_GYSMC(I_EBELN);
        }

        public string StaffINFO(string INITS)
        {
            return detaAccess.StaffINFO(INITS);
        }

        public PS_ZPSFUG_Q_LJSJ NetWork_READ_main(string AUFNR)
        {
            return detaAccess.NetWork_READ_main(AUFNR);
        }
    }
}
