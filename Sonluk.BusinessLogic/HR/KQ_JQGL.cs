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
    public class KQ_JQGL
    {
        private static readonly IKQ_JQGL IKQ_JQGLdata = HRDataAccess.CreateKQ_JQGL();
        public MES_RETURN INSERT(HR_KQ_JQGL model)
        {
            return IKQ_JQGLdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_JQGL model, int LB)
        {
            return IKQ_JQGLdata.UPDATE(model, LB);
        }
        public HR_KQ_JQGL_SELECT SELECT(HR_KQ_JQGL model)
        {
            return IKQ_JQGLdata.SELECT(model);
        }
    }
}
