using Sonluk.Entities.MES;
using Sonluk.Entities.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.QM
{
    public class ZSL_QMFM_012_SELECT
    {
        private List<ZSL_QMS012> _ET_YHINFO;

        public List<ZSL_QMS012> ET_YHINFO
        {
            get { return _ET_YHINFO; }
            set { _ET_YHINFO = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private string _IV_YHNO;

        public string IV_YHNO
        {
            get { return _IV_YHNO; }
            set { _IV_YHNO = value; }
        }
        private string _IV_VBELN;

        public string IV_VBELN
        {
            get { return _IV_VBELN; }
            set { _IV_VBELN = value; }
        }
        private string _IV_BOX;

        public string IV_BOX
        {
            get { return _IV_BOX; }
            set { _IV_BOX = value; }
        }
        private string _IS_DATE_LOW;

        public string IS_DATE_LOW
        {
            get { return _IS_DATE_LOW; }
            set { _IS_DATE_LOW = value; }
        }
        private string _IS_DATE_HIGH;

        public string IS_DATE_HIGH
        {
            get { return _IS_DATE_HIGH; }
            set { _IS_DATE_HIGH = value; }
        }
        private string _IS_TJDATE_LOW;

        public string IS_TJDATE_LOW
        {
            get { return _IS_TJDATE_LOW; }
            set { _IS_TJDATE_LOW = value; }
        }
        private string _IS_TJDATE_HIGH;

        public string IS_TJDATE_HIGH
        {
            get { return _IS_TJDATE_HIGH; }
            set { _IS_TJDATE_HIGH = value; }
        }
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
        private string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
    }
}
