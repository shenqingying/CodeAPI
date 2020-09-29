using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_SBBHDEVICETYPE
    {
        private static readonly ISY_SBBHDEVICETYPE _DataAccess = RMSDataAccess.CreateEMSY_SBBHDEVICETYPE();
        private static readonly ISY_DEVICETYPE _DevcietypeDataAccess = RMSDataAccess.CreateEMSY_DEVICETYPE();
        private static readonly ISY_DEVICEDETAILDOC _DEVICEDETAILDOCDataAccess = RMSDataAccess.CreateEMSY_DEVICEDETAILDOC();
        private static readonly ISY_MANUALPATH _SY_MANUALPATHDataAccess = RMSDataAccess.CreateEMSY_MANUALPATH();
        public MES_RETURN Create(EM_SY_SBBHDEVICETYPE model)
        {
            return _DataAccess.Create(model);
        }

        public IList<EM_SY_SBBHDEVICETYPELIST> Read(EM_SY_SBBHDEVICETYPE model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(EM_SY_SBBHDEVICETYPE model)
        {
            return _DataAccess.Delete(model);
        }
        public EM_SY_SBBHDEVICETYPESELECT ReadSopFronSBBH(string SBBH, string Langu)
        {
            EM_SY_SBBHDEVICETYPE SBBHDEVICETYPEnode = new EM_SY_SBBHDEVICETYPE();
            SBBHDEVICETYPEnode.SBBH = SBBH;
            List<EM_SY_SBBHDEVICETYPELIST> SBBHDEVICETYPEnodeList = Read(SBBHDEVICETYPEnode).ToList();
            List<EM_SY_DEVICETYPE> EM_SY_DEVICETYPEList = new List<EM_SY_DEVICETYPE>();
            List<EM_SY_DEVICEDETAILDOC> EM_SY_DEVICEDETAILDOCList = new List<EM_SY_DEVICEDETAILDOC>();
            List<EM_SY_MANUALPATH> EM_SY_MANUALPATHList = new List<EM_SY_MANUALPATH>();
            MES_RETURN mr = new MES_RETURN();
            for (int i = 0; i < SBBHDEVICETYPEnodeList.Count ; i++)
            {
                //SBBHDEVICETYPEnodeList[i];
                EM_SY_DEVICETYPE node = new EM_SY_DEVICETYPE();
                node.DID = SBBHDEVICETYPEnodeList[i].DID;                
                EM_SY_DEVICETYPEList.AddRange(_DevcietypeDataAccess.Read(node).ToList());
            }
            for (int i = 0; i < EM_SY_DEVICETYPEList.Count; i++)
            {
                EM_SY_DEVICEDETAILDOC node = new EM_SY_DEVICEDETAILDOC();
                node.DID = EM_SY_DEVICETYPEList[i].DID;
                node.LANGUMS = Langu;
                EM_SY_DEVICEDETAILDOCList.AddRange(_DEVICEDETAILDOCDataAccess.Read(node).ToList());
            }
            for (int i = 0; i < EM_SY_DEVICEDETAILDOCList.Count; i++)
            {
                EM_SY_MANUALPATH node = new EM_SY_MANUALPATH();
                node.BBID = EM_SY_DEVICEDETAILDOCList[i].DOCID;
                EM_SY_MANUALPATHList.AddRange(_SY_MANUALPATHDataAccess.Read(node).ToList());
            }

            EM_SY_SBBHDEVICETYPESELECT res = new EM_SY_SBBHDEVICETYPESELECT();
            res.EM_SY_DEVICEDETAILDOCList = EM_SY_DEVICEDETAILDOCList;
            res.EM_SY_DEVICETYPEList = EM_SY_DEVICETYPEList;
            res.EM_SY_MANUALPATHList = EM_SY_MANUALPATHList;
            res.SBBHDEVICETYPEnodeList = SBBHDEVICETYPEnodeList;
            mr.TYPE = "S";
            res.MES_RETURN = mr;
            return res;

        }




      
    }
}
