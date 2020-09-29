using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IKQ_JQGLMX
    {
        MES_RETURN INSERT(HR_KQ_JQGLMX model);
        MES_RETURN UPDATE(HR_KQ_JQGLMX model, int LB);
        HR_KQ_JQGLMX_SELECT SELECT(HR_KQ_JQGLMX model);
        HR_KQ_JQGLMX_SELECT SELECT_REPORT(HR_KQ_JQGLMX model, int LB);
        MES_RETURN AUTO_ADD_TO_FFJLMX(HR_KQ_JQGLMX model);
    }
}
