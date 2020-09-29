using Sonluk.Entities.KQ;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_KQINFO
    {
        int SELECT_MAX();
        MES_RETURN INSERT(HR_KQ_KQINFO model);
        HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model);
    }
}
