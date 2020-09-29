using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_TPM
    {
        ZBCFUN_TPINFO_INSERT INSERT_TPM(ZSL_BCS025 model, string IV_COUNT);
        ZBCFUN_TPINFO_INSERT DELETE_TPM(string IV_TPNO);
        ZBCFUN_TPINFO_INSERT UPDATE_TPM(ZSL_BCS025 model, List<ZSL_BCT012> model_IT_TPYD, string IV_FCODE, string IV_LGORT, string IV_WERKS);
        ZBCFUN_TPINFO_SELECT SELECT_TPM(ZSL_BCS025 model);
        ZBCFUN_TP_ZHM_GL INSERT_TP_ZHM(string IV_FCODE, ZSL_BCT011 IT_TPZHNO, List<ZSL_BCT012> IT_TPZHNO_GL);
        ZBCFUN_TP_ZHM_GL SELECT_TP_ZHM(string IV_FCODE, string IV_TPZHNO, string IV_CJRQKS, string IV_CJRQJS, string IV_CJRNAME);
        ZBCFUN_TP_ZHM_GL DELETE_TP_ZHM(ZSL_BCT012 model_IS_TPZHNO_GL, string IV_FCODE, string IV_TPZHNO);
        ZBCFUN_TP_RKBS_GL INSERT_TP_RKBS(List<ZSL_BCT010> IT_TPNO_GL);
        ZBCFUN_TP_RKBS_GL SELECT_TP_RKBS(string IV_TPNO);
        ZBCFUN_TP_RKBS_GL DELETE_TP_RKBS(ZSL_BCT010 IS_TPNO_GL);
    }
}
