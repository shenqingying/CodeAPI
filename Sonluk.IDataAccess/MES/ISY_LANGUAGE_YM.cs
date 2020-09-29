using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_LANGUAGE_YM
    {
        MES_RETURN INSERT(MES_SY_LANGUAGE_YM model, int SYLANGUAGEID);
        MES_SY_LANGUAGE_TABLEZD_SELECT SELECT_TABLEZD(MES_SY_LANGUAGE_TABLEZD model);
        MES_SY_LANGUAGE_ZD_SELECT SELECT_ZD(MES_SY_LANGUAGE_ZD model);
    }
}
