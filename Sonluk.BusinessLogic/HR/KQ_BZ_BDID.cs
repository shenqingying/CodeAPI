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
    public class KQ_BZ_BDID
    {
        private static readonly IKQ_BZ_BDID IKQ_BZ_BDIDdata = HRDataAccess.CreateIKQ_BZ_BDID();
        public MES_RETURN INSERT(HR_KQ_BZ_BDID model)
        {
            return IKQ_BZ_BDIDdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_BZ_BDID model, int LB)
        {
            return IKQ_BZ_BDIDdata.UPDATE(model, LB);
        }
        public HR_KQ_BZ_BDID_SELECT SELECT(HR_KQ_BZ_BDID model)
        {
            return IKQ_BZ_BDIDdata.SELECT(model);
        }
    }
}
