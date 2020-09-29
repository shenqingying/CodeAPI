using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CP
    {
        private static readonly ICOST_CP _DataAccess = RMSDataAccess.CreateCOST_CP();
        private static readonly ISAP_Report _SAP_Report_DataAccess = RMSDataAccess.CreateSAP_Report();

        public int Create(CRM_COST_CP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CP model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CP> ReadByParam(CRM_COST_CP model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int CPID)
        {
            return _DataAccess.Delete(CPID);
        }
        public CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE)
        {
            return _DataAccess.ReportYEARData(LKAYEARTTID, ISACTIVE);
        }
        public IList<CRM_COST_CP_JXSReport> JXSReport(CRM_COST_CP_JXSReport model)
        {
            IList<CRM_COST_CP_JXSReport> data = _DataAccess.JXSReport(model);
            IList<ZSD_JXSKP> RFCdata = new List<ZSD_JXSKP>();
            for (int i = 0; i < data.Count; i++)
            {
                ZSD_JXSKP temp = new ZSD_JXSKP();
                temp.KUNNR = data[i].JXSSAPSN;
                temp.MATNR = data[i].SAPCP;
                RFCdata.Add(temp);
            }

            string STARTDATE = model.HTYEAR + "-01-01";
            string ENDDATE = model.HTYEAR + "-12-31";


            //STARTDATE = Regex.Replace(STARTDATE, @"[^\d]*", "");
            //ENDDATE = Regex.Replace(ENDDATE, @"[^\d]*", "");
            IList<ZSD_JXSKP> RFCmodel = _SAP_Report_DataAccess.GET_JXSKP(STARTDATE, ENDDATE, RFCdata);
            for (int i = 0; i < RFCmodel.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (RFCmodel[i].KUNNR == data[j].JXSSAPSN && RFCmodel[i].MATNR == data[j].SAPCP)
                    {
                        data[j].KPJE = RFCmodel[i].KPJE;
                        data[j].KPSL = RFCmodel[i].KPSL;
                        data[j].CPFL = RFCmodel[i].ZHWGG1;
                    }
                }
            }

            return data;
        }


    }
}
