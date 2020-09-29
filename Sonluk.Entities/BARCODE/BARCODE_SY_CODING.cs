using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BARCODE
{
  public  class BARCODE_SY_CODING
    {
        private int iD;
        private string bARCODE;
        private string dESCRIPTION;
        private int pP;
        private int cPZL;
        private int xH;
        private int qUANTITY;
        private int bZXS;
        private string bZSL;
        private string vERSION;
        private string yWY;
        private string sQR;
        private int bEGINNING;
        private string pIPECODE;
        private string bEIZ;
        private int iSACTIVE;
        private int cJR;
        private string cJSJ;
        private int xGR;
        private string xGSJ;
        private string _CJRNAME;
        private string _XGRNAME;
        private string _PPMC;
        private string _CPZLMC;
        private string _XHMC;
        private string _QUANTITYMC;
        private string _BZXSMC;
        private string _KSTIME;
        private string _JSTIME;
        private int _SERIES;
        private string _SERIESMC;
        private Byte[] _IMGBYTE;
        public int ID { get => iD; set => iD = value; }
        public string BARCODE { get => bARCODE; set => bARCODE = value; }
        public string DESCRIPTION { get => dESCRIPTION; set => dESCRIPTION = value; }
        public int PP { get => pP; set => pP = value; }
        public int CPZL { get => cPZL; set => cPZL = value; }
        public int XH { get => xH; set => xH = value; }
        public int QUANTITY { get => qUANTITY; set => qUANTITY = value; }
        public int BZXS { get => bZXS; set => bZXS = value; }
        public string BZSL { get => bZSL; set => bZSL = value; }
        public string VERSION { get => vERSION; set => vERSION = value; }
        public string YWY { get => yWY; set => yWY = value; }
        public string SQR { get => sQR; set => sQR = value; }
        public int BEGINNING { get => bEGINNING; set => bEGINNING = value; }
        public string PIPECODE { get => pIPECODE; set => pIPECODE = value; }
        public string BEIZ { get => bEIZ; set => bEIZ = value; }
        public int ISACTIVE { get => iSACTIVE; set => iSACTIVE = value; }
        public int CJR { get => cJR; set => cJR = value; }
        public string CJSJ { get => cJSJ; set => cJSJ = value; }
        public int XGR { get => xGR; set => xGR = value; }
        public string XGSJ { get => xGSJ; set => xGSJ = value; }
        public string CJRNAME { get => _CJRNAME; set => _CJRNAME = value; }
        public string XGRNAME { get => _XGRNAME; set => _XGRNAME = value; }
        public string PPMC { get => _PPMC; set => _PPMC = value; }
        public string CPZLMC { get => _CPZLMC; set => _CPZLMC = value; }
        public string XHMC { get => _XHMC; set => _XHMC = value; }
        public string QUANTITYMC { get => _QUANTITYMC; set => _QUANTITYMC = value; }
        public string BZXSMC { get => _BZXSMC; set => _BZXSMC = value; }
        public string KSTIME { get => _KSTIME; set => _KSTIME = value; }
        public string JSTIME { get => _JSTIME; set => _JSTIME = value; }
        public int SERIES { get => _SERIES; set => _SERIES = value; }
        public string SERIESMC { get => _SERIESMC; set => _SERIESMC = value; }
        public byte[] IMGBYTE { get => _IMGBYTE; set => _IMGBYTE = value; }
    }
}
