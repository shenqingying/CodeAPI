using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_TAX_TAXSLMX
    {
        MES_RETURN INSERT(HR_XZGL_TAX_TAXSLMX model);
        HR_XZGL_TAX_TAXSLMX_SELECT SELECT(HR_XZGL_TAX_TAXSLMX model);
        MES_RETURN UPDATE(HR_XZGL_TAX_TAXSLMX model, int LB);
    }
}
