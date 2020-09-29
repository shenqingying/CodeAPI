using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAXS
    {

        private static readonly ICOST_LKAXS _DataAccess = RMSDataAccess.CreateCOST_LKAXS();

        public int CreateTT(CRM_COST_LKAXSTT model)
        {
            return _DataAccess.CreateTT(model);
        }
        public int UpdateTT(CRM_COST_LKAXSTT model)
        {
            return _DataAccess.UpdateTT(model);
        }
        public IList<CRM_COST_LKAXSTT> ReadTTByParam(CRM_COST_LKAXSTT model, int STAFFID)
        {
            return _DataAccess.ReadTTByParam(model, STAFFID);
        }
        public int DeleteTT(int LKAXSTTID)
        {
            return _DataAccess.DeleteTT(LKAXSTTID);
        }
        public IList<CRM_COST_LKAXSTT> ReadKHbasic(CRM_COST_LKAXSTT model)
        {
            return _DataAccess.ReadKHbasic(model);
        }


        public int CreateMX(CRM_COST_LKAXSMX model)
        {
            return _DataAccess.CreateMX(model);
        }
        public int UpdateMX(CRM_COST_LKAXSMX model)
        {
            return _DataAccess.UpdateMX(model);
        }
        public IList<CRM_COST_LKAXSMX> ReadMXByTTID(CRM_COST_LKAXSMX model)
        {
            return _DataAccess.ReadMXByTTID(model);
        }
        public int DeleteMX(int LKAXSMXID)
        {
            return _DataAccess.DeleteMX(LKAXSMXID);
        }



    }
}
