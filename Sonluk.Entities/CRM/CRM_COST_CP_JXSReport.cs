using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_COST_CP_JXSReport
    {

        string _YWYNAME;
        int _JXSID;
        string _JXSNAME;
        string _JXSSAPSN;
        string _HTYEAR;
        string _SAPCP;
        string _CPMC;
        string _CPFL;
        string _CCJXS;
        string _THISYEARXLYG;
        string _KPJE;
        string _KPSL;

        public string KPSL { get => _KPSL; set => _KPSL = value; }
        public string KPJE { get => _KPJE; set => _KPJE = value; }
        public string THISYEARXLYG { get => _THISYEARXLYG; set => _THISYEARXLYG = value; }
        public string CCJXS { get => _CCJXS; set => _CCJXS = value; }
        public string CPFL { get => _CPFL; set => _CPFL = value; }
        public string CPMC { get => _CPMC; set => _CPMC = value; }
        public string SAPCP { get => _SAPCP; set => _SAPCP = value; }
        public string HTYEAR { get => _HTYEAR; set => _HTYEAR = value; }
        public string JXSSAPSN { get => _JXSSAPSN; set => _JXSSAPSN = value; }
        public string JXSNAME { get => _JXSNAME; set => _JXSNAME = value; }
        public int JXSID { get => _JXSID; set => _JXSID = value; }
        public string YWYNAME { get => _YWYNAME; set => _YWYNAME = value; }
    }
}
