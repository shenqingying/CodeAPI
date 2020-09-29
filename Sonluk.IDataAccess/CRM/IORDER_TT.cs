using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IORDER_TT
    {
        int CreateTT(CRM_ORDER_TT model);
        int CreateMX(CRM_ORDER_MX model);
        int UpdateTT(CRM_ORDER_TT model);
        int UpdateTT_KHinfo(CRM_ORDER_TT model);
        int UpdateTT_BJ(CRM_ORDER_TT model);
        int UpdateOrderIsactive(int ORDERTTID, int ISACTIVE);
        int UpdateOrder_SAPORDER(CRM_ORDER_TT model);
        int UpdateOrder_LOCK(int ORDERTTID, int ISLOCK);
        int UpdateMX(CRM_ORDER_MX model);
        int UpdateMX_WLinfo(CRM_ORDER_MX model, int STAFFID);
        int DeleteTT(int ORDERTTID, string which);
        int AddPrintCount(int ORDERTTID);
        int DeleteMX(int ORDERMXID, int XGR);
        int DeleteMXbyFItem(CRM_ORDER_MX model, int STAFFID);
        CRM_ORDER_TT ReadTTbyID(int ORDERTTID);
        IList<CRM_ORDER_TT> ReadTTbyParam(CRM_ORDER_TT model, int STAFFID, int forCopy, int isGun);
        IList<CRM_ORDER_MX> ReadMXbyTTID(int ORDERTTID);
        IList<CRM_ORDER_MX> ReadMXbyParam(CRM_ORDER_MX model);
        CRM_ORDER_MX ReadMXbyMXID(int ORDERMXID);
        MES_RETURN INSERT_DRF_SYNC(CRM_ORDER_DRF_SYNC model);
        CRM_ORDER_DRF_SYNC_SELECT SELECT_DRF_SYNC(CRM_ORDER_DRF_SYNC model);
        MES_RETURN UPDATE_DRF_SYNC(CRM_ORDER_DRF_SYNC model);
        CRM_ORDER_DRF_USER_SELECT SELECT_USER_SYNC(CRM_ORDER_DRF_USER model);
        CRM_ORDER_DRF_SYNC_TD_SELECT SELECT_DRF_SYNC_TD(CRM_ORDER_DRF_SYNC_TD model);
    }
}
