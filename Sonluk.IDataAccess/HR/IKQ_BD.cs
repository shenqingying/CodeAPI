using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_BD
    {
        MES_RETURN INSERT(HR_KQ_BD model);
        MES_RETURN UPDATE(HR_KQ_BD model, int LB);
        HR_KQ_BD_SELECT SELECT(HR_KQ_BD model);
    }
}
