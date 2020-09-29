using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_GYS
    {
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private string _GYS;

        public string GYS
        {
            get { return _GYS; }
            set { _GYS = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
    }
}
