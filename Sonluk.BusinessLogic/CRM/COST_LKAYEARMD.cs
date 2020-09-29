using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARMD
    {
        private static readonly ICOST_LKAYEARMD _DataAccess = RMSDataAccess.CreateCOST_LKAYEARMD();

        public int Create(CRM_COST_LKAYEARMD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAYEARMD model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateMDSL(int LKAYEARTTID)
        {
            return _DataAccess.UpdateMDSL(LKAYEARTTID);
        }
        public IList<CRM_COST_LKAYEARMD> ReadByParam(CRM_COST_LKAYEARMD model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int MDID)
        {
            return _DataAccess.Delete(MDID);
        }
        public IList<CRM_COST_LKAYEARMD> ReadMDQKbyKHID(int KHID)
        {
            return _DataAccess.ReadMDQKbyKHID(KHID);
        }
    }
}
