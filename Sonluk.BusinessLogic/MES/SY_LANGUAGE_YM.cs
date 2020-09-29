using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_LANGUAGE_YM
    {
        private static readonly ISY_LANGUAGE_YM ISY_LANGUAGE_YMdata = MESDataAccess.CreateISY_LANGUAGE_YM();
        public MES_RETURN INSERT(MES_SY_LANGUAGE_YM model, int SYLANGUAGEID)
        {
            return ISY_LANGUAGE_YMdata.INSERT(model, SYLANGUAGEID);
        }
        public MES_SY_LANGUAGE_TABLEZD_SELECT SELECT_TABLEZD(MES_SY_LANGUAGE_TABLEZD model)
        {
            return ISY_LANGUAGE_YMdata.SELECT_TABLEZD(model);
        }
        public MES_SY_LANGUAGE_ZD_SELECT SELECT_ZD(MES_SY_LANGUAGE_ZD model)
        {
            return ISY_LANGUAGE_YMdata.SELECT_ZD(model);
        }
    }
}
