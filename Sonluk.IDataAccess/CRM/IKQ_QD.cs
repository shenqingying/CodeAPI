using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_QD
    {
        int Create(CRM_KQ_QD model);
        int Update(CRM_KQ_QD model);
        CRM_KQ_QD ReadByKQQDID(int KQQDID);
        IList<CRM_KQ_QD> ReadByQDLXandQDGSID(int QDLX, int QDGSID);
        IList<CRM_KQ_QD> ReadYCQD_ByDATE(string QDRQ, int SXB, int STAFFID);
        int Delete(int KQQDID);
        IList<string[]> Verify_QD(int STAFFID, string ED, string JD, double WXRC);

        int ReadQD_COUNTS(CRM_KQ_QD model);

    }
}
