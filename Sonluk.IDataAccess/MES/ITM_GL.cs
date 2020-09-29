using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ITM_GL
    {
        MES_RETURN INSERT(List<MES_TM_GL> model);
        MES_RETURN DELETE_BY_SCTM(string SCTM);
        MES_TM_GL_SELECT SELECT(MES_TM_GL model);
    }
}
