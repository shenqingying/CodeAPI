using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_STAFF_DEP
    {
        private int _STAFFID;
        private int _DEPTID;
        private int _TYPEID;
        private string _STAFFNAME;
        private string _DEPTNAME;
        private string _TYPENAME;

        public int STAFFID { get => _STAFFID; set => _STAFFID = value; }
        public int DEPTID { get => _DEPTID; set => _DEPTID = value; }
        public int TYPEID { get => _TYPEID; set => _TYPEID = value; }
        public string STAFFNAME { get => _STAFFNAME; set => _STAFFNAME = value; }
        public string DEPTNAME { get => _DEPTNAME; set => _DEPTNAME = value; }
        public string TYPENAME { get => _TYPENAME; set => _TYPENAME = value; }
    }
}
