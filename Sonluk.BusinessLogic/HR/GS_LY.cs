using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class GS_LY
    {
        private static readonly IGS_LY IGS_LYdata = HRDataAccess.CreateGS_LY();
        public MES_RETURN INSERT(HR_GS_LY model)
        {
            return IGS_LYdata.INSERT(model);
        }
        public HR_GS_LY_SELECT SELECT(HR_GS_LY model)
        {
            return IGS_LYdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_GS_LY model)
        {
            return IGS_LYdata.UPDATE(model);
        }
        public MES_RETURN DELETE(int LYID)
        {
            return IGS_LYdata.DELETE(LYID);
        }
    }
}
