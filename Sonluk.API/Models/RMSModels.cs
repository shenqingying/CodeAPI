using Sonluk.BusinessLogic.RMS;
using Sonluk.BusinessLogic.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.BusinessLogic.FIVES;
using Sonluk.BusinessLogic.EM;
using Sonluk.BusinessLogic.FICO;
using Sonluk.BusinessLogic.BARCODE;

namespace Sonluk.API.Models
{
    public class RMSModels
    {
        EM_MISSION _EM_MISSION;

        public EM_MISSION EM_MISSION
        {
            get
            {
                if (_EM_MISSION == null)
                {
                    _EM_MISSION = new EM_MISSION();
                } return _EM_MISSION;
            }
            set { _EM_MISSION = value; }
        }

        SY_DEPTPUSHRY _SY_DEPTPUSHRY;

        public SY_DEPTPUSHRY SY_DEPTPUSHRY
        {
            get
            {
                if (_SY_DEPTPUSHRY == null)
                {
                    _SY_DEPTPUSHRY = new SY_DEPTPUSHRY();
                } return _SY_DEPTPUSHRY;
            }
            set { _SY_DEPTPUSHRY = value; }
        }
        SY_STAFFIDBINDPB _SY_STAFFIDBINDPB;

        public SY_STAFFIDBINDPB SY_STAFFIDBINDPB
        {
            get
            {
                if (_SY_STAFFIDBINDPB == null)
                {
                    _SY_STAFFIDBINDPB = new SY_STAFFIDBINDPB();
                } return _SY_STAFFIDBINDPB;
            }
            set { _SY_STAFFIDBINDPB = value; }
        }
        SY_SBBINDPB _SY_SBBINDPB;

        public SY_SBBINDPB SY_SBBINDPB
        {
            get
            {
                if (_SY_SBBINDPB == null)
                {
                    _SY_SBBINDPB = new SY_SBBINDPB();
                } return _SY_SBBINDPB;
            }
            set { _SY_SBBINDPB = value; }
        }
        SY_PB _SY_PB;

        public SY_PB SY_PB
        {
            get
            {
                if (_SY_PB == null)
                {
                    _SY_PB = new SY_PB();
                } return _SY_PB;
            }
            set { _SY_PB = value; }
        }
        SY_SBBHMANUAL _SY_SBBHMANUAL;

        public SY_SBBHMANUAL SY_SBBHMANUAL
        {
            get
            {
                if (_SY_SBBHMANUAL == null)
                {
                    _SY_SBBHMANUAL = new SY_SBBHMANUAL();
                } return _SY_SBBHMANUAL;
            }
            set { _SY_SBBHMANUAL = value; }
        }
        SY_DEVICEQRJL _SY_DEVICEQRJL;

        public SY_DEVICEQRJL SY_DEVICEQRJL
        {
            get
            {
                if (_SY_DEVICEQRJL == null)
                {
                    _SY_DEVICEQRJL = new SY_DEVICEQRJL();
                } return _SY_DEVICEQRJL;
            }
            set { _SY_DEVICEQRJL = value; }
        }
        SY_DEVICEDETAILDOC _SY_DEVICEDETAILDOC;

        public SY_DEVICEDETAILDOC SY_DEVICEDETAILDOC
        {
            get
            {
                if (_SY_DEVICEDETAILDOC == null)
                {
                    _SY_DEVICEDETAILDOC = new SY_DEVICEDETAILDOC();
                } return _SY_DEVICEDETAILDOC;
            }
            set { _SY_DEVICEDETAILDOC = value; }
        }
        SY_DEVICETYPE _SY_DEVICETYPE;

        public SY_DEVICETYPE SY_DEVICETYPE
        {
            get
            {
                if (_SY_DEVICETYPE == null)
                {
                    _SY_DEVICETYPE = new SY_DEVICETYPE();
                } return _SY_DEVICETYPE;
            }
            set { _SY_DEVICETYPE = value; }
        }
        SY_SBBHDEVICETYPE _SY_SBBHDEVICETYPE;

        public SY_SBBHDEVICETYPE SY_SBBHDEVICETYPE
        {
            get
            {
                if (_SY_SBBHDEVICETYPE == null)
                {
                    _SY_SBBHDEVICETYPE = new SY_SBBHDEVICETYPE();
                } return _SY_SBBHDEVICETYPE;
            }
            set { _SY_SBBHDEVICETYPE = value; }
        }
        SY_INFOREPORT _SY_INFOREPORT;

        public SY_INFOREPORT SY_INFOREPORT
        {
            get
            {
                if (_SY_INFOREPORT == null)
                {
                    _SY_INFOREPORT = new SY_INFOREPORT();
                } return _SY_INFOREPORT;
            }
            set { _SY_INFOREPORT = value; }
        }
        SY_BINDINGDEVICE _SY_BINDINGDEVICE;

        public SY_BINDINGDEVICE SY_BINDINGDEVICE
        {
            get
            {
                if (_SY_BINDINGDEVICE == null)
                {
                    _SY_BINDINGDEVICE = new SY_BINDINGDEVICE();
                } return _SY_BINDINGDEVICE;
            }
            set { _SY_BINDINGDEVICE = value; }
        }
        SY_DEVICE_CONTRACT _SY_DEVICE_CONTRACT;

        public SY_DEVICE_CONTRACT SY_DEVICE_CONTRACT
        {
            get
            {
                if (_SY_DEVICE_CONTRACT == null)
                {
                    _SY_DEVICE_CONTRACT = new SY_DEVICE_CONTRACT();
                } return _SY_DEVICE_CONTRACT;
            }
            set { _SY_DEVICE_CONTRACT = value; }
        }
        FILE_PATH _FILE_PATH;

        public FILE_PATH FILE_PATH
        {
            get
            {
                if (_FILE_PATH == null)
                {
                    _FILE_PATH = new FILE_PATH();
                } return _FILE_PATH;
            }
            set { _FILE_PATH = value; }
        }
        SY_XTBB _SY_XTBB;

        public SY_XTBB SY_XTBB
        {
            get
            {
                if (_SY_XTBB == null)
                {
                    _SY_XTBB = new SY_XTBB();
                } return _SY_XTBB;
            }
            set { _SY_XTBB = value; }
        }
        SY_MANUAL _SY_MANUAL;

        public SY_MANUAL SY_MANUAL
        {
            get
            {
                if (_SY_MANUAL == null)
                {
                    _SY_MANUAL = new SY_MANUAL();
                } return _SY_MANUAL;
            }
            set { _SY_MANUAL = value; }
        }
        SY_MANUALBB _SY_MANUALBB;

        public SY_MANUALBB SY_MANUALBB
        {
            get
            {
                if (_SY_MANUALBB == null)
                {
                    _SY_MANUALBB = new SY_MANUALBB();
                } return _SY_MANUALBB;
            }
            set { _SY_MANUALBB = value; }
        }
        SY_MANUALPATH _SY_MANUALPATH;

        public SY_MANUALPATH SY_MANUALPATH
        {
            get
            {
                if (_SY_MANUALPATH == null)
                {
                    _SY_MANUALPATH = new SY_MANUALPATH();
                } return _SY_MANUALPATH;
            }
            set { _SY_MANUALPATH = value; }
        }
        SY_STAFF_EMTYPE _SY_STAFF_EMTYPE;

        public SY_STAFF_EMTYPE SY_STAFF_EMTYPE
        {
            get
            {
                if (_SY_STAFF_EMTYPE == null)
                {
                    _SY_STAFF_EMTYPE = new SY_STAFF_EMTYPE();
                } return _SY_STAFF_EMTYPE;
            }
            set { _SY_STAFF_EMTYPE = value; }
        }
        SY_RELATIONSHIPBIND _SY_RELATIONSHIPBIND;

        public SY_RELATIONSHIPBIND SY_RELATIONSHIPBIND
        {
            get
            {
                if (_SY_RELATIONSHIPBIND == null)
                {
                    _SY_RELATIONSHIPBIND = new SY_RELATIONSHIPBIND();
                } return _SY_RELATIONSHIPBIND;
            }
            set { _SY_RELATIONSHIPBIND = value; }
        }
        SY_CHECKPOINT_CHECKDETAIL _SY_CHECKPOINT_CHECKDETAIL;

        public SY_CHECKPOINT_CHECKDETAIL SY_CHECKPOINT_CHECKDETAIL
        {
            get
            {
                if (_SY_CHECKPOINT_CHECKDETAIL == null)
                {
                    _SY_CHECKPOINT_CHECKDETAIL = new SY_CHECKPOINT_CHECKDETAIL();
                }
                return _SY_CHECKPOINT_CHECKDETAIL;
            }
            set { _SY_CHECKPOINT_CHECKDETAIL = value; }
        }
        SY_TYPE _SY_TYPE;

