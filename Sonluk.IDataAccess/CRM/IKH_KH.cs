using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_KH
    {
        int Create(CRM_KH_KH KH_S);
        int Update(CRM_KH_KH KH_S, bool isKHID);
        int UpdateSFCS(CRM_KH_KH KH);
        IList<CRM_KH_KH> Read(CRM_KH_KH keywords);
        CRM_KH_KHList Read(int KHID);

        IList<string> Read();  
        int Delete(int KHID);
        IList<CRM_KH_KHList> Report(CRM_Report_KHModel model,int STAFFID);
        IList<CRM_KH_KHList> Report_PLUS(CRM_Report_KHModel model, int STAFFID);

        IList<CRM_KH_KH_Report_ZDWDList> Report_ZDWD(CRM_KH_KH_Report_ZDWD model, int STAFFID);

        IList<CRM_KH_KH_Report_LKAList> Report_LKA(CRM_KH_KH_Report_LKA model, int STAFFID, int RightOn);

        int Verify(string SAPSN, string CRMID);
        int Modify(SAP_KH model);
        int DeleteSDF(string SAPSN);

        int UpdateSAPSN(string CRMID,string SAPSN);

        IList<string> ReadXSZZ();

        IList<CRM_KH_BankList> Blank_Report(int SFID, int CSID);
        CRM_KH_KH ReadByCRMID(string CRMID);
        IList<CRM_KH_KH_INFO> ReadBF_KHList(CRM_KH_KH_PARAM model);
        IList<SAP_KH> ReadKHForSap(int STAFFID);
        IList<CRM_KH_KHList> ReadBySTAFFID(int STAFFID);
        CRM_KH_KH ReadJXSByKHID(int KHID);
        IList<CRM_KH_KH> ReadByJXS(CRM_KH_KH model);
        IList<CRM_KH_KHList> ReadUser_KH(CRM_Report_KHModel model);
        IList<CRM_KH_KH> ReadSDFbyPKH(string SAPSN);
        CRM_KH_KH ReadBySAPSN(string SAPSN);
        IList<CRM_KH_KHList> ReadKHAcount(CRM_Report_KHModel model);
    }
}
