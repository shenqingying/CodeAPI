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
    public class KQ_JQGLMX
    {
        private static readonly IKQ_JQGLMX IKQ_JQGLMXdata = HRDataAccess.CreateKQ_JQGLMX();
        public MES_RETURN INSERT(HR_KQ_JQGLMX model)
        {
            return IKQ_JQGLMXdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_KQ_JQGLMX model, int LB)
        {
            return IKQ_JQGLMXdata.UPDATE(model, LB);
        }
        public HR_KQ_JQGLMX_SELECT SELECT(HR_KQ_JQGLMX model)
        {
            return IKQ_JQGLMXdata.SELECT(model);
        }
        public HR_KQ_JQGLMX_SELECT SELECT_REPORT(HR_KQ_JQGLMX model, int LB)
        {
            return IKQ_JQGLMXdata.SELECT_REPORT(model, LB);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_KQ_JQGLMX model)
        {
            return IKQ_JQGLMXdata.AUTO_ADD_TO_FFJLMX(model);
        }
    }
}
