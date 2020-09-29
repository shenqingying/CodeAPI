using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class KQ_YCKQ
    {
        private static readonly IKQ_YCKQ IKQ_YCKQdata = HRDataAccess.CreateIKQ_YCKQ();
        public HR_KQ_YCKQ_SELECT SELECT(HR_KQ_YCKQ model)
        {
            return IKQ_YCKQdata.SELECT(model);
        }
    }
}
