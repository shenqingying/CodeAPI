using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_RETURN
    {
        private string _MSGNO;

        public string MSGNO
        {
            get { return _MSGNO; }
            set { _MSGNO = value; }
        }
        private string _MSGNAME;

        public string MSGNAME
        {
            get { return _MSGNAME; }
            set { _MSGNAME = value; }
        }
        private string _MSGREMARK;

        public string MSGREMARK
        {
            get { return _MSGREMARK; }
            set { _MSGREMARK = value; }
        }
        private int _CJRID;

        public int CJRID
        {
            get { return _CJRID; }
            set { _CJRID = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private int _MSGID;

        public int MSGID
        {
            get { return _MSGID; }
            set { _MSGID = value; }
        }
        private int _MSGTYPE;

        public int MSGTYPE
        {
            get { return _MSGTYPE; }
            set { _MSGTYPE = value; }
        }
        private string _MSGTYPENAME;

        public string MSGTYPENAME
        {
            get { return _MSGTYPENAME; }
            set { _MSGTYPENAME = value; }
        }

        private string _XGRID;

        public string XGRID
        {
            get { return _XGRID; }
            set { _XGRID = value; }
        }
    }
}
