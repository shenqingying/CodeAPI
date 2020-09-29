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
    public class KQ_BZ
    {
        private static readonly IKQ_BZ IKQ_BZdata = HRDataAccess.CreateIKQ_BZ();
        public MES_RETURN INSERT(HR_KQ_BZ model)
        {
            return IKQ_BZdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_BZ model, int LB)
        {
            return IKQ_BZdata.UPDATE(model, LB);
        }
        public HR_KQ_BZ_SELECT SELECT(HR_KQ_BZ model)
        {
            return IKQ_BZdata.SELECT(model);
        }
    }
}