        public SY_TYPE SY_TYPE
        {
            get
            {
                if (_SY_TYPE == null)
                {
                    _SY_TYPE = new SY_TYPE();
                } return _SY_TYPE;
            }
            set { _SY_TYPE = value; }
        }
        SY_DICT _SY_DICT;

        public SY_DICT SY_DICT
        {
            get
            {
                if (_SY_DICT == null)
                {
                    _SY_DICT = new SY_DICT();
                } return _SY_DICT;
            }
            set { _SY_DICT = value; }
        }
        SY_CHECKGROUP_STAFF _SY_CHECKGROUP_STAFF;

        public SY_CHECKGROUP_STAFF SY_CHECKGROUP_STAFF
        {
            get
            {
                if (_SY_CHECKGROUP_STAFF == null)
                {
                    _SY_CHECKGROUP_STAFF = new SY_CHECKGROUP_STAFF();
                } return _SY_CHECKGROUP_STAFF;
            }
            set { _SY_CHECKGROUP_STAFF = value; }
        }
        SY_CHECKGROUP _SY_CHECKGROUP;

        public SY_CHECKGROUP SY_CHECKGROUP
        {
            get
            {
                if (_SY_CHECKGROUP == null)
                {
                    _SY_CHECKGROUP = new SY_CHECKGROUP();
                } return _SY_CHECKGROUP;
            }
            set { _SY_CHECKGROUP = value; }
        }
        SY_CHECKGROUP_DEPARTMENT _SY_CHECKGROUP_DEPARTMENT;

        public SY_CHECKGROUP_DEPARTMENT SY_CHECKGROUP_DEPARTMENT
        {
            get
            {
                if (_SY_CHECKGROUP_DEPARTMENT == null)
                {
                    _SY_CHECKGROUP_DEPARTMENT = new SY_CHECKGROUP_DEPARTMENT();
                } return _SY_CHECKGROUP_DEPARTMENT;
            }
            set { _SY_CHECKGROUP_DEPARTMENT = value; }
        }
        CHECK_INFO _CHECK_INFO;

        public CHECK_INFO CHECK_INFO
        {
            get
            {
                if (_CHECK_INFO == null)
                {
                    _CHECK_INFO = new CHECK_INFO();
                } return _CHECK_INFO;
            }
            set { _CHECK_INFO = value; }
        }
        CHECK_INFODETAIL _CHECK_INFODETAIL;

        public CHECK_INFODETAIL CHECK_INFODETAIL
        {
            get
            {
                if (_CHECK_INFODETAIL == null)
                {
                    _CHECK_INFODETAIL = new CHECK_INFODETAIL();
                } return _CHECK_INFODETAIL;
            }
            set { _CHECK_INFODETAIL = value; }
        }
        SY_STATION _SY_STATION;

        public SY_STATION SY_STATION
        {
            get
            {
                if (_SY_STATION == null)
                {
                    _SY_STATION = new SY_STATION();
                } return _SY_STATION;
            }
            set { _SY_STATION = value; }
        }
        SY_PRINCIPALCATEGROY _SY_PRINCIPALCATEGROY;

        public SY_PRINCIPALCATEGROY SY_PRINCIPALCATEGROY
        {
            get
            {
                if (_SY_PRINCIPALCATEGROY == null)
                {
                    _SY_PRINCIPALCATEGROY = new SY_PRINCIPALCATEGROY();
                } return _SY_PRINCIPALCATEGROY;
            }
            set { _SY_PRINCIPALCATEGROY = value; }
        }
        SY_CHECKPOINTCATEGROY _SY_CHECKPOINTCATEGROY;

        public SY_CHECKPOINTCATEGROY SY_CHECKPOINTCATEGROY
        {
            get
            {
                if (_SY_CHECKPOINTCATEGROY == null)
                {
                    _SY_CHECKPOINTCATEGROY = new SY_CHECKPOINTCATEGROY();
                } return _SY_CHECKPOINTCATEGROY;
            }
            set { _SY_CHECKPOINTCATEGROY = value; }
        }
        SY_CHECKPOINT_POINTCATEGROY _SY_CHECKPOINT_POINTCATEGROY;

        public SY_CHECKPOINT_POINTCATEGROY SY_CHECKPOINT_POINTCATEGROY
        {
            get
            {
                if (_SY_CHECKPOINT_POINTCATEGROY == null)
                {
                    _SY_CHECKPOINT_POINTCATEGROY = new SY_CHECKPOINT_POINTCATEGROY();
                } return _SY_CHECKPOINT_POINTCATEGROY;
            }
            set { _SY_CHECKPOINT_POINTCATEGROY = value; }
        }
        SY_CHECKPOINT _SY_CHECKPOINT;

        public SY_CHECKPOINT SY_CHECKPOINT
        {
            get
            {
                if (_SY_CHECKPOINT == null)
                {
                    _SY_CHECKPOINT = new SY_CHECKPOINT();
                } return _SY_CHECKPOINT;
            }
            set { _SY_CHECKPOINT = value; }
        }
        SY_POINTCATEGROY_DETAIL _SY_POINTCATEGROY_DETAIL;

        public SY_POINTCATEGROY_DETAIL SY_POINTCATEGROY_DETAIL
        {
            get
            {
                if (_SY_POINTCATEGROY_DETAIL == null)
                {
                    _SY_POINTCATEGROY_DETAIL = new SY_POINTCATEGROY_DETAIL();
                } return _SY_POINTCATEGROY_DETAIL;
            }
            set { _SY_POINTCATEGROY_DETAIL = value; }
        }
        SY_CHECKDETAILCATEGROY _SY_CHECKDETAILCATEGROY;

        public SY_CHECKDETAILCATEGROY SY_CHECKDETAILCATEGROY
        {
            get
            {
                if (_SY_CHECKDETAILCATEGROY == null)
                {
                    _SY_CHECKDETAILCATEGROY = new SY_CHECKDETAILCATEGROY();
                } return _SY_CHECKDETAILCATEGROY;
            }
            set { _SY_CHECKDETAILCATEGROY = value; }
        }
        SY_CHECKDETAILS _SY_CHECKDETAILS;

        public SY_CHECKDETAILS SY_CHECKDETAILS
        {
            get
            {
                if (_SY_CHECKDETAILS == null)
                {
                    _SY_CHECKDETAILS = new SY_CHECKDETAILS();
                } return _SY_CHECKDETAILS;
            }
            set { _SY_CHECKDETAILS = value; }
        }

        KH_KHXS _KH_KHXS;

        public KH_KHXS KH_KHXS
        {
            get
            {
                if (_KH_KHXS == null)
                {
                    _KH_KHXS = new KH_KHXS();
                } return _KH_KHXS;
            }
            set { _KH_KHXS = value; }
        }
        HG_KHLX _HG_KHLX;

        public HG_KHLX HG_KHLX
        {
            get
            {
                if (_HG_KHLX == null)
                {
                    _HG_KHLX = new HG_KHLX();
                } return _HG_KHLX;
            }
            set { _HG_KHLX = value; }
        }

        HG_STAFFKHLX _HG_STAFFKHLX;

        public HG_STAFFKHLX HG_STAFFKHLX
        {
            get
            {
                if (_HG_STAFFKHLX == null)
                {
                    _HG_STAFFKHLX = new HG_STAFFKHLX();
                } return _HG_STAFFKHLX;
            }
            set { _HG_STAFFKHLX = value; }
        }
        CRM_PENDING _CRM_PENDING;

        public CRM_PENDING CRM_PENDING
        {
            get
            {
                if (_CRM_PENDING == null)
                {
                    _CRM_PENDING = new CRM_PENDING();
                } return _CRM_PENDING;
            }
            set { _CRM_PENDING = value; }
        }
        BF_BFJHMX _BF_BFJHMX;

        public BF_BFJHMX BF_BFJHMX
        {
            get
            {
                if (_BF_BFJHMX == null)
                {
                    _BF_BFJHMX = new BF_BFJHMX();
                } return _BF_BFJHMX;
            }
            set { _BF_BFJHMX = value; }
        }
        KH_KHBF _KH_KHBF;

        public KH_KHBF KH_KHBF
        {
            get
            {
                if (_KH_KHBF == null)
                {
                    _KH_KHBF = new KH_KHBF();
                } return _KH_KHBF;
            }
            set { _KH_KHBF = value; }
        }

        KH_BF _KH_BF;

        public KH_BF KH_BF
        {
            get
            {
                if (_KH_BF == null)
                {
                    _KH_BF = new KH_BF();

                } return _KH_BF;
            }
            set { _KH_BF = value; }
        }
        SYS_CS _SYS_CS;

        public SYS_CS SYS_CS
        {
            get
            {
                if (_SYS_CS == null)
                {
                    _SYS_CS = new SYS_CS();
                } return _SYS_CS;
            }
            set { _SYS_CS = value; }
        }
        WX_OPENID _WX_OPENID;

