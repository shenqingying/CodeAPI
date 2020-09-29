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
    public class ADMINISTRATION_DORM
    {
        private static readonly IADMINISTRATION_DORM IADMINISTRATION_DORMdata = HRDataAccess.CreateIADMINISTRATION_DORM();
        public MES_RETURN INSERT(HR_ADMINISTRATION_DORM_DORM model)
        {
            return IADMINISTRATION_DORMdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_ADMINISTRATION_DORM_DORM model)
        {
            return IADMINISTRATION_DORMdata.UPDATE(model);
        }
        public HR_ADMINISTRATION_DORM_DORM_SELECT SELECT(HR_ADMINISTRATION_DORM_DORM model)
        {
            return IADMINISTRATION_DORMdata.SELECT(model);
        }
        public MES_RETURN ROOM_INSERT(HR_ADMINISTRATION_DORM_ROOM model)
        {
            return IADMINISTRATION_DORMdata.ROOM_INSERT(model);
        }
        public HR_ADMINISTRATION_DORM_ROOM_SELECT ROOM_SELECT(HR_ADMINISTRATION_DORM_ROOM model)
        {
            return IADMINISTRATION_DORMdata.ROOM_SELECT(model);
        }
        public MES_RETURN ROOM_UPDATE(HR_ADMINISTRATION_DORM_ROOM model)
        {
            return IADMINISTRATION_DORMdata.ROOM_UPDATE(model);
        }
        public MES_RETURN LIVE_INSERT(HR_ADMINISTRATION_DORM_LIVE model)
        {
            return IADMINISTRATION_DORMdata.LIVE_INSERT(model);
        }
        public HR_ADMINISTRATION_DORM_LIVE_SELECT LIVE_SELECT(HR_ADMINISTRATION_DORM_LIVE model)
        {
            return IADMINISTRATION_DORMdata.LIVE_SELECT(model);
        }
        public MES_RETURN LIVE_UPDATE(HR_ADMINISTRATION_DORM_LIVE model)
        {
            return IADMINISTRATION_DORMdata.LIVE_UPDATE(model);
        }
    }
}
