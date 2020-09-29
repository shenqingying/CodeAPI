using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_QJ
    {
        MES_RETURN INSERT(HR_KQ_QJ model);
        MES_RETURN UPDATE(HR_KQ_QJ model, int LB);
        HR_KQ_QJ_SELECT SELECT(HR_KQ_QJ model, int LB);
    }
}
