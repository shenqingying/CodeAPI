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
    public class KQ_WCDJ
    {
        private static readonly IKQ_WCDJ IKQ_WCDJdata = HRDataAccess.CreateIKQ_WCDJ();
        public MES_RETURN INSERT(HR_KQ_WCDJ model)
        {
            return IKQ_WCDJdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_WCDJ model, int LB)
        {
            return IKQ_WCDJdata.UPDATE(model, LB);
        }
        public HR_KQ_WCDJ_SELECT SELECT(HR_KQ_WCDJ model)
        {
            return IKQ_WCDJdata.SELECT(model);
        }
    }
}
