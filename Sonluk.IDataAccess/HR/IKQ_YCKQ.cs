using Sonluk.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_YCKQ
    {
        HR_KQ_YCKQ_SELECT SELECT(HR_KQ_YCKQ model);
    }
}