        public WX_OPENID WX_OPENID
        {
            get
            {
                if (_WX_OPENID == null)
                {
                    _WX_OPENID = new WX_OPENID();
                } return _WX_OPENID;
            }
            set { _WX_OPENID = value; }
        }
        HD_NKAMD _HD_NKAMD;

        public HD_NKAMD HD_NKAMD
        {
            get
            {
                if (_HD_NKAMD == null)
                {
                    _HD_NKAMD = new HD_NKAMD();
                } return _HD_NKAMD;
            }
            set { _HD_NKAMD = value; }
        }
        HD_NKAXT _HD_NKAXT;

        public HD_NKAXT HD_NKAXT
        {
            get
            {
                if (_HD_NKAXT == null)
                {
                    _HD_NKAXT = new HD_NKAXT();
                } return _HD_NKAXT;
            }
            set { _HD_NKAXT = value; }
        }
        HD_ZYCXY _HD_ZYCXY;

        public HD_ZYCXY HD_ZYCXY
        {
            get
            {
                if (_HD_ZYCXY == null)
                {
                    _HD_ZYCXY = new HD_ZYCXY();
                } return _HD_ZYCXY;
            }
            set { _HD_ZYCXY = value; }
        }
        OA_TRANSMIT _OA_TRANSMIT;

        public OA_TRANSMIT OA_TRANSMIT
        {
            get
            {
                if (_OA_TRANSMIT == null)
                {
                    _OA_TRANSMIT = new OA_TRANSMIT();
                } return _OA_TRANSMIT;
            }
            set { _OA_TRANSMIT = value; }
        }
        HD_ZDF _HD_ZDF;

        public HD_ZDF HD_ZDF
        {
            get
            {
                if (_HD_ZDF == null)
                {
                    _HD_ZDF = new HD_ZDF();
                } return _HD_ZDF;
            }
            set { _HD_ZDF = value; }
        }
        CRM_KQ_Report _CRM_KQ_Report;

        public CRM_KQ_Report CRM_KQ_Report
        {
            get
            {
                if (_CRM_KQ_Report == null)
                {
                    _CRM_KQ_Report = new CRM_KQ_Report();
                } return _CRM_KQ_Report;
            }
            set { _CRM_KQ_Report = value; }
        }

        BF_BFQD _BF_BFQD;

        public BF_BFQD BF_BFQD
        {
            get
            {
                if (_BF_BFQD == null)
                {
                    _BF_BFQD = new BF_BFQD();
                } return _BF_BFQD;
            }
            set { _BF_BFQD = value; }
        }
        KH_GROUP_XSQY _KH_GROUP_XSQY;

        public KH_GROUP_XSQY KH_GROUP_XSQY
        {
            get
            {
                if (_KH_GROUP_XSQY == null)
                {
                    _KH_GROUP_XSQY = new KH_GROUP_XSQY();
                }
                return _KH_GROUP_XSQY;
            }
            set { _KH_GROUP_XSQY = value; }
        }
        BF_BF _BF_BF;

        public BF_BF BF_BF
        {
            get
            {
                if (_BF_BF == null)
                {
                    _BF_BF = new BF_BF();
                } return _BF_BF;
            }
            set { _BF_BF = value; }
        }
        KQ_CC _KQ_CC;

        public KQ_CC KQ_CC
        {
            get
            {
                if (_KQ_CC == null)
                {
                    _KQ_CC = new KQ_CC();
                }
                return _KQ_CC;
            }
            set { _KQ_CC = value; }
        }
        KH_DZ _KH_DZ;

        public KH_DZ KH_DZ
        {
            get
            {
                if (_KH_DZ == null)
                {
                    _KH_DZ = new KH_DZ();
                }
                return _KH_DZ;
            }
            set { _KH_DZ = value; }
        }
        KQ_YCKQSM _KQ_YCKQSM;

        public KQ_YCKQSM KQ_YCKQSM
        {
            get
            {
                if (_KQ_YCKQSM == null)
                {
                    _KQ_YCKQSM = new KQ_YCKQSM();
                }
                return _KQ_YCKQSM;
            }
            set { _KQ_YCKQSM = value; }
        }
        CRM_Login _CRM_Login;

        public CRM_Login CRM_Login
        {
            get
            {
                if (_CRM_Login == null)
                {
                    _CRM_Login = new CRM_Login();
                }
                return _CRM_Login;
            }
            set { _CRM_Login = value; }
        }
        KH_GROUP_STAFF _KH_GROUP_STAFF;

        public KH_GROUP_STAFF KH_GROUP_STAFF
        {
            get
            {
                if (_KH_GROUP_STAFF == null)
                {
                    _KH_GROUP_STAFF = new KH_GROUP_STAFF();
                }
                return _KH_GROUP_STAFF;
            }
            set { _KH_GROUP_STAFF = value; }
        }
        KQ_QD _KQ_QD;

        public KQ_QD KQ_QD
        {
            get
            {
                if (_KQ_QD == null)
                {
                    _KQ_QD = new KQ_QD();
                }
                return _KQ_QD;
            }
            set { _KQ_QD = value; }
        }

        KQ_YGQJ _KQ_YGQJ;

        public KQ_YGQJ KQ_YGQJ
        {
            get
            {
                if (_KQ_YGQJ == null)
                {
                    _KQ_YGQJ = new KQ_YGQJ();
                }
                return _KQ_YGQJ;
            }
            set { _KQ_YGQJ = value; }
        }
        HG_RIGHTGROUP _HG_RIGHTGROUP;

        public HG_RIGHTGROUP HG_RIGHTGROUP
        {
            get
            {
                if (_HG_RIGHTGROUP == null)
                {
                    _HG_RIGHTGROUP = new HG_RIGHTGROUP();
                }
                return _HG_RIGHTGROUP;
            }
            set { _HG_RIGHTGROUP = value; }
        }

        HG_RIGHT _HG_RIGHT;

        public HG_RIGHT HG_RIGHT
        {
            get
            {
                if (_HG_RIGHT == null)
                {
                    _HG_RIGHT = new HG_RIGHT();
                }
                return _HG_RIGHT;
            }
            set { _HG_RIGHT = value; }
        }

        HG_ROLE _HG_ROLE;

        public HG_ROLE HG_ROLE
        {
            get
            {
                if (_HG_ROLE == null)
                {
                    _HG_ROLE = new HG_ROLE();
                }
                return _HG_ROLE;
            }
            set { _HG_ROLE = value; }
        }

        private Product _Product;

        public Product Product
        {
            get
            {
                if (_Product == null)
                    _Product = new Product();
                return _Product;
            }
            set { _Product = value; }
        }
        CRM_OA _CRM_OA;

        public CRM_OA CRM_OA
        {
            get
            {
                if (_CRM_OA == null)
                {
                    _CRM_OA = new CRM_OA();
                }
                return _CRM_OA;
            }
            set { _CRM_OA = value; }
        }
        CRM_OA_FLOW _CRM_OA_FLOW;

        public CRM_OA_FLOW CRM_OA_FLOW
        {
            get
            {
                if (_CRM_OA_FLOW == null)
                {
                    _CRM_OA_FLOW = new CRM_OA_FLOW();
                } return _CRM_OA_FLOW;
            }
            set { _CRM_OA_FLOW = value; }
        }

        private CRM_KH _CRM_KH;

        public CRM_KH CRM_KH
        {
            get
            {
                if (_CRM_KH == null)
                {
                    _CRM_KH = new CRM_KH();
                }
                return _CRM_KH;
            }
            set { _CRM_KH = value; }
        }
        CRM_HG _CRM_HG;

        public CRM_HG CRM_HG
        {
            get
            {
                if (_CRM_HG == null)
                {
                    _CRM_HG = new CRM_HG();
                }
                return _CRM_HG;
            }
            set { _CRM_HG = value; }
        }

        CRM_BF _CRM_BF;

        public CRM_BF CRM_BF
        {
            get
            {
                if (_CRM_BF == null)
                {
                    _CRM_BF = new CRM_BF();
                }
                return _CRM_BF;
            }
            set { _CRM_BF = value; }
        }
        CRM_HD _CRM_HD;

        public CRM_HD CRM_HD
        {
            get
            {
                if (_CRM_HD == null)
                {
                    _CRM_HD = new CRM_HD();
                }
                return _CRM_HD;
            }
            set { _CRM_HD = value; }
        }
        CRM_KQ _CRM_KQ;

        public CRM_KQ CRM_KQ
        {
            get
            {
                if (_CRM_KQ == null)
                {
                    _CRM_KQ = new CRM_KQ();
                }
                return _CRM_KQ;
            }
            set { _CRM_KQ = value; }
        }
        KH_KH _KH_KH;

        public KH_KH KH_KH
        {
            get
            {
                if (_KH_KH == null)
                {
                    _KH_KH = new KH_KH();
                }
                return _KH_KH;
            }
            set { _KH_KH = value; }
        }
        KH_LXR _KH_LXR;

