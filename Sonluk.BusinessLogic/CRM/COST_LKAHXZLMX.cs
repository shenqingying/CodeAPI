using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAHXZLMX
    {
        private static readonly ICOST_LKAHXZLMX _DataAccess = RMSDataAccess.CreateCOST_LKAHXZLMX();
        private static readonly ICOST_ZZFTT _ZZFDataAccess = RMSDataAccess.CreateCOST_ZZFTT();
        private static readonly IKH_KH _KHDataAccess = RMSDataAccess.CreateKH_KH();

        public int Create(CRM_COST_LKAHXZLMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAHXZLMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAHXZLMX> ReadByParam(CRM_COST_LKAHXZLMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_LKAHXZLMX> ReadByTTID(int HXZLTTID)
        {
            return _DataAccess.ReadByTTID(HXZLTTID);
        }
        public int Delete(int HXZLMXID)
        {
            return _DataAccess.Delete(HXZLMXID);
        }
        public int DeleteByLKAFYTTID(int LKAFYTTID)
        {
            return _DataAccess.DeleteByLKAFYTTID(LKAFYTTID);
        }
        public CRM_COST_LKAHXZLMX ReadMXinfo(CRM_COST_LKAHXZLMX model, string HTYEAR, int LKAID)
        {
            return _DataAccess.ReadMXinfo(model, HTYEAR, LKAID);
        }
        public IList<CRM_COST_LKAHXZLMX> Read_Unconnected(CRM_COST_LKAHXZLMX model)
        {
            IList<CRM_COST_LKAHXZLMX> data = _DataAccess.Read_Unconnected(model);

            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].COSTITEMID == 14)
                {
                    //制作费
                    CRM_COST_ZZFTT cxdata = new CRM_COST_ZZFTT();
                    cxdata.TTID = data[0].COSTID;
                    IList<CRM_COST_ZZFTT> ZZF = _ZZFDataAccess.ReadByParam(cxdata,0);
                    if(ZZF.Count != 0)
                    {
                        CRM_KH_KHList KH = _KHDataAccess.Read(ZZF[0].KHID);
                        data[i].MDMC = KH.MC;
                        data[i].MCSX = KH.MCSX;
                    }
                }
            }


            return data;
        }
        public CRM_COST_LKAHXZLMX Read_CostTime(CRM_COST_LKAHXZLMX model)
        {
            return _DataAccess.Read_CostTime(model);
        }



    }
}
