using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBC_FXCH
    {
        int TTCreate(CRM_BC_FXCHTT model);
        int MXCreate(CRM_BC_FXCHMX model);
        int TTDelete(int FXCHTTID);
        int MXDelete(int FXCHMXID);
        int MXDeleteByDXM(string DXM);
        IList<CRM_BC_FXCHTTList> ReadTTbyParam(CRM_BC_FXCHParam model);
        CRM_BC_FXCHTTList ReadTTbyTTID(int FXCHTTID);
        IList<CRM_BC_FXCHTTList> Report(CRM_BC_FXCHParam model);
        IList<CRM_BC_FXCHMX> ReadMXbyTTID(int FXCHTTID);
        IList<CRM_BC_FXCHMX> ReadMXbyParam(CRM_BC_FXCHMX model);
        int ReadCountByDXM(string DXM, string TPM);
        int Verify_IfHaveKHRight(int STAFFID, string CRMID);
        int Verify_IfHaveCHRight(int STAFFID, string DXM, string TPM);
    }
}