        public KH_LXR KH_LXR
        {
            get
            {
                if (_KH_LXR == null)
                {
                    _KH_LXR = new KH_LXR();
                }
                return _KH_LXR;
            }
            set { _KH_LXR = value; }
        }
        KH_GXQY _KH_GXQY;

        public KH_GXQY KH_GXQY
        {
            get
            {
                if (_KH_GXQY == null)
                {
                    _KH_GXQY = new KH_GXQY();
                }
                return _KH_GXQY;
            }
            set { _KH_GXQY = value; }
        }
        KH_KHQTXX _KH_KHQTXX;

        public KH_KHQTXX KH_KHQTXX
        {
            get
            {
                if (_KH_KHQTXX == null)
                {
                    _KH_KHQTXX = new KH_KHQTXX();
                }
                return _KH_KHQTXX;
            }
            set { _KH_KHQTXX = value; }
        }
        HG_WJJL _HG_WJJL;

        public HG_WJJL HG_WJJL
        {
            get
            {
                if (_HG_WJJL == null)
                {
                    _HG_WJJL = new HG_WJJL();
                }
                return _HG_WJJL;
            }
            set { _HG_WJJL = value; }
        }

        HG_DICT _HG_DICT;

        public HG_DICT HG_DICT
        {
            get
            {
                if (_HG_DICT == null)
                {
                    _HG_DICT = new HG_DICT();
                }
                return _HG_DICT;
            }
            set { _HG_DICT = value; }
        }
        HG_TYPE _HG_TYPE;

        public HG_TYPE HG_TYPE
        {
            get
            {
                if (_HG_TYPE == null)
                {
                    _HG_TYPE = new HG_TYPE();
                }
                return _HG_TYPE;
            }
            set { _HG_TYPE = value; }
        }
        KH_GROUP _KH_GROUP;

        public KH_GROUP KH_GROUP
        {
            get
            {
                if (_KH_GROUP == null)
                {
                    _KH_GROUP = new KH_GROUP();
                }
                return _KH_GROUP;
            }
            set { _KH_GROUP = value; }
        }

        KH_HZHB _KH_HZHB;

        public KH_HZHB KH_HZHB
        {
            get
            {
                if (_KH_HZHB == null)
                {
                    _KH_HZHB = new KH_HZHB();
                }
                return _KH_HZHB;
            }
            set { _KH_HZHB = value; }
        }

        KH_GROUP_KH _KH_GROUP_KH;

        public KH_GROUP_KH KH_GROUP_KH
        {
            get
            {
                if (_KH_GROUP_KH == null)
                {
                    _KH_GROUP_KH = new KH_GROUP_KH();
                }
                return _KH_GROUP_KH;
            }
            set { _KH_GROUP_KH = value; }
        }

        HG_STAFF _HG_STAFF;

        public HG_STAFF HG_STAFF
        {
            get
            {
                if (_HG_STAFF == null)
                {
                    _HG_STAFF = new HG_STAFF();
                }
                return _HG_STAFF;
            }
            set { _HG_STAFF = value; }
        }

        HG_DEPT _HG_DEPT;

        public HG_DEPT HG_DEPT
        {
            get
            {
                if (_HG_DEPT == null)
                {
                    _HG_DEPT = new HG_DEPT();
                }
                return _HG_DEPT;
            }
            set { _HG_DEPT = value; }
        }
        HG_DUTY _HG_DUTY;

        public HG_DUTY HG_DUTY
        {
            get
            {
                if (_HG_DUTY == null)
                {
                    _HG_DUTY = new HG_DUTY();
                }
                return _HG_DUTY;
            }
            set { _HG_DUTY = value; }
        }
        HG_STAFFDUTY _HG_STAFFDUTY;

        public HG_STAFFDUTY HG_STAFFDUTY
        {
            get
            {
                if (_HG_STAFFDUTY == null)
                {
                    _HG_STAFFDUTY = new HG_STAFFDUTY();
                }
                return _HG_STAFFDUTY;
            }
            set { _HG_STAFFDUTY = value; }
        }

        HG_BZGZSJ _HG_BZGZSJ;

        public HG_BZGZSJ HG_BZGZSJ
        {
            get
            {
                if (_HG_BZGZSJ == null)
                {
                    _HG_BZGZSJ = new HG_BZGZSJ();
                }
                return _HG_BZGZSJ;
            }
            set { _HG_BZGZSJ = value; }
        }
        HG_KQDZ _HG_KQDZ;

        public HG_KQDZ HG_KQDZ
        {
            get
            {
                if (_HG_KQDZ == null)
                {
                    _HG_KQDZ = new HG_KQDZ();
                }
                return _HG_KQDZ;
            }
            set { _HG_KQDZ = value; }
        }

        HG_RYKQ _HG_RYKQ;

        public HG_RYKQ HG_RYKQ
        {
            get
            {
                if (_HG_RYKQ == null)
                {
                    _HG_RYKQ = new HG_RYKQ();
                }
                return _HG_RYKQ;
            }
            set { _HG_RYKQ = value; }
        }

        KQ_GZRL _KQ_GZRL;

        public KQ_GZRL KQ_GZRL
        {
            get
            {
                if (_KQ_GZRL == null)
                {
                    _KQ_GZRL = new KQ_GZRL();
                }
                return _KQ_GZRL;
            }
            set { _KQ_GZRL = value; }
        }
        KQ_GZRLMX _KQ_GZRLMX;

        public KQ_GZRLMX KQ_GZRLMX
        {
            get
            {
                if (_KQ_GZRLMX == null)
                {
                    _KQ_GZRLMX = new KQ_GZRLMX();
                }
                return _KQ_GZRLMX;
            }
            set { _KQ_GZRLMX = value; }
        }

        SonlukRegex.Sonluk _Sonluk;

        public SonlukRegex.Sonluk Sonluk
        {
            get
            {
                if (_Sonluk == null)
                {
                    _Sonluk = new SonlukRegex.Sonluk();
                }
                return _Sonluk;
            }
            set { _Sonluk = value; }
        }

        SAP_Report _SAP_Report;

        public SAP_Report SAP_Report
        {
            get
            {
                if (_SAP_Report == null)
                {
                    _SAP_Report = new SAP_Report();
                }
                return _SAP_Report;
            }
            set { _SAP_Report = value; }
        }

        KH_XSYWJZ _KH_XSYWJZ;

        public KH_XSYWJZ KH_XSYWJZ
        {
            get
            {
                if (_KH_XSYWJZ == null)
                {
                    _KH_XSYWJZ = new KH_XSYWJZ();
                }
                return _KH_XSYWJZ;
            }
            set { _KH_XSYWJZ = value; }
        }

        KH_KHZZ _KH_KHZZ;

        public KH_KHZZ KH_KHZZ
        {
            get
            {
                if (_KH_KHZZ == null)
                {
                    _KH_KHZZ = new KH_KHZZ();
                }
                return _KH_KHZZ;
            }
            set { _KH_KHZZ = value; }
        }

        KH_HD _KH_HD;

        public KH_HD KH_HD
        {
            get
            {
                if (_KH_HD == null)
                {
                    _KH_HD = new KH_HD();
                }
                return _KH_HD;
            }
            set { _KH_HD = value; }
        }

        BC_PMLIST _BC_PMLIST;

        public BC_PMLIST BC_PMLIST
        {
            get
            {
                if (_BC_PMLIST == null)
                {
                    _BC_PMLIST = new BC_PMLIST();
                }
                return _BC_PMLIST;
            }
            set { _BC_PMLIST = value; }
        }

        BC_CHTT _BC_CHTT;

        public BC_CHTT BC_CHTT
        {
            get
            {
                if (_BC_CHTT == null)
                {
                    _BC_CHTT = new BC_CHTT();
                }
                return _BC_CHTT;
            }
            set { _BC_CHTT = value; }
        }

        BC_CHTT_FAKE _BC_CHTT_FAKE;

        public BC_CHTT_FAKE BC_CHTT_FAKE
        {
            get
            {
                if (_BC_CHTT_FAKE == null)
                {
                    _BC_CHTT_FAKE = new BC_CHTT_FAKE();
                }
                return _BC_CHTT_FAKE;
            }
            set { _BC_CHTT_FAKE = value; }
        }

        BC_FXCH _BC_FXCH;

        public BC_FXCH BC_FXCH
        {
            get
            {
                if (_BC_FXCH == null)
                {
                    _BC_FXCH = new BC_FXCH();
                }
                return _BC_FXCH;
            }
            set { _BC_FXCH = value; }
        }

        MSG_INVOICE _MSG_INVOICE;

        public MSG_INVOICE MSG_INVOICE
        {
            get
            {
                if (_MSG_INVOICE == null)
                {
                    _MSG_INVOICE = new MSG_INVOICE();
                }
                return _MSG_INVOICE;
            }
            set { _MSG_INVOICE = value; }
        }

