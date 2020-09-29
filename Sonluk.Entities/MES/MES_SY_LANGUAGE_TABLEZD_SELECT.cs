using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_TABLEZD_SELECT
    {
        private List<MES_SY_LANGUAGE_TABLEZD> _MES_SY_LANGUAGE_TABLEZD;

        public List<MES_SY_LANGUAGE_TABLEZD> MES_SY_LANGUAGE_TABLEZD
        {
            get { return _MES_SY_LANGUAGE_TABLEZD; }
            set { _MES_SY_LANGUAGE_TABLEZD = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
