using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IGS_LY
    {
        MES_RETURN INSERT(HR_GS_LY model);
        HR_GS_LY_SELECT SELECT(HR_GS_LY model);
        MES_RETURN UPDATE(HR_GS_LY model);
        MES_RETURN DELETE(int LYID);
    }
}