        MSG_NOTICE _MSG_NOTICE;

        public MSG_NOTICE MSG_NOTICE
        {
            get
            {
                if (_MSG_NOTICE == null)
                {
                    _MSG_NOTICE = new MSG_NOTICE();
                }
                return _MSG_NOTICE;
            }
            set { _MSG_NOTICE = value; }
        }

        PRODUCT_PRODUCT _PRODUCT_PRODUCT;

        public PRODUCT_PRODUCT PRODUCT_PRODUCT
        {
            get
            {
                if (_PRODUCT_PRODUCT == null)
                {
                    _PRODUCT_PRODUCT = new PRODUCT_PRODUCT();
                }
                return _PRODUCT_PRODUCT;
            }
            set { _PRODUCT_PRODUCT = value; }
        }

        PRODUCT_PRODUCTGROUP _PRODUCT_PRODUCTGROUP;

        public PRODUCT_PRODUCTGROUP PRODUCT_PRODUCTGROUP
        {
            get
            {
                if (_PRODUCT_PRODUCTGROUP == null)
                {
                    _PRODUCT_PRODUCTGROUP = new PRODUCT_PRODUCTGROUP();
                }
                return _PRODUCT_PRODUCTGROUP;
            }
            set { _PRODUCT_PRODUCTGROUP = value; }
        }

        PRODUCT_GROUP _PRODUCT_GROUP;

        public PRODUCT_GROUP PRODUCT_GROUP
        {
            get
            {
                if (_PRODUCT_GROUP == null)
                {
                    _PRODUCT_GROUP = new PRODUCT_GROUP();
                }
                return _PRODUCT_GROUP;
            }
            set { _PRODUCT_GROUP = value; }
        }

        PRODUCT_KHGROUP _PRODUCT_KHGROUP;

        public PRODUCT_KHGROUP PRODUCT_KHGROUP
        {
            get
            {
                if (_PRODUCT_KHGROUP == null)
                {
                    _PRODUCT_KHGROUP = new PRODUCT_KHGROUP();
                }
                return _PRODUCT_KHGROUP;
            }
            set { _PRODUCT_KHGROUP = value; }
        }

        PRODUCT_WARN _PRODUCT_WARN;

        public PRODUCT_WARN PRODUCT_WARN
        {
            get
            {
                if (_PRODUCT_WARN == null)
                {
                    _PRODUCT_WARN = new PRODUCT_WARN();
                }
                return _PRODUCT_WARN;
            }
            set { _PRODUCT_WARN = value; }
        }

        ORDER_TT _ORDER_TT;

        public ORDER_TT ORDER_TT
        {
            get
            {
                if (_ORDER_TT == null)
                {
                    _ORDER_TT = new ORDER_TT();
                }
                return _ORDER_TT;
            }
            set { _ORDER_TT = value; }
        }

        SAP_ORDER _SAP_ORDER;

        public SAP_ORDER SAP_ORDER
        {
            get
            {
                if (_SAP_ORDER == null)
                {
                    _SAP_ORDER = new SAP_ORDER();
                }
                return _SAP_ORDER;
            }
            set { _SAP_ORDER = value; }
        }

        SY_STAFF_DEP _SY_STAFF_DEP;

        public SY_STAFF_DEP SY_STAFF_DEP
        {
            get
            {
                if (_SY_STAFF_DEP == null)
                {
                    _SY_STAFF_DEP = new SY_STAFF_DEP();
                } return _SY_STAFF_DEP;
            }
            set { _SY_STAFF_DEP = value; }
        }
        STAFF_DEP _STAFF_DEP;

        public STAFF_DEP STAFF_DEP
        {
            get
            {
                if (_STAFF_DEP == null)
                {
                    _STAFF_DEP = new STAFF_DEP();
                }
                return _STAFF_DEP;
            }
            set { _STAFF_DEP = value; }
        }

        QYJS_MENU _QYJS_MENU;

        public QYJS_MENU QYJS_MENU
        {
            get
            {
                if (_QYJS_MENU == null)
                {
                    _QYJS_MENU = new QYJS_MENU();
                }
                return _QYJS_MENU;
            }
            set { _QYJS_MENU = value; }
        }

        OA_OPINION _OA_OPINION;

        public OA_OPINION OA_OPINION
        {
            get
            {
                if (_OA_OPINION == null)
                {
                    _OA_OPINION = new OA_OPINION();
                }
                return _OA_OPINION;
            }
            set { _OA_OPINION = value; }
        }

        QYJS_FILE _QYJS_FILE;

        public QYJS_FILE QYJS_FILE
        {
            get
            {
                if (_QYJS_FILE == null)
                {
                    _QYJS_FILE = new QYJS_FILE();
                }
                return _QYJS_FILE;
            }
            set { _QYJS_FILE = value; }
        }

        COST_LKAPRODUCT _COST_LKAPRODUCT;

        public COST_LKAPRODUCT COST_LKAPRODUCT
        {
            get
            {
                if (_COST_LKAPRODUCT == null)
                {
                    _COST_LKAPRODUCT = new COST_LKAPRODUCT();
                }
                return _COST_LKAPRODUCT;
            }
            set { _COST_LKAPRODUCT = value; }
        }

        COST_LKAXS _COST_LKAXS;

        public COST_LKAXS COST_LKAXS
        {
            get
            {
                if (_COST_LKAXS == null)
                {
                    _COST_LKAXS = new COST_LKAXS();
                }
                return _COST_LKAXS;
            }
            set { _COST_LKAXS = value; }
        }

        COST_GGGS _COST_GGGS;

        public COST_GGGS COST_GGGS
        {
            get
            {
                if (_COST_GGGS == null)
                {
                    _COST_GGGS = new COST_GGGS();
                }
                return _COST_GGGS;
            }
            set { _COST_GGGS = value; }
        }


        COST_ITEM _COST_ITEM;

        public COST_ITEM COST_ITEM
        {
            get
            {
                if (_COST_ITEM == null)
                {
                    _COST_ITEM = new COST_ITEM();
                }
                return _COST_ITEM;
            }
            set { _COST_ITEM = value; }
        }

        COST_CP _COST_CP;

        public COST_CP COST_CP
        {
            get
            {
                if (_COST_CP == null)
                {
                    _COST_CP = new COST_CP();
                }
                return _COST_CP;
            }
            set { _COST_CP = value; }
        }
        COST_LKAYEARCOST _COST_LKAYEARCOST;

        public COST_LKAYEARCOST COST_LKAYEARCOST
        {
            get
            {
                if (_COST_LKAYEARCOST == null)
                {
                    _COST_LKAYEARCOST = new COST_LKAYEARCOST();
                }
                return _COST_LKAYEARCOST;
            }
            set { _COST_LKAYEARCOST = value; }
        }
        COST_LKAYEARLIST _COST_LKAYEARLIST;

        public COST_LKAYEARLIST COST_LKAYEARLIST
        {
            get
            {
                if (_COST_LKAYEARLIST == null)
                {
                    _COST_LKAYEARLIST = new COST_LKAYEARLIST();
                }
                return _COST_LKAYEARLIST;
            }
            set { _COST_LKAYEARLIST = value; }
        }
        COST_LKAYEARMD _COST_LKAYEARMD;

        public COST_LKAYEARMD COST_LKAYEARMD
        {
            get
            {
                if (_COST_LKAYEARMD == null)
                {
                    _COST_LKAYEARMD = new COST_LKAYEARMD();
                }
                return _COST_LKAYEARMD;
            }
            set { _COST_LKAYEARMD = value; }
        }
        COST_LKAYEARTT _COST_LKAYEARTT;

        public COST_LKAYEARTT COST_LKAYEARTT
        {
            get
            {
                if (_COST_LKAYEARTT == null)
                {
                    _COST_LKAYEARTT = new COST_LKAYEARTT();
                }
                return _COST_LKAYEARTT;
            }
            set { _COST_LKAYEARTT = value; }
        }
        COST_LKAYEARXS _COST_LKAYEARXS;

        public COST_LKAYEARXS COST_LKAYEARXS
        {
            get
            {
                if (_COST_LKAYEARXS == null)
                {
                    _COST_LKAYEARXS = new COST_LKAYEARXS();
                }
                return _COST_LKAYEARXS;
            }
            set { _COST_LKAYEARXS = value; }
        }

        COST_ZZFSJT _COST_ZZFSJT;

        public COST_ZZFSJT COST_ZZFSJT
        {
            get
            {
                if (_COST_ZZFSJT == null)
                {
                    _COST_ZZFSJT = new COST_ZZFSJT();
                }
                return _COST_ZZFSJT;
            }
            set { _COST_ZZFSJT = value; }
        }
        COST_ZZFMX _COST_ZZFMX;

