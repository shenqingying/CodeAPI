using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sonluk.BusinessLogic.CRM
{
    public class COST_ZZFTT
    {
        private static readonly ICOST_ZZFTT _DataAccess = RMSDataAccess.CreateCOST_ZZFTT();

        public int Create(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_ZZFTT> ReadByParam(CRM_COST_ZZFTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public IList<CRM_COST_ZZFTT> Read_KA(CRM_COST_ZZFTT model, int STAFFID)
        {
            return _DataAccess.Read_KA(model, STAFFID);
        }
        public IList<CRM_COST_ZZFTT> Read_LKA(CRM_COST_ZZFTT model, int STAFFID)
        {
            return _DataAccess.Read_LKA(model, STAFFID);
        }
        public IList<CRM_COST_ZZFTT> ReadByCostitemid(CRM_COST_ZZFTT model)
        {
            return _DataAccess.ReadByCostitemid(model);
        }
        public IList<CRM_COST_ZZFTT> Read_LKAUnconnected(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Read_LKAUnconnected(model);
        }
        public IList<CRM_COST_ZZFTT> Read_KAUnconnected(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Read_KAUnconnected(model);
        }
        public int Delete(int TTID)
        {
            return _DataAccess.Delete(TTID);
        }
        public int UpdateTBSJ(int TTID)
        {
            return _DataAccess.UpdateTBSJ(TTID);
        }
        public IList<CRM_COST_ZZFTT> Read_Unconnected(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public IList<CRM_COST_ZZFTT> Read_Unconnected2(CRM_COST_ZZFTT model)
        {
            return _DataAccess.Read_Unconnected2(model);
        }
    }
}
