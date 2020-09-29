using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class ZSD_JXSKP
    {
        string _KUNNR;
        string _MATNR;
        string _KPJE;
        string _KPSL;
        string _ZHWGG1;

        public string KPSL { get => _KPSL; set => _KPSL = value; }
        public string KPJE { get => _KPJE; set => _KPJE = value; }
        public string MATNR { get => _MATNR; set => _MATNR = value; }
        public string KUNNR { get => _KUNNR; set => _KUNNR = value; }
        public string ZHWGG1 { get => _ZHWGG1; set => _ZHWGG1 = value; }
    }
}
