using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IFB_QMP
    {
        MES_RETURN INSERT(DataTable dt, int LB);
        MES_RETURN INSERT_D(DataTable dt);
        MES_FB_QMP_SELECT SELECT(MES_FB_QMP model, int LB);
        MES_FB_QMP_D_SELECT SELECT_D(MES_FB_QMP_D model, int LB);
        MES_RETURN UPDATE(MES_FB_QMP model, int LB);
        MES_RETURN INSERT_TM(MES_FB_QMP_TM model);
    }
}
