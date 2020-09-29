using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;

namespace Sonluk.IDataAccess.BC
{
    public interface IBarCode
    {
        string ZBCFUN_TBM_ZFTH(string srwlm, string tgwlm, string fcode);
        ZSL_BCS007 ZBCFUN_MAT_GET(string IV_MATNR, string IV_MTART, string IV_DATUM);

        PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM);

        IList<ZSL_BCS107> ZBCFUN_LTPM_READ(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN);

        TrackInfo ZBCFUN_WLZS_READ(string IV_WLM);

        RktjInfo ZBCFUN_RKTJ_READ(string IV_START, string IV_END);

        DeliveryNoteInfo ZSD_JH_READ(string I_VBELN, string I_UNAME);

        SalesOrderInfo ZSD_DD_READ(string I_VBELN, string I_UNAME);

        CKInfo ZSD_CK_READ(string I_START, string I_END, string I_UNAME);

        TpmInfo ZBCFUN_TPM_READ(string IV_TPM);

        GdInfo ZBCFUN_GD_READ(string IV_GD);
        MODEL_ZBCFUN_CUS_GET GET_ZBCFUN_CUS_GET();
        MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET(string IV_DATE, string IV_SYS);
        MODEL_ZBCFUN_MAT_GET GET_ZBCFUN_MAT_GET(string IV_DATUM, string IV_MTART, string IV_MATNR, string IV_ZSBS);
        MODEL_ZBCFUN_ORT_GET GET_ZBCFUN_ORT_GET();
        MODEL_ZBCFUN_TM_READ GET_ZBCFUN_TM_READ(string IV_AUFNR, string IV_KZBEW);
        MODEL_ZBCFUN_THLOG_READ GET_ZBCFUN_THLOG_READ();
        MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET2(string KHmodeldata);
        MODEL_ZBCFUN_POITEM_READ GET_ZBCFUN_POITEM_READ(string IV_EBELN, string IV_EBELP);
        ZSL_BCST100 GET_ZBCFUN_PO_RECEIPT(string IV_CKDJH, string IV_KZBEW);
        MODEL_ZBCFUN_JHD_READ JHD_READ(string VBELN);
        MES_RETURN JHD_UPDATE(List<ZSL_BCT110> model);
        MODEL_ZBCFUN_JHZ_READ JHZ_READ(MODEL_ZBCFUN_JHZ_READ model);
    }
}
