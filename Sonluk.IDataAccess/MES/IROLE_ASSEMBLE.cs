using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IROLE_ASSEMBLE
    {
        MES_RETURN INSERT(MES_ROLE_ASSEMBLE model);
        MES_RETURN UPDATE(MES_ROLE_ASSEMBLE model);
        MES_ROLE_ASSEMBLE_SELECT SELECT(MES_ROLE_ASSEMBLE model);
        MES_RETURN DELETE(int ID);
        MES_ROLE_ASSEMBLE_JS_LAY_SELECT SELECT_JS_LAY(int STAFFID);
        MES_ROLE_ASSEMBLE_LAY_SELECT SELECT_LAY(int STAFFID, int ROLELB);
        MES_RETURN INSERT_JS(List<MES_ROLE_ASSEMBLE_JS_LAY> model);
        MES_RETURN DELETE_JS(int STAFFID);
        MES_ROLE_ASSEMBLE_SELECT SELECT_LB(MES_ROLE_ASSEMBLE model);
    }
}