        public COST_ZZFMX COST_ZZFMX
        {
            get
            {
                if (_COST_ZZFMX == null)
                {
                    _COST_ZZFMX = new COST_ZZFMX();
                }
                return _COST_ZZFMX;
            }
            set { _COST_ZZFMX = value; }
        }
        COST_ZZFTT _COST_ZZFTT;

        public COST_ZZFTT COST_ZZFTT
        {
            get
            {
                if (_COST_ZZFTT == null)
                {
                    _COST_ZZFTT = new COST_ZZFTT();
                }
                return _COST_ZZFTT;
            }
            set { _COST_ZZFTT = value; }
        }

        COST_LKAFYTT _COST_LKAFYTT;

        public COST_LKAFYTT COST_LKAFYTT
        {
            get
            {
                if (_COST_LKAFYTT == null)
                {
                    _COST_LKAFYTT = new COST_LKAFYTT();
                }
                return _COST_LKAFYTT;
            }
            set { _COST_LKAFYTT = value; }
        }

        COST_LKAFYMXDT _COST_LKAFYMXDT;

        public COST_LKAFYMXDT COST_LKAFYMXDT
        {
            get
            {
                if (_COST_LKAFYMXDT == null)
                {
                    _COST_LKAFYMXDT = new COST_LKAFYMXDT();
                }
                return _COST_LKAFYMXDT;
            }
            set { _COST_LKAFYMXDT = value; }
        }

        COST_LKAFYMXTSCL _COST_LKAFYMXTSCL;

        public COST_LKAFYMXTSCL COST_LKAFYMXTSCL
        {
            get
            {
                if (_COST_LKAFYMXTSCL == null)
                {
                    _COST_LKAFYMXTSCL = new COST_LKAFYMXTSCL();
                }
                return _COST_LKAFYMXTSCL;
            }
            set { _COST_LKAFYMXTSCL = value; }
        }

        COST_LKAYEARCOST_LKAHXZLMX _COST_LKAYEARCOST_LKAHXZLMX;

        public COST_LKAYEARCOST_LKAHXZLMX COST_LKAYEARCOST_LKAHXZLMX
        {
            get
            {
                if (_COST_LKAYEARCOST_LKAHXZLMX == null)
                {
                    _COST_LKAYEARCOST_LKAHXZLMX = new COST_LKAYEARCOST_LKAHXZLMX();
                }
                return _COST_LKAYEARCOST_LKAHXZLMX;
            }
            set { _COST_LKAYEARCOST_LKAHXZLMX = value; }
        }
        COST_LKAHXZLTT _COST_LKAHXZLTT;

        public COST_LKAHXZLTT COST_LKAHXZLTT
        {
            get
            {
                if (_COST_LKAHXZLTT == null)
                {
                    _COST_LKAHXZLTT = new COST_LKAHXZLTT();
                }
                return _COST_LKAHXZLTT;
            }
            set { _COST_LKAHXZLTT = value; }
        }
        COST_LKAHXZLMX _COST_LKAHXZLMX;

        public COST_LKAHXZLMX COST_LKAHXZLMX
        {
            get
            {
                if (_COST_LKAHXZLMX == null)
                {
                    _COST_LKAHXZLMX = new COST_LKAHXZLMX();
                }
                return _COST_LKAHXZLMX;
            }
            set { _COST_LKAHXZLMX = value; }
        }
        COST_LKAHXZLMD _COST_LKAHXZLMD;

        public COST_LKAHXZLMD COST_LKAHXZLMD
        {
            get
            {
                if (_COST_LKAHXZLMD == null)
                {
                    _COST_LKAHXZLMD = new COST_LKAHXZLMD();
                }
                return _COST_LKAHXZLMD;
            }
            set { _COST_LKAHXZLMD = value; }
        }
        COST_LKAHXZLMX_LKAHXDJMX _COST_LKAHXZLMX_LKAHXDJMX;

        public COST_LKAHXZLMX_LKAHXDJMX COST_LKAHXZLMX_LKAHXDJMX
        {
            get
            {
                if (_COST_LKAHXZLMX_LKAHXDJMX == null)
                {
                    _COST_LKAHXZLMX_LKAHXDJMX = new COST_LKAHXZLMX_LKAHXDJMX();
                }
                return _COST_LKAHXZLMX_LKAHXDJMX;
            }
            set { _COST_LKAHXZLMX_LKAHXDJMX = value; }
        }
        COST_LKAHXDJTT _COST_LKAHXDJTT;

        public COST_LKAHXDJTT COST_LKAHXDJTT
        {
            get
            {
                if (_COST_LKAHXDJTT == null)
                {
                    _COST_LKAHXDJTT = new COST_LKAHXDJTT();
                }
                return _COST_LKAHXDJTT;
            }
            set { _COST_LKAHXDJTT = value; }
        }
        COST_LKAHXDJMX _COST_LKAHXDJMX;

        public COST_LKAHXDJMX COST_LKAHXDJMX
        {
            get
            {
                if (_COST_LKAHXDJMX == null)
                {
                    _COST_LKAHXDJMX = new COST_LKAHXDJMX();
                }
                return _COST_LKAHXDJMX;
            }
            set { _COST_LKAHXDJMX = value; }
        }
        WL_TT _WL_TT;

        public WL_TT WL_TT
        {
            get
            {
                if (_WL_TT == null)
                {
                    _WL_TT = new WL_TT();
                }
                return _WL_TT;
            }
            set { _WL_TT = value; }
        }

        COST_FI _COST_FI;

        public COST_FI COST_FI
        {
            get
            {
                if (_COST_FI == null)
                {
                    _COST_FI = new COST_FI();
                }
                return _COST_FI;
            }
            set { _COST_FI = value; }
        }
        COST_CLFMX _COST_CLFMX;

        public COST_CLFMX COST_CLFMX
        {
            get
            {
                if (_COST_CLFMX == null)
                {
                    _COST_CLFMX = new COST_CLFMX();
                }
                return _COST_CLFMX;
            }
            set { _COST_CLFMX = value; }
        }

        COST_CLFTT _COST_CLFTT;

        public COST_CLFTT COST_CLFTT
        {
            get
            {
                if (_COST_CLFTT == null)
                {
                    _COST_CLFTT = new COST_CLFTT();
                }
                return _COST_CLFTT;
            }
            set { _COST_CLFTT = value; }
        }

        COST_CLFTT_STAFF _COST_CLFTT_STAFF;

        public COST_CLFTT_STAFF COST_CLFTT_STAFF
        {
            get
            {
                if (_COST_CLFTT_STAFF == null)
                {
                    _COST_CLFTT_STAFF = new COST_CLFTT_STAFF();
                }
                return _COST_CLFTT_STAFF;
            }
            set { _COST_CLFTT_STAFF = value; }
        }

        COST_CBZX _COST_CBZX;

        public COST_CBZX COST_CBZX
        {
            get
            {
                if (_COST_CBZX == null)
                {
                    _COST_CBZX = new COST_CBZX();
                }
                return _COST_CBZX;
            }
            set { _COST_CBZX = value; }
        }
        COST_TS _COST_TS;

        public COST_TS COST_TS
        {
            get
            {
                if (_COST_TS == null)
                {
                    _COST_TS = new COST_TS();
                }
                return _COST_TS;
            }
            set { _COST_TS = value; }
        }
        COST_TSMX _COST_TSMX;

        public COST_TSMX COST_TSMX
        {
            get
            {
                if (_COST_TSMX == null)
                {
                    _COST_TSMX = new COST_TSMX();
                }
                return _COST_TSMX;
            }
            set { _COST_TSMX = value; }
        }
        COST_CLFHX _COST_CLFHX;

        public COST_CLFHX COST_CLFHX
        {
            get
            {
                if (_COST_CLFHX == null)
                {
                    _COST_CLFHX = new COST_CLFHX();
                }
                return _COST_CLFHX;
            }
            set { _COST_CLFHX = value; }
        }
        COST_CLFMX_CLFHX _COST_CLFMX_CLFHX;

        public COST_CLFMX_CLFHX COST_CLFMX_CLFHX
        {
            get
            {
                if (_COST_CLFMX_CLFHX == null)
                {
                    _COST_CLFMX_CLFHX = new COST_CLFMX_CLFHX();
                }
                return _COST_CLFMX_CLFHX;
            }
            set { _COST_CLFMX_CLFHX = value; }
        }
        COST_KAXS _COST_KAXS;

        public COST_KAXS COST_KAXS
        {
            get
            {
                if (_COST_KAXS == null)
                {
                    _COST_KAXS = new COST_KAXS();
                }
                return _COST_KAXS;
            }
            set { _COST_KAXS = value; }
        }

        COST_KAYEARTT _COST_KAYEARTT;

        public COST_KAYEARTT COST_KAYEARTT
        {
            get
            {
                if (_COST_KAYEARTT == null)
                {
                    _COST_KAYEARTT = new COST_KAYEARTT();
                }
                return _COST_KAYEARTT;
            }
            set { _COST_KAYEARTT = value; }
        }

