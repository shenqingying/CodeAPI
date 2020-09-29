using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_BZ_BDID
    {
        MES_RETURN INSERT(HR_KQ_BZ_BDID model);
        MES_RETURN UPDATE(HR_KQ_BZ_BDID model, int LB);
        HR_KQ_BZ_BDID_SELECT SELECT(HR_KQ_BZ_BDID model);
    }
}
