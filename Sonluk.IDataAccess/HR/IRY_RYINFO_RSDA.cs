using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IRY_RYINFO_RSDA
    {
        MES_RETURN JYJL_INSERT(HR_RY_JYJL model);
        HR_RY_JYJL_SELECT JYJL_SELECT(HR_RY_JYJL model);
        MES_RETURN JYJL_UPDATE(HR_RY_JYJL model);
        MES_RETURN JYJL_DELETE(int EDUID);
        MES_RETURN GRJL_INSERT(HR_RY_GRJL model);
        HR_RY_GRJL_SELECT GRJL_SELECT(HR_RY_GRJL model);
        MES_RETURN GRJL_UPDATE(HR_RY_GRJL model);
        MES_RETURN GRJL_DELETE(int GRJLID);
        MES_RETURN HOMEGX_INSERT(HR_RY_HOMEGX model);
        HR_RY_HOMEGX_SELECT HOMEGX_SELECT(HR_RY_HOMEGX model);
        MES_RETURN HOMEGX_UPDATE(HR_RY_HOMEGX model);
        MES_RETURN HOMEGX_DELETE(int JTGXID);
        MES_RETURN GSGL_INSERT(HR_RY_GSGL model);
        HR_RY_GSGL_SELECT GSGL_SELECT(HR_RY_GSGL model);
        MES_RETURN GSGL_UPDATE(HR_RY_GSGL model);
        MES_RETURN GSGL_DELETE(int GSID);
        MES_RETURN WJGL_INSERT(HR_RY_WJGL model);
        HR_RY_WJGL_SELECT WJGL_SELECT(HR_RY_WJGL model);
        MES_RETURN WJGL_UPDATE(HR_RY_WJGL model);
        MES_RETURN WJGL_DELETE(int WJID);
        MES_RETURN HT_INSERT(HR_RY_HT model);
        HR_RY_HT_SELECT HT_SELECT(HR_RY_HT model);
        MES_RETURN HT_UPDATE(HR_RY_HT model);
        MES_RETURN HT_UPDATE_HTQCS(HR_RY_HT model);
        MES_RETURN HT_DELETE(int HTID);
        MES_RETURN ZC_INSERT(HR_RY_ZC model);
        HR_RY_ZC_SELECT ZC_SELECT(HR_RY_ZC model);
        HR_RY_ZC_SELECT RY_ZC_SELECT(HR_RY_ZC model);
        MES_RETURN ZC_UPDATE(HR_RY_ZC model);
        MES_RETURN ZC_DELETE(int ZCID);
        MES_RETURN WBZW_INSERT(HR_RY_WBZW model);
        HR_RY_WBZW_SELECT WBZW_SELECT(HR_RY_WBZW model);
        MES_RETURN WBZW_UPDATE(HR_RY_WBZW model);
        MES_RETURN WBZW_DELETE(int WBZWID);
    }
}