        COST_KAYEARCOST _COST_KAYEARCOST;

        public COST_KAYEARCOST COST_KAYEARCOST
        {
            get
            {
                if (_COST_KAYEARCOST == null)
                {
                    _COST_KAYEARCOST = new COST_KAYEARCOST();
                }
                return _COST_KAYEARCOST;
            }
            set { _COST_KAYEARCOST = value; }
        }

        COST_PSF _COST_PSF;

        public COST_PSF COST_PSF
        {
            get
            {
                if (_COST_PSF == null)
                {
                    _COST_PSF = new COST_PSF();
                }
                return _COST_PSF;
            }
            set { _COST_PSF = value; }
        }

        COST_OTHER _COST_OTHER;

        public COST_OTHER COST_OTHER
        {
            get
            {
                if (_COST_OTHER == null)
                {
                    _COST_OTHER = new COST_OTHER();
                }
                return _COST_OTHER;
            }
            set { _COST_OTHER = value; }
        }

        COST_KADTTT _COST_KADTTT;

        public COST_KADTTT COST_KADTTT
        {
            get
            {
                if (_COST_KADTTT == null)
                {
                    _COST_KADTTT = new COST_KADTTT();
                }
                return _COST_KADTTT;
            }
            set { _COST_KADTTT = value; }
        }

        COST_KADTDP _COST_KADTDP;

        public COST_KADTDP COST_KADTDP
        {
            get
            {
                if (_COST_KADTDP == null)
                {
                    _COST_KADTDP = new COST_KADTDP();
                }
                return _COST_KADTDP;
            }
            set { _COST_KADTDP = value; }
        }

        COST_KADTMX _COST_KADTMX;

        public COST_KADTMX COST_KADTMX
        {
            get
            {
                if (_COST_KADTMX == null)
                {
                    _COST_KADTMX = new COST_KADTMX();
                }
                return _COST_KADTMX;
            }
            set { _COST_KADTMX = value; }
        }

        COST_KATSCLTT _COST_KATSCLTT;

        public COST_KATSCLTT COST_KATSCLTT
        {
            get
            {
                if (_COST_KATSCLTT == null)
                {
                    _COST_KATSCLTT = new COST_KATSCLTT();
                }
                return _COST_KATSCLTT;
            }
            set { _COST_KATSCLTT = value; }
        }

        COST_KATSCLMX _COST_KATSCLMX;

        public COST_KATSCLMX COST_KATSCLMX
        {
            get
            {
                if (_COST_KATSCLMX == null)
                {
                    _COST_KATSCLMX = new COST_KATSCLMX();
                }
                return _COST_KATSCLMX;
            }
            set { _COST_KATSCLMX = value; }
        }

        COST_MDBS _COST_MDBS;

        public COST_MDBS COST_MDBS
        {
            get
            {
                if (_COST_MDBS == null)
                {
                    _COST_MDBS = new COST_MDBS();
                }
                return _COST_MDBS;
            }
            set { _COST_MDBS = value; }
        }

        COST_KAHXZLMX _COST_KAHXZLMX;

        public COST_KAHXZLMX COST_KAHXZLMX
        {
            get
            {
                if (_COST_KAHXZLMX == null)
                {
                    _COST_KAHXZLMX = new COST_KAHXZLMX();
                }
                return _COST_KAHXZLMX;
            }
            set { _COST_KAHXZLMX = value; }
        }

        COST_KAHXZLTT _COST_KAHXZLTT;

        public COST_KAHXZLTT COST_KAHXZLTT
        {
            get
            {
                if (_COST_KAHXZLTT == null)
                {
                    _COST_KAHXZLTT = new COST_KAHXZLTT();
                }
                return _COST_KAHXZLTT;
            }
            set { _COST_KAHXZLTT = value; }
        }

        COST_CXY _COST_CXY;

        public COST_CXY COST_CXY
        {
            get
            {
                if (_COST_CXY == null)
                {
                    _COST_CXY = new COST_CXY();
                }
                return _COST_CXY;
            }
            set { _COST_CXY = value; }
        }
        COST_CXYGZ _COST_CXYGZ;

        public COST_CXYGZ COST_CXYGZ
        {
            get
            {
                if (_COST_CXYGZ == null)
                {
                    _COST_CXYGZ = new COST_CXYGZ();
                }
                return _COST_CXYGZ;
            }
            set { _COST_CXYGZ = value; }
        }

        COST_KAHXDJTT _COST_KAHXDJTT;

        public COST_KAHXDJTT COST_KAHXDJTT
        {
            get
            {
                if (_COST_KAHXDJTT == null)
                {
                    _COST_KAHXDJTT = new COST_KAHXDJTT();
                }
                return _COST_KAHXDJTT;
            }
            set { _COST_KAHXDJTT = value; }
        }

        COST_KAHXDJMX _COST_KAHXDJMX;

        public COST_KAHXDJMX COST_KAHXDJMX
        {
            get
            {
                if (_COST_KAHXDJMX == null)
                {
                    _COST_KAHXDJMX = new COST_KAHXDJMX();
                }
                return _COST_KAHXDJMX;
            }
            set { _COST_KAHXDJMX = value; }
        }

        COST_KAYEARCOST_KAHXDJMX _COST_KAYEARCOST_KAHXDJMX;

        public COST_KAYEARCOST_KAHXDJMX COST_KAYEARCOST_KAHXDJMX
        {
            get
            {
                if (_COST_KAYEARCOST_KAHXDJMX == null)
                {
                    _COST_KAYEARCOST_KAHXDJMX = new COST_KAYEARCOST_KAHXDJMX();
                }
                return _COST_KAYEARCOST_KAHXDJMX;
            }
            set { _COST_KAYEARCOST_KAHXDJMX = value; }
        }
        COST_KAHXZLMX_KAHXDJMX _COST_KAHXZLMX_KAHXDJMX;

        public COST_KAHXZLMX_KAHXDJMX COST_KAHXZLMX_KAHXDJMX
        {
            get
            {
                if (_COST_KAHXZLMX_KAHXDJMX == null)
                {
                    _COST_KAHXZLMX_KAHXDJMX = new COST_KAHXZLMX_KAHXDJMX();
                }
                return _COST_KAHXZLMX_KAHXDJMX;
            }
            set { _COST_KAHXZLMX_KAHXDJMX = value; }
        }
        COST_MDBS_KAHXDJMX _COST_MDBS_KAHXDJMX;

        public COST_MDBS_KAHXDJMX COST_MDBS_KAHXDJMX
        {
            get
            {
                if (_COST_MDBS_KAHXDJMX == null)
                {
                    _COST_MDBS_KAHXDJMX = new COST_MDBS_KAHXDJMX();
                }
                return _COST_MDBS_KAHXDJMX;
            }
            set { _COST_MDBS_KAHXDJMX = value; }
        }
        COST_OTHER_KAHXDJMX _COST_OTHER_KAHXDJMX;

        public COST_OTHER_KAHXDJMX COST_OTHER_KAHXDJMX
        {
            get
            {
                if (_COST_OTHER_KAHXDJMX == null)
                {
                    _COST_OTHER_KAHXDJMX = new COST_OTHER_KAHXDJMX();
                }
                return _COST_OTHER_KAHXDJMX;
            }
            set { _COST_OTHER_KAHXDJMX = value; }
        }
        COST_PSF_KAHXDJMX _COST_PSF_KAHXDJMX;

        public COST_PSF_KAHXDJMX COST_PSF_KAHXDJMX
        {
            get
            {
                if (_COST_PSF_KAHXDJMX == null)
                {
                    _COST_PSF_KAHXDJMX = new COST_PSF_KAHXDJMX();
                }
                return _COST_PSF_KAHXDJMX;
            }
            set { _COST_PSF_KAHXDJMX = value; }
        }
        COST_JXSHXDJMX _COST_JXSHXDJMX;

        public COST_JXSHXDJMX COST_JXSHXDJMX
        {
            get
            {
                if (_COST_JXSHXDJMX == null)
                {
                    _COST_JXSHXDJMX = new COST_JXSHXDJMX();
                }
                return _COST_JXSHXDJMX;
            }
            set { _COST_JXSHXDJMX = value; }
        }
        COST_JXSHXDJTT _COST_JXSHXDJTT;

        public COST_JXSHXDJTT COST_JXSHXDJTT
        {
            get
            {
                if (_COST_JXSHXDJTT == null)
                {
                    _COST_JXSHXDJTT = new COST_JXSHXDJTT();
                }
                return _COST_JXSHXDJTT;
            }
            set { _COST_JXSHXDJTT = value; }
        }


        COST_CPLX _COST_CPLX;

