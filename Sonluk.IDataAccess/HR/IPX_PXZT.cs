using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IPX_PXZT
    {
        MES_RETURN INSERT_PXZT(HR_PX_PXZT model);
        HR_PX_PXZT_SELECT SELECT_PXZT(HR_PX_PXZT model);
        MES_RETURN UPDATE_PXZT(HR_PX_PXZT model);
        MES_RETURN INSERT_PXZT_FJ(HR_PX_PXZT model);
        HR_PX_PXZT_SELECT SELECT_PXZT_FJ(int PXZTID);
        MES_RETURN INSERT_PXZTMX(HR_PX_PXZT model);
        HR_PX_PXZT_SELECT SELECT_PXZTMX(HR_PX_PXZT model);
        MES_RETURN DELETE_PXZT(int PXZTID);
        MES_RETURN DELETE_PXZT_FJ(int FJID);
        MES_RETURN DELETE_PXZTMX(int PXZTMXID);
        HR_PX_PXZT_SELECT SELECT_PXZT_RY(HR_PX_PXZT model);
        MES_RETURN PXZT_BMRY_INSERT(HR_PX_PXZT_BMRY model);
        MES_RETURN PXZT_BMRY_UPDATE(HR_PX_PXZT_BMRY model);
        HR_PX_PXZT_BMRY_SELECT PXZT_BMRY_SELECT(HR_PX_PXZT_BMRY model);
    }
}
