using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZS_SY_JL_QJQXJL_SELECT
    {
        private List<MES_ZS_SY_JL_QJQXJL> _MES_ZS_SY_JL_QJQXJL;
        private MES_RETURN _MES_RETURN;
        private DataTable _DATALIST;


        public List<MES_ZS_SY_JL_QJQXJL> MES_ZS_SY_JL_QJQXJL { get => _MES_ZS_SY_JL_QJQXJL; set => _MES_ZS_SY_JL_QJQXJL = value; }
        public MES_RETURN MES_RETURN { get => _MES_RETURN; set => _MES_RETURN = value; }
        public DataTable DATALIST { get => _DATALIST; set => _DATALIST = value; }
    }
}
