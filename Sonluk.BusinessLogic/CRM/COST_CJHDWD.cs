using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CJHDWD
    {
        private static readonly ICOST_CJHDWD _DataAccess = RMSDataAccess.CreateCOST_CJHDWD();
        private static readonly IKH_KH _KHDataAccess = RMSDataAccess.CreateKH_KH();

        public int Create(CRM_COST_CJHDWD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CJHDWD model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CJHDWD> ReadByParam(CRM_COST_CJHDWD model)
        {
            IList<CRM_COST_CJHDWD> data = _DataAccess.ReadByParam(model);
            for (int i = 0; i < data.Count; i++)
            {
                CRM_KH_KH KH = _KHDataAccess.ReadJXSByKHID(data[i].KHID);
                data[i].JXSNAME = KH.MC;
                data[i].JXSCRMID = KH.CRMID;
                data[i].JXSSAPSN = KH.SAPSN;
            }
            return data;
        }
        public int Delete(int CJHDWDID)
        {
            return _DataAccess.Delete(CJHDWDID);
        }




    }
}
