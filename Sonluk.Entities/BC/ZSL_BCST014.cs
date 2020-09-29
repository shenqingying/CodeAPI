using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ZSL_BCST014
    {
        string _VBELN;

        public string VBELN
        {
            get { return _VBELN; }
            set { _VBELN = value; }
        }
        string _POSNR;

        public string POSNR
        {
            get { return _POSNR; }
            set { _POSNR = value; }
        }
        string _MATNR;

        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }
        string _MAKTX;

        public string MAKTX
        {
            get { return _MAKTX; }
            set { _MAKTX = value; }
        }
        decimal _ORMNG;

        public decimal ORMNG
        {
            get { return _ORMNG; }
            set { _ORMNG = value; }
        }
        string _VRKME;

        public string VRKME
        {
            get { return _VRKME; }
            set { _VRKME = value; }
        }
        string _SONUM;

        public string SONUM
        {
            get { return _SONUM; }
            set { _SONUM = value; }
        }
        string _SOBKZ;

        public string SOBKZ
        {
            get { return _SOBKZ; }
            set { _SOBKZ = value; }
        }
        string _CHARG;

        public string CHARG
        {
            get { return _CHARG; }
            set { _CHARG = value; }
        }
        string _UECHA;

        public string UECHA
        {
            get { return _UECHA; }
            set { _UECHA = value; }
        }
        decimal _LGMNG;

        public decimal LGMNG
        {
            get { return _LGMNG; }
            set { _LGMNG = value; }
        }
        string _MEINS;

        public string MEINS
        {
            get { return _MEINS; }
            set { _MEINS = value; }
        }
        string _WERKS;

        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }
        string _LGORT;

        public string LGORT
        {
            get { return _LGORT; }
            set { _LGORT = value; }
        }
        int _ZPAR;

        public int ZPAR
        {
            get { return _ZPAR; }
            set { _ZPAR = value; }
        }
        int _ZBON;

        public int ZBON
        {
            get { return _ZBON; }
            set { _ZBON = value; }
        }
        int _ZPKS;

        public int ZPKS
        {
            get { return _ZPKS; }
            set { _ZPKS = value; }
        }
        int _ZPCS;

        public int ZPCS
        {
            get { return _ZPCS; }
            set { _ZPCS = value; }
        }
        string _ZLTBS;

        public string ZLTBS
        {
            get { return _ZLTBS; }
            set { _ZLTBS = value; }
        }
        int _DXS;

        public int DXS
        {
            get { return _DXS; }
            set { _DXS = value; }
        }
        int _NHS;

        public int NHS
        {
            get { return _NHS; }
            set { _NHS = value; }
        }
        int _ZS;

        public int ZS
        {
            get { return _ZS; }
            set { _ZS = value; }
        }
        string _JHZ;

        public string JHZ
        {
            get { return _JHZ; }
            set { _JHZ = value; }
        }
        string _ZZKGGKH;

        public string ZZKGGKH
        {
            get { return _ZZKGGKH; }
            set { _ZZKGGKH = value; }
        }

        List<TMmodel> _TM;

        public List<TMmodel> TM
        {
            get {
                if (_TM == null)
                    _TM = new List<TMmodel>();
                return _TM; }
            set { _TM = value; }
        }





        public class TMmodel
        {
            string _Barcode;

            public string Barcode
            {
                get { return _Barcode; }
                set { _Barcode = value; }
            }
            int _SCANED;

            public int SCANED
            {
                get { return _SCANED; }
                set { _SCANED = value; }
            }
        }










    }
}
