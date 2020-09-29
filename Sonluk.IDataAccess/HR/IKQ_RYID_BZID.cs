using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_RYID_BZID
    {
        MES_RETURN UPDATE(HR_KQ_RYID_BZID model, int LB);
        HR_KQ_RYID_BZID_SELECT SELECT(HR_KQ_RYID_BZID model, int LB);
    }
}
