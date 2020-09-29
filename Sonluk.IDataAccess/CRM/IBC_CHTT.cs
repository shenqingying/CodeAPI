using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBC_CHTT
    {
        int Modify();
        int SelectMXIDbyDXM(string DXM);
        string SelectKUNAGbyTTID(int PMCHTTID);
        IList<CRM_BC_CHMX> SelectCHMXbyDXM(string DXM, string TPM);
        IList<CRM_BC_CHMX> ReadMXbyParam(CRM_BC_CHMX model);
        IList<CRM_BC_CHMX> ReadDXMbyTPM(string TPM);


    }
}