        public COST_CPLX COST_CPLX
        {
            get {
                if (_COST_CPLX == null)
                {
                    _COST_CPLX = new COST_CPLX();
                } 
                return _COST_CPLX;
            }
            set { _COST_CPLX = value; }
        }
        COST_CXHD _COST_CXHD;

        public COST_CXHD COST_CXHD
        {
            get {
                if (_COST_CXHD == null)
                {
                    _COST_CXHD = new COST_CXHD();
                } 
                return _COST_CXHD;
            }
            set { _COST_CXHD = value; }
        }
        COST_CXHDTC _COST_CXHDTC;

        public COST_CXHDTC COST_CXHDTC
        {
            get {
                if (_COST_CXHDTC == null)
                {
                    _COST_CXHDTC = new COST_CXHDTC();
                } 
                return _COST_CXHDTC;
            }
            set { _COST_CXHDTC = value; }
        }
        COST_GSZCFS _COST_GSZCFS;

        public COST_GSZCFS COST_GSZCFS
        {
            get {
                if (_COST_GSZCFS == null)
                {
                    _COST_GSZCFS = new COST_GSZCFS();
                } 
                return _COST_GSZCFS;
            }
            set { _COST_GSZCFS = value; }
        }
        COST_CXHDPGQD _COST_CXHDPGQD;

        public COST_CXHDPGQD COST_CXHDPGQD
        {
            get {
                if (_COST_CXHDPGQD == null)
                {
                    _COST_CXHDPGQD = new COST_CXHDPGQD();
                } 
                return _COST_CXHDPGQD;
            }
            set { _COST_CXHDPGQD = value; }
        }
        COST_CXHDPGHZ _COST_CXHDPGHZ;

        public COST_CXHDPGHZ COST_CXHDPGHZ
        {
            get {
                if (_COST_CXHDPGHZ == null)
                {
                    _COST_CXHDPGHZ = new COST_CXHDPGHZ();
                } 
                return _COST_CXHDPGHZ;
            }
            set { _COST_CXHDPGHZ = value; }
        }

        COST_LKAEachYEAR _COST_LKAEachYEAR;

        public COST_LKAEachYEAR COST_LKAEachYEAR
        {
            get {
                if (_COST_LKAEachYEAR == null)
                {
                    _COST_LKAEachYEAR = new COST_LKAEachYEAR();
                } 
                return _COST_LKAEachYEAR; }
            set { _COST_LKAEachYEAR = value; }
        }
        COST_JXSHXDJMX_COST _COST_JXSHXDJMX_COST;

        public COST_JXSHXDJMX_COST COST_JXSHXDJMX_COST
        {
            get {
                if (_COST_JXSHXDJMX_COST == null)
                {
                    _COST_JXSHXDJMX_COST = new COST_JXSHXDJMX_COST();
                } 
                return _COST_JXSHXDJMX_COST; }
            set { _COST_JXSHXDJMX_COST = value; }
        }

        COST_CJHDWD _COST_CJHDWD;

        public COST_CJHDWD COST_CJHDWD
        {
            get {
                if (_COST_CJHDWD == null)
                {
                    _COST_CJHDWD = new COST_CJHDWD();
                }
                return _COST_CJHDWD; }
            set { _COST_CJHDWD = value; }
        }

        COST_WDTC _COST_WDTC;

        public COST_WDTC COST_WDTC
        {
            get {
                if (_COST_WDTC == null)
                {
                    _COST_WDTC = new COST_WDTC();
                }
                return _COST_WDTC; }
            set { _COST_WDTC = value; }
        }

        COST_MDBSHX _COST_MDBSHX;

        public COST_MDBSHX COST_MDBSHX
        {
            get {
                if (_COST_MDBSHX == null)
                {
                    _COST_MDBSHX = new COST_MDBSHX();
                }
                return _COST_MDBSHX; }
            set { _COST_MDBSHX = value; }
        }

        HG_STAFFDICT _HG_STAFFDICT;

        public HG_STAFFDICT HG_STAFFDICT
        {
            get {
                if (_HG_STAFFDICT == null)
                {
                    _HG_STAFFDICT = new HG_STAFFDICT();
                }
                return _HG_STAFFDICT; }
            set { _HG_STAFFDICT = value; }
        }


        private CRM_DRF _CRM_DRF;

        public CRM_DRF CRM_DRF
        {
            get
            {
                if (_CRM_DRF == null)
                    _CRM_DRF = new CRM_DRF();
                return _CRM_DRF;
            }
            set { _CRM_DRF = value; }
        }
        private PRODUCT_HH _PRODUCT_HH;

        public PRODUCT_HH PRODUCT_HH
        {
            get {
                if (_PRODUCT_HH == null)
                    _PRODUCT_HH = new PRODUCT_HH();
                return _PRODUCT_HH;
            }
            set { _PRODUCT_HH = value; }
        }
        private PRODUCT_PRODUCT_HH _PRODUCT_PRODUCT_HH;

        public PRODUCT_PRODUCT_HH PRODUCT_PRODUCT_HH
        {
            get {
                if (_PRODUCT_PRODUCT_HH == null)
                    _PRODUCT_PRODUCT_HH = new PRODUCT_PRODUCT_HH(); 
                return _PRODUCT_PRODUCT_HH;
            }
            set { _PRODUCT_PRODUCT_HH = value; }
        }

        ORDER_SH _ORDER_SH;

        public ORDER_SH ORDER_SH
        {
            get {
                if (_ORDER_SH == null)
                {
                    _ORDER_SH = new ORDER_SH();
                }
                return _ORDER_SH; }
            set { _ORDER_SH = value; }
        }

        COST_ZZFTT_LKAHXDJMX _COST_ZZFTT_LKAHXDJMX;

        public COST_ZZFTT_LKAHXDJMX COST_ZZFTT_LKAHXDJMX
        {
            get {
                if (_COST_ZZFTT_LKAHXDJMX == null)
                {
                    _COST_ZZFTT_LKAHXDJMX = new COST_ZZFTT_LKAHXDJMX();
                }
                return _COST_ZZFTT_LKAHXDJMX; }
            set { _COST_ZZFTT_LKAHXDJMX = value; }
        }

        COST_ZZFTT_KAHXDJMX _COST_ZZFTT_KAHXDJMX;

        public COST_ZZFTT_KAHXDJMX COST_ZZFTT_KAHXDJMX
        {
            get {
                if (_COST_ZZFTT_KAHXDJMX == null)
                {
                    _COST_ZZFTT_KAHXDJMX = new COST_ZZFTT_KAHXDJMX();
                }
                return _COST_ZZFTT_KAHXDJMX; }
            set { _COST_ZZFTT_KAHXDJMX = value; }
        }
        PRODUCT_KB _PRODUCT_KB;

        public PRODUCT_KB PRODUCT_KB
        {
            get
            {
                if (_PRODUCT_KB == null)
                {
                    _PRODUCT_KB = new PRODUCT_KB();
                }
                return _PRODUCT_KB;
            }
            set { _PRODUCT_KB = value; }
        }

        PRODUCT_KBMX _PRODUCT_KBMX;

        public PRODUCT_KBMX PRODUCT_KBMX
        {
            get
            {
                if (_PRODUCT_KBMX == null)
                {
                    _PRODUCT_KBMX = new PRODUCT_KBMX();
                }
                return _PRODUCT_KBMX;
            }
            set { _PRODUCT_KBMX = value; }
        }
        DuiBiReport _DuiBiReport;

        public DuiBiReport DuiBiReport
        {
            get
            {
                if (_DuiBiReport == null)
                {
                    _DuiBiReport = new DuiBiReport();
                } 
                return _DuiBiReport; }
            set { _DuiBiReport = value; }
        }
        COST_PUBLIC _COST_PUBLIC;

        public COST_PUBLIC COST_PUBLIC
        {
            get
            {
                if (_COST_PUBLIC == null)
                {
                    _COST_PUBLIC = new COST_PUBLIC();
                }
                return _COST_PUBLIC;
            }
            set { _COST_PUBLIC = value; }
        }
        FM_ElectricInvoice _FM_ElectricInvoice;

        public FM_ElectricInvoice FM_ElectricInvoice
        {
            get
            {
                if (_FM_ElectricInvoice == null)
                {
                    _FM_ElectricInvoice = new FM_ElectricInvoice();
                }
                return _FM_ElectricInvoice;
            }
            set { _FM_ElectricInvoice = value; }
        }

        COST_LKADTDP _COST_LKADTDP;

        public COST_LKADTDP COST_LKADTDP
        {
            get {
                if (_COST_LKADTDP == null)
                {
                    _COST_LKADTDP = new COST_LKADTDP();
                }
                return _COST_LKADTDP; }
            set { _COST_LKADTDP = value; }
        }

        public SY_CODING SY_CODING { get => _SY_CODING == null ? _SY_CODING = new SY_CODING() : _SY_CODING ; set => _SY_CODING = value; }

        SY_CODING _SY_CODING;



    }
}