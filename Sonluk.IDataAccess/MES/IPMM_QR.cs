using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_QR
    {
        MES_PMM_QR_SELECT QLTY_SELECT(MES_PMM_QR model);
        MES_RETURN QLTY_INSERT(MES_PMM_QR model, int STAFFID);
        MES_RETURN QLTY_UPDATE(MES_PMM_QR model, int STAFFID);
        MES_RETURN QLTY_DELETE(int QID, int STAFFID);
        MES_PMM_QR_SELECT REP_SELECT(MES_PMM_QR model);
        MES_RETURN REP_INSERT(MES_PMM_QR model, int STAFFID);
        MES_RETURN REP_UPDATE(MES_PMM_QR model, int STAFFID);
        MES_RETURN REP_DELETE(int RID, int STAFFID);
        MES_PMM_QR_SELECT QR_SELECT_BY_QCODE(int QID);
        MES_RETURN QR_COVER(MES_PMM_QR model);
        MES_RETURN QR_DELETE(MES_PMM_QR model);
    }
}
