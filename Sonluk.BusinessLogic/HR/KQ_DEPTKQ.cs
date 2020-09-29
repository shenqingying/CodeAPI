using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class KQ_DEPTKQ
    {
        private static readonly IKQ_DEPTKQ IKQ_DEPTKQdata = HRDataAccess.CreateIKQ_DEPTKQ();
        public MES_RETURN INSERT(HR_KQ_DEPTKQ model)
        {
            return IKQ_DEPTKQdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_DEPTKQ model, int LB)
        {
            return IKQ_DEPTKQdata.UPDATE(model, LB);
        }
        public HR_KQ_DEPTKQ_SELECT SELECT(HR_KQ_DEPTKQ model, int LB)
        {
            return IKQ_DEPTKQdata.SELECT(model, LB);
        }
    }
}
