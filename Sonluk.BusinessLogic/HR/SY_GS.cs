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
    public class SY_GS
    {
        private static readonly ISY_GS ISY_GSdata = HRDataAccess.CreateSY_GS();
        public MES_RETURN INSERT(HR_SY_GS model)
        {
            return ISY_GSdata.INSERT(model);
        }
        public HR_SY_GS_SELECT SELECT(HR_SY_GS model)
        {
            return ISY_GSdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_SY_GS model)
        {
            return ISY_GSdata.UPDATE(model);
        }
        public MES_RETURN DELETE(HR_SY_GS model)
        {
            return ISY_GSdata.DELETE(model);
        }
        public MES_RETURN UPDATE_YYZZ(HR_SY_GS model)
        {
            return ISY_GSdata.UPDATE_YYZZ(model);
        }
        public HR_SY_GS_LAY_SELECT SELECT_GS_ROLE_LAY(int STAFFID)
        {
            return ISY_GSdata.SELECT_GS_ROLE_LAY(STAFFID);
        }
        public MES_RETURN DELETE_GS_ROLE_LAY(int STAFFID)
        {
            return ISY_GSdata.DELETE_GS_ROLE_LAY(STAFFID);
        }
        public MES_RETURN INSERT_GS_ROLE_LAY(HR_SY_GS_LAY model)
        {
            return ISY_GSdata.INSERT_GS_ROLE_LAY(model);
        }
        public HR_SY_GS_SELECT SELECT_BY_ROLE(int STAFFID)
        {
            return ISY_GSdata.SELECT_BY_ROLE(STAFFID);
        }
    }
}
