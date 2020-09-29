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
    public class KQ_RYID_BZID
    {
        private static readonly IKQ_RYID_BZID IKQ_RYID_BZIDdata = HRDataAccess.CreateIKQ_RYID_BZID();
        public MES_RETURN UPDATE(HR_KQ_RYID_BZID model, int LB)
        {
            return IKQ_RYID_BZIDdata.UPDATE(model, LB);
        }
        public HR_KQ_RYID_BZID_SELECT SELECT(HR_KQ_RYID_BZID model, int LB)
        {
            return IKQ_RYID_BZIDdata.SELECT(model, LB);
        }
    }
}
