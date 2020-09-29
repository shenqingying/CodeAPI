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
    public class KQ_DEPTID_FZID
    {
        private static readonly IKQ_DEPTID_FZID IKQ_DEPTID_FZIDdata = HRDataAccess.CreateIKQ_DEPTID_FZID();
        public MES_RETURN UPDATE(HR_KQ_DEPTID_FZID model)
        {
            return IKQ_DEPTID_FZIDdata.UPDATE(model);
        }
        public HR_KQ_DEPTID_FZID_SELECT SELECT(HR_KQ_DEPTID_FZID model, int LB)
        {
            return IKQ_DEPTID_FZIDdata.SELECT(model, LB);
        }
    }
}
