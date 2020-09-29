using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.PS
{
    public interface INetWork
    {
        NetworkRead NetWork_READ(string AUFNR);

        string NetWork_CONFIRM(Ps_work ps_work, Ps_staff ps_staff);

        IList<PS_SXXGOA> PS_OA_XMXX(string PSPID, string POSID, string PSPIDPO, string POSIDPO);
        IList<PS_wlXX> PS_OA_wlxx(string MATNR, string MAKTX);

        IList<ZSL_PSS_OUT_NAME> PS_OA_GYSMC(string I_EBELN);

        string StaffINFO(string INITS);

        PS_ZPSFUG_Q_LJSJ NetWork_READ_main(string AUFNR);
    }
}
