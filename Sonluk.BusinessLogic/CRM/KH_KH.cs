using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_KH
    {
        private static readonly IKH_KH _DataAccess = RMSDataAccess.CreateKH_KH();
        private static readonly IKH_GROUP_KH _GroupDataAccess = RMSDataAccess.CreateKH_GROUP_KH();
        private static readonly IKH_HZHB_SAP _KH_HZHB_SAPDataAccess = RMSDataAccess.CreateKH_HZHB_SAP();
        public int Create(CRM_KH_KH KH_S)
        {
            return _DataAccess.Create(KH_S);
        }
        public int Update(CRM_KH_KH KH_S, bool isKHID)
        {
            //直营卖场同系统下门店编号不可重复
            IList<CRM_KH_GROUP_KHList> data = _GroupDataAccess.ReadStruct(KH_S.KHID, 0);
            if (KH_S.KHLX == 3 && KH_S.MCSX == 2 && KH_S.BEIZ != "")
            {
                for (int i = 0; i < data.Count; i++)
                {
                    CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                    cxmodel.GID = data[i].GID;
                    cxmodel.BEIZ = KH_S.BEIZ;
                    IList<CRM_KH_KHList> KH = _DataAccess.Report(cxmodel, 0);
                    if (KH.Count > 1)
                    {
                        return -100;
                    }
                }
            }



            //如果SAP编号不为空，则更新客户名称
            if (!String.IsNullOrEmpty(KH_S.SAPSN))
            {
                SAP_KH[] KH = new SAP_KH[1];
                KH[0] = new SAP_KH();
                KH[0].KUNNR = KH_S.SAPSN;

                SAP_HZHBList result = _KH_HZHB_SAPDataAccess.SyncSapRead(KH, KH_S.KHLX);
                if (result.ET_KH.Count != 0)
                {
                    KH_S.MC = result.ET_KH[0].NAME1;
                    _DataAccess.Update(KH_S, true);
                }
            }


            return _DataAccess.Update(KH_S, isKHID);
        }
        public int UpdateSFCS(CRM_KH_KH KH)
        {
            return _DataAccess.UpdateSFCS(KH);
        }
        public IList<CRM_KH_KH> Read(CRM_KH_KH keywords)
        {
            return _DataAccess.Read(keywords);
        }
        public CRM_KH_KHList Read(int KHID)
        {
            return _DataAccess.Read(KHID);
        }
        public int Delete(int KHID)
        {
            return _DataAccess.Delete(KHID);
        }
        public IList<CRM_KH_KHList> Report(CRM_Report_KHModel model, int STAFFID)
        {
            return _DataAccess.Report(model, STAFFID);
        }
        public IList<CRM_KH_KHList> Report_PLUS(CRM_Report_KHModel model, int STAFFID)
        {
            return _DataAccess.Report(model, STAFFID);
        }
        public IList<CRM_KH_KH_Report_ZDWDList> Report_ZDWD(CRM_KH_KH_Report_ZDWD model, int STAFFID)
        {
            return _DataAccess.Report_ZDWD(model, STAFFID);
        }
        public IList<CRM_KH_KH_Report_LKAList> Report_LKA(CRM_KH_KH_Report_LKA model, int STAFFID, int RightOn)
        {
            return _DataAccess.Report_LKA(model, STAFFID, RightOn);
        }
        public List<string> ReadXSZZ()
        {
            return _DataAccess.ReadXSZZ().ToList();
        }
        public IList<CRM_KH_BankList> Blank_Report(int SFID, int CSID)
        {
            return _DataAccess.Blank_Report(SFID, CSID);
        }
        public CRM_KH_KH ReadByCRMID(string CRMID)
        {
            return _DataAccess.ReadByCRMID(CRMID);
        }
        public IList<CRM_KH_KH_INFO> ReadBF_KHList(CRM_KH_KH_PARAM model)
        {
            return _DataAccess.ReadBF_KHList(model);
        }
        public IList<SAP_KH> ReadKHForSap(int STAFFID)
        {
            return _DataAccess.ReadKHForSap(STAFFID);
        }
        public IList<CRM_KH_KHList> ReadBySTAFFID(int STAFFID)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID);
        }
        public CRM_KH_KH ReadJXSByKHID(int KHID)
        {
            return _DataAccess.ReadJXSByKHID(KHID);
        }
        public IList<CRM_KH_KH> ReadByJXS(CRM_KH_KH model)
        {
            return _DataAccess.ReadByJXS(model);
        }
        public IList<CRM_KH_KHList> ReadUser_KH(CRM_Report_KHModel model)
        {
            return _DataAccess.ReadUser_KH(model);
        }
        public IList<CRM_KH_KH> ReadSDFbyPKH(string SAPSN)
        {
            return _DataAccess.ReadSDFbyPKH(SAPSN);
        }
        public CRM_KH_KH ReadBySAPSN(string SAPSN)
        {
            return _DataAccess.ReadBySAPSN(SAPSN);
        }
        public IList<CRM_KH_KHList> ReadKHAcount(CRM_Report_KHModel model)
        {
            return _DataAccess.ReadKHAcount(model);
        }
    }
}
