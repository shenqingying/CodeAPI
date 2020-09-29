using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ROLE_ASSEMBLE
    {
        private static readonly IROLE_ASSEMBLE mesdetaAccess = MESDataAccess.CreateROLE_ASSEMBLE();
        public MES_RETURN INSERT(MES_ROLE_ASSEMBLE model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN UPDATE(MES_ROLE_ASSEMBLE model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public MES_ROLE_ASSEMBLE_SELECT SELECT(MES_ROLE_ASSEMBLE model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_ROLE_ASSEMBLE_SELECT SELECT_LB(MES_ROLE_ASSEMBLE model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
        public MES_RETURN DELETE(int ID)
        {
            return mesdetaAccess.DELETE(ID);
        }
        public MES_ROLE_ASSEMBLE_JS_LAY_SELECT SELECT_JS_LAY(int STAFFID)
        {
            return mesdetaAccess.SELECT_JS_LAY(STAFFID);
        }
        public MES_ROLE_ASSEMBLE_LAY_SELECT SELECT_LAY(int STAFFID, int ROLELB)
        {
            return mesdetaAccess.SELECT_LAY(STAFFID, ROLELB);
        }
        public MES_RETURN INSERT_JS(List<MES_ROLE_ASSEMBLE_JS_LAY> model)
        {
            return mesdetaAccess.INSERT_JS(model);
        }
        public MES_RETURN DELETE_JS(int STAFFID)
        {
            return mesdetaAccess.DELETE_JS(STAFFID);
        }
    }
}
