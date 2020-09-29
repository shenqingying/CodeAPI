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
    public class KQ_PBFZ
    {
        private static readonly IKQ_PBFZ KQ_PBFZdata = HRDataAccess.CreateIKQ_PBFZ();
        public MES_RETURN INSERT(HR_KQ_PBFZ model)
        {
            return KQ_PBFZdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_PBFZ model, int LB)
        {
            return KQ_PBFZdata.UPDATE(model, LB);
        }
        public HR_KQ_PBFZ_SELECT SELECT(HR_KQ_PBFZ model)
        {
            return KQ_PBFZdata.SELECT(model);
        }
    }
}
