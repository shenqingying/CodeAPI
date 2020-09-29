using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class ORDER_TT
    {
        private static readonly IORDER_TT _DataAccess = RMSDataAccess.CreateIORDER_TT();

        public int CreateTT(CRM_ORDER_TT model)
        {
            return _DataAccess.CreateTT(model);
        }
        public int CreateMX(CRM_ORDER_MX model)
        {
            return _DataAccess.CreateMX(model);
        }
        public int UpdateTT(CRM_ORDER_TT model)
        {
            return _DataAccess.UpdateTT(model);
        }
        public int UpdateTT_KHinfo(CRM_ORDER_TT model)
        {
            return _DataAccess.UpdateTT_KHinfo(model);
        }
        public int UpdateTT_BJ(CRM_ORDER_TT model)
        {
            return _DataAccess.UpdateTT_BJ(model);
        }
        public int UpdateOrderIsactive(int ORDERTTID, int ISACTIVE)
        {
            return _DataAccess.UpdateOrderIsactive(ORDERTTID, ISACTIVE);
        }
        public int UpdateOrder_SAPORDER(CRM_ORDER_TT model)
        {
            return _DataAccess.UpdateOrder_SAPORDER(model);
        }
        public int UpdateOrder_LOCK(int ORDERTTID, int ISLOCK)
        {
            return _DataAccess.UpdateOrder_LOCK(ORDERTTID, ISLOCK);
        }
        public int UpdateMX(CRM_ORDER_MX model)
        {
            return _DataAccess.UpdateMX(model);
        }
        public int UpdateMX_WLinfo(CRM_ORDER_MX model, int STAFFID)
        {
            return _DataAccess.UpdateMX_WLinfo(model, STAFFID);
        }
        public int DeleteTT(int ORDERTTID, string which)
        {
            return _DataAccess.DeleteTT(ORDERTTID, which);
        }
        public int AddPrintCount(int ORDERTTID)
        {
            return _DataAccess.AddPrintCount(ORDERTTID);
        }
        public int DeleteMX(int ORDERMXID, int XGR)
        {
            return _DataAccess.DeleteMX(ORDERMXID, XGR);
        }
        public int DeleteMXbyFItem(CRM_ORDER_MX model, int STAFFID)
        {
            return _DataAccess.DeleteMXbyFItem(model, STAFFID);
        }
        public CRM_ORDER_TT ReadTTbyID(int ORDERTTID)
        {
            return _DataAccess.ReadTTbyID(ORDERTTID);
        }
        public IList<CRM_ORDER_TT> ReadTTbyParam(CRM_ORDER_TT model, int STAFFID, int forCopy, int isGun)
        {
            return _DataAccess.ReadTTbyParam(model, STAFFID, forCopy, isGun);
        }
        public IList<CRM_ORDER_MX> ReadMXbyTTID(int ORDERTTID)
        {
            return _DataAccess.ReadMXbyTTID(ORDERTTID);
        }
        public IList<CRM_ORDER_MX> ReadMXbyParam(CRM_ORDER_MX model)
        {
            return _DataAccess.ReadMXbyParam(model);
        }
        public CRM_ORDER_MX ReadMXbyMXID(int ORDERMXID)
        {
            return _DataAccess.ReadMXbyMXID(ORDERMXID);
        }

        public MES_RETURN INSERT_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            return _DataAccess.INSERT_DRF_SYNC(model);
        }
        public CRM_ORDER_DRF_SYNC_SELECT SELECT_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            return _DataAccess.SELECT_DRF_SYNC(model);
        }
        public MES_RETURN UPDATE_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            return _DataAccess.UPDATE_DRF_SYNC(model);
        }
    }
}
