using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_GYS_SELECT
    {
        private List<MES_ROLE_GYS> _MES_ROLE_GYS;

        public List<MES_ROLE_GYS> MES_ROLE_GYS
        {
            get { return _MES_ROLE_GYS; }
            set { _MES_ROLE_GYS = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
