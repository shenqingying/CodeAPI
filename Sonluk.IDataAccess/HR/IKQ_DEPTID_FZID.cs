using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_DEPTID_FZID
    {
        MES_RETURN UPDATE(HR_KQ_DEPTID_FZID model);
        HR_KQ_DEPTID_FZID_SELECT SELECT(HR_KQ_DEPTID_FZID model, int LB);
    }
}
