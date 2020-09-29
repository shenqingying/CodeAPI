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
    public class RY_BANKNO
    {
        private static readonly IRY_BANKNO IRY_BANKNOdata = HRDataAccess.CreateRY_BANKNO();
        public MES_RETURN INSERT(HR_RY_BANKNO model)
        {
            return IRY_BANKNOdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_RY_BANKNO model, int LB)
        {
            return IRY_BANKNOdata.UPDATE(model, LB);
        }
        public HR_RY_BANKNO_SELECT SELECT(HR_RY_BANKNO model)
        {
            return IRY_BANKNOdata.SELECT(model);
        }
    }
}
