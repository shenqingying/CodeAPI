using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_QD
    {
        private static readonly IKQ_QD _DataAccess = RMSDataAccess.CreateKQ_QD();
        public int Create(CRM_KQ_QD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KQ_QD model)
        {
            return _DataAccess.Update(model);
        }
        public CRM_KQ_QD ReadByKQQDID(int KQQDID)
        {
            return _DataAccess.ReadByKQQDID(KQQDID);
        }
        public IList<CRM_KQ_QD> ReadByQDLXandQDGSID(int QDLX, int QDGSID)
        {
            return _DataAccess.ReadByQDLXandQDGSID(QDLX, QDGSID);
        }
        public IList<CRM_KQ_QD> ReadYCQD_ByDATE(string QDRQ, int SXB, int STAFFID)
        {
            return _DataAccess.ReadYCQD_ByDATE(QDRQ, SXB,STAFFID);
        }
        public int Delete(int KQQDID)
        {
            return _DataAccess.Delete(KQQDID);
        }
        public IList<string[]> Verify_QD(int STAFFID, string ED, string JD, double WXRC)
        {
            return _DataAccess.Verify_QD(STAFFID, ED, JD, WXRC);
        }
        public int ReadQD_COUNTS(CRM_KQ_QD model)
        {
            return _DataAccess.ReadQD_COUNTS(model);
        }
    }
}
