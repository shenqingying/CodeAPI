using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class ZSD_JXSKP_RETURN
    {
        private MES_RETURN _MES_RETURN;


        private List<ZSD_JXSKP> _ES_ZSD_JXSKP;
        
        public MES_RETURN MES_RETURN { get => _MES_RETURN; set => _MES_RETURN = value; }
        public List<ZSD_JXSKP> ES_ZSD_JXSKP { get => _ES_ZSD_JXSKP; set => _ES_ZSD_JXSKP = value; }
    }
}
