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
    public class KQ_QJ
    {
        private static readonly IKQ_QJ IKQ_QJdata = HRDataAccess.CreateIKQ_QJ();
        public MES_RETURN INSERT(HR_KQ_QJ model)
        {
            return IKQ_QJdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_QJ model, int LB)
        {
            return IKQ_QJdata.UPDATE(model, LB);
        }
        public HR_KQ_QJ_SELECT SELECT(HR_KQ_QJ model, int LB)
        {
            return IKQ_QJdata.SELECT(model, LB);
        }
    }
}
