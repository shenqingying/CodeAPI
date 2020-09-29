using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAHXZLMX
    {
        private static readonly ICOST_KAHXZLMX _DataAccess = RMSDataAccess.CreateCOST_KAHXZLMX();
        private static readonly ICOST_KADTTT _KADTTTDataAccess = RMSDataAccess.CreateCOST_KADTTT();
        private static readonly ICOST_KATSCLMX _KATSCLMXDataAccess = RMSDataAccess.CreateCOST_KATSCLMX();
        private static readonly ICOST_ZZFTT _ZZFDataAccess = RMSDataAccess.CreateCOST_ZZFTT();
        private static readonly IKH_KH _KHDataAccess = RMSDataAccess.CreateKH_KH();


        public int Create(CRM_COST_KAHXZLMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAHXZLMX model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateByKADTTTID(CRM_COST_KAHXZLMX model)
        {
            return _DataAccess.UpdateByKADTTTID(model);
        }
        public IList<CRM_COST_KAHXZLMX> ReadByParam(CRM_COST_KAHXZLMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_KAHXZLMX> ReadByTTID(int HXZLTTID)
        {
            return _DataAccess.ReadByTTID(HXZLTTID);
        }
        public IList<CRM_COST_KAHXZLMX> Read_Unconnected(CRM_COST_KAHXZLMX model)
        {
            //因为在读取对应的未核销费用数据时，需要看到相关的信息，存储过程做太复杂，所以改为在这里按类别查询
            IList<CRM_COST_KAHXZLMX> data = _DataAccess.Read_Unconnected(model);
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].COSTITEMID == 51 || data[i].COSTITEMID == 52 || data[i].COSTITEMID == 55)
                {
                    //堆头、海报、活动补差
                    CRM_COST_KADTTT cxdata = new CRM_COST_KADTTT();
                    cxdata.KADTTTID = data[i].KADTTTID;
                    IList<CRM_COST_KADTTT> KADT = _KADTTTDataAccess.ReadByParam(cxdata, 0);
                    if(KADT.Count != 0)
                    {
                        data[i].BEGINDATE = KADT[0].HDBEGINDATE;
                        data[i].ENDDATE = KADT[0].HDENDDATE;
                        data[i].DQ = KADT[i].DQ;
                    }
                }
                else if(data[i].COSTITEMID == 60)
                {
                    //特殊陈列
                    CRM_COST_KATSCLMX cxdata = new CRM_COST_KATSCLMX();
                    cxdata.KATSCLMXID = data[i].COSTID;
                    IList<CRM_COST_KATSCLMX> KATSCLMX = _KATSCLMXDataAccess.ReadByParam(cxdata);
                    if(KATSCLMX.Count != 0)
                    {
                        data[i].MDMC = _KHDataAccess.Read(KATSCLMX[0].KHID).MC;
                        data[i].BEGINDATE = KATSCLMX[0].BEGINDATE;
                        data[i].ENDDATE = KATSCLMX[0].ENDDATE;
                    }
                }
                else if(data[i].COSTITEMID == 53)
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
                        data[i].SQR = ZZF[0].CJR;
                        data[i].SQRNAME = ZZF[0].CJRDES;
                    }
                }
            }




            return data;
        }
        public int Delete(int HXZLMXID)
        {
            return _DataAccess.Delete(HXZLMXID);
        }
        public int DeleteByKADTTTID(int KADTTTID)
        {
            return _DataAccess.DeleteByKADTTTID(KADTTTID);
        }



    }
}
