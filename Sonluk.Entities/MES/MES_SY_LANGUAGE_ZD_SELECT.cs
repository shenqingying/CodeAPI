using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_ZD_SELECT
    {
        private List<MES_SY_LANGUAGE_ZD> _MES_SY_LANGUAGE_ZD;

        public List<MES_SY_LANGUAGE_ZD> MES_SY_LANGUAGE_ZD
        {
            get { return _MES_SY_LANGUAGE_ZD; }
            set { _MES_SY_LANGUAGE_ZD = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
