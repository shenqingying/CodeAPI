using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_MM
    {
        ZBCFUN_KCDD_READ GET_KCDD(string IV_WERKS);
        IList<ZSL_BCST300> GET_GZZX(string IV_WERKS);
        IList<ZSL_BCST301> GET_PFDH();
        MES_SY_MATERIAL_GROUP_SELECT GET_WLGROUP();
        MES_SY_MATERIAL_INSERT_LIST GET_WLXXBYGROUP(string IV_WERKS, string WLGROUP, string MATNR, string FCODE);
        ZBCFUN_GDJGXX_READ get_GDJGXX(string IV_AUFNR);
        ZBCFUN_GDLIST_READ GET_GDLIST(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH);
        MES_SY_PFDH_LIST GET_PFDH_ACTION_SAP(string GC);
        ZBCFUN_CPBZ_READ get_CPBZ_READ(string IV_TPM);
        ZBCFUN_PURBS_READ GET_PURBS_READ(string IV_FCODE, ZSL_BCS303_CT IS_PURCT, ZSL_BCS303_BS IS_PURBS);
        ZBCFUN_XFPC_READ GET_XFPC_READ(string IV_WERKS, string IV_MATNR);
        ZBCFUN_GDLIST_READ GET_GDLIST_1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH);
        ZBCFUN_GDLIST_READ GET_GDLIST_IV_MATNR(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string IV_MATNR);
        ZBCFUN_GDLIST_READ GET_GDLIST_IV_MATNR_NODELETE(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string IV_MATNR);
    }
}
