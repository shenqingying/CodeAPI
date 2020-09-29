using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_PLDH
    {
        MES_RETURN INSERT(MES_SY_PLDH model);
        MES_RETURN SELECT_COUNT(MES_SY_PLDH model);
        MES_SY_PLDH_SELECT SELECT_LIST(MES_SY_PLDH model);
        MES_SY_PLDH_SELECT SELECT(MES_SY_PLDH model);
        MES_RETURN PLDH_SBBH_INSERT(MES_SY_PLDH_SBBH model);
        MES_RETURN PLDH_SBBH_UPDATE(MES_SY_PLDH_SBBH model);
        MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(MES_SY_PLDH_SBBH model);
        MES_RETURN UPDATE(MES_SY_PLDH model);
        MES_SY_PLDH_ZJINFO_SELECT SELECT_ZJINFO(MES_SY_PLDH_ZJINFO model);
        MES_RETURN UPDATE_ZJINFO(MES_SY_PLDH_ZJINFO model);
    }
}
