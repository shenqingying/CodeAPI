using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_TPM
    {
        private static readonly IMES_TPM mesdetaAccess = MESDataAccess.CreateMES_TPM();
        public ZBCFUN_TPINFO_INSERT INSERT_TPM(ZSL_BCS025 model, string IV_COUNT)
        {
            return mesdetaAccess.INSERT_TPM(model,IV_COUNT);
        }
        public ZBCFUN_TPINFO_INSERT DELETE_TPM(string IV_TPNO)
        {
            return mesdetaAccess.DELETE_TPM(IV_TPNO);
        }
        public ZBCFUN_TPINFO_INSERT UPDATE_TPM(ZSL_BCS025 model, List<ZSL_BCT012> model_IT_TPYD, string IV_FCODE, string IV_LGORT, string IV_WERKS)
        {
            return mesdetaAccess.UPDATE_TPM(model, model_IT_TPYD, IV_FCODE, IV_LGORT, IV_WERKS);
        }
        public ZBCFUN_TPINFO_SELECT SELECT_TPM(ZSL_BCS025 model)
        {
            return mesdetaAccess.SELECT_TPM(model);
        }
        public ZBCFUN_TP_ZHM_GL INSERT_TP_ZHM(string IV_FCODE, ZSL_BCT011 IT_TPZHNO, List<ZSL_BCT012> IT_TPZHNO_GL)
        {
            return mesdetaAccess.INSERT_TP_ZHM(IV_FCODE, IT_TPZHNO, IT_TPZHNO_GL);
        }
        public ZBCFUN_TP_ZHM_GL SELECT_TP_ZHM(string IV_FCODE, string IV_TPZHNO, string IV_CJRQKS, string IV_CJRQJS, string IV_CJRNAME)
        {
            return mesdetaAccess.SELECT_TP_ZHM(IV_FCODE, IV_TPZHNO, IV_CJRQKS, IV_CJRQJS, IV_CJRNAME);
        }
        public ZBCFUN_TP_ZHM_GL DELETE_TP_ZHM(ZSL_BCT012 model_IS_TPZHNO_GL, string IV_FCODE, string IV_TPZHNO)
        {
            return mesdetaAccess.DELETE_TP_ZHM(model_IS_TPZHNO_GL, IV_FCODE, IV_TPZHNO);
        }
        public ZBCFUN_TP_RKBS_GL INSERT_TP_RKBS(List<ZSL_BCT010> IT_TPNO_GL)
        {
            return mesdetaAccess.INSERT_TP_RKBS(IT_TPNO_GL);
        }
        public ZBCFUN_TP_RKBS_GL SELECT_TP_RKBS(string IV_TPNO)
        {
            return mesdetaAccess.SELECT_TP_RKBS(IV_TPNO);
        }
        public ZBCFUN_TP_RKBS_GL DELETE_TP_RKBS(ZSL_BCT010 IS_TPNO_GL)
        {
            return mesdetaAccess.DELETE_TP_RKBS(IS_TPNO_GL);
        }
    }
}
