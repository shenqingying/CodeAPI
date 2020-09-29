using Sonluk.Entities.KQ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.KQ
{
    public interface IKQinfo
    {
        KQINFO getKQINFO(string date);
        string StaffCardID(string cardno);
        string GET_STAFFNAME_BYGH(string GH);
        HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model);
    }
}
