using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_SPECS_PERFOR
    {
        MES_DCDXNSZ_SELECT SELECT(MES_DCDXNSZ_SEARCH model);
        MES_RETURN UPDATE(MES_DCDXNSZ model);
        MES_RETURN INSERT(MES_DCDXNSZ model);
        MES_RETURN COVER(MES_DCDXNSZ model);
        MES_RETURN DELETE(int RI);
        MES_RETURN MCOVER(List<MES_DCDXNSZ> modelList);
    }
}
