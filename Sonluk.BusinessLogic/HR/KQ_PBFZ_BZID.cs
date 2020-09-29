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
    public class KQ_PBFZ_BZID
    {
        private static readonly IKQ_PBFZ_BZID IKQ_PBFZ_BZIDdata = HRDataAccess.CreateIKQ_PBFZ_BZID();
        public MES_RETURN INSERT(HR_KQ_PBFZ_BZID model)
        {
            return IKQ_PBFZ_BZIDdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_PBFZ_BZID model, int LB)
        {
            return IKQ_PBFZ_BZIDdata.UPDATE(model, LB);
        }
        public HR_KQ_PBFZ_BZID_SELECT SELECT(HR_KQ_PBFZ_BZID model)
        {
            return IKQ_PBFZ_BZIDdata.SELECT(model);
        }
    }
}
