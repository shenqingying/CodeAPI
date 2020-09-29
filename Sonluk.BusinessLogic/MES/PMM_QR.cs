using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PMM_QR
    {
        private static readonly IPMM_QR mesdataAccess = MESDataAccess.CreatePMM_QR();

        public MES_PMM_QR_SELECT QLTY_SELECT(MES_PMM_QR model)
        {
            return mesdataAccess.QLTY_SELECT(model);
        }

        public MES_RETURN QLTY_INSERT(MES_PMM_QR model, int STAFFID)
        {
            return mesdataAccess.QLTY_INSERT(model, STAFFID);
        }

        public MES_RETURN QLTY_UPDATE(MES_PMM_QR model, int STAFFID)
        {
            return mesdataAccess.QLTY_UPDATE(model, STAFFID);
        }

        public MES_RETURN QLTY_DELETE(int QID, int STAFFID)
        {
            return mesdataAccess.QLTY_DELETE(QID, STAFFID);
        }

        public MES_PMM_QR_SELECT REP_SELECT(MES_PMM_QR model)
        {
            return mesdataAccess.REP_SELECT(model);
        }

        public MES_RETURN REP_INSERT(MES_PMM_QR model, int STAFFID)
        {
            return mesdataAccess.REP_INSERT(model, STAFFID);
        }

        public MES_RETURN REP_UPDATE(MES_PMM_QR model, int STAFFID)
        {
            return mesdataAccess.REP_UPDATE(model, STAFFID);
        }

        public MES_RETURN REP_DELETE(int RID, int STAFFID)
        {
            return mesdataAccess.REP_DELETE(RID, STAFFID);
        }

        public MES_PMM_QR_SELECT QR_SELECT_BY_QCODE(int QID)
        {
            return mesdataAccess.QR_SELECT_BY_QCODE(QID);
        }

        public MES_RETURN QR_COVER(MES_PMM_QR model)
        {
            return mesdataAccess.QR_COVER(model);
        }

        public MES_RETURN QR_DELETE(MES_PMM_QR model)
        {
            return mesdataAccess.QR_DELETE(model);
        }
    }
}
