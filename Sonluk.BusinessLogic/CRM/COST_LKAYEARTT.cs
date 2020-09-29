using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARTT
    {
        private static readonly ICOST_LKAYEARTT _DataAccess = RMSDataAccess.CreateCOST_LKAYEARTT();
        private static readonly ISAP_Report _sapDataAccess = RMSDataAccess.CreateSAP_Report();
        private static readonly ICOST_LKAEachYEAR _eachDataAccess = RMSDataAccess.CreateCOST_LKAEachYEAR();

        public int Create(CRM_COST_LKAYEARTT model)
        {
            int LKAYEARTTID = _DataAccess.Create(model);
            int yearcount = Convert.ToInt32(model.ENDDATE.Split('-')[0]) - Convert.ToInt32(model.BEGINDATE.Split('-')[0]) + 1;
            for (int i = 0; i < yearcount; i++)
            {
                CRM_COST_LKAEachYEAR EACH = new CRM_COST_LKAEachYEAR();
                EACH.LKAYEARTTID = LKAYEARTTID;
                EACH.KHID = model.LKAID;
                int year = Convert.ToInt32(model.BEGINDATE.Split('-')[0]) + i;
                EACH.HTYEAR = year.ToString();
                EACH.ISACTIVE = 1;
                _eachDataAccess.Create(EACH);
            }
            _eachDataAccess.UpdateByTTID(LKAYEARTTID);
            return LKAYEARTTID;
        }
        public int Update(CRM_COST_LKAYEARTT model)
        {
             int LKAYEARTTID = _DataAccess.Update(model);
            _eachDataAccess.UpdateByTTID(model.LKAYEARTTID);
            return LKAYEARTTID;
        }
        public int UpdateSubmitCount(int LKAYEARTTID)
        {
            return _DataAccess.UpdateSubmitCount(LKAYEARTTID);
        }
        public int UpdateStatus(CRM_COST_LKAYEARTT model)
        {
            return _DataAccess.UpdateStatus(model);
        }
        public int CheckStatus(int LKAYEARTTID)
        {
            int status = _DataAccess.CheckStatus(LKAYEARTTID);
            _eachDataAccess.UpdateByTTID(LKAYEARTTID);
            return status;
        }
        public IList<CRM_COST_LKAYEARTT> ReadByParam(CRM_COST_LKAYEARTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int LKAYEARTTID)
        {
            int i = _DataAccess.Delete(LKAYEARTTID);
            _eachDataAccess.DeleteByTTID(LKAYEARTTID);
            return i;
        }
        public int Verify(CRM_COST_LKAYEARTT model)
        {
            return _DataAccess.Verify(model);
        }
        public IList<CRM_COST_LKAYEARTT_JXS> ReportJXS(int LKAYEARTTID)
        {
            IList<CRM_COST_LKAYEARTT_JXS> data = _DataAccess.ReportJXS(LKAYEARTTID);
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAYEARTTID = LKAYEARTTID;
            CRM_COST_LKAYEARTT TTdata = _DataAccess.ReadByParam(cxmodel, 0)[0];
            for (int i = 0; i < data.Count; i++)
            {
                string year = DateTime.Now.Year.ToString();
                string begin = "";
                string end = "";
                if (year == data[i].HTYEAR.ToString())
                {
                    begin = year + "0101";
                    end = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    begin = data[i].HTYEAR + "0101";
                    end = data[i].HTYEAR + "1231";
                }
                SAP_RWXSInfo XS = _sapDataAccess.SAP_RWXS(TTdata.JXSSAPSN, begin, end);
                data[i].SJXS = Convert.ToDouble(XS.Jz1);
                data[i].SJXS_JX = Convert.ToDouble(XS.Jz2);
                data[i].FB_GS = 0;
                data[i].ZFY = 0;
                data[i].ZFB = 0;
            }

            return data;
        }
        public IList<CRM_COST_LKAYearReport> Report_TaiZhang(CRM_COST_LKAYearReport model)
        {
            return _DataAccess.Report_TaiZhang(model);
        }
        public IList<CRM_COST_LKAYEARTT_Report> Report(CRM_COST_LKAYEARTT_Report model)
        {
            return _DataAccess.Report(model);
        }



    }
}
