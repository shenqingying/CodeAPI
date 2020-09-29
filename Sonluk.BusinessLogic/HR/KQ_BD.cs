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
    public class KQ_BD
    {
        private static readonly IKQ_BD IKQ_BDdata = HRDataAccess.CreateIKQ_BD();
        public MES_RETURN INSERT(HR_KQ_BD model)
        {
            return IKQ_BDdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_BD model, int LB)
        {
            return IKQ_BDdata.UPDATE(model, LB);
        }
        public HR_KQ_BD_SELECT SELECT(HR_KQ_BD model)
        {
            return IKQ_BDdata.SELECT(model);
        }
    }
}
