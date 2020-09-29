using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBC_PMLIST
    {
        int Create(CRM_BC_PMLIST model);
        IList<CRM_BC_PMLIST> SelectByModel(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE);
        IList<CRM_BC_PMLISTList> SelectGD(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE);
        IList<CRM_BC_PMLISTList> SelectByGD(string AUFNR);
        IList<CRM_BC_PMLISTList> SelectByGDandParam(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE);
        CRM_BC_PMLISTList SelectByDXM(string DXM);
        IList<CRM_BC_PMLISTList> SelectOtherBigByDXM(string DXM);
        int Delete(int PMID);
        int DeleteByGD(string AUFNR);
        int UpdatePM();
        IList<CRM_BC_PMLIST> SelectMATNRbyCHARGandPM(CRM_BC_PMLIST model);
        IList<CRM_BC_KH> SelectKHbyMCP(CRM_BC_PMLIST model);
        IList<CRM_BC_KH> SelectKHbyDXM(CRM_BC_PMLIST model);
        IList<CRM_BC_KH> SelectKHbyNHM(CRM_BC_CHMX model);
        int Create_WLM(CRM_BC_WLM_TEMP model);
        int Delete_WLM();
        int Modify_WLM();
    }
}
