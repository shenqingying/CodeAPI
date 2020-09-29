using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_QJ_ERRORJL_SELECT
    {
        private List<MES_ZS_QJ_ERRORJL> _MES_ZS_QJ_ERRORJL;

        public List<MES_ZS_QJ_ERRORJL> MES_ZS_QJ_ERRORJL
        {
            get { return _MES_ZS_QJ_ERRORJL; }
            set { _MES_ZS_QJ_ERRORJL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
