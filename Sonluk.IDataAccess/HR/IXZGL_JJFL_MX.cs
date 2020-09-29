using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_JJFL_MX
    {
        MES_RETURN INSERT(HR_XZGL_JJFL_MX model, DataTable RYLIST);
        MES_RETURN UPDATE(HR_XZGL_JJFL_MX model, int LB);
        HR_XZGL_JJFL_MX_SELECT SELECT(HR_XZGL_JJFL_MX model);
    }
}
