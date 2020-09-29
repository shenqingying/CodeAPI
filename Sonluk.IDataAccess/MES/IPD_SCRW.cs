using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPD_SCRW
    {
        SELECT_MES_PD_SCRW SELECT(MES_PD_SCRW model);
        MES_RETURN DELETE(MES_PD_SCRW model);
        MES_RETURN INSERT(MES_PD_SCRW model);
        SELECT_MES_PD_SCRW SELECT_ZPQD(MES_PD_SCRW model);
        SELECT_MES_PD_SCRW SELECT_TM_TL_BYSB_LAST(MES_PD_SCRW model);
        MES_RETURN UPDATE_RWQD_FJTL(MES_PD_SCRW model);
        MES_RETURN UPDATE_RWQD_FJCC(MES_PD_SCRW model);
        MES_RETURN DELETE_GZZX(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ);
        MES_RETURN SELECT_BY_ALL(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH);
        MES_RETURN UPDATE_ISDELETE(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH, decimal SL);
        MES_PD_SCRW_CCTH SELECT_ZXCCINFO(string RWBH, int BC, int LB);
        MES_RETURN UPDATE_ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, int LB);
        MES_RETURN DELETE_ZXCC(string TM);
        MES_RETURN UPDATE_SCRW(MES_PD_SCRW model);
        MES_RETURN SELECT_COUNT(MES_PD_SCRW model);
        MES_RETURN INSERT_BY_FJPD(MES_PD_SCRW model);
        SELECT_MES_PD_SCRW SELECT_BY_ROLE(MES_PD_SCRW model);
        MES_PD_SCRW_SUM_SELECT SELECT_SUM(MES_PD_SCRW_SUM_LIST model);
        MES_SY_FJ_RWKB_SELECT SELECT_JDKB(MES_SY_FJ_RWKB model);
        MES_RETURN UPDATE_ALL(MES_PD_SCRW_UPDATE_IN model, int LB);
    }
}
