using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace Sonluk.DataAccess.Utility.SAP
{
    public abstract class RFC
    {
        private static readonly RfcDestination _Dest = Destination.Create("Sonluk", "30970345");

        public static IRfcFunction Function(string funcName)
        {
            return _Dest.Repository.CreateFunction(funcName);
        }

        public static bool Invoke(IRfcFunction func, bool commitWorkAndWait)
        {
            RfcSessionManager.BeginContext(_Dest);
            func.Invoke(_Dest);
            if (commitWorkAndWait)
            {
                IRfcFunction commit = CommitWorkAndWait();
                commit.Invoke(_Dest);
            }
            RfcSessionManager.BeginContext(_Dest);
            return true;
        }

        public static bool Invoke(IRfcFunction[] funcs, bool commitWorkAndWait)
        {
            RfcSessionManager.BeginContext(_Dest);
            for (int i = 0; i < funcs.Length; i++)
            {
                funcs[i].Invoke(_Dest);
                if (commitWorkAndWait)
                {
                    IRfcFunction commit = CommitWorkAndWait();
                    commit.Invoke(_Dest);
                }
            }
            RfcSessionManager.BeginContext(_Dest);
            return true;
        }

        public static string Client()
        {
            return _Dest.Client;
        }

        private static IRfcFunction CommitWorkAndWait()
        {
            IRfcFunction commit = _Dest.Repository.CreateFunction("BAPI_TRANSACTION_COMMIT");
            commit.SetValue("WAIT", "X");
            return commit;

        }

    }
}
