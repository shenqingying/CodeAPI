using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class KQ_GSKQ
    {
        private static readonly IKQ_GSKQ IKQ_GSKQdata = HRDataAccess.CreateIKQ_GSKQ();
        public HR_KQ_GSKQ_SELECT SELECT(HR_KQ_GSKQ model, int LB)
        {
            return IKQ_GSKQdata.SELECT(model, LB);
        }
    }
}
