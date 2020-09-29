using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_PSF
    {
        int Create(CRM_COST_PSF model);
        int Update(CRM_COST_PSF model);
        IList<CRM_COST_PSF> ReadByParam(CRM_COST_PSF model, int STAFFID);
        IList<CRM_COST_PSF> ReportWLGS(CRM_COST_PSF model);
        IList<CRM_COST_PSF> ReportJXS(CRM_COST_PSF model);
        IList<CRM_COST_PSF> Read_Unconnected(CRM_COST_PSF model);
        int Delete(int PSFID);
        int AddPrintCount(int PSFID);


    }
}
