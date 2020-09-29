using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_PBFZ_BZID
    {
        MES_RETURN INSERT(HR_KQ_PBFZ_BZID model);
        MES_RETURN UPDATE(HR_KQ_PBFZ_BZID model, int LB);
        HR_KQ_PBFZ_BZID_SELECT SELECT(HR_KQ_PBFZ_BZID model);
    }
}
