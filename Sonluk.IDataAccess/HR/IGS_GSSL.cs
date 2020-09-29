using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IGS_GSSL
    {
        MES_RETURN INSERT(HR_GS_GSSL model);
        MES_RETURN UPDATE(HR_GS_GSSL model, int LB);
        HR_GS_GSSL_SELECT SELECT(HR_GS_GSSL model);
    }
}
