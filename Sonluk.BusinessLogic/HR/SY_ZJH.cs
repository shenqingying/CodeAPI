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
    public class SY_ZJH
    {
        private static readonly ISY_ZJH ISY_ZJHdata = HRDataAccess.CreateSY_ZJH();
        public MES_RETURN INSERT(HR_SY_ZJH model)
        {
            return ISY_ZJHdata.INSERT(model);
        }
        public HR_SY_ZJH_SELECT SELECT(HR_SY_ZJH model)
        {
            return ISY_ZJHdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_SY_ZJH model)
        {
            return ISY_ZJHdata.UPDATE(model);
        }
        public MES_RETURN DELETE(int ZJHID)
        {
            return ISY_ZJHdata.DELETE(ZJHID);
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_LAY(int ZJHID, string GS)
        {
            return ISY_ZJHdata.SELECT_ZJH_LAY(ZJHID, GS);
        }
        public MES_RETURN DELETE_ZJH_LAY(int ZJHID)
        {
            return ISY_ZJHdata.DELETE_ZJH_LAY(ZJHID);
        }
        public MES_RETURN INSERT_ZJH_LAY(HR_SY_ZJH_LAY model)
        {
            return ISY_ZJHdata.INSERT_ZJH_LAY(model);
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_ROLE_LAY(int STAFFID)
        {
            return ISY_ZJHdata.SELECT_ZJH_ROLE_LAY(STAFFID);
        }
        public MES_RETURN INSERT_ZJH_ROLE_LAY(HR_SY_ZJH_LAY model)
        {
            return ISY_ZJHdata.INSERT_ZJH_ROLE_LAY(model);
        }
        public MES_RETURN DELETE_ZJH_ROLE_LAY(int STAFFID)
        {
            return ISY_ZJHdata.DELETE_ZJH_ROLE_LAY(STAFFID);
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_BY_ROLE(int STAFFID, string GS)
        {
            return ISY_ZJHdata.SELECT_BY_ROLE(STAFFID, GS);
        }
    }
}
