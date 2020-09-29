using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.OA
{
    public class FlowLock
    {
        private int _Lock;

        public FlowLock(int status) {
            _Lock = status;
        }

        public int Lock
        {
            get { return _Lock; }
            set { _Lock = value; }
        }
    }
}
