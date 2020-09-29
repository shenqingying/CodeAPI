using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BC_FXCH
    {
        private static readonly IBC_FXCH _DataAccess_FXCH = RMSDataAccess.CreateIBC_FXCH();

        public int TTCreate(CRM_BC_FXCHTT model)
        {
            return _DataAccess_FXCH.TTCreate(model);
        }
        public int MXCreate(CRM_BC_FXCHMX model)
        {
            return _DataAccess_FXCH.MXCreate(model);
        }
        public int TTDelete(int FXCHTTID)
        {
            return _DataAccess_FXCH.TTDelete(FXCHTTID);
        }
        public int MXDelete(int FXCHMXID)
        {
            return _DataAccess_FXCH.MXDelete(FXCHMXID);
        }
        public int MXDeleteByDXM(string DXM)
        {
            return _DataAccess_FXCH.MXDeleteByDXM(DXM);
        }
        public IList<CRM_BC_FXCHTTList> ReadTTbyParam(CRM_BC_FXCHParam model)
        {
            return _DataAccess_FXCH.ReadTTbyParam(model);
        }
        public CRM_BC_FXCHTTList ReadTTbyTTID(int FXCHTTID)
        {
            return _DataAccess_FXCH.ReadTTbyTTID(FXCHTTID);
        }
        public IList<CRM_BC_FXCHTTList> Report(CRM_BC_FXCHParam model)
        {
            return _DataAccess_FXCH.Report(model);
        }
        public IList<CRM_BC_FXCHMX> ReadMXbyTTID(int FXCHTTID)
        {
            return _DataAccess_FXCH.ReadMXbyTTID(FXCHTTID);
        }
        public IList<CRM_BC_FXCHMX> ReadMXbyParam(CRM_BC_FXCHMX model)
        {
            return _DataAccess_FXCH.ReadMXbyParam(model);
        }
        public int ReadCountByDXM(string DXM, string TPM)
        {
            return _DataAccess_FXCH.ReadCountByDXM(DXM, TPM);
        }
        public int Verify_IfHaveKHRight(int STAFFID, string CRMID)
        {
            return _DataAccess_FXCH.Verify_IfHaveKHRight(STAFFID, CRMID);
        }
        public int Verify_IfHaveCHRight(int STAFFID, string DXM, string TPM)
        {
            return _DataAccess_FXCH.Verify_IfHaveCHRight(STAFFID, DXM, TPM);
        }


    }
}
