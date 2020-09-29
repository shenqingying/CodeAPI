using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_PSF
    {
        private static readonly ICOST_PSF _DataAccess = RMSDataAccess.CreateCOST_PSF();


        public int Create(CRM_COST_PSF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_PSF model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_PSF> ReadByParam(CRM_COST_PSF model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public IList<CRM_COST_PSF> ReportWLGS(CRM_COST_PSF model)
        {
            return _DataAccess.ReportWLGS(model);
        }
        public IList<CRM_COST_PSF> ReportJXS(CRM_COST_PSF model)
        {
            return _DataAccess.ReportJXS(model);
        }
        public IList<CRM_COST_PSF> Read_Unconnected(CRM_COST_PSF model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public int Delete(int PSFID)
        {
            return _DataAccess.Delete(PSFID);
        }
        public int AddPrintCount(int PSFID)
        {
            return _DataAccess.AddPrintCount(PSFID);
        }




    }
}
