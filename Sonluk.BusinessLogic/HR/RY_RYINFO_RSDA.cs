using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class RY_RYINFO_RSDA
    {
        private static readonly IRY_RYINFO_RSDA IRY_RYINFO_RSDAdata = HRDataAccess.CreateRY_RYINFO_RSDA();
        public MES_RETURN JYJL_INSERT(HR_RY_JYJL model)
        {
            return IRY_RYINFO_RSDAdata.JYJL_INSERT(model);
        }
        public HR_RY_JYJL_SELECT JYJL_SELECT(HR_RY_JYJL model)
        {
            return IRY_RYINFO_RSDAdata.JYJL_SELECT(model);
        }
        public MES_RETURN JYJL_UPDATE(HR_RY_JYJL model)
        {
            return IRY_RYINFO_RSDAdata.JYJL_UPDATE(model);
        }
        public MES_RETURN JYJL_DELETE(int EDUID)
        {
            return IRY_RYINFO_RSDAdata.JYJL_DELETE(EDUID);
        }
        public MES_RETURN GRJL_INSERT(HR_RY_GRJL model)
        {
            return IRY_RYINFO_RSDAdata.GRJL_INSERT(model);
        }
        public HR_RY_GRJL_SELECT GRJL_SELECT(HR_RY_GRJL model)
        {
            return IRY_RYINFO_RSDAdata.GRJL_SELECT(model);
        }
        public MES_RETURN GRJL_UPDATE(HR_RY_GRJL model)
        {
            return IRY_RYINFO_RSDAdata.GRJL_UPDATE(model);
        }
        public MES_RETURN GRJL_DELETE(int GRJLID)
        {
            return IRY_RYINFO_RSDAdata.GRJL_DELETE(GRJLID);
        }
        public MES_RETURN HOMEGX_INSERT(HR_RY_HOMEGX model)
        {
            return IRY_RYINFO_RSDAdata.HOMEGX_INSERT(model);
        }
        public HR_RY_HOMEGX_SELECT HOMEGX_SELECT(HR_RY_HOMEGX model)
        {
            return IRY_RYINFO_RSDAdata.HOMEGX_SELECT(model);
        }
        public MES_RETURN HOMEGX_UPDATE(HR_RY_HOMEGX model)
        {
            return IRY_RYINFO_RSDAdata.HOMEGX_UPDATE(model);
        }
        public MES_RETURN HOMEGX_DELETE(int JTGXID)
        {
            return IRY_RYINFO_RSDAdata.HOMEGX_DELETE(JTGXID);
        }
        public MES_RETURN GSGL_INSERT(HR_RY_GSGL model)
        {
            return IRY_RYINFO_RSDAdata.GSGL_INSERT(model);
        }
        public HR_RY_GSGL_SELECT GSGL_SELECT(HR_RY_GSGL model)
        {
            return IRY_RYINFO_RSDAdata.GSGL_SELECT(model);
        }
        public MES_RETURN GSGL_UPDATE(HR_RY_GSGL model)
        {
            return IRY_RYINFO_RSDAdata.GSGL_UPDATE(model);
        }
        public MES_RETURN GSGL_DELETE(int GSID)
        {
            return IRY_RYINFO_RSDAdata.GSGL_DELETE(GSID);
        }
        public MES_RETURN WJGL_INSERT(HR_RY_WJGL model)
        {
            return IRY_RYINFO_RSDAdata.WJGL_INSERT(model);
        }
        public HR_RY_WJGL_SELECT WJGL_SELECT(HR_RY_WJGL model)
        {
            return IRY_RYINFO_RSDAdata.WJGL_SELECT(model);
        }
        public MES_RETURN WJGL_UPDATE(HR_RY_WJGL model)
        {
            return IRY_RYINFO_RSDAdata.WJGL_UPDATE(model);
        }
        public MES_RETURN WJGL_DELETE(int WJID)
        {
            return IRY_RYINFO_RSDAdata.WJGL_DELETE(WJID);
        }
        public MES_RETURN HT_INSERT(HR_RY_HT model)
        {
            return IRY_RYINFO_RSDAdata.HT_INSERT(model);
        }
        public HR_RY_HT_SELECT HT_SELECT(HR_RY_HT model)
        {
            return IRY_RYINFO_RSDAdata.HT_SELECT(model);
        }
        public MES_RETURN HT_UPDATE(HR_RY_HT model)
        {
            return IRY_RYINFO_RSDAdata.HT_UPDATE(model);
        }
        public MES_RETURN HT_UPDATE_HTQCS(HR_RY_HT model)
        {
            return IRY_RYINFO_RSDAdata.HT_UPDATE_HTQCS(model);
        }
        public MES_RETURN HT_DELETE(int HTID)
        {
            return IRY_RYINFO_RSDAdata.HT_DELETE(HTID);
        }
        public MES_RETURN ZC_INSERT(HR_RY_ZC model)
        {
            return IRY_RYINFO_RSDAdata.ZC_INSERT(model);
        }
        public HR_RY_ZC_SELECT ZC_SELECT(HR_RY_ZC model)
        {
            return IRY_RYINFO_RSDAdata.ZC_SELECT(model);
        }
        public HR_RY_ZC_SELECT RY_ZC_SELECT(HR_RY_ZC model)
        {
            return IRY_RYINFO_RSDAdata.RY_ZC_SELECT(model);
        }
        public MES_RETURN ZC_UPDATE(HR_RY_ZC model)
        {
            return IRY_RYINFO_RSDAdata.ZC_UPDATE(model);
        }
        public MES_RETURN ZC_DELETE(int ZCID)
        {
            return IRY_RYINFO_RSDAdata.ZC_DELETE(ZCID);
        }
        public MES_RETURN WBZW_INSERT(HR_RY_WBZW model)
        {
            return IRY_RYINFO_RSDAdata.WBZW_INSERT(model);
        }
        public HR_RY_WBZW_SELECT WBZW_SELECT(HR_RY_WBZW model)
        {
            return IRY_RYINFO_RSDAdata.WBZW_SELECT(model);
        }
        public MES_RETURN WBZW_UPDATE(HR_RY_WBZW model)
        {
            return IRY_RYINFO_RSDAdata.WBZW_UPDATE(model);
        }
        public MES_RETURN WBZW_DELETE(int WBZWID)
        {
            return IRY_RYINFO_RSDAdata.WBZW_DELETE(WBZWID);
        }
    }
}
