using Sonluk.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_GSKQ
    {
        HR_KQ_GSKQ_SELECT SELECT(HR_KQ_GSKQ model, int LB);
    }
}
